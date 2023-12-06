using Reporting.NRA.XmlStructure.ReportBody;
using Reporting.NRA.XmlStructure.ReportHeader;
using System.Xml.Linq;

namespace Reporting.NRA.XmlStructure
{
    public class Cesop
    {
        /// <summary>
        /// The MessageSpec element represents the header of the CESOP payment data message.
        /// </summary>
        public MessageSpec Header { get; set; } = null!;

        /// <summary>
        /// The PaymentDataBody element represents the body of the CESOP payment data message.
        /// </summary>
        public PaymentDataBody Body { get; set; } = null!;

        /// <summary>
        /// XElement representation of the report model
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXml() => new(Constants.NameSpaceCesop + nameof(Cesop),
                new XAttribute(XNamespace.Xmlns + Constants.CommonType, Constants.NameSpaceCommonType),
                new XAttribute(XNamespace.Xmlns + Constants.Cesop, Constants.NameSpaceCesop),
                new XAttribute("version", "4.02"),
                Header.ToXml(),
                Body.ToXml()
            );

        /// <summary>
        /// Serialized Xml representation of the report model
        /// </summary>
        /// <returns>String</returns>
        public string ToXmlString()
        {
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null), ToXml());
            var wr = new StringWriter();
            doc.Save(wr);
            return wr.ToString();
        }

    }
}
