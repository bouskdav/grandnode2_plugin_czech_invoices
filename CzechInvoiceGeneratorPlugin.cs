using Grand.Business.Core.Extensions;
using Grand.Business.Core.Interfaces.Common.Localization;
using Grand.Business.Core.Interfaces.Storage;
using Grand.Domain.Data;
using Grand.Infrastructure.Plugins;
using Misc.CzechInvoiceGenerator.Domain;

namespace Misc.CzechInvoiceGenerator
{
    /// <summary>
    /// PLugin
    /// </summary>
    public class CzechInvoiceGeneratorPlugin : BasePlugin, IPlugin
    {
        private readonly IPictureService _pictureService;
        private readonly ITranslationService _translationService;
        private readonly ILanguageService _languageService;
        private readonly IDatabaseContext _databaseContext;
        private readonly IRepository<OrderInvoiceExtension> _orderInvoiceRepository;

        public CzechInvoiceGeneratorPlugin(IPictureService pictureService,
            ITranslationService translationService,
            ILanguageService languageService,
            IDatabaseContext databaseContext,
            IRepository<OrderInvoiceExtension> orderInvoiceRepository)
        {
            _pictureService = pictureService;
            _translationService = translationService;
            _languageService = languageService;
            _databaseContext = databaseContext;
            _orderInvoiceRepository = orderInvoiceRepository;
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override async Task Install()
        {
            //Create index
            await _databaseContext.CreateIndex(_orderInvoiceRepository, OrderBuilder<OrderInvoiceExtension>.Create().Ascending(x => x.OrderGuid), "OrderInvoice_OrderGuid");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "PDFInvoice.UnitPrice", "Unit price");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "PDFInvoice.UnitTaxRate", "Tax");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "PDFInvoice.PriceTaxExcl", "Tax excl.");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "PDFInvoice.PriceTaxExcl", "Tax");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "PDFInvoice.TaxTotal", "Tax sum");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Added", "Record added");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edited", "Record edited");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Info", "Details");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Manage", "Manage");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.AddNew", "Add new");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edit", "Edit");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.BackToList", "Back to list");

            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.From", "Valid from");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.From", "Valid from");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.NextNumber", "Next number");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.NextNumber", "Next number");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Pattern", "Pattern");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Pattern", "Pattern");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.LimitedToStores", "Limited to stores");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.DisplayOrder", "Display order");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.CustomerGroups", "Customer groups");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Stores", "Stores");
            
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Misc.CzechInvoiceGenerator.Fields.Invoices", "Invoices");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Misc.CzechInvoiceGenerator.Fields.InvoiceSettings", "Invoice settings");
            await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Plugins.Misc.CzechInvoiceGenerator.Fields.InvoiceList", "List of invoices");

            await base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override async Task Uninstall()
        {
            await this.DeletePluginTranslationResource(_translationService, _languageService, "PDFInvoice.UnitPrice");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "PDFInvoice.UnitTaxRate");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "PDFInvoice.PriceTaxExcl");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "PDFInvoice.PriceTaxExcl");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "PDFInvoice.TaxTotal");

            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Added");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edited");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Info");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Manage");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.AddNew");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edit");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.BackToList");

            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.From");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.From");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.NextNumber");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.NextNumber");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Pattern");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Pattern");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.LimitedToStores");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.DisplayOrder");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.CustomerGroups");
            await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Stores");

            await base.Uninstall();
        }

        public override string ConfigurationUrl()
        {
            return CzechInvoiceGeneratorDefaults.ConfigurationUrl;
        }
    }
}
