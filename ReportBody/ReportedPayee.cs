using System.Xml.Linq;

namespace Reporting.NRA.XmlStructure.ReportBody
{
    public class ReportedPayee
    {
        /// <summary>
        /// Article 243d (1b). The name of the Reported Payee company or natural person.
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

        /// <summary>
        /// Article 243d (1d). The country of the payee's origin (ISO-3166 Alpha 2).
        /// </summary>
        public string Country { get; set; } = null!;

        /// <summary>
        /// Used Only For Creating The XML
        /// </summary>
        private readonly string Address = "Address";

        /// <summary>
        /// •	CESOP301: residentialOrBusiness 
        /// •	CESOP302: residential 
        /// •	CESOP303: business 
        /// •	CESOP304: registeredOffice 
        /// •	CESOP309: unspecified
        /// </summary>
        public string LegalAddressType { get; set; } = null!;

        /// <summary>
        /// The Country Code of the payee’s address (ISO-3166 Alpha 2)
        /// </summary>
        public string CountryCodeAddress { get; set; } = null!;

        /// <summary>
        /// Free text address.
        /// </summary>
        public string AddressFree { get; set; } = null!;

        /// <summary>
        /// Used Only For Creating The XML
        /// </summary>
        private readonly string TAXIdentification = "TAXIdentification";

        /// <summary>
        /// The EU confirmed VAT identification number of the payee.
        /// </summary>
        public string? VATId { get; set; }

        /// <summary>
        /// Any taxation identifier of the payee.
        /// </summary>
        public string? TAXId { get; set; }

        /// <summary>
        /// Country that issued VATId or TAXId
        /// </summary>
        public string IssuedBy { get; set; } = null!;

        /// <summary>
        /// The IBAN of the payee’s payment account or any other identifier which unambiguously identifies, and gives the location of, the payee.
        /// This field is mandatory when funds are transferred to a payment account of the payee.
        /// From the legal basis, this element must be provided if available.Otherwise it can be empty.
        /// </summary>
        public string AccountIdentifier { get; set; } = null!;

        /// <summary>
        /// The Country Code of the payee’s address (ISO-3166 Alpha 2)
        /// </summary>
        public string CountryCodeAccount { get; set; } = null!;
        /// <summary>
        /// •	IBAN: The IBAN of the payer/payee’s payment account which unambiguously identifies, and gives the location of, the payer/payee. 
        /// •	OBAN: The OBAN of the payer/payee’s payment account which unambiguously identifies, and gives the location of, the payer/payee.
        /// •	Other: Other identifier which unambiguously identifies, and gives the location of, the payer/payee.
        /// </summary>
        public string Type { get; set; } = null!;

        /// <summary>
        /// The parent Reported Transaction element listing all the received payments and payment refunds for the given payee reported by the PSP.
        /// This element is optional only in case of deletion of the related Reported Payee.Otherwise the element is mandatory.
        /// </summary>
        public IEnumerable<ReportedTransaction> ReportedTransactions { get; set; } = null!;

        /// <summary>
        /// Used Only For Creating The XML
        /// </summary>
        private readonly string DocSpec = "DocSpec";

        /// <summary>
        /// •	CESOP1: New Data
        /// •	CESOP2: Corrected Data
        /// •	CESOP3: Deletion of Data
        /// </summary>
        public string DocTypeIndic { get; set; } = null!;

        /// <summary>
        /// The unique reference of the parent element in form of a UUID version 4.
        /// When the error is related to a Reported Payee or a Reported Transaction, this field allows to link the error to the related DocSpec.
        /// </summary>
        public string DocRefId { get; set; } = null!;

        /// <summary>
        /// XElement representation of the report model
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXml() => new(Constants.NameSpaceCesop + nameof(ReportedPayee),
                new XElement(Constants.NameSpaceCesop + nameof(Name), Name, new XAttribute(nameof(NameType), NameType)),
                new XElement(Constants.NameSpaceCesop + nameof(Country), Country),
                new XElement(Constants.NameSpaceCesop + nameof(Address), new XAttribute(nameof(LegalAddressType), LegalAddressType),
                        new XElement(Constants.NameSpaceCommonType + "CountryCode", CountryCodeAddress),
                        new XElement(Constants.NameSpaceCommonType + nameof(AddressFree), AddressFree)
                    ),
                new XElement(Constants.NameSpaceCesop + nameof(TAXIdentification),
                    () => !string.IsNullOrEmpty(VATId)
                        ? new XElement(Constants.NameSpaceCesop + nameof(VATId), VATId, new XAttribute(nameof(IssuedBy), IssuedBy))
                        : new XElement(Constants.NameSpaceCesop + nameof(TAXId), VATId, new XAttribute(nameof(IssuedBy), IssuedBy))
                    ),
                new XElement(Constants.NameSpaceCesop + nameof(AccountIdentifier), AccountIdentifier,
                        new XAttribute("CountryCode", CountryCodeAccount),
                        new XAttribute(nameof(Type), Type)
                    ),
                ReportedTransactions.Select(x => x.ToXml()),
                new XElement(Constants.NameSpaceCesop + nameof(DocSpec),
                        new XElement(Constants.NameSpaceCommonType + nameof(DocTypeIndic), DocTypeIndic),
                        new XElement(Constants.NameSpaceCommonType + nameof(DocRefId), DocRefId)
                    )
            );
    }
}
