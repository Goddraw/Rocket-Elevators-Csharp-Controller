using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Column
    {
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
            this.ID = _ID;
            this.status = "online";
            this.amountOfElevators = _amountOfElevators;
            this.elevatorsList = new List<Elevator>();
            this.callButtonList = new List<CallButton>();
            this.servedFloorsList = _servedFloors;
            this.amountOfFloorsServed = servedFloorsList.Count;
            this.createElevators(amountOfFloorsServed, amountOfElevators);
            this.createCallButtons(amountOfFloorsServed, _isBasement);
        }

        public class BestElevatorInformations
        {
            public Elevator bestElevator;
            public int bestScore;
            public int referenceGap;

            public BestElevatorInformations(Elevator bestElevator, int bestScore, int referenceGap)
            {
                this.bestElevator = bestElevator;
                this.bestScore = bestScore;
                this.referenceGap = referenceGap;
            }
        }

        public BestElevatorInformations checkIfElevatorIsBetter(int scoreTocheck, Elevator newElevator, BestElevatorInformations bestElevatorInformations, int floor)
        {
            if (scoreTocheck < bestElevatorInformations.bestScore)
            {
                bestElevatorInformations.bestScore = scoreTocheck;
                bestElevatorInformations.bestElevator = newElevator;
                bestElevatorInformations.referenceGap = Math.Abs(newElevator.currentFloor - floor);
            }
            else if (bestElevatorInformations.bestScore == scoreTocheck)
            {
                int gap = Math.Abs(newElevator.currentFloor - floor);
                if (bestElevatorInformations.referenceGap > gap)
                {
                    bestElevatorInformations.bestElevator = newElevator;
                    bestElevatorInformations.referenceGap = gap;
                }
            }
            return bestElevatorInformations;
        }

        public Elevator findElevator(int requestedFloor, string requestedDirection)
        {
            BestElevatorInformations bestElevatorInformations = new BestElevatorInformations(null, 6, 10000000);
            if (requestedFloor == 1)
            {
                foreach (Elevator elevator in this.elevatorsList)
                {
                    if (1 == elevator.currentFloor && elevator.status == "stopped")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(1, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (1 == elevator.currentFloor && elevator.status == "idle")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (1 > elevator.currentFloor && elevator.direction == "up")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(3, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (1 < elevator.currentFloor  && elevator.direction == "down")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(3, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (elevator.status == "idle")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(4, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(5, elevator, bestElevatorInformations, requestedFloor);
                    }
                }
            }
            else
            {
                foreach (Elevator elevator in this.elevatorsList) 
                {
                    if (requestedFloor == elevator.currentFloor && elevator.status == "stopped" &&
                    requestedDirection == elevator.direction)  
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(1, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (requestedFloor > elevator.currentFloor && elevator.direction == "up" && requestedDirection == "up")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (requestedFloor < elevator.currentFloor && elevator.direction == "down" && requestedDirection == "down")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(2, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else if (elevator.status == "idle")
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(4, elevator, bestElevatorInformations, requestedFloor);
                    }
                    else
                    {
                        bestElevatorInformations = this.checkIfElevatorIsBetter(5, elevator, bestElevatorInformations, requestedFloor);
                    }
                }
            }
            return bestElevatorInformations.bestElevator;
        }

        public Elevator requestElevator(int userPosition, string direction)
        {
            Elevator elevator = this.findElevator(userPosition, direction);
            elevator.addNewRequest(userPosition);
            elevator.move();
            elevator.addNewRequest(1);
            elevator.move();
            return elevator;
        }

        public void createElevators(int amountOfFloors, int amountOfElevators)
        {
            for (int i = 0; i < amountOfElevators; i++)
            {
                Elevator elevator = new Elevator(this.ID + (i + 1));
                this.elevatorsList.Add(elevator);
                Battery.elevatorID++;
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