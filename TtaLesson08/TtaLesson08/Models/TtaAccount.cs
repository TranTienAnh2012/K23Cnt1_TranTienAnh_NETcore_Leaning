using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Ttalesson08.Controllers;

namespace Ttalesson08.Models
{
    public class TtaAccount
    {
        [Key]
        public int TtaId { get; set; }

        [Display(Name = "Họ và Tên")]
        [Required(ErrorMessage = "Họ ko đc để trống")]
        [MinLength(6, ErrorMessage = "Họ tên ít nhất 6 ký tự")]
        [MaxLength(20, ErrorMessage = "Họ tên tối đa 20 ký tự")]
        public string TtaFulloName { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Địa chỉ email không được để trống")]
        [EmailAddress(ErrorMessage = "Địa chỉ email không đúng định dạng")]
        public string TtaEmail { get; set; }

        [Display(Name = "Số Điện Thoại")]
        [DataType(DataType.PhoneNumber)]
        [Remote(action: "VerifyPhone", controller: "Account")] // tên controller không có chữ "Controller" ở cuối
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        public string TtaPhone { get; set; }

        [Display(Name = "Địa Chỉ Thường Trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(35, ErrorMessage = "Địa chỉ không vượt quá 35 ký tự")]
        public string TtaAddress { get; set; }

        [Display(Name = "Ảnh Đại Diện")]
        public string TtaAvata { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime TtaBirtday { get; set; }

        [Display(Name = "Giới tính")]
        public string TtaGender { get; set; }

        [Display(Name = "Mật khẩu")]
        [DataType(DataType.Password)]
        public string TtaPassWord { get; set; }

        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "URL phải đúng định dạng bao gồm http hoặc https, tên miền VD: https://facebook.com/itvnsoft")]
        public string TtaFacebook { get; set; }
    }
}
                                