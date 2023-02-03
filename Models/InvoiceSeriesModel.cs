using Grand.Infrastructure.ModelBinding;
using Grand.Infrastructure.Models;
using Grand.Web.Common.Link;
using Grand.Web.Common.Models;
using System.ComponentModel.DataAnnotations;

namespace Misc.CzechInvoiceGenerator.Models
{
    public partial class InvoiceSeriesModel : BaseEntityModel, IStoreLinkModel
    {
        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.From")]
        public DateTime From { get; set; }

        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.NextNumber")]
        public int NextNumber { get; set; }

        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.Pattern")]
        public string Pattern { get; set; }

        //Store acl
        [GrandResourceDisplayName("Misc.CzechInvoiceGenerator.LimitedToStores")]
        [UIHint("Stores")]
        public string[] Stores { get; set; }
    }
}
