using Grand.Business.Core.Events.Checkout.Orders;
using Grand.Business.Core.Interfaces.Common.Directory;
using Grand.Domain.Data;
using MediatR;
using Misc.CzechInvoiceGenerator.Domain;
using Misc.CzechInvoiceGenerator.Services;

namespace Misc.CzechInvoiceGenerator.Events
{
    public class OrderPaidEventHandler : INotificationHandler<OrderPaidEvent>
    {
        private readonly IRepository<OrderInvoiceExtension> _orderInvoiceRepository;
        private readonly IUserFieldService _userFieldService;
        private readonly IInvoiceSeriesService _invoiceSeriesService;

        public OrderPaidEventHandler(
            IRepository<OrderInvoiceExtension> orderInvoiceRepository,
            IUserFieldService userFieldService,
            IInvoiceSeriesService invoiceSeriesService)
        {
            _orderInvoiceRepository = orderInvoiceRepository;
            _userFieldService = userFieldService;
            _invoiceSeriesService = invoiceSeriesService;
        }

        public async Task Handle(OrderPaidEvent notification, CancellationToken cancellationToken)
        {
            // check, if order already have invoice record
            var invoiceNumber = await _userFieldService.GetFieldsForEntity<string>(notification.Order, InvoiceConstants.INVOICE_NUMBER_FIELD_KEY);

            // skip
            if (!String.IsNullOrEmpty(invoiceNumber))
                return;

            _ = await _invoiceSeriesService.SetNextAvailableNumberForOrder(notification.Order, DateTime.Today);
        }
    }
}
