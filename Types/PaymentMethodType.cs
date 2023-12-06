using System.ComponentModel;

namespace Reporting.NRA.XmlStructure.Types
{
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
    public enum PaymentMethodType
    {
        [Description("Card payment")]
        CardPayment,

        [Description("Bank transfer")]
        BankTransfer,

        [Description("Direct debit")]
        DirectDebit,

        [Description("E-money")]
        Emoney,

        [Description("Money Remittance")]
        MoneyRemittance,

        [Description("Marketplace")]
        Marketplace,

        [Description("Intermediary")]
        Intermediary,

        [Description("Other")]
        Other
    }
}
