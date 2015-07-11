namespace WcfSimpleTokenExample.Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Token")]
    public partial class Token
    {
        public int Id { get; set; }

        [Column("Token")]
        [Required]
        [StringLength(250)]
        public string Text { get; set; }

        public int UserId { get; set; }

        public DateTime CreateDate { get; set; }

        public virtual User User { get; set; }
    }
}
