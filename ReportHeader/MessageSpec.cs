using System.Xml.Linq;

namespace Reporting.NRA.XmlStructure.ReportHeader
{
    public class MessageSpec
    {
        /// <summary>
        /// Article 243d (2a). The element represents the quarter to which the payment data refers.
        /// </summary>
        private readonly int Quater;

        /// <summary>
        /// rticle 243d (2a). The element represents the year to which the payment data refers.
        /// </summary>
        private readonly int Year;

        /// <summary>
        /// The exact date and time when the PSP has generated the message.
        /// Please note that the expected format for the timestamp is the combination of the date, the time of the day as specified in [ISO-8601] and the time zone
        /// (i.e. 'YYYY-MM-DDThh:mm:ss.SSSZ' if the time refers to the UTC time zone, otherwise 'YYYY-MM-DDThh:mm:ss.SSS-hh:mm' where hh : mm is the time shift from the UTC time zone).
        /// </summary>
        private readonly DateTime Timestamp;

        public MessageSpec(DateTime from, DateTime to)
        {
            Quater = Math.Abs(to.AddDays(-1).Month / 3);
            Year = from.AddDays(-1).Year;
            Timestamp = DateTime.UtcNow;
        }

        /// <summary>
        /// PMT = The message type is 'Payment data' (or 'No Payment data').
        /// VLD = The message type is 'Validation result message'.
        /// </summary>
        private const string MessageType = "PMT";

        /// <summary>
        /// CESOP100 = The message contains new data.
        /// CESOP101 = The message contains corrections or deletions of previously sent data.
        /// CESOP102 = The message indicates there is no data to report.
        /// </summary>
        private const string MessageTypeIndic = "CESOP100";

        /// <summary>
        /// The Member State of the national TAX administration through which the Payment data transits (ISO-3166 Alpha 2).
        /// </summary>
        public string TransmittingCountry { get; set; } = "BG";

        /// <summary>
        /// Used Only For Creating The XML
        /// </summary>
        private readonly string ReportingPeriod = "ReportingPeriod";

        /// <summary>
        /// XElement representation of the report model
        /// </summary>
        /// <returns>XElement</returns>
        public XElement ToXml() => new(Constants.NameSpaceCesop + nameof(MessageSpec),
            new XElement(Constants.NameSpaceCesop + nameof(TransmittingCountry), TransmittingCountry),
            new XElement(Constants.NameSpaceCesop + nameof(MessageType), MessageType),
            new XElement(Constants.NameSpaceCesop + nameof(MessageTypeIndic), MessageTypeIndic),
            new XElement(Constants.NameSpaceCesop + nameof(ReportingPeriod),
                new XElement(Constants.NameSpaceCesop + nameof(Quater), Quater),
                new XElement(Constants.NameSpaceCesop + nameof(Year), Year)
                ),
            new XElement(Constants.NameSpaceCesop + nameof(Timestamp), Timestamp.ToString("s"))
        );
    }
}
