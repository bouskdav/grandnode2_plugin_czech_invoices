using Grand.Domain.Configuration;

namespace Misc.CzechInvoiceGenerator
{
    public class CzechInvoiceGeneratorSettings : ISettings
    {
        public CzechInvoiceGeneratorSettings()
        {
            LimitedToStores = new List<string>();
            LimitedToGroups = new List<string>();
        }
        public int DisplayOrder { get; set; }

        public IList<string> LimitedToStores { get; set; }

        public IList<string> LimitedToGroups { get; set; }
    }
}
