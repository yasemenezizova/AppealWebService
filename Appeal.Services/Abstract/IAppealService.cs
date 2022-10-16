using Appeal.Entities.Dtos.AppeatDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.Abstract
{
    public interface IAppealService
    {
        Task<AppealGetDto> Get(int id);
        Task<IEnumerable<AppealGetAllDto>> GetAll(AppealRequestDto appealRequest);
        Task<int> Add(AppealCreateDto dto,int? fileId);
        Task Delete(int id);
        Task<IEnumerable<AppealTypeGetDto>> GetAllAppealTypes();
    }
}
