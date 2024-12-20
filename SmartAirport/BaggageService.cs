using System.Collections.Generic;
using System.Linq;

namespace SmartAirport.Services
{
    public class BaggageService
    {
        private List<Baggage> baggageList = new List<Baggage>();

        public List<Baggage> GetAllBaggage()
        {
            return baggageList;
        }

        public void AddBaggage(Baggage baggage)
        {
            baggageList.Add(baggage);
        }

        public void RemoveBaggage(string baggageID)
        {
            var baggage = baggageList.FirstOrDefault(b => b.BaggageID == baggageID);
            if (baggage != null) baggageList.Remove(baggage);
        }

        public Baggage FindLostBaggage()
        {
            return baggageList.FirstOrDefault(b => b.Status == "Потерян");
        }
    }
}