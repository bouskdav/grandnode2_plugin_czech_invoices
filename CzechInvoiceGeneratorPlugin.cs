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

            ////pictures
            //var sampleImagesPath = CommonPath.MapPath("Plugins/Misc.CzechInvoiceGenerator/Assets/membersOnly/sample-images/");
            //var byte1 = File.ReadAllBytes(sampleImagesPath + "banner1.png");
            //var byte2 = File.ReadAllBytes(sampleImagesPath + "banner2.png");

            //var pictureMembersOnly1 = new PictureMembersOnly()
            //{
            //    DisplayOrder = 0,
            //    Link = "",
            //    Name = "Sample membersOnly 1",
            //    FullWidth = true,
            //    Published = true,
            //    Description = "<div class=\"row slideRow justify-content-start\"><div class=\"col-lg-6 d-flex flex-column justify-content-center align-items-center\"><div><div class=\"animate-top animate__animated animate__backInDown\" >exclusive - modern - elegant</div><div class=\"animate-center-title animate__animated animate__backInLeft animate__delay-05s\">Smart watches</div><div class=\"animate-center-content animate__animated animate__backInLeft animate__delay-1s\">Go to collection and see more...</div><a href=\"/smartwatches\" class=\"animate-bottom btn btn-info animate__animated animate__backInUp animate__delay-15s\"> SHOP NOW </a></div></div></div>"
            //};

            //var pic1 = await _pictureService.InsertPicture(byte1, "image/png", "banner_1",reference: Grand.Domain.Common.Reference.Widget, objectId: pictureMembersOnly1.Id, validateBinary: false);
            //pictureMembersOnly1.PictureId = pic1.Id;
            //await _pictureMembersOnlyRepository.InsertAsync(pictureMembersOnly1);


            //var pictureMembersOnly2 = new PictureMembersOnly()
            //{
            //    DisplayOrder = 1,
            //    Link = "https://grandnode.com",
            //    Name = "Sample membersOnly 2",
            //    FullWidth = true,
            //    Published = true,
            //    Description = "<div class=\"row slideRow\"><div class=\"col-md-6 offset-md-6 col-12 offset-0 d-flex flex-column justify-content-center align-items-start px-0 pr-md-3\"><div class=\"slide-title text-dark animate__animated animate__fadeInRight animate__delay-05s\"><h2 class=\"mt-0\">Redmi Note 9</h2></div><div class=\"slide-content animate__animated animate__fadeInRight animate__delay-1s\"><p class=\"mb-0\"><span>Equipped with a high-performance octa-core processor <br/> with a maximum clock frequency of 2.0 GHz.</span></p></div><div class=\"slide-price animate__animated animate__fadeInRight animate__delay-15s d-inline-flex align-items-center justify-content-start w-100 mt-2\"><p class=\"actual\">$249.00</p><p class=\"old-price\">$399.00</p></div><div class=\"slide-button animate__animated animate__fadeInRight animate__delay-2s mt-3\"><a class=\"btn btn-outline-info\" href=\"/redmi-note-9\">BUY REDMI NOTE 9</a></div></div></div>",
            //};
            //var pic2 = await _pictureService.InsertPicture(byte2, "image/png", "banner_2", reference: Grand.Domain.Common.Reference.Widget, objectId: pictureMembersOnly2.Id, validateBinary: false);
            //pictureMembersOnly2.PictureId = pic2.Id;

            //await _pictureMembersOnlyRepository.InsertAsync(pictureMembersOnly2);

            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.DisplayOrder", "Display order");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.LimitedToGroups", "Limited to groups");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.LimitedToStores", "Limited to stores");


            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.FriendlyName", "Widget MembersOnly");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Added", "MembersOnly added");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Addnew", "Add new membersOnly");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.AvailableStores", "Available stores");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.AvailableStores.Hint", "Select stores for which the membersOnly will be shown.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Backtolist", "Back to list");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Category", "Category");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Category.Hint", "Select the category where membersOnly should appear.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Category.Required", "Category is required");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Description", "Description");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Description.Hint", "Enter the description of the membersOnly");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.DisplayOrder", "Display Order");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.DisplayOrder.Hint", "The membersOnly display order. 1 represents the first item in the list.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edit", "Edit membersOnly");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edited", "MembersOnly edited");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Displayorder", "Display Order");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Link", "Link");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.ObjectType", "MembersOnly type");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Picture", "Picture");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Published", "Published");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Title", "Title");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.FullWidth", "Full width");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.FullWidth.hint", "Full width");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Info", "Info");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.LimitedToStores", "Limited to stores");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.LimitedToStores.Hint", "Determines whether the membersOnly is available only at certain stores.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Link", "URL");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Link.Hint", "Enter URL. Leave empty if you don't want this picture to be clickable.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Manage", "Manage Bootstrap MembersOnly");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Collection", "Collection");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Collection.Hint", "Select the collection where membersOnly should appear.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Collection.Required", "Collection is required");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Brand", "Brand");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Brand.Hint", "Select the brand where membersOnly should appear.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Brand.Required", "Brand is required");

            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Name", "Name");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Name.Hint", "Enter the name of the membersOnly");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Name.Required", "Name is required");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Picture", "Picture");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Picture.Required", "Picture is required");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Published", "Published");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Published.Hint", "Specify it should be visible or not");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.MembersOnlyType", "MembersOnly type");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.MembersOnlyType.Hint", "Choose the membersOnly type. Home page, category or collection page.");
            //await this.AddOrUpdatePluginTranslateResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Stores", "Stores");


            await base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override async Task Uninstall()
        {

            ////clear repository
            //await _pictureMembersOnlyRepository.DeleteAsync(_pictureMembersOnlyRepository.Table.ToList());

            ////locales
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Added");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Addnew");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.AvailableStores");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.AvailableStores.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Backtolist");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Category");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Category.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Category.Required");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Description");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Description.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.DisplayOrder");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.DisplayOrder.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edit");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Edited");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Displayorder");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Link");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.ObjectType");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Picture");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Published");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Fields.Title");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Info");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.LimitedToStores");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.LimitedToStores.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Link");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Link.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Manage");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Collection");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Collection.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Collection.Required");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Brand");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Brand.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Brand.Required");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Name");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Name.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Name.Required");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Picture");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Picture.Required");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Published");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Published.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.MembersOnlyType");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.MembersOnlyType.Hint");
            //await this.DeletePluginTranslationResource(_translationService, _languageService, "Misc.CzechInvoiceGenerator.Stores");

            await base.Uninstall();
        }

        public override string ConfigurationUrl()
        {
            return CzechInvoiceGeneratorDefaults.ConfigurationUrl;
        }
    }
}
