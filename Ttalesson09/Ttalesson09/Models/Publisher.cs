using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ttalesson09.Models;

public partial class Publisher
{
    [Key]
    [Required(ErrorMessage = "Mã nhà phát triển không được để trống")]
    [Display(Name = "Mã nhà phát triển")]
    public int PublisherId { get; set; }

    [Required(ErrorMessage = "Tên nhà phát triển không được để trống")]
    [StringLength(100, ErrorMessage = "Tên nhà phát triển tối đa 100 ký tự")]
    [Display(Name = "Tên nhà phát triển")]
    public string? PublisherName { get; set; }

    public string? Phone { get; set; }

    public string? Address { get; set; }

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}
