#nullable disable
using Appeal.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Appeal.Entities.Concretes
{
    public partial class Appeal : EntityBase, IEntity
    {
        public int AppealTypeId { get; set; }
        public int OrganizationId { get; set; }
        public int FileId { get; set; }
        public string Text { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }
}