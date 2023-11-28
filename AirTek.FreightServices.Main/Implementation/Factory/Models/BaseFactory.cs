using AirTek.FreightServices.Shared.Models.Flight;

namespace AirTek.FreightServices.Main.Implementation.Factory.Models
{
    public abstract class BaseFactory
    {
        public CityInformation CreateCityInformation(string name, string abbreviation)
        {
            return new CityInformation(name, abbreviation);
        }
    }
}
