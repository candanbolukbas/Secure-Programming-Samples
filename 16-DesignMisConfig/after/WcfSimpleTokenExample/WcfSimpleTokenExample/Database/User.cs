namespace WcfSimpleTokenExample.Database
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("User")]
    public partial class User
    {
        public User()
        {
            Tokens = new HashSet<Token>();
        }

        public int Id { get; set; }

        [Column("User")]
        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(250)]
        public string Password { get; set; }

        [Required]
        [StringLength(250)]
        public string Salt { get; set; }

        public virtual ICollection<Token> Tokens { get; set; }
    }
}
