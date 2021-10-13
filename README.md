# Kapa.Culture
A Simple way to create countries from two letter code, three leter code, numeric code

### Create Country

```csharp
// Create country from two letter code
var country = Country.FromCode("GR");

// Create country from three letter code
var country = Country.FromCode("GRC");

// Create country from numeric code
var country = Country.FromCode("300");

```

### Sample Code
```csharp
var country = Country.FromCode("GR");
Console.WriteLine($"Country Name: {country.Name}");
Console.WriteLine($"Three Letter Code: {country.ThreeLetterCode}");
Console.WriteLine($"Two Letter Code: {country.TwoLetterCode}");
Console.WriteLine($"Numeric Code: {country.NumericCode}");
Console.WriteLine($"Currency Iso Code : {country.CurrencyIsoCode}");
Console.WriteLine($"Currency Symbol: {country.CurrencySymbol}");
Console.WriteLine($"Languages: {string.Join(',', country.Languages)}");
Console.WriteLine($"Dialing Codes: {string.Join(',', country.DialingCodes)}");

// Output
// Country Name: Greece
// Three Letter Code: GRC
// Two Letter Code: GR
// Numeric Code: 300
// Currency Iso Code : EUR
// Currency Symbol: ?
// Languages: el-GR
// Dialing Codes: 30

```
