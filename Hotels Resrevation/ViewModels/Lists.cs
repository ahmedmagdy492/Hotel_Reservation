using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hotels_Resrevation.ViewModels
{
    public class Lists
    {
        private static List<string> items = new List<string>
        {
            "Afghanistan",
            "Albania",
            "Algeria",
            "Andorra",
            "Angola",
            "Antigua and a and Barbuda",
            "Argentina",
            "Armenia",
            "Australia",
            "Austria",
            "Austrian Empmpire",
            "Azerbaijan",
            "Baden",
            "Bahamas",
            "Bahrain",
            "Bangladesh",
            "Barbados",
            "Bavaria",
            "Belarus",
            "Belgium",
            "Belize",
            "Benin(Dahomey)",
            "Bolivia",
            "Bosnia and Herzegovina",
            "Botswana",
            "Brazil",
            "Brunei",
            "Brunswick and Lüneburg",
            "Bulgaria",
            "Burkina Faso(Upper Volta)",
            "Burma",
            "Burundi",
            "Cabo Verde",
            "Cambodia",
            "Cameroon",
            "Canada",
            "Cayman Islands",
            "The Central African Republic",
            "Central American Federation",
            "Chad",
            "Chile",
            "China",
            "Colombia",
            "Congo Free State",
            "Costa Rica",
            "Cote d’Ivoire",
            "Croatia",
            "Cuba",
            "Cyprus",
            "Czechia",
            "Czechoslovakia"
        };
        public static SelectList Locations = new SelectList(items);

        public static SelectList TypeOfUsers = new SelectList(new List<string> { "Hotel", "User" });
        public static SelectList PriceRanges = new SelectList(new List<string>
            {
                "From 70 to 100",
                "From 120 to 200",
                "From 300 to 500",
                "Above 500"
            }
        );
        public static SelectList RoomCapacity = new SelectList(new List<string>
        {
            $"1 {Resources.Rooms.RoomsIndex.Persons}",
            $"2 {Resources.Rooms.RoomsIndex.Persons}",
            $"3 {Resources.Rooms.RoomsIndex.Persons}",
            $"4 {Resources.Rooms.RoomsIndex.Persons}",
            $"5 {Resources.Rooms.RoomsIndex.Persons}"
        });
    }
}