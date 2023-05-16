using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LibaryProject.Models.Entity;
namespace LibaryProject.Models.Classes
{
	public class Class1
	{
        public IEnumerable <TblKitap> KitapDeger { get; set; }
        public IEnumerable <TblHakkimizda> HakkimizdaDeger { get; set; }
    }
}