namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            AssignUserCompanies = new HashSet<AssignUserCompany>();
            Companies = new HashSet<Company>();
            Tokens = new HashSet<Token>();
        }

        [Key]
        public Guid IdUser { get; set; }

        [Required]
        [StringLength(50)]
        public string NameUser { get; set; }

        [Required]
        [StringLength(100)]
        public string LastNameUser { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string PasswordUser { get; set; }

        public bool UserType { get; set; }

        public bool UserActive { get; set; }

        public bool Privacity { get; set; }

        [StringLength(100)]
        public string Latitud { get; set; }

        [StringLength(100)]
        public string Longitud { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AssignUserCompany> AssignUserCompanies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Company> Companies { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Token> Tokens { get; set; }
    }
}
