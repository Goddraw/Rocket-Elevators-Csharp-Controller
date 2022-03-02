using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
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
            if (_amountOfBasements > 0)
            {
                this.createBasementFloorRequestButtons(amountOfBasements);
                this.createBasementColumn(amountOfBasements, amountOfElevatorPerColumn);
                amountOfColumns--;
            }
            this.createBasementFloorRequestButtons(amountOfFloors);
            this.createColumns(amountOfColumns, amountOfFloors, amountOfElevatorPerColumn);
        }
        public async void createBasementColumn(int amountOfBasements, int amountOfElevatorPerColumn)
        {
            List<int> servedFloorsList = new List<int>();
            int floor = -1;
                for(int i = 0; i < amountOfBasements; i++)
                {
                servedFloorsList.Add(floor);
                floor--;
                }
        }
        public void createFloorRequestButtons(int amountOfFloor)
        {
            int buttonFloor = 1;
            FloorRequestButton floorRequestButton;
            for (int i = 0; i < amountOfFloors; i++)
            {
              floorRequestButton = new FloorRequestButton(buttonFloor, "up");
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

                    Column column = new Column(ID,
                    amountOfFloors,
                    amountOfElevatorPerColumn,
                    servedFloors,
                    false
                    );
                    columnsList.Add(column);
                    ID++;
                }
            }
        }
        public void createBasementFloorRequestButtons(int amountOfBasements)
        {

        }

        public Column findBestColumn(int _requestedFloor)
        {
            foreach(Column i in this.columnsList)
            {
                if(Column.servedFloorList.Contains(_requestedFloor))
                {

                }
            }
            return Column;
        }

        // Simulate when a user press a button at the lobby
        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
          return (column, elevator);
        }
    }
}

