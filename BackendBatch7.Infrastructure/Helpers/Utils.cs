using AutoMapper;
using AutoMapper.QueryableExtensions;
using BackendBatch7.Domain.Request.SearchParam;
using BackendBatch7.Domain.Response.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;

namespace BackendBatch7.Infrastructure.Helpers;

public static class Utils
{
    public static string EncryptedPassword(string password, string? salt = null)
    {
        var cryptoher = new Cryptopher();
        if (!string.IsNullOrEmpty(salt))
            cryptoher.AppKeySalt = salt;
        return cryptoher.PasswordHash(password);
    }

    public static async Task<PaginatedResponse<List<TDestination>>> ToPagedResponse<TSource, TDestination>(this IQueryable<TSource> query, BaseSearchParam filter, IMapper mapper, Expression<Func<TSource, object>> orderBy)
        where TSource : class
        where TDestination : class
    {
        var totalRecords = query.Count();
        var pagedData = await query
            .AsNoTracking()
            .OrderByDescending(orderBy)
            .Skip((filter.PageNumber - 1) * filter.PageSize)
            .Take(filter.PageSize)
            .ProjectTo<TDestination>(mapper.ConfigurationProvider)
            .ToListAsync();
        var lastPage = (int)Math.Ceiling(totalRecords / (double)filter.PageSize);
        Paging paging = new()
        {
            CurrentRecords = pagedData.Count,
            PageNumber = filter.PageNumber,
            PageSize = filter.PageSize,
            LastPage = lastPage,
            TotalRecords = totalRecords,
            NextPage = filter.PageNumber >= lastPage ? 0 : filter.PageNumber + 1,
            PreviousPage = filter.PageNumber > 1 ? filter.PageNumber - 1 : 0,
        };
        return new PaginatedResponse<List<TDestination>>(pagedData, paging);
    }

    public static (ClaimsPrincipal, SecurityToken) ValidateToken(string secretKey, string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey)),
            ValidateIssuer = false, // Tùy chỉnh nếu bạn có `Issuer`
            ValidateAudience = false, // Tùy chỉnh nếu bạn có `Audience`
            ValidateLifetime = true, // Kiểm tra hạn sử dụng
            ClockSkew = TimeSpan.Zero // Không cho phép sai lệch thời gian
        };

        var principal = tokenHandler.ValidateToken(token, validationParameters, out var validatedToken);
        // Kiểm tra thuật toán của token
        if (validatedToken is JwtSecurityToken jwtToken &&
            jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
        {
            return (principal, validatedToken);
        }

        throw new SecurityTokenException("Invalid Algorithm Token!");
    }
}
