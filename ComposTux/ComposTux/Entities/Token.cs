namespace ComposTux.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Token")]
    public partial class Token
    {
        [Key]
        public Guid IdToken { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string PlayerId { get; set; }

        [Column(TypeName = "text")]
        [Required]
        public string PushToken { get; set; }

        public Guid IdUser { get; set; }

        public virtual User User { get; set; }
    }
}
