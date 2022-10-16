using Appeal.Data.Abstract;
using Appeal.Entities.Concretes;
using Appeal.Shared.Data.Concrete;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Concrete
{
    public class OrganizationRepository : IOrganizationRepository
    {
        readonly DBClient _dbClient;
        public OrganizationRepository(DBClient dbClient)
        {
            _dbClient = dbClient;
        }
        public async Task<IEnumerable<Organization>> GetOrganizationsByAppealTypeId(int appealTypeId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@appealTypeId", appealTypeId);
            string sql = @"SELECT O.ID, O.NAME 
                            FROM AppealTypeOrganization ATO
                            LEFT JOIN Organization O
                            ON ATO.OrganizationId = O.ID
                            WHERE AppealTypeId = @appealTypeId AND ATO.Status!=0 AND O.Status!=0
                            ORDER BY ID DESC";
            return await _dbClient.QueryAll<Organization>(sql,p);
        }

        public Task<int> AddAsync(Organization entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Organization>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Organization> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

    }
}
