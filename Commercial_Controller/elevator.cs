using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string ID;
        public string status;
        public int currentFloor;
        public string direction;
        public Door door;
        public List<int> floorRequestsList;
        public List<int> completedRequestsList;
        public int amountOfFloors;


        public Elevator(string id)
        {
            this.ID = id;
            this.status = "idle";
            this.currentFloor = 1;
            this.direction = "none";
            this.door = new Door(Battery.elevatorID);
            this.floorRequestsList = new List<int>();
            this.completedRequestsList = new List<int>();
        }
        public void move()
        {
            while (this.floorRequestsList.Count != 0)
            {
                int destination = floorRequestsList[0];
                this.status = "moving";
                if (this.currentFloor < destination)
                {
                    direction = "up";
                    this.sortFloorList();
                    while (this.currentFloor < destination)
                    {
                        currentFloor++;
                        int screenDisplay = this.currentFloor;
                    }
                }
                else if (this.currentFloor > destination)
                {
                    direction = "down";
                    this.sortFloorList();
                    while (this.currentFloor < destination)
                    {
                        currentFloor--;
                        int screenDispay = this.currentFloor;
                    }
                }
                this.status = "stopped";
                //this.operateDoors();
                completedRequestsList.Add(floorRequestsList[0]);
                floorRequestsList.Remove(0);
            }
            this.status = "idle";
        }

        public void sortFloorList()
        {
            if (this.direction == "up")
            {
                floorRequestsList.Sort(); // Ascending order
            }
            else if (this.direction == "down")
            {
                floorRequestsList.Reverse(); // Descending order
            }
        }
        public void addNewRequest(int requestedFloor)
        {
            if (!this.floorRequestsList.Contains(requestedFloor))
            {
                floorRequestsList.Add(requestedFloor);
            }
            if (this.currentFloor < requestedFloor)
            {
                this.direction = "up";
            }
            if (this.currentFloor > requestedFloor)
            {
                this.direction = "down";
            }
        }
    }
}