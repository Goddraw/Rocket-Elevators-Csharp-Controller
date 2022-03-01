using System.Threading;
using System.Collections.Generic;

namespace Commercial_Controller
{
    public class Elevator
    {
        public string elevatorID;
        public string status;
        public int currentFloor;
        public string direction;
        public Door door;
        public List<int> floorRequestList;
        public List<int> completedRequestList;


        public Elevator(string _elevatorID)
        {
            this.elevatorID = _elevatorID;
            this.status = "idle";
            this.currentFloor = 1;
            this.direction = "none";
            this.door = new Door();
            this.floorRequestList = new List<int>();
            this.completedRequestList = new List<int>();

        // public static int AutoIncrementElevatorId = 1;
        // public int ElevatorId { get; }
        // public Elevator()
        // {
        //     ElevatorId = AutoIncrementElevatorId;
        //     AutoIncrementElevatorId++;
        // }
    }
    public void move(int calledFloor, string direction)
    {
        if (this.currentFloor > calledFloor)
        {
            direction = "down";
        }
        else if (this.currentFloor < calledFloor)
        {

            direction = "up";
        }
        else
        {
            direction = null;
        }
        while (currentFloor != calledFloor)
        {
            if (direction == "up")
            {
                currentFloor++;
            }
            if (direction == "down")
            {
                currentFloor--;
            }
        }
        //operate doors       
    }

}
}