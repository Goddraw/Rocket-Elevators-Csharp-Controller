using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public static int columnID = 1;
        public int ID;
        public int amountOfColumns;
        public int amountOfFloors;
        public int amountOfBasements;
        public int amountOfElevatorPerColumn;
        public string status;
        public List<Column> columnsList;
        public List<FloorRequestButton> floorRequestButtonList;
        public Column basementColumn;

        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
            this.ID = _ID;
            this.status = "online";
            List<Column> columnList = new List<Column>();
            List<FloorRequestButton> floorRequestButtonsList = new List<FloorRequestButton>();
            if (amountOfBasements > 0)
            {
                this.createBasementFloorRequestButtons(amountOfBasements);
                this.createBasementColumn(amountOfBasements, amountOfElevatorPerColumn);
                amountOfColumns--;
            }
            this.createBasementFloorRequestButtons(amountOfFloors);
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
            Column basementColumn = new Column(Battery.columnID.ToString(),
            amountOfElevatorPerColumn,
            servedFloorsList,
            true);
            this.columnsList.Add(basementColumn);
            Battery.columnID++;
        }
        public void createFloorRequestButtons(int amountOfFloor)
        {
            int buttonFloor = 1;
            FloorRequestButton floorRequestButton;
            for (int i = 0; i < amountOfFloors; i++)
            {
                floorRequestButton = new FloorRequestButton(buttonFloor, "up");
                this.floorRequestButtonList.Add(floorRequestButton);
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
                for (i = 0; i < amountOfFloorsPerColumn; i++)
                {

                    if (floor <= this.amountOfFloors)
                    {
                        servedFloorsList.Add(floor);
                        floor++;
                    }

                    Column column = new Column(Battery.columnID.ToString(),
                    amountOfElevatorPerColumn,
                    servedFloorsList,
                    false
                    );
                    columnsList.Add(column);
                    Battery.columnID++;  
                }
            }
        }
        public void createBasementFloorRequestButtons(int amountOfBasements)
        {
            int buttonFloor = -1;
            for (int i = 0; i < amountOfBasements; i++)
            {
                FloorRequestButton basementButton = new FloorRequestButton(buttonFloor, "down");
                this.floorRequestButtonList.Add(basementButton);
                buttonFloor--;
            }
        }

        public Column findBestColumn(int _requestedFloor)
        {
            foreach (Column column in this.columnsList)
            {
                if (column.servedFloorsList.Contains(_requestedFloor))
                {
                    return column;
                }
            }
            return null; 
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

