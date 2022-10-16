using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Entities.Dtos.AppeatDtos
{
    public class AppealCreateDto
    {
        public int Id { get; set; }
        public int AppealTypeId { get; set; }
        public int OrganizationId { get; set; }
        public IFormFile? Doc { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
      
    }
}
