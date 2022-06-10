
using AutoMapper;

namespace Assignment_2.Models.Data.Dto
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Batch, BatchDto>().ReverseMap();
            CreateMap<Batch, ViewBatchDto>().ReverseMap();
        }
    }
}
