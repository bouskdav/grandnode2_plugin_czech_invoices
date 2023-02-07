using Grand.Business.Core.Utilities.Common.Security;
using Grand.Domain.Admin;
using Grand.Web.Common.Menu;

namespace Misc.CzechInvoiceGenerator
{
    public class CzechInvoiceGeneratorMenuProvider : IAdminMenuProvider
    {
        private readonly CzechInvoiceGeneratorSettings _czechInvoiceGeneratorSettings;

        public CzechInvoiceGeneratorMenuProvider(
            CzechInvoiceGeneratorSettings czechInvoiceGeneratorSettings) 
        {
            _czechInvoiceGeneratorSettings = czechInvoiceGeneratorSettings;
        }

        public string ConfigurationUrl => CzechInvoiceGeneratorDefaults.ConfigurationUrl;

        public string SystemName => CzechInvoiceGeneratorDefaults.ProviderSystemName;

        public string FriendlyName => CzechInvoiceGeneratorDefaults.FriendlyName;

        public int Priority => _czechInvoiceGeneratorSettings.DisplayOrder;

        public IList<string> LimitedToStores => _czechInvoiceGeneratorSettings.LimitedToStores;

        public IList<string> LimitedToGroups => _czechInvoiceGeneratorSettings.LimitedToGroups;

        public Task ManageSiteMap(SiteMapNode rootNode)
        {
            var salesNode = rootNode.ChildNodes.FirstOrDefault(i => i.SystemName == "Sales");

            if (salesNode == null)
                return Task.CompletedTask;

            salesNode.ChildNodes.Add(new SiteMapNode() {
                SystemName = "Invoices",
                ResourceName = "Plugins.Misc.CzechInvoiceGenerator.Fields.Invoices",
                IconClass = "fa fa-dot-circle-o",
                Visible = true,
                ChildNodes = new List<SiteMapNode> {
                    new () {
                        SystemName = "Invoices.Settings",
                        ResourceName = "Plugins.Misc.CzechInvoiceGenerator.Fields.InvoiceSettings",
                        ControllerName = "MiscCzechInvoiceGenerator",
                        ActionName = "Configure",
                        Visible = true,
                    },
                    new () {
                        SystemName = "Invoices.List",
                        ResourceName = "Plugins.Misc.CzechInvoiceGenerator.Fields.InvoiceList",
                        ControllerName = "MiscCzechInvoiceGenerator",
                        ActionName = "Configure",
                        Visible = true,
                    },
                }
            });

            return Task.CompletedTask;
        }
    }
}
