using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace PJHostedPaymentsClient
{
    public static class HostedPaymentsClient
    {
        private static string _clientId = "";
        private static string _apiKey = "";

        private const string baseApiURL = "https://www.payjinn.com/api/HostedPayments/";

        public static String clientId
        {
            get { return _clientId; }
        }
        
        public static void SetAPICredentials(String clientId, String apiKey)
        {
            _clientId = clientId;
            _apiKey = apiKey;
        }

        private static void SetHttpBasicAuthHeader(HttpClient client)
        {
            var byteArray = Encoding.ASCII.GetBytes(_clientId + ":" + _apiKey);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", Convert.ToBase64String(byteArray));
        }

        public static async Task<NewPaymentReply> NewPaymentClient(NewPaymentRequest newPaymentRequest)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseApiURL);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    SetHttpBasicAuthHeader(client);
                    HttpResponseMessage response = await client.PostAsJsonAsync("NewPayment", newPaymentRequest);
                             
                    if ((int)response.StatusCode == 200)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        NewPaymentReply reply = JsonConvert.DeserializeObject<NewPaymentReply>(result);
                        return reply;
                    }

                    return null; 
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return null;
            }
        }

        public static async Task<PaymentDetailReply> GetPaymentDetailsClient(string transactionId)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(baseApiURL);
                    SetHttpBasicAuthHeader(client);
                    HttpResponseMessage response = await client.GetAsync(_clientId + "/" + transactionId);

                    if ((int)response.StatusCode == 200)
                    {
                        string result = await response.Content.ReadAsStringAsync();
                        PaymentDetailReply reply = JsonConvert.DeserializeObject<PaymentDetailReply>(result);
                        return reply;
                    }

                    return null;
                }
            }
            catch (Exception e)
            {
                Console.Write(e.ToString());
                return null;
            }
        }

        public static bool ValidateResponseHash(
                    string sessionCode,
                    string orderCode,
                    string payjinnStatus,
                    string responseHash)
        {
            return HashLib.ValidateResponseHash(_clientId, _apiKey, sessionCode, orderCode, payjinnStatus, responseHash);
        }
    }
}
