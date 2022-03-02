using System;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Battery
    {
        public int AutoIncrementId;
        public int ID;
        public int amountOfColumns; 
        public int amountOfFloors;
        public int amountOfBasements;
        public int amountOfElevatorPerColumn;
        public string status;
        public List<Column> columnsList; 
        public List<FloorRequestButton> floorRequestButtonList;
        
        public Battery(int _ID, int _amountOfColumns, int _amountOfFloors, int _amountOfBasements, int _amountOfElevatorPerColumn)
        {
          this.AutoIncrementId = 1;
          this.ID = _ID;
          this.amountOfColumns = _amountOfColumns;
          this.amountOfFloors = _amountOfFloors;
          this.amountOfBasements = _amountOfBasements;
          this.amountOfElevatorPerColumn = _amountOfElevatorPerColumn;
          this.status = "online";
          this.columnsList = new List<Column>();
          //create basement column
          for (int i = 0; i <= this.amountOfColumns; i++)
          { 
            List<int> servedFloorsList = new List<int>();
          //fill the list
            int minFloor = 21;
            int maxFloor = 40;

            for (i = minFloor; i <= maxFloor; i++)
            {
              servedFloorsList.Add(i);
            }

            this.columnsList.Add(new Column(this.AutoIncrementId.ToString(), 
              _amountOfElevatorPerColumn, 
              servedFloorsList, 
              false));
            AutoIncrementId++;

          }

          this.floorRequestButtonList = new List<FloorRequestButton>();
        }

        public Column findBestColumn(int _requestedFloor)
        {
          if (_requestedFloor < 0)
        {
          return basementColumn
        }
          for (int i = 0; i < servedFloors; i++)
          {
            if (columnsList.minFloor >= floorRequested && 
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

