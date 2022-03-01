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
          public List<Column> columnList; 
          public List<FloorRequestButton> floorRequestButtonList;
        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
          this.ID = _ID;
          this.amountOfColumns = _amountOfColumns;
          this.amountOfFloors = _amountOfFloors;
          this.amountOfBasements = _amountOfBasements;
          this.amountOfElevatorPerColumn = _amountOfElevatorPerColumn;
          this.status = "online";
          this.columnList = new List<Column>();
          this.floorRequestButtonList = new List<FloorRequestButton>();
        }

        public Column findBestColumn(int _requestedFloor)
        {
          if (_requestedFloor < 0)
        {
          return basementColumn
        }
          for (int i = 0; i < columnList.lenght; i++)
          {
            if (columnList.minFloor >= floorRequested && 
            Column.maxFloor <= floorRequested)
            {
              return bestColumn
            }
          }
        }
        //Simulate when a user press a button at the lobby
        public (Column, Elevator) assignElevator(int _requestedFloor, string _direction)
        {
            
        }
    }
}

