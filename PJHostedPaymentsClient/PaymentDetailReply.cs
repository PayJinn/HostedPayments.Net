using System;
using System.Globalization;
using System.Text;

namespace PJHostedPaymentsClient
{
    public class PaymentDetailReply
    {
        public string wsSessionCode;
        public string wsClientId;
        public string wsSessionType;
        public string wsBeginDate;
        public string wsBeginTime;
        public string wsEndDate;
        public string wsEndTime;
        public string wsClientOrderCode;

        public string wsTransferAmount;

        public string wsBaseAccountHolderName;
        public string wsBaseCountryCode;
        public string wsBaseBLZ;
        public string wsBaseBIC;
        public string wsBaseIBAN;
              
        public string wsSenderAccountHolderName;
        public string wsSenderCountryCode;
        public string wsSenderBLZ;
        public string wsSenderBIC;
        public string wsSenderIBAN;
        
        public bool wsTransactionState;
        public string wsTranResult;

        // External Payments Related
        public string wsProviderCode;
        public string wsPaymentCode;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("wsSessionCode = " + wsSessionCode + "\n");
            sb.Append("wsClientId = " + wsClientId + "\n");
            sb.Append("wsSessionType = " + wsSessionType + "\n");
            sb.Append("wsPaymentCode = " + wsPaymentCode + "\n");
            sb.Append("wsProviderCode = " + wsProviderCode + "\n");
            sb.Append("wsBeginDate = " + wsBeginDate + "\n");
            sb.Append("wsBeginTime = " + wsBeginTime + "\n");
            sb.Append("wsEndDate = " + wsEndDate + "\n");
            sb.Append("wsEndTime = " + wsEndTime + "\n");
            sb.Append("wsClientOrderCode = " + wsClientOrderCode + "\n");
            sb.Append("wsTransferAmount = " + wsTransferAmount + "\n");
            sb.Append("wsBaseAccountHolderName = " + wsBaseAccountHolderName + "\n");
            sb.Append("wsBaseCountryCode = " + wsBaseCountryCode + "\n");
            sb.Append("wsBaseBLZ = " + wsBaseBLZ + "\n");
            sb.Append("wsBaseBIC = " + wsBaseBIC + "\n");
            sb.Append("wsBaseIBAN = " + wsBaseIBAN + "\n");
            sb.Append("wsSenderAccountHolderName = " + wsSenderAccountHolderName + "\n");
            sb.Append("wsSenderCountryCode = " + wsSenderCountryCode + "\n");
            sb.Append("wsSenderBLZ = " + wsSenderBLZ + "\n");
            sb.Append("wsSenderBIC = " + wsSenderBIC + "\n");
            sb.Append("wsSenderIBAN = " + wsSenderIBAN + "\n");
            sb.Append("wsTransactionState = " + (wsTransactionState ? "TRUE" : "FALSE") + "\n");
            sb.Append("wsTranResult = " + wsTranResult + "\n");

            return sb.ToString();
        }
    }
}