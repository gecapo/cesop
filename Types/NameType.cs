namespace Reporting.NRA.XmlStructure.Types
{
    /// <summary>
    /// •	BUSINESS: Business name 
    /// •	TRADE: Trade name 
    /// •	LEGAL: Legal name 
    /// •	PERSON: Person name
    /// •	OTHER: Other name 
    /// </summary>
    public enum NameType
    {
        BUSINESS, TRADE, LEGAL, PERSON, OTHER
    }

    /// <summary>
    /// •	IBAN: The IBAN of the payer/payee’s payment account which unambiguously identifies, and gives the location of, the payer/payee. 
    /// •	OBAN: The OBAN of the payer/payee’s payment account which unambiguously identifies, and gives the location of, the payer/payee.
    /// •	Other: Other identifier which unambiguously identifies, and gives the location of, the payer/payee.
    /// </summary>
    public enum BankIdentityType
    {
        IBAN, OBAN, Other
    }
}
