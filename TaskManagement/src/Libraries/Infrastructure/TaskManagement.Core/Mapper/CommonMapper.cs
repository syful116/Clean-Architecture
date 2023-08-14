using AutoMapper;
using TaskManagement.Model;
using TaskManagement.Services.Model;

namespace TaskManagement.Core.Mapper;

public class CommonMapper:Profile
{
    public CommonMapper()
    {
        CreateMap<VmProduct,Model.Product>().ReverseMap();

    }
}
