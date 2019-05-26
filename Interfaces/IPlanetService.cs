using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildYourFirstBlazor.Models;

namespace BuildYourFirstBlazor.Interfaces
{
    interface IPlanetService
    {
        IEnumerable<Planet> GetPlanets(string filter);

        void AddPlanet(Planet planet);
    }
}
