namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Company")]
    public partial class Company
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Company()
        {
            AssignUserCompanies = new HashSet<AssignUserCompany>();
        }

        [Key]
        public Guid IdCompany { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyName { get; set; }

        [StringLength(100)]
        public string CompanyAddress { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyLatitud { get; set; }

        [Required]
        [StringLength(100)]
        public string CompanyLongitud { get; set; }

        public Guid IdUser { get; set; }

        public bool CompanyActive { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignUserCompany> AssignUserCompanies { get; set; }

        public virtual User User { get; set; }
    }
}
