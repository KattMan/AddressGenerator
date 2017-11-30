namespace AddressGeneratorInterfaces
{
    public interface IGenerator
    {
        string GenerateCity();
        string GenerateState();
        string GenerateCounty();
        string GenerateZipcode();
        string GenerateCombinedZipInfo();
        string GenerateStreetNumber();
        string GenerateStreetName();
        string GenerateSubType();
        string GenerateSubNumber();
    }

}