namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssignUserCompany")]
    public partial class AssignUserCompany
    {
        [Key]
        public Guid IdAssignUserCompany { get; set; }

        public Guid? IdCompany { get; set; }

        public Guid? IdUser { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? Datemodified { get; set; }

        public virtual Company Company { get; set; }

        public virtual User User { get; set; }
    }
}
