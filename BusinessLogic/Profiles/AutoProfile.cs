using BusinessLogic.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Entities;
using AutoMapper;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;
using BusinessLogic.Interfaces;

namespace BusinessLogic.Profiles
{
    public class ApplicationProfile : Profile
    {
        public ApplicationProfile(IFileService fileService)
        {
            CreateMap<Auto, AutoDto>();
            CreateMap<AutoDto, Auto>()
                .ForMember(x => x.Company, opt => opt.Ignore());

            CreateMap<Company, CompanyDto>().ReverseMap();

            CreateMap<CreateAutoModel, Auto>()
                .ForMember(x => x.ImgURL, opt => opt.MapFrom(src => fileService.SaveAutoImage(src.Image).Result));
        }
    }
}
