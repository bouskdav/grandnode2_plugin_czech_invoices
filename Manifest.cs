using Grand.Infrastructure;
using Grand.Infrastructure.Plugins;
using Misc.CzechInvoiceGenerator;

[assembly: PluginInfo(
    FriendlyName = "CzechInvoiceGenerator",
    Group = "Invoices",
    SystemName = CzechInvoiceGeneratorDefaults.ProviderSystemName,
    SupportedVersion = GrandVersion.SupportedPluginVersion,
    Author = "Laguna Solutions",
    Version = "1.0"
)]