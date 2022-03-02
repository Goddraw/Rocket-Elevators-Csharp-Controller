using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
        public int AutoIncrementId; 
        public string ID;
        public string status;
        public int amountOfElevators;
        public List<int> servedFloorsList;
        public bool isBasement; 
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonList;

        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
          this.AutoIncrementId = 1;
          this.ID = _ID;
          this.status = "online";
          this.amountOfElevators = _amountOfElevators;
          this.servedFloorsList = _servedFloors;
          isBasement = _isBasement;
          this.elevatorsList = new List<Elevator>();
          for (int i = 0; i < this.amountOfElevators; i++)
          {
            this.elevatorsList.Add(new Elevator(this.AutoIncrementId.ToString()));
            AutoIncrementId++;
          }
          this.callButtonList = new List<CallButton>();
          foreach (int floor in this.servedFloorsList)
          {
            CallButton callButton;
            if (isBasement == true)
            {
              callButton = new CallButton(floor, "up");
            } else {
              callButton = new CallButton(floor, "down");
            }
            this.callButtonList.Add(callButton);
          } 
        }

        //Simulate when a user press a button on a floor to go back to the first floor
        public Elevator requestElevator(int userPosition, string direction)
        {
          // Battery.assignElevator();
          // Elevator.move(bestElevator);
          Elevator bestElevator = new Elevator("2");
          return bestElevator;
        }

    }
}