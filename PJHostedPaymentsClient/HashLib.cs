using System;
using System.Security.Cryptography;
using System.Text;

namespace PJHostedPaymentsClient
{
    internal static class HashLib
    {
        private static string BinaryToHextString(byte[] data, int startIndex, int count)
        {
            try
            {
                StringBuilder str = new StringBuilder(count * 2);

                for (int i = 0; i < count; i++)
                    str.Append(data[i + startIndex].ToString("X2"));

                return str.ToString();
            }
            catch
            {
                return null;
            }
        }

        private static string CreateSHA512Hash(string hashData)
        {
            SHA512Managed sha512 = new SHA512Managed();

            byte[] hash = sha512.ComputeHash(Encoding.UTF8.GetBytes(hashData));

            sha512.Clear();

            return BinaryToHextString(hash, 0, hash.Length).ToUpper();
        }

        public static bool ValidateResponseHash(
                    string clientId,
                    string apiKey,
                    string sessionCode,
                    string orderCode,
                    string payjinnStatus,
                    string responseHash)
        {
            // Hashed_APIKey = SHA512(Clear_APIKey + ClientId)
            string hashedAPIKey = CreateSHA512Hash(apiKey + clientId);

            // SHA512(ClientId + Hashed_APIKey + SessionCode + ClientOrderCode + PayJinnStatus)
            string calculatedHash = CreateSHA512Hash(clientId + hashedAPIKey + sessionCode + orderCode + payjinnStatus);

            // Compare results
            if (calculatedHash.ToUpper().Equals(responseHash.ToUpper()))
                return true;
            else
                return false;
        }
    }
}