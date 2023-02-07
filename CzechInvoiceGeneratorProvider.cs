using Grand.Business.Core.Interfaces.Cms;
using Grand.Business.Core.Interfaces.Common.Localization;

namespace Misc.CzechInvoiceGenerator
{
    public class CzechInvoiceGeneratorProvider : IWidgetProvider
    {
        private readonly ITranslationService _translationService;
        private readonly CzechInvoiceGeneratorSettings _czechInvoiceGeneratorSettings;

        public CzechInvoiceGeneratorProvider(
            ITranslationService translationService, 
            CzechInvoiceGeneratorSettings czechInvoiceGeneratorSettings)
        {
            _translationService = translationService;
            _czechInvoiceGeneratorSettings = czechInvoiceGeneratorSettings;
        }

        public string ConfigurationUrl => CzechInvoiceGeneratorDefaults.ConfigurationUrl;

        public string SystemName => CzechInvoiceGeneratorDefaults.ProviderSystemName;

        public string FriendlyName => _translationService.GetResource(CzechInvoiceGeneratorDefaults.FriendlyName);

        public int Priority => _czechInvoiceGeneratorSettings.DisplayOrder;

        public IList<string> LimitedToStores => _czechInvoiceGeneratorSettings.LimitedToStores;

        public IList<string> LimitedToGroups => _czechInvoiceGeneratorSettings.LimitedToGroups;

        /// <summary>
        /// Gets widget zones where this widget should be rendered
        /// </summary>
        /// <returns>Widget zones</returns>
        public async Task<IList<string>> GetWidgetZones()
        {
            //return await Task.FromResult(new List<string>
            //{
            //    CzechInvoiceGeneratorDefaults.WidgetZoneHomePage,
            //    CzechInvoiceGeneratorDefaults.WidgetZoneCategoryPage,
            //    CzechInvoiceGeneratorDefaults.WidgetZoneCollectionPage,
            //    CzechInvoiceGeneratorDefaults.WidgetZoneBrandPage,
            //});

            return new List<string>();
        }

        public Task<string> GetPublicViewComponentName(string widgetZone)
        {
            return Task.FromResult("CzechInvoiceGenerator");
        }

    }
}
