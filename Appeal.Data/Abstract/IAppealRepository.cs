using Appeal.Entities.Concretes;
using Appeal.Entities.Dtos.AppeatDtos;
using Appeal.Entities.Views;
using Appeal.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Abstract
{
    public interface IAppealRepository : IGenericRepository<Appeal.Entities.Concretes.Appeal>
    {
        Task<VwAppeal> GetByIdAsync(int id);
        Task<IEnumerable<VwAppeal>> GetAllAppealsAsync(AppealRequestDto requestDto);
        Task<IEnumerable<AppealType>> GetAllAppealTypesAsync();
    }
}
