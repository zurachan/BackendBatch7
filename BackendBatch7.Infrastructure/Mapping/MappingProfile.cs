using AutoMapper;
using BackendBatch7.Domain.Entities;
using BackendBatch7.Domain.Response;

namespace BackendBatch7.Infrastructure.Mapping;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<User, UserModel>();
    }
}
