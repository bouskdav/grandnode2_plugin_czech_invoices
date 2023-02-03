using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using System.ComponentModel.DataAnnotations;

namespace Misc.CzechInvoiceGenerator.Models
{
    public class ConfigurationModel : BaseModel
    {
        
        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.Fields.DisplayOrder")]
        public int DisplayOrder { get; set; }

        [UIHint("CustomerGroups")]
        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.Fields.LimitedToGroups")]
        public string[] CustomerGroups { get; set; }

        //Store acl
        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.Fields.LimitedToStores")]
        [UIHint("Stores")]
        public string[] Stores { get; set; }

        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.Fields.MembersOnlyAccessEnabled")]
        public bool MembersOnlyAccessEnabled { get; set; }

        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.Fields.StorePassword")]
        public string StorePassword { get; set; }
    }
}