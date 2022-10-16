using Appeal.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Appeal.Entities.Concretes
{
    public partial class AppealTypeOrganization : EntityBase, IEntity
    {
        public int AppealTypeId { get; set; }
        public int OrganizationId { get; set; }
    }
}