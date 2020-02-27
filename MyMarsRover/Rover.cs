using System;
using System.ComponentModel.DataAnnotations;

namespace MyMarsRover
{
    class Rover
    {
        [Required]
        [Range(0, Int32.MaxValue)]
        public int PositionX { get; set; }
        [Required]
        [Range(0, Int32.MaxValue)]
        public int PositionY { get; set; }
        [Required]
        public Direction Position { get; set; }
        [RegularExpression("^[LRM]*$")]
        public string Commands { get; set; }

        public bool IsRoverValid()
        {
            var context = new ValidationContext(this);
            var isValid = Validator.TryValidateObject(this, context, null, true);
            if (isValid)
            {
                isValid = Enum.IsDefined(typeof(Direction), Position);
            }
            return isValid;
        }
        private void TurnClockwise(bool clockwise)
        {
            if(clockwise)
            {
                if (Position != Direction.WEST)
                    Position++;
                else
                    Position = Direction.NORTH;
            }else
            {
                if (Position != Direction.NORTH)
                    Position--;
                else
                    Position = Direction.WEST;
            }
        }
        private void MoveForward()
        {
            switch(Position)
            {
                case Direction.NORTH:
                    PositionY++; break;
                case Direction.EAST:
                    PositionX++; break;
                case Direction.SOUTH:
                    PositionY--; break;
                case Direction.WEST:
                    PositionX--; break;
            }
        }

        public void ApplyCommands()
        {
            foreach (var command in Commands.ToCharArray())
            {
                switch(command)
                {
                    case 'L':
                        TurnClockwise(false); break;
                    case 'R':
                        TurnClockwise(true); break;
                    case 'M':
                        MoveForward(); break;
                }
            }
        }

        public char GetMyDirection()
        {
            return Position.ToString()[0];
        }
    }

    enum Direction
    {
        NORTH = 1,
        EAST = 2,
        SOUTH = 3,
        WEST = 4
    }
}
