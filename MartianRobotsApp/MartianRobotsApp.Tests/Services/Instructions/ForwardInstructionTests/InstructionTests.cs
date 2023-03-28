using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Tests.Services.Instructions.ForwardInstructionTests
{
	[TestClass]
	public class InstructionTests : TestBase
	{
		[TestMethod]
		public void WhenInstructionTypeIsGot_ItIsCorrect()
		{
			Assert.AreEqual(TestObject.Instruction, Models.EInstruction.F);
		}

		[TestMethod]
		public void WhenInstructionIsInvokedAndRobotOrientationIsNorth_RobotMovesToNorth()
		{
			var robotNorth = GetRobotWithOrientation(Orientation.N);

			TestObject.InstructionAction.Invoke(robotNorth);

			Assert.IsTrue(robotNorth.xCoordinate == 1 && robotNorth.yCoordinate == 2);
		}

		[TestMethod]
		public void WhenInstructionIsInvokedAndRobotOrientationIsEast_RobotMovesToEast()
		{
			var robotEast = GetRobotWithOrientation(Orientation.E);

			TestObject.InstructionAction.Invoke(robotEast);

			Assert.IsTrue(robotEast.xCoordinate == 2 && robotEast.yCoordinate == 1);
		}

		[TestMethod]
		public void WhenInstructionIsInvokedAndRobotOrientationIsSouth_RobotMovesToSouth()
		{
			var robotSouth = GetRobotWithOrientation(Orientation.S);

			TestObject.InstructionAction.Invoke(robotSouth);

			Assert.IsTrue(robotSouth.xCoordinate == 1 && robotSouth.yCoordinate == 0);
		}

		[TestMethod]
		public void WhenInstructionIsInvokedAndRobotOrientationIsWest_RobotMovesToWest()
		{
			var robotWest = GetRobotWithOrientation(Orientation.W);

			TestObject.InstructionAction.Invoke(robotWest);

			Assert.IsTrue(robotWest.xCoordinate == 0 && robotWest.yCoordinate == 1);
		}

		private Robot GetRobotWithOrientation(Orientation orientation)
		{
            // Instructions are not important for these tests, that's why it is an empty string
            return new Robot(1, 1, orientation, "");
        }
	}
}

