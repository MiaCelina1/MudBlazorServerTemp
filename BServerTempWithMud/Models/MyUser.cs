using System.ComponentModel.DataAnnotations;

namespace BServerTempWithMud.Models
{
	public class MyUser
	{
		[Key] 
		public int UserId { get; set; }
		[Required(ErrorMessage = " الزامی است")]
		public string UserName { get; set; }
	}
}
