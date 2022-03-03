using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
        public static int elevatorID = 1;
        public static int columnID = 1;
        public string ID;
        public string status;
        public int amountOfElevators;
        public int amountOfFloorsServed;
        public List<int> servedFloorsList;
        public bool isBasement;
        public List<Elevator> elevatorsList;
        public List<CallButton> callButtonList;

        public Column(string _ID, int _amountOfElevators, List<int> _servedFloors, bool _isBasement)
        {
            this.ID = columnID.ToString();
            this.status = "online";
            this.amountOfElevators = _amountOfElevators;
            this.elevatorsList = new List<Elevator>();
            this.callButtonList = new List<CallButton>();
            this.servedFloorsList = _servedFloors;
            this.amountOfFloorsServed = servedFloorsList.Count;  
            this.createElevators(amountOfFloorsServed, amountOfElevators);
            this.createCallButtons(amountOfFloorsServed, _isBasement);
        }
        
        public (Elevator bestElevator, int bestScore, int referenceGap) checkIfElevatorIsBetter(int scoreTocheck, Elevator newElevator, int bestScore, 
        int referenceGap, Elevator bestElevator, int floor)
        {
          if (scoreTocheck < bestScore)
          {
            bestScore = scoreTocheck;
            bestElevator = newElevator;
            referenceGap = Math.Abs(newElevator.currentFloor - floor);
          }
          else if(bestScore == scoreTocheck)
          {
            int gap = Math.Abs(newElevator.currentFloor - floor);
            if(referenceGap > gap)
            {
              bestElevator = newElevator;
              referenceGap = gap; 
            }
          }
          return (bestElevator, bestScore, referenceGap); 
        }
        
        public Elevator findElevator(int userPosition, string direction)
        {
          return null;
        }
        
        public Elevator requestElevator(int userPosition, string direction)
        {
            Elevator elevator = this.findElevator(userPosition, direction);
            elevator.addNewRequest(_requestedFloor)
            elevator.move();
            elevator.addNewRequest(1);
            elevator.move();

        }

        public void createElevators(int amountOfFloors, int amountOfElevators)
        {
            for (int i = 0; i < amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(Column.elevatorID.ToString());
                this.elevatorsList.Add(elevator);
                Column.elevatorID++;
            }
        }
        public void createCallButtons(int amountOfFloors, bool _isBasement)
        {
            if (_isBasement)
            {
                int buttonFloor = -1;
                for (int i = 0; i < amountOfFloors; i++)
                {
                    CallButton callButton = new CallButton(buttonFloor, "up");
                    this.callButtonList.Add(callButton);
                    buttonFloor--;
                }
            }
            else
            {
                int buttonFloor = 1;
                for (int i = 0; i < amountOfFloors; i++)
                {
                    CallButton callButton = new CallButton(buttonFloor, "down");
                    this.callButtonList.Add(callButton);
                    buttonFloor++;
                }
            }

        }

    }
}