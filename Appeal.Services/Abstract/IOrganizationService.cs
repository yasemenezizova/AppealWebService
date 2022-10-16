using Appeal.Entities.Dtos.OrganizationDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.Abstract
{
    public interface IOrganizationService
    {
        Task<IEnumerable<OrganizationGetAllDto>> GetOrganizationsByAppealTypeId(int appealTypeId);
    }
}
