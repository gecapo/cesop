using System.Xml.Linq;

namespace Reporting.NRA.XmlStructure.ReportBody
{
    public class ReportingPSP
    {
        /// <summary>
        /// The element represents the type of the Payment Service Provider identifier.
        /// </summary>
        public string PSPId { get; set; } = null!;

        /// <summary>
        /// • BIC: The PSP Identifier is a BIC code.
        /// • Other: Other PSP Identifier type.
        /// </summary>
        public string PSPIdType { get; set; } = null!;

        /// <summary>
        /// The name of the Payment Service Provider reporting the payment data to national TAX administration.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// •	BUSINESS: Business name 
        /// •	TRADE: Trade name 
        /// •	LEGAL: Legal name 
        /// •	PERSON: Person name
        /// •	OTHER: Other name 
        /// </summary>
        public string NameType { get; set; } = null!;

        public ReportingPSP(string bic, string reportingPSPName)
        {
            PSPId = bic;
            Name = reportingPSPName;
        }

        /// <summary>
        /// XElement representation of the report model
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXml() => new(Constants.NameSpaceCesop + nameof(ReportingPSP),
                new XElement(Constants.NameSpaceCesop + nameof(PSPId), new XAttribute(nameof(PSPIdType), PSPIdType), PSPId),
                new XElement(Constants.NameSpaceCesop + nameof(Name), new XAttribute(nameof(NameType), NameType), Name)
            );
    }
}
