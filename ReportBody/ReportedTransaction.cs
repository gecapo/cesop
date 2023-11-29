using System.Xml.Linq;

namespace Reporting.NRA.XmlStructure.ReportBody
{
    public class ReportedTransaction
    {
        /// <summary>
        /// Article 243d (2d). Any reference which unambiguously identifies the payment for the PSP. The reference must be unique for the Reporting Period.
        /// </summary>
        public string TransactionIdentifier { get; set; } = null!;

        /// <summary>
        /// Article 243d (1g and 1h). The element identifies the refund. Value 'FALSE' represents a 'payment', value 'TRUE' represents a 'payment refund'.
        /// This attribute is optional.If not provided, the default value 'FALSE' will be assigned.
        /// </summary>
        public bool IsRefund { get; set; }

        /// <summary>
        /// Article 243d (2a). The element expresses the date and the time of the related transaction.
        /// Please note that the expected format for the timestamp is the combination of the date, 
        /// the time of the day as specified in [ISO-8601] and the time zone
        /// (i.e. 'YYYY-MM-DDThh:mm:ss.SSSZ' if the time refers to the UTC time zone, otherwise 'YYYY-MM-DDThh:mm:ss.SSS-hh:mm' where hh : mm is the time shift from the UTC time zone).
        /// </summary>
        public DateTime DateTime { get; set; } 

        /// <summary>
        /// •	CESOP701: Execution Date 
        /// •	CESOP702: Clearing Date 
        /// •	CESOP703: Authorisation Date 
        /// •	CESOP704: Purchase Date 
        /// •	CESOP709: Other Date
        /// </summary>
        public string TransactionDateType { get; set; } = null!;

        /// <summary>
        /// Article 243d (2b). The amount and the currency of the payment or of the payment refund.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        ///  The currency code refers to ISO-4217 three-byte alpha version.
        /// </summary>
        public string Currency { get; set; } = null!;

        /// <summary>
        /// Used Only For Creating The XML
        /// </summary>
        public string PaymentMethod { get; set; } = "PaymentMethod";

        /// <summary>
        /// •	Card payment: The credit card as a means of payment. 
        /// •	Bank transfer: The bank transfer as a means of payment.
        /// •	Direct debit: The direct debit as a means of payment. 
        /// •	E-money: The e-Money as a means of payment. 
        /// •	Money Remittance: The money remittance as a means of payment. 
        /// •	Marketplace: The marketplace as a means of payment. 
        /// •	Intermediary: The intermediary as a means of payment. 
        /// •	Other: Other mean of payment. Please specify it in the element PaymentMethodOther.
        /// </summary>
        public string PaymentMethodType { get; set; } = null!;

        /// <summary>
        /// Article 243d (2e). Information that the payment is initiated at the physical premises of the merchant. 
        /// The element has a value 'TRUE' if the payment is initiated at the premises of the merchant. 
        /// Otherwise, the element has a value 'FALSE'.
        /// </summary>
        public bool InitiatedAtPhysicalPremisesOfMerchant { get; set; }

        /// <summary>
        /// Article 243d (2c). Member State of the payer. The payer is the Principal of the transaction, always located in EU. (ISO-3166 Alpha 2).
        /// </summary>
        public string PayerMS { get; set; } = null!;

        /// <summary>
        /// •	IBAN: The IBAN of the payer/payee’s payment account which unambiguously identifies, and gives the location of, the payer/payee. 
        /// •	OBAN: The OBAN of the payer/payee’s payment account which unambiguously identifies, and gives the location of, the payer/payee.
        /// •	Other: Other identifier which unambiguously identifies, and gives the location of, the payer/payee.
        /// </summary>
        public string PayerMSSource { get; set; } = null!;

        /// <summary>
        /// XElement representation of the report model
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXml() => new(Constants.NameSpaceCesop + nameof(ReportedTransaction),
                new XAttribute(nameof(IsRefund), IsRefund ? "true" : "false"),
                new XElement(Constants.NameSpaceCesop + nameof(TransactionIdentifier), TransactionIdentifier),
                new XElement(Constants.NameSpaceCesop + nameof(DateTime), DateTime.ToString("s"),
                    new XAttribute(nameof(TransactionDateType), TransactionDateType)
                ),
                new XElement(Constants.NameSpaceCesop + nameof(Amount), Amount,
                    new XAttribute(nameof(Currency), Currency)
                ),
                new XElement(Constants.NameSpaceCesop + nameof(PaymentMethod),
                    new XElement(Constants.NameSpaceCommonType + nameof(PaymentMethodType), PaymentMethodType)
                ),
                new XElement(Constants.NameSpaceCesop + nameof(InitiatedAtPhysicalPremisesOfMerchant), InitiatedAtPhysicalPremisesOfMerchant ? "true" : "false"),
                new XElement(Constants.NameSpaceCesop + nameof(PayerMS), PayerMS,
                    new XAttribute(nameof(PayerMSSource), PayerMSSource)
                )
        );
    }
}
