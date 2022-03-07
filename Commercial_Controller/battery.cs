using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        // Globals
        public static int elevatorID = 1;
        
        public static string alphabet = "ABCDEFGHIJKLMONPQRSTUVWXYZ";

        // Instance variables
        public int columnID;
        public int ID;
        public int amountOfColumns;
        public int amountOfFloors;
        public int amountOfBasements;
        public int amountOfElevatorPerColumn;
        public string status;
        public List<Column> columnsList;
        public List<FloorRequestButton> floorRequestButtonsList;
        public Column basementColumn;

        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.columnID = 1;
            this.amountOfColumns = _amountOfColumns;
            this.amountOfFloors = _amountOfFloors;
            this.amountOfBasements = _amountOfBasements;
            this.amountOfElevatorPerColumn = _amountOfElevatorPerColumn;
            this.ID = _ID;
            this.status = "online";
            this.columnsList = new List<Column>();
            this.floorRequestButtonsList = new List<FloorRequestButton>();
            if (amountOfBasements > 0)
            {
                this.createBasementFloorRequestButtons(amountOfBasements);
                this.createBasementColumn(amountOfBasements, amountOfElevatorPerColumn);
                amountOfColumns--;
            }
            this.createFloorRequestButtons(amountOfFloors);
            this.createColumns(amountOfColumns, amountOfFloors, amountOfBasements, amountOfElevatorPerColumn);
        }
        public void createBasementColumn(int amountOfBasements, int amountOfElevatorPerColumn)
        {
            List<int> servedFloorsList = new List<int>();
            int floor = -1;
            for (int i = 0; i < amountOfBasements; i++)
            {
                servedFloorsList.Add(floor);
                floor--;
            }
            Column basementColumn = new Column(alphabet[this.columnID - 1].ToString(),
                amountOfElevatorPerColumn,
                servedFloorsList,
                true);
            this.columnsList.Add(basementColumn);
            this.columnID++;
        }
        public void createFloorRequestButtons(int amountOfFloors)
        {
            int buttonFloor = 1;
            FloorRequestButton floorRequestButton;
            for (int i = 0; i < amountOfFloors; i++)
            {
                floorRequestButton = new FloorRequestButton(buttonFloor, "up");
                this.floorRequestButtonsList.Add(floorRequestButton);
                buttonFloor++;
            }
        }
        public void createColumns(int amountOfColumns,
            int amountOfFloors,
            int amountOfBasements,
            int amountOfElevatorsPerColumn)
        {
            int amountOfFloorsPerColumn = (int)Math.Round(amountOfFloors / (double)amountOfColumns);
            int floor = 1;
            for (int i = 0; i < amountOfColumns; i++)
            {
                List<int> servedFloorsList = new List<int>();
                for (int j = 0; j < amountOfFloorsPerColumn; j++)
                {
                    if (floor <= this.amountOfFloors)
                    {
                        servedFloorsList.Add(floor);
                        floor++;
                    }
                }
                Column column = new Column(alphabet[this.columnID - 1].ToString(),
                    amountOfElevatorPerColumn,
                    servedFloorsList,
                    false
                    );
                columnsList.Add(column);
                this.columnID++;
            }
        }
        public void createBasementFloorRequestButtons(int amountOfBasements)
        {
            int buttonFloor = -1;
            for (int i = 0; i < amountOfBasements; i++)
            {
                FloorRequestButton basementButton = new FloorRequestButton(buttonFloor, "down");
                this.floorRequestButtonsList.Add(basementButton);
                buttonFloor--;
            }
        }

        public Column findBestColumn(int _requestedFloor)
        {
            Column bestColumn = null;
            foreach (Column column in this.columnsList)
            {
                if (column.servedFloorsList.Contains(_requestedFloor))
                {
                    bestColumn = column;
                    break;
                }
            }
            return bestColumn;
        }

        // Simulate when a user press a button at the lobby
        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
            Column column = this.findBestColumn(_requestedFloor);
            Elevator elevator = column.findElevator(1, _direction);
            elevator.addNewRequest(1);
            elevator.move();
            elevator.addNewRequest(_requestedFloor);
            elevator.move();
            return (column, elevator);
        }
    }
}

