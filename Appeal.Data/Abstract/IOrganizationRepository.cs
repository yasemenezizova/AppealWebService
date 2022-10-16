using Appeal.Entities.Concretes;
using Appeal.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Abstract
{
    public interface IOrganizationRepository : IGenericRepository<Organization>
    {
        Task<IEnumerable<Organization>> GetOrganizationsByAppealTypeId( int appealTypeId);
    }
}
