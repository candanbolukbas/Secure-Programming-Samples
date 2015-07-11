using System;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace _5_CSRF.Models
{
  public class StatusUpdateViewModel
  {
    [Display(Name = "Status date")]
    [DisplayFormat(DataFormatString = "{0:d MMM yyyy, HH:mm}")]
    public DateTime StatusDate { get; set; }

    [Required]
    [AllowHtml]
    [StringLength(140)]
    public string Status { get; set; }
  }
}