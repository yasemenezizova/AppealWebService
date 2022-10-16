using Appeal.Shared.Data.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Data.Abstract
{
    public interface IFileRepository : IGenericRepository<Appeal.Entities.Concretes.File>
    {
    }
}
