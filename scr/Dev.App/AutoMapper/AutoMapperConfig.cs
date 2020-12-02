using AutoMapper;
using Dev.App.ViewModels;
using Dev.Business.Models;

namespace Dev.App.AutoMapper
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Prospect, ProspectViewModel>().ReverseMap();
            CreateMap<Category, CategoryViewModel>().ReverseMap();
            CreateMap<Employee, EmployeeViewModel>().ReverseMap();
            CreateMap<Customer, CustomerViewModel>().ReverseMap();
            CreateMap<Segment, SegmentViewModel>().ReverseMap();
            CreateMap<Company, CompanyViewModel>().ReverseMap();
            CreateMap<ProspectEmployee, ProspectEmployeeViewModel>().ReverseMap();
        }
    }
}
