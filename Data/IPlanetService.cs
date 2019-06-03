using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Data
{
    interface IPlanetService
    {
        IEnumerable<Planet> GetPlanets(string filter = null);

        bool AddPlanet(Planet planet);

        bool UpdatePlanet(Planet inputPlanet, Planet editPlanet);
    }
}
