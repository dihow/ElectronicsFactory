using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectronicsFactory
{
    public static class Settings
    {
        public static bool IsAdmin { get; set; } = false;
        public static int CurrentEmployeeId { get; set; }
        public static string CurrentEmployeeName { get; set; } = "";
    }
}
