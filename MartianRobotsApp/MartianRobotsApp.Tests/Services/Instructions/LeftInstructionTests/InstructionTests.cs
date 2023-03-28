using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Tests.Services.Instructions.LeftInstructionTests
{
	[TestClass]
	public class InstructionTests : TestBase
	{
        [TestMethod]
        public void WhenInstructionTypeIsGot_ItIsCorrect()
        {
            Assert.AreEqual(TestObject.Instruction, Models.EInstruction.L);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsNorth_RobotRotatesToWest()
        {
            var robotNorth = GetRobotWithOrientation(Orientation.N);

            TestObject.InstructionAction.Invoke(robotNorth);

            Assert.IsTrue(robotNorth.orientation == Orientation.W);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsWest_RobotRotatesToSouth()
        {
            var robotWest = GetRobotWithOrientation(Orientation.W);

            TestObject.InstructionAction.Invoke(robotWest);

            Assert.IsTrue(robotWest.orientation == Orientation.S);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsSouth_RobotRotatesToEast()
        {
            var robotSouth = GetRobotWithOrientation(Orientation.S);

            TestObject.InstructionAction.Invoke(robotSouth);

            Assert.IsTrue(robotSouth.orientation == Orientation.E);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsEast_RobotMovesToNorth()
        {
            var robotEast = GetRobotWithOrientation(Orientation.E);

            TestObject.InstructionAction.Invoke(robotEast);

            Assert.IsTrue(robotEast.orientation == Orientation.N);
        }

        private Robot GetRobotWithOrientation(Orientation orientation)
        {
            // Instructions are not important for these tests, that's why it is an empty string
            return new Robot(1, 1, orientation, "");
        }
    }
}

