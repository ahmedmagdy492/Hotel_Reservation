using Hotels_Resrevation.Models;
using Hotels_Resrevation.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Hotels_Resrevation.Constants
{
    public static class Filters
    {
        public static List<Room> FilterByPrices(List<Room> rooms, string filter)
        {
            bool isEqual = Utility.IsEqualtoListItem(Lists.PriceRanges, filter);
            if(isEqual)
            {
                if (filter == "Above 500")
                {
                    return rooms.Where(r => r.Price > 500).ToList();
                }
                int fromRange = Convert.ToInt32(filter.Split(' ')[1]);
                int toRange = Convert.ToInt32(filter.Split(' ')[3]);
                return rooms.Where(r => (r.Price >= fromRange && r.Price <= toRange)).ToList();
            }
            return rooms;
        }

        public static List<Room> FilterByCapacity(List<Room> rooms, string filter)
        {
            bool isEqual = Utility.IsEqualtoListItem(Lists.RoomCapacity, filter);
            if(isEqual)
            {
                int capacity = Convert.ToInt32(filter.Split(' ')[0]);
                return rooms.Where(r => r.Capcity == capacity).ToList();
            }
            return rooms;
        }

        public static List<Room> FilterByPriceAndCapacity(List<Room> rooms, string priceFilter, string capacityFilter)
        {
            var filteredRooms = FilterByCapacity(rooms, capacityFilter);
            return FilterByPrices(filteredRooms, priceFilter);
        }
    }
}
