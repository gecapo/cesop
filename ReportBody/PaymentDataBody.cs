using System.Xml.Linq;

namespace Reporting.NRA.XmlStructure.ReportBody
{
    public class PaymentDataBody
    {
        /// <summary>
        /// The Reporting PSP element uniquely defines the Payment Service Provider, which reports the payment data to national TAX administration.
        /// </summary>
        public ReportingPSP ReportingPSP { get; set; } = null!;

        /// <summary>
        /// The Reported Payee element defines the payee, to which the payment data submitted by Payment Service Provider relates.
        /// The 'ReportedPayee' element is repeatable as a PSP can report data from many Payees.
        /// This element is mandatory as soon as transactions are reported.It can only be omitted in case there is no transaction to report.
        /// </summary>
        public IEnumerable<ReportedPayee>? ReportedPayees { get; set; }

        public PaymentDataBody(string bic, string reportingPSPName, IEnumerable<ReportedPayee> reportedPayees)
        {
            ReportingPSP = new ReportingPSP(bic, reportingPSPName);
            ReportedPayees = reportedPayees;
        }

        /// <summary>
        /// XElement representation of the report model
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXml() => new(Constants.NameSpaceCesop + nameof(PaymentDataBody),
                ReportingPSP.ToXml(),
                ReportedPayees?.Select(x => x.ToXml())
            );
    }
}
