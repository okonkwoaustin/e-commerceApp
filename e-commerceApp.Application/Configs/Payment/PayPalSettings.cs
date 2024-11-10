using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_commerceApp.Application.Configs.Payment
{
    public class PayPalSettings
    {
        public string ClientId { get; set; }
        public string ClientSecret { get; set; }
        public string Environment { get; set; } // "sandbox" or "live"
    }
}
