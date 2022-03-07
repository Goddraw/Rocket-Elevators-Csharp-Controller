Rocket-Elevators-Csharp-Controller
This my C# Residential Controller from the pseudocode. Enjoy!

This program controls a Column of elevators.

It sends an elevator when a user presses a call button on a floor and it takes
a user to its desired floor when a button is pressed from the inside of the elevator. 

The elevator selection is based on the current direction and status of every elevators. It priorizes the elevator going in the same direction the user wants to go and sends the closest one as well so that the user waits less time.

To be able to try the program, you need 

- To create column with the parameters: id, amount of Floors and amount of Elevators
- Set the status of the elevators (are they moving in a direction or idle?)
- To set which floor is requested and where each elevators are.
- Once this is done, you can decide the behaviour of each elevators and then start a scenario.


Here is an example of a potential test scenario for the program:

public class Scenarios
    {
        Battery battery = new Battery(1, 4, 60, 6, 5);

        public Column moveAllElevators(Column column) {
            
            for (int i = 0; i < column.elevatorsList.Count; i++)
            {
               
                while (column.elevatorsList[i].floorRequestsList.Count != 0)
                {
                     Console.WriteLine(column.elevatorsList[i].currentFloor);
                    column.elevatorsList[i].move();
                }
            }
            return column;
        }

        public Column setupElevators(Column column, List<ElevatorDetails> elevatorDetails) {
            for (int i = 0; i < column.elevatorsList.Count; i++)
            {
                column.elevatorsList[i].currentFloor = elevatorDetails[i].floor;
                column.elevatorsList[i].direction = elevatorDetails[i].direction;
                column.elevatorsList[i].status = elevatorDetails[i].status;
                column.elevatorsList[i].floorRequestsList = elevatorDetails[i].floorRequests;
            }
            return column;
        }

                public (Column, Elevator) scenario1()
        {
            Column column = battery.columnsList[1];

            ElevatorDetails elevator1 = new ElevatorDetails(20,"down","moving", new List<int>{5});
            ElevatorDetails elevator2 = new ElevatorDetails(3,"up","moving",  new List<int>{15});
            ElevatorDetails elevator3 = new ElevatorDetails(13,"down","moving",new List<int>{1});
            ElevatorDetails elevator4 = new ElevatorDetails(15,"down","moving", new List<int>{2});
            ElevatorDetails elevator5 = new ElevatorDetails(6,"down","moving", new List<int>{2});
            List<ElevatorDetails> elevatorDetails = new List<ElevatorDetails>{elevator1,elevator2,elevator3,elevator4,elevator5};
            battery.columnsList[1] = setupElevators(column, elevatorDetails);

            (Column chosenColumn, Elevator chosenElevator) = battery.assignElevator(20, "up");
            chosenColumn = moveAllElevators(chosenColumn);
            return (chosenColumn, chosenElevator);
        }