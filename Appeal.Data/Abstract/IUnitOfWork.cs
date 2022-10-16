using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Abstract
{
    public interface IUnitOfWork
    {
        IAppealRepository AppealRepository { get; }
        IFileRepository FileRepository { get; }
        IOrganizationRepository OrganizationRepository { get; }
    }
}
