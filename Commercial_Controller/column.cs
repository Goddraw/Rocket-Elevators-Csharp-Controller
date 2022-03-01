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
        public List<Elevator> elevatorList;
        public List<CallButton> callButtonList;

        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
          this.ID = _ID;
          this.status = "online";
          this.amountOfElevators = _amountOfElevators;
          this.servedFloorsList = new List<int>();
          isBasement = false;
          this.elevatorList = new List<Elevator>();
          this.callButtonList = new List<CallButton>();
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
          Battery.assignElevator();
          Elevator.move(bestElevator);
          return bestElevator
        }

    }
}