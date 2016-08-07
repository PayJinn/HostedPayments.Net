using PJHostedPaymentsClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PJHostedPaymentsClientDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            Task t = new Task(HostedPaymentsClientDemo);
            t.Start();
            Console.ReadLine();
        }

        static async void HostedPaymentsClientDemo()
        {
            try
            {
                // Set api credentials (call once per run)
                HostedPaymentsClient.SetAPICredentials("TEST0001", "12345678");
                
                // Start a 1.25 EU transaction for TEST0001 user code whose API Key is 12345678
                NewPaymentRequest newPaymentRequest = new NewPaymentRequest()
                {
                    wsClientId = HostedPaymentsClient.clientId  // Your PayJinn API Client Id
                    , wsClientOrderCode = ""                    // Your specific order code goes here,  Max 128 characters 
                    , wsTransferAmount = new decimal(1.25)      // Transaction amount in EURO with 2 significant digits after decimal seperator
                    , wsClientNotificationURL = ""              // "https://www.YourCompanyURL.com/Notify" - Where should we redirect if an error occurs, Max 256 characters
                    , wsClientSuccessURL = ""                   // "https://www.YourCompanyURL.com/Success" - Where should we redirect if transaction ends successfully, Max 256 characters
                    , wsBaseAccountIBAN = ""                    // Base Account IBAN, send empty string to use default account, 0 (for default account ) or 22 characters
                };

                var newPaymentReply = await HostedPaymentsClient.NewPaymentClient(newPaymentRequest);

                // Print output to console
                Console.WriteLine("NewPayment Result:");
                Console.WriteLine("PayJinn Transaction Id: " + newPaymentReply.transactionId);
                Console.WriteLine("PayJinn Payment Session URL: " + newPaymentReply.paymentURL);
                Console.WriteLine("");

                // Query session details
                PaymentDetailReply paymentDetailReply = await HostedPaymentsClient.GetPaymentDetailsClient(newPaymentReply.transactionId);

                if (paymentDetailReply != null)
                {
                    // Print out result
                    Console.WriteLine("GetPaymentDetails Result:");
                    Console.WriteLine(paymentDetailReply.ToString());
                    Console.WriteLine("");
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
            }
        }
    }
}
