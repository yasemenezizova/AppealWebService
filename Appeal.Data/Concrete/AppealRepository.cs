using Appeal.Data.Abstract;
using Appeal.Entities.Concretes;
using Appeal.Entities.Dtos.AppeatDtos;
using Appeal.Entities.Views;
using Appeal.Shared.Data.Abstract;
using Appeal.Shared.Data.Concrete;
using Dapper;

namespace Appeal.Data.Concrete
{
    public class AppealRepository : IAppealRepository
    {
        readonly DBClient _dbClient;
        public AppealRepository(DBClient dbClient)
        {
            _dbClient = dbClient;
        }

        public async Task<int> AddAsync(Entities.Concretes.Appeal entity)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id", entity.Id);
            p.Add("@AppealTypeId", entity.AppealTypeId);
            p.Add("@OrganizationId", entity.OrganizationId);
            p.Add("@FileId", entity.FileId);
            p.Add("@Text", entity.Text);
            p.Add("@Email", entity.Email);
            p.Add("@Phone", entity.Phone);
            p.Add("@InsertedUser", entity.InsertedUser);
            p.Add("@UpdatedUser", entity.UpdatedUser);
            return await _dbClient.QuerySingle<int>("AppealInsert", p);

        }

        public async Task<int> DeleteAsync(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id", id);

            return await _dbClient.QuerySingle<object>("AppealDelete", p);
        }

        public Task<IEnumerable<Entities.Concretes.Appeal>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<AppealType>> GetAllAppealTypesAsync()
        {
            string sql = "SELECT * FROM AppealType WHERE Status!=0";
            return await _dbClient.QueryAll<AppealType>(sql);
        }

        public async Task<IEnumerable<VwAppeal>> GetAllAppealsAsync(AppealRequestDto requestDto)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@BeginDate", Convert.ToDateTime(requestDto.BeginDate).ToString("dd/MM/yyyy"));
            p.Add("@EndDate", Convert.ToDateTime(requestDto.EndDate).ToString("dd/MM/yyyy"));
            p.Add("@AppealTypeId", requestDto.AppealTypeId);
            p.Add("@OrganizationId", requestDto.OrganizationId);
            p.Add("@Text", requestDto.Text);
            p.Add("@PageNumber", requestDto.PageNumber);
            p.Add("@RowNumber", requestDto.RowNumber);

            string sql = @$"SELECT * FROM VwAppeal  WHERE  CONVERT (DATE, InsertedTime,103)>= CONVERT (DATE,CONVERT(VARCHAR,@BeginDate,103),103)  
			AND  CONVERT (DATE, InsertedTime,103)<= CONVERT (DATE,CONVERT(VARCHAR,@EndDate,103),103)
            {(requestDto.AppealTypeId == null || requestDto.AppealTypeId == 0 ? "" : " AND AppealTypeId=@AppealTypeId ")} 
            {(requestDto.OrganizationId == null || requestDto.OrganizationId == 0 ? "" : " AND OrganizationId=@OrganizationId ")} 
            {(string.IsNullOrEmpty(requestDto.Text) ? "" : " AND Text=@Text ")} 
             ORDER BY Id DESC OFFSET {(requestDto.PageNumber == null || requestDto.PageNumber == 0 ? "0" : " ((@PageNumber - 1) * @RowNumber) ")} 
            ROWS FETCH NEXT {(requestDto.RowNumber == null || requestDto.RowNumber == 0 ? "10" : "@RowNumber")} ROWS ONLY";
            return await _dbClient.QueryAll<VwAppeal>(sql, p);
        }

        public async Task<VwAppeal> GetByIdAsync(int id)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("@Id", id);
            string sql = $"SELECT * FROM VwAppeal WHERE Id=@Id";
            return await _dbClient.Query<VwAppeal>(sql, p);
        }

        Task<Entities.Concretes.Appeal> IGenericRepository<Entities.Concretes.Appeal>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
