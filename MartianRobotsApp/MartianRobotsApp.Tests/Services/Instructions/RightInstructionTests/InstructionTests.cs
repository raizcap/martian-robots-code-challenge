using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Tests.Services.Instructions.RightInstructionTests
{
	[TestClass]
	public class InstructionTests : TestBase
	{
        [TestMethod]
        public void WhenInstructionTypeIsGot_ItIsCorrect()
        {
            Assert.AreEqual(TestObject.Instruction, Models.EInstruction.R);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsNorth_RobotRotatesToEast()
        {
            var robotNorth = GetRobotWithOrientation(Orientation.N);

            TestObject.InstructionAction.Invoke(robotNorth);

            Assert.IsTrue(robotNorth.orientation == Orientation.E);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsWest_RobotRotatesToNorth()
        {
            var robotWest = GetRobotWithOrientation(Orientation.W);

            TestObject.InstructionAction.Invoke(robotWest);

            Assert.IsTrue(robotWest.orientation == Orientation.N);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsSouth_RobotRotatesToWest()
        {
            var robotSouth = GetRobotWithOrientation(Orientation.S);

            TestObject.InstructionAction.Invoke(robotSouth);

            Assert.IsTrue(robotSouth.orientation == Orientation.W);
        }

        [TestMethod]
        public void WhenInstructionIsInvokedAndRobotOrientationIsEast_RobotMovesToSouth()
        {
            var robotEast = GetRobotWithOrientation(Orientation.E);

            TestObject.InstructionAction.Invoke(robotEast);

            Assert.IsTrue(robotEast.orientation == Orientation.S);
        }

        private Robot GetRobotWithOrientation(Orientation orientation)
        {
            // Instructions are not important for these tests, that's why it is an empty string
            return new Robot(1, 1, orientation, "");
        }
    }
}

