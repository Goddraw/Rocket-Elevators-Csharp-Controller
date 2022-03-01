namespace Commercial_Controller
{
    //Button on a floor or basement to go back to lobby
    public class FloorRequestButton
    {
        public int ID;
        public string status;
        public int requestedFloor;
        public string direction;

        public FloorRequestButton(int _floor, string _direction)
        {
           this.ID = 1;
           this.status = "online";
           this.requestedFloor = _floor;
           this.direction = _direction;
        }
    }
}