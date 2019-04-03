namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Colony")]
    public partial class Colony
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Colony()
        {
            AssigmentColonies = new HashSet<AssigmentColony>();
        }

        [Key]
        public Guid IdColony { get; set; }

        [Required]
        [StringLength(50)]
        public string ColonyName { get; set; }

        [Required]
        [StringLength(100)]
        public string ColonyAddress { get; set; }

        public Guid IdProject { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public bool Active { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssigmentColony> AssigmentColonies { get; set; }

        public virtual Project Project { get; set; }
    }
}
