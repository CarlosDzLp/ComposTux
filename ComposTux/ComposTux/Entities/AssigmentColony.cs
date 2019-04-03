namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AssigmentColony")]
    public partial class AssigmentColony
    {
        [Key]
        public Guid IdAssigmentColony { get; set; }

        public Guid IdColony { get; set; }

        public Guid IdUser { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public bool Active { get; set; }

        public virtual Colony Colony { get; set; }

        public virtual User User { get; set; }
    }
}
