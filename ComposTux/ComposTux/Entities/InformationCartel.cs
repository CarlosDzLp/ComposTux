namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("InformationCartel")]
    public partial class InformationCartel
    {
        [Key]
        public Guid IdInformationCartel { get; set; }

        public Guid IdUser { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string UrlImage { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string CartelDescription { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateCreated { get; set; }

        public bool Active { get; set; }

        public virtual User User { get; set; }
    }
}
