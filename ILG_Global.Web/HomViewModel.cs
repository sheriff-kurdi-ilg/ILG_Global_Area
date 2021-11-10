using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ILG_Global.Web
{
    public class HomViewModel
    {
        public CultureInfo enculture { get; set; }
        public CultureInfo arculture { get; set; }
        public string returnUrl { get; set; }
    }
}
