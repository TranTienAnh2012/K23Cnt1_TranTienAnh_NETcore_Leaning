namespace Ttalesson06.Models
{
	// Đây là class đại diện cho Học viên
	public class TtaEmployee
	{
		public int TtaId { get; set; }

		public string TtaName { get; set; }

		public DateTime TtaBirthDay { get; set; }

		public string TtaEmail { get; set; }  // ✅ Email là string

		public string TtaPhone { get; set; }

		public float TtaSalary { get; set; }

		public int TtaStatus { get; set; }

		
	}

}

