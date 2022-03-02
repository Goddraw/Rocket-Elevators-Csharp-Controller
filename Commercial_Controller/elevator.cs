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
        public List<int> completedRequestList;


        public Elevator(string _elevatorID)
        {
            this.ID = "1";
            // this.status = "idle";
            // this.currentFloor = 1;
            // this.direction = "none";
            // this.door = new Door();
            // this.floorRequestsList = new List<int>();
            // this.completedRequestList = new List<int>();
        }
        public void move()
        {      
        }

    }
}