using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BuildYourFirstBlazor.Interfaces;
using BuildYourFirstBlazor.Models;
using Microsoft.AspNetCore.Components;

namespace BuildYourFirstBlazor.Services
{
    public class PlanetService : IPlanetService
    {
        // Planet names are ©1974-1981 BBC. https://www.bbc.co.uk/
        // Planet images are courtesy of the National Aeronautics and Space Administration (NASA). https://www.nasa.gov/
        private List<Planet> _planets = new List<Planet>
        {
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e001417/GSFC_20171208_Archive_e001417~orig.jpg", Name = "Skaro" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22069/PIA22069~orig.jpg", Name = "Skonnos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA19344/PIA19344~orig.jpg", Name = "Argolis" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA13994/PIA13994~orig.jpg", Name = "Castrovalva" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e000019/GSFC_20171208_Archive_e000019~orig.png", Name = "Diplos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22084/PIA22084~orig.jpg", Name = "Karn" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22087/PIA22087~orig.jpg", Name = "Logopolis" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA22098/PIA22098~orig.jpg", Name = "Minyos II" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA18018/PIA18018~orig.jpg", Name = "Ribos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA14888/PIA14888~orig.jpg", Name = "Skaar" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e001427/GSFC_20171208_Archive_e001427~orig.jpg", Name = "Tara" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e000132/GSFC_20171208_Archive_e000132~orig.jpg", Name = "Traken" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA01253/PIA01253~orig.jpg", Name = "Usurius" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA05988/PIA05988~orig.jpg", Name = "Vampire Planet" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e001545/GSFC_20171208_Archive_e001545~orig.png", Name = "Zanak" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA19833/PIA19833~orig.jpg", Name = "Zeos" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/GSFC_20171208_Archive_e002172/GSFC_20171208_Archive_e002172~orig.jpg", Name = "Zeta Minor" },
            new Planet { ImageUrl = "https://images-assets.nasa.gov/image/PIA20068/PIA20068~orig.jpg", Name = "Voga" },
            /*
            new Planet { Code = "ARR", Name = "Arrakis", ImageUrl = "https://" },
            new Planet { Code = "CAL", Name = "Caladan", ImageUrl = "https://" },
            new Planet { Code = "GIE", Name = "Giedi Prime", ImageUrl = "https://" },
            new Planet { Code = "KAI", Name = "Kaitain", ImageUrl = "https://" },
            new Planet { Code = "CRE", Name = "Crematoria", ImageUrl = "https://" },
            new Planet { Code = "HEL", Name = "Helion Prime", ImageUrl = "https://" },
            new Planet { Code = "MIR", Name = "Miranda", ImageUrl = "https://" },
            new Planet { Code = "VUL", Name = "Vulcan", ImageUrl = "https://" },
            new Planet { Code = "ROM", Name = "Romulus", ImageUrl = "https://" },
            new Planet { Code = "BET", Name = "Betazed", ImageUrl = "https://" },
            new Planet { Code = "BOP", Name = "Borg Prime", ImageUrl = "https://" },
            new Planet { Code = "OMT", Name = "Omicron Theta", ImageUrl = "https://" },
            new Planet { Code = "PRA", Name = "Praxis", ImageUrl = "https://" },
            new Planet { Code = "RUP", Name = "Rura Penthe", ImageUrl = "https://" },
            new Planet { Code = "ZY3", Name = "Zytchin III", ImageUrl = "https://" },
            new Planet { Code = "TAT", Name = "Tatooine", ImageUrl = "https://" },
            new Planet { Code = "ALD", Name = "Alderaan", ImageUrl = "https://" },
            new Planet { Code = "DAG", Name = "Dagobah", ImageUrl = "https://" },
            new Planet { Code = "END", Name = "Endor", ImageUrl = "https://" },
            new Planet { Code = "HOT", Name = "Hoth", ImageUrl = "https://" },
            new Planet { Code = "YAV", Name = "Yavin 4", ImageUrl = "https://" },
            new Planet { Code = "AL4", Name = "Altair IV", ImageUrl = "https://" },
            new Planet { Code = "FIR", Name = "Fire", ImageUrl = "https://" },
            new Planet { Code = "KLE", Name = "Klendathu", ImageUrl = "https://" },
            new Planet { Code = "KRY", Name = "Krypton", ImageUrl = "https://" },
            new Planet { Code = "LV426", Name = "LV-426", ImageUrl = "https://" },
            new Planet { Code = "FIO", Name = "Fiorina 'Fury' 161", ImageUrl = "https://" },
            new Planet { Code = "EP3", Name = "Epsilon 3", ImageUrl = "https://" },
            new Planet { Code = "CAP", Name = "Caprica", ImageUrl = "https://" },
            new Planet { Code = "CYG", Name = "Cygnus Alpha", ImageUrl = "https://" },
            new Planet { Code = "BALLS", Name = "Spaceball", ImageUrl = "https://" },
            new Planet { Code = "THR", Name = "Thra", ImageUrl = "https://" },
            new Planet { Code = "MON", Name = "Mongo", ImageUrl = "https://" },
            new Planet { Code = "ARB", Name = "Arboria", ImageUrl = "https://" },
            new Planet { Code = "FRI", Name = "Frigia", ImageUrl = "https://" },
            new Planet { Code = "ORK", Name = "Ork", ImageUrl = "https://" },
            new Planet { Code = "RIM", Name = "Rimmerworld", ImageUrl = "https://" },
            */
        };

        public IEnumerable<Planet> GetPlanets(string filter)
        {
            if (string.IsNullOrEmpty(filter))
            {
                return _planets;
            }
            else
            {
                return _planets.Where(f => 
                    f.Name.StartsWith(filter, StringComparison.OrdinalIgnoreCase));
            }
        }

        public void AddPlanet(Planet Planet)
        {
            _planets.Add(Planet);
        }
    }
}
