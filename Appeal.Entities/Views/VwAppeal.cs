using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Entities.Views
{
    public class VwAppeal
    {
        public int Id { get; set; }
        public int AppealTypeId { get; set; }
        public string AppealType { get; set; }
        public int OrganizationId { get; set; }
        public string OrganizationName { get; set; }
        public int FileId { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime InsertedTime { get; set; }
    }
}
