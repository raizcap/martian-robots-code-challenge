using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Tests.Services.MarsSurfaceServiceTests
{
	[TestClass]
	public class GetResultsTests : TestBase
	{
		[TestMethod]
		public void WhenGetResultsIsCalled_CorrectInfoIsReturned()
		{
			(IEnumerable<Robot> robots1, string expectedResult1) = GetTestData1();
			(IEnumerable<Robot> robots2, string expectedResult2) = GetTestData2();

			robots1.ToList().ForEach(robot => TestObject.AddRobot(robot));

			var result1 = TestObject.GetResults();

			Assert.AreEqual(expectedResult1, result1);

			ResetTestObject();

            robots2.ToList().ForEach(robot => TestObject.AddRobot(robot));

            var result2 = TestObject.GetResults();

            Assert.AreEqual(expectedResult2, result2);
        }

		private (IEnumerable<Robot>, string) GetTestData1()
		{
			var robotsList = new List<Robot>();
			var robot = new Robot(1, 1, Orientation.N, "L");

			robot.status = RobotStatus.REACHABLE;
			robotsList.Add(robot);

			robot = new Robot(2, 2, Orientation.E, "R");
			robot.status = RobotStatus.REACHABLE;
            robotsList.Add(robot);

            robot = new Robot(3, 3, Orientation.W, "F");
			robot.status = RobotStatus.REACHABLE;
            robotsList.Add(robot);

			var expectedResult =
				"1 1 N" + Environment.NewLine +
				"2 2 E" + Environment.NewLine +
				"3 3 W" + Environment.NewLine;

			return (robotsList, expectedResult);
        }

		private (IEnumerable<Robot>, string) GetTestData2()
		{
            var robotsList = new List<Robot>();
            var robot = new Robot(3, 3, Orientation.E, "F");

            robot.status = RobotStatus.LOST;
            robotsList.Add(robot);

            robot = new Robot(4, 4, Orientation.S, "L");
            robot.status = RobotStatus.LOST;
            robotsList.Add(robot);

            robot = new Robot(5, 5, Orientation.N, "R");
            robot.status = RobotStatus.LOST;
            robotsList.Add(robot);

            var expectedResult =
                "3 3 E LOST" + Environment.NewLine +
                "4 4 S LOST" + Environment.NewLine +
                "5 5 N LOST" + Environment.NewLine;

			return (robotsList, expectedResult);
        }
	}
}

