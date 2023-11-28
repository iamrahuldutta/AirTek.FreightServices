using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Shared.Interfaces.Factory.Models
{
    public interface ICityInformationFactory
    {
        CityInformation CreateCityInformation(string name, string abbreviation);
    }
}
