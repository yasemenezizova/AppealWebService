using Appeal.Data.Abstract;
using Appeal.Entities.Concretes;
using Appeal.Entities.Dtos.AppeatDtos;
using Appeal.Entities.Views;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.AutoMapper.Profiles
{
    public class AppealProfile:Profile
    {
        public AppealProfile()
        {
            CreateMap<Appeal.Entities.Concretes.Appeal, AppealCreateDto>().ReverseMap();
            CreateMap<VwAppeal, AppealGetAllDto>().ReverseMap();
            CreateMap<VwAppeal, AppealGetDto>().ReverseMap();
            CreateMap<AppealType, AppealTypeGetDto>().ReverseMap();
        }

    }
}
