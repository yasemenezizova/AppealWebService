using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Shared.Entities.Abstract
{
    public abstract class EntityBase
    {
        public int Id { get; set; }
        public int InsertedUser { get; set; }
        public DateTime InsertedTime { get; set; }
        public int? UpdatedUser { get; set; }
        public DateTime? UpdatedTime { get; set; }
        public bool Status { get; set; }
    }
}
