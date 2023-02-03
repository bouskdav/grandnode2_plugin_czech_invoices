using Grand.Business.Core.Events.Checkout.Orders;
using Grand.Business.Core.Interfaces.Common.Directory;
using Grand.Domain.Common;
using Grand.Domain.Data;
using Grand.Domain.Orders;
using MediatR;
using Misc.CzechInvoiceGenerator.Domain;
using Misc.CzechInvoiceGenerator.Services;

namespace Misc.CzechInvoiceGenerator.Events
{
    public class OrderPlacedEventHandler : INotificationHandler<OrderPlacedEvent>
    {
        private readonly IRepository<Order> _orderRepository;
        //private readonly IRepository<OrderInvoiceExtension> _orderInvoiceRepository;
        //private readonly IRepository<OrderInvoiceSerie> _orderInvoiceSeriesRepository;
        private readonly PdfSettings _pdfSettings;
        private readonly IUserFieldService _userFieldService;
        private readonly IInvoiceSeriesService _invoiceSeriesService;

        public OrderPlacedEventHandler(
            IRepository<Order> orderRepository,
            //IRepository<OrderInvoiceExtension> orderInvoiceRepository,
            //IRepository<OrderInvoiceSerie> orderInvoiceSeriesRepository,
            PdfSettings pdfSettings,
            IUserFieldService userFieldService,
            IInvoiceSeriesService invoiceSeriesService)
        {
            _orderRepository = orderRepository;
            //_orderInvoiceRepository = orderInvoiceRepository;
            //_orderInvoiceSeriesRepository = orderInvoiceSeriesRepository;
            _pdfSettings = pdfSettings;
            _userFieldService = userFieldService;
            _invoiceSeriesService = invoiceSeriesService;
        }

        public async Task Handle(OrderPlacedEvent notification, CancellationToken cancellationToken)
        {
            // dont create invoice for pending order if not explicitly set
            bool disableInvoiceForPendingOrders = _pdfSettings.DisablePdfInvoicesForPendingOrders && notification.Order.OrderStatusId == (int)OrderStatusSystem.Pending;

            if (!disableInvoiceForPendingOrders || true)
            {
                // check, if order already have invoice record
                var invoiceNumber = await _userFieldService.GetFieldsForEntity<string>(notification.Order, InvoiceConstants.INVOICE_NUMBER_FIELD_KEY);

                // skip
                if (!String.IsNullOrEmpty(invoiceNumber))
                    return;

                _ = await _invoiceSeriesService.SetNextAvailableNumberForOrder(notification.Order, DateTime.Today);

                // if not, get next invoice number available
                //int nextInvoiceNumber = _orderInvoiceRepository.Table
                //    .Where(i => 
                //        i.InvoiceEffectiveDate >= new DateTime(DateTime.Now.Year, 1, 1) && 
                //        i.InvoiceEffectiveDate <= new DateTime(DateTime.Now.Year, 12, 31))


                //notification.Order.UserFields.Add(new UserField() 
                //{ 
                //    Key = notification.Order.Id, 
                //    StoreId = notification.Order.StoreId,
                //    Value = "20220001",
                //});

                //var userFields = notification.Order.UserFields;

                //userFields.Add(new UserField() 
                //{
                //    Key = notification.Order.Id,
                //    StoreId = notification.Order.StoreId,
                //    Value = "20220001",
                //});

                //UpdateBuilder<Order> orderUpdater = UpdateBuilder<Order>.Create()
                //    .Set(i => i.UserFields, userFields);

                //await _orderRepository.UpdateOneAsync(i => i.Id == notification.Order.Id, orderUpdater);

                //OrderInvoiceExtension invoiceExtension = new OrderInvoiceExtension() 
                //{
                //    OrderGuid = notification.Order.OrderGuid,
                //    InvoiceEffectiveDate = DateTime.Today,
                //    InvoiceNumber = "202200001",
                //};
                
                //await _orderInvoiceRepository.InsertAsync(invoiceExtension);
            }
        }
    }
}
