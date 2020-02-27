using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyMarsRover.UnitTests
{
    [TestFixture]
    class RoverTests
    {
        [Test]
        public void IsRoverValid_NegativePos_ReturnsFalse()
        {
            Rover rover = new Rover()
            {
                PositionX = -1,
                PositionY = -1
            };
            bool isValid = rover.IsRoverValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsRoverValid_ZeroEnum_ReturnsFalse()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = (Direction)Enum.Parse(typeof(Direction), 0 + "")
            };
            bool isValid = rover.IsRoverValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsRoverValid_InvalidEnum_ReturnsFalse([Range(5,10)] int d)
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = (Direction)Enum.Parse(typeof(Direction), d + "")
            };
            bool isValid = rover.IsRoverValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsRoverValid_InvalidCommand_ReturnsFalse()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = Direction.NORTH,
                Commands = "QTYU"
            };
            bool isValid = rover.IsRoverValid();
            Assert.IsFalse(isValid);
        }
        [Test]
        public void IsRoverValid_ValidRover_ReturnsTrue()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = Direction.NORTH,
                Commands = "RMLM"
            };
            bool isValid = rover.IsRoverValid();
            Assert.IsTrue(isValid);
        }
        [Test]
        public void TurnClockwise_North_ReturnsEast()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = Direction.NORTH,
                Commands = "R"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.Position, Direction.EAST);
        }
        [Test]
        public void TurnClockwise_West_ReturnsNorth()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = Direction.WEST,
                Commands = "R"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.Position, Direction.NORTH);
        }
        [Test]
        public void AntiTurnClockwise_West_ReturnsSouth()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = Direction.WEST,
                Commands = "L"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.Position, Direction.SOUTH);
        }
        [Test]
        public void AntiTurnClockwise_North_ReturnsWest()
        {
            Rover rover = new Rover()
            {
                PositionX = 1,
                PositionY = 1,
                Position = Direction.NORTH,
                Commands = "L"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.Position, Direction.WEST);
        }
        [Test]
        public void MoveForward_North_ReturnsY1()
        {
            Rover rover = new Rover()
            {
                Position = Direction.NORTH,
                Commands = "M"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.PositionY, 1);
        }
        [Test]
        public void MoveForward_South_ReturnsYMinus1()
        {
            Rover rover = new Rover()
            {
                Position = Direction.SOUTH,
                Commands = "M"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.PositionY, -1);
        }
        [Test]
        public void MoveForward_West_ReturnsXMinus1()
        {
            Rover rover = new Rover()
            {
                Position = Direction.WEST,
                Commands = "M"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.PositionX, -1);
        }
        [Test]
        public void MoveForward_East_ReturnsX1()
        {
            Rover rover = new Rover()
            {
                Position = Direction.EAST,
                Commands = "M"
            };
            rover.ApplyCommands();
            Assert.AreEqual(rover.PositionX, 1);
        }
    }
}
