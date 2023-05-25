using LibaryProject.Models.Entity;
using System.Collections.Generic;
namespace LibaryProject.Models.Classes
{
	public class Class1
	{
		public IEnumerable<TblKitap> KitapDeger { get; set; }
		public IEnumerable<TblHakkimizda> HakkimizdaDeger { get; set; }
	}
}