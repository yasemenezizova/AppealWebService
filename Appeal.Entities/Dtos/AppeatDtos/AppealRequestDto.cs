using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Entities.Dtos.AppeatDtos
{
    public class AppealRequestDto
    {
        public DateTime? BeginDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? AppealTypeId { get; set; }
        public int? OrganizationId { get; set; }
        public string Text { get; set; } = String.Empty;
        public int? PageNumber { get; set; }
        public int? RowNumber { get; set; }
    }
}
