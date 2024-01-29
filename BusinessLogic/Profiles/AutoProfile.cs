using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile()
        {
            CreateMap<AutoDto, Auto>()
                .ForMember(x => x.Company, opt => opt.Ignore());
            CreateMap<Auto, AutoDto>();

            CreateMap<Company, CompanyDto>().ReverseMap();
        }
    }
}
