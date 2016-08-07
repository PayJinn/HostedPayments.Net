
namespace PJHostedPaymentsClient
{
    public class NewPaymentRequest
    {
        public string wsClientId { get; set; }
        public string wsClientOrderCode { get; set; }
        public decimal wsTransferAmount { get; set; }
        public string wsClientNotificationURL { get; set; }
        public string wsClientSuccessURL { get; set; }
        public string wsBaseAccountIBAN { get; set; }
    }
}