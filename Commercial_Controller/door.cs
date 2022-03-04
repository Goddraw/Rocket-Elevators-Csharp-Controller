namespace Commercial_Controller
{
    public class Door
    {
        public int ID;
        public string status;
        public Door(int id)
        {
            ID = id;
            status = "closed";  
        }
    }
}