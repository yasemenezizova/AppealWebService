using Appeal.Entities.Dtos.FileDtos;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.AutoMapper.Profiles
{
    public class FileProfile : Profile
    {
        public FileProfile()
        {
            CreateMap<Appeal.Entities.Concretes.File, FileGetDto>();
        }

    }
}
