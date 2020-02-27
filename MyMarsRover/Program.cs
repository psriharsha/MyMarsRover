using System;
using System.Collections.Generic;

namespace MyMarsRover
{
    class Program
    {
        int MaximumX, MaximumY;
        List<Rover> Rovers = new List<Rover>();
        
        static void Main(string[] args)
        {
            (new Program()).Execute();
        }

        private void Execute()
        {
            try
            {
                //Get TopRight coordinates of Mars
                string[] TopRightCoordinates = Console.ReadLine().Split(' ');
                MaximumX = Int32.Parse(TopRightCoordinates[0]);
                MaximumY = Int32.Parse(TopRightCoordinates[1]);
                //As the number of rovers is not defined
                while(true)
                {
                    //Read RoverState or Exit
                    string[] RoverState = Console.ReadLine().ToUpper().Split(' ');
                    //Break if Q is pressed and start moving the rovers
                    if ("Q".Equals(RoverState[0]) || RoverState.Length != 3)
                        break;
                    string command = Console.ReadLine().ToUpper();
                    int x = Int32.Parse(RoverState[0]);
                    int y = Int32.Parse(RoverState[1]);
                    var d = Direction.NORTH; // Assumed default as NORTH in case of invalid characters
                    switch((RoverState[2])[0])
                    {
                        case 'E': d = Direction.EAST; break;
                        case 'W': d = Direction.WEST; break;
                        case 'S': d = Direction.SOUTH; break;
                    }
                    Rover NewRover = new Rover()
                    {
                        PositionX = x,
                        PositionY = y,
                        Position = d,
                        Commands = command
                    };
                    //Consider a Rover entry only if valid
                    if(NewRover.IsRoverValid())
                    {
                        Rovers.Add(NewRover);
                    }
                }
                foreach (var RoverObject in Rovers)
                {
                    RoverObject.ApplyCommands();
                    int x = RoverObject.PositionX;
                    int y = RoverObject.PositionY;
                    //Beyond permitted grids
                    if(x > MaximumX || y > MaximumY || x < 0 || y < 0)
                    {
                        Console.WriteLine("It's dangerous to float in vacuum. Come home ASAP!!");
                    }
                    else
                    {
                        Console.WriteLine(x + " " + y + " " + RoverObject.GetMyDirection());
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Invalid input. Process terminates here");
            }
            finally
            {
                Console.ReadLine();//Wait for user to view output and then exit
            }
        }
    }
}
