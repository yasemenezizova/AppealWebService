using Appeal.Entities.Concretes;
using Appeal.Entities.Dtos.OrganizationDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.AutoMapper.Profiles
{
    public class OrganizationProfile:Profile
    {
        public OrganizationProfile()
        {
            CreateMap<Organization, OrganizationGetAllDto>();
        }

    }
}
