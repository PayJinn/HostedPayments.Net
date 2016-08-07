
namespace PJHostedPaymentsClient
{
    public class NewPaymentReply
    {
        public string paymentURL { get; set; }
        public string transactionId { get; set; }

        public NewPaymentReply()
        {
            paymentURL = "";
            transactionId = "";
        }

        public NewPaymentReply(string url, string id)
        {
            paymentURL = url;
            transactionId = id;
        }
    }
}
