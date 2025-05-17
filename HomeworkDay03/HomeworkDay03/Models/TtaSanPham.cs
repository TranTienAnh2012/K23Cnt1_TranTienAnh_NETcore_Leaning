namespace HomeworkDay03.Models
{
	public class TtaSanPham
	{
		public int IdSp { get; set; }
		public string NameSp { get; set; }
		public string Gia { get; set; } // Giá gốc
		public string GiaKhuyenMai { get; set; } // Giá sau giảm
		public string MoTa { get; set; }
		public string AvatarSp { get; set; }
		public string TrangThai { get; set; }
		public string BioSp { get; set; }
		public DateTime NgayDang { get; set; }
	}

}
