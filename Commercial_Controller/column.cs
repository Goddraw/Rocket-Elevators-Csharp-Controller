using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
        public string ID;
        public string status;
        public int amountOfElevators;
        public List<int> servedFloorsList;
        public bool isBasement; 
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonList;

        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
          this.ID = 1;
        }
        public Elevator requestElevator(int userPosition, string direction)
        {
        }

    }
}