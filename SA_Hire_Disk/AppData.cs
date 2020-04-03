using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace SA_Hire_Disk
{
    public class AppData
    {
        public static Frame MainFrame = new Frame();
        public static Hire_DiskEntities Context = new Hire_DiskEntities();
        public static string username;
        public static string disk;
    }
}
