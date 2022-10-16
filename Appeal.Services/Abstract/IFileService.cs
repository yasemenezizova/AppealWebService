using Appeal.Entities.Dtos.FileDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.Abstract
{
    public interface IFileService
    {
        Task<FileGetDto> Get(int id);
        Task<int> Add(Appeal.Entities.Concretes.File entity);
    }
}
