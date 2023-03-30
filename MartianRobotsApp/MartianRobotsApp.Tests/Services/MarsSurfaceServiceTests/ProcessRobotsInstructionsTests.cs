using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.MarsSurfaceServiceTests
{
	[TestClass]
	public class ProcessRobotsInstructionsTests : TestBase
	{
		[TestMethod]
        public void WhenProcessRobotsInstructionsIsCalledAndRobotsListIsEmpty_RobotInstructionsManagerServiceProcessRobotInstructionsIsNotCalled()
		{
			TestObject.ProcessRobotsInstructions();

			mRobotInstructionsManagerService.DidNotReceive().ProcessRobotInstructions(Arg.Any<Robot>(), Arg.Any<Surface>());
        }

		[TestMethod]
		[DataRow(1)]
		[DataRow(5)]
		[DataRow(10)]
		[DataRow(20)]
		public void WhenProcessRobotsInstructionsIsCalledWithRobotsInTheList_RobotInstructionsManagerServiceProcessRobotInstructionsIsCalledNTimes(int robotsQty)
		{
			AddRobots(robotsQty);

			TestObject.ProcessRobotsInstructions();

            mRobotInstructionsManagerService.Received(robotsQty).ProcessRobotInstructions(Arg.Any<Robot>(), Arg.Any<Surface>());
        }

		private void AddRobots(int robotsQty)
		{
			for (int i = 1; i <= robotsQty; i++)
			{
				TestObject.AddRobot(GetNewRobot());
			}
		}

		private Robot GetNewRobot()
		{
			return new Robot(1, 1, Orientation.N, "LR");
		}
    }
}

