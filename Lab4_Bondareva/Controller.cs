using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab4_Bondareva.Models;

namespace Lab4_Bondareva
{
    public class Controller
    {
        public static Lab4Table GoControl(string name, string messege)
        {
            Lab4Table table = new Lab4Table();

            if (AppData.SearchInfo(name, messege) == null) AppData.AddRecord(name, messege);
            return AppData.SearchInfo(name, messege);
        }
    }
}
