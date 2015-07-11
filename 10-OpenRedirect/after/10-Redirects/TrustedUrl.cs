using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace _10_Redirects
{
  public class TrustedUrl
  {
    [Key]
    public int Id { get; set; }
    public string Url { get; set; }
  }

  public class TrustedUrlContext : DbContext
  {
    public TrustedUrlContext() : base("DefaultConnection") { }
    public DbSet<TrustedUrl> TrustedUrls { get; set; }
  }
}