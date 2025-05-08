namespace EggCodeStampDecoder;

internal record CountryModel
{
    /// <summary>
    /// Country name
    /// </summary>
    internal string Name { get; }
    /// <summary>
    /// Alpha-2 code
    /// </summary>
    internal string AlphaTwoCode { get; }
    /// <summary>
    /// Alpha-3 code
    /// </summary>
    internal string AlphaThreeCode { get; }
    /// <summary>
    /// Numeric code
    /// </summary>
    internal ushort NumericCode { get; }

    public CountryModel(string name, string alphatwo, string alphathree, ushort numeric)
    {
        Name = name;
        AlphaTwoCode = alphatwo;
        AlphaThreeCode = alphathree;
        NumericCode = numeric;
    }
}