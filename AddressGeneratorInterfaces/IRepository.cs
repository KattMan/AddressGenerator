using System.Collections.Generic;

namespace AddressGeneratorInterfaces
{
    public interface IRepository
    {
        List<string> GetAdjectives();
        List<string> GetNouns();
        List<string> GetStreetTypes();
        List<string> GetSubTypes();
        List<string> GetZipCodeInfo();
    }
}