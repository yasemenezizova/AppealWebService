using Appeal.Data.Abstract;
using Appeal.Shared.Data.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Concrete
{
    public class UnitOfWork : IUnitOfWork
    {
        private DBClient _dbClient;
        private AppealRepository _appealRepository;
        private FileRepository _fileRepository;
        private OrganizationRepository _organizationRepository;
        public UnitOfWork(DBClient dbClient)
        {
            _dbClient = dbClient;
        }
        public IAppealRepository AppealRepository => _appealRepository ?? new AppealRepository(_dbClient);

        public IFileRepository FileRepository => _fileRepository ?? new FileRepository(_dbClient);

        public IOrganizationRepository OrganizationRepository  => _organizationRepository   ?? new OrganizationRepository(_dbClient);
    }
}
