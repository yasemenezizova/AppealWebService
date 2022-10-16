using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Entities.Dtos.AppeatDtos
{
    public class AppealGetAllDto
    {
        public int Id { get; set; }
        public string AppealType { get; set; }
        public string OrganizationName { get; set; }
        public string FileName { get; set; }
        public string Text { get; set; }
        public DateTime InsertedTime { get; set; }
    }
}
