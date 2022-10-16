using Appeal.Data.Abstract;
using Appeal.Shared.Data.Concrete;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Concrete
{
    public class FileRepository : IFileRepository
    {
        readonly DBClient _dbClient;
        public FileRepository(DBClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<int> AddAsync(Entities.Concretes.File entity)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@FileName", entity.FileName);
            p.Add("@FileSize", entity.FileSize);
            p.Add("@ContentType", entity.ContentType);
            p.Add("@FileContent", entity.FileContent);
            p.Add("@InsertedUser", 1);
            return await _dbClient.QuerySingle<int>("FileInsert", p);
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Entities.Concretes.File>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Entities.Concretes.File> GetByIdAsync(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id", id);
            string sql = $"SELECT Id, FileName, ContentType,FileContent FROM [File] WHERE ID=@Id";
            return await _dbClient.Query<Entities.Concretes.File>(sql, p);
        }
    }
}
