using Appeal.Shared.Entities.Abstract;
using System;
using System.Collections.Generic;

namespace Appeal.Entities.Concretes
{
    public  class AppealType : EntityBase, IEntity
    {
        public string Name { get; set; }

    }
}