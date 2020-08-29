using AutoMapper;
using BusinessTempus.Models;
using UI.ViewModels;

namespace UI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
        }
    }
}