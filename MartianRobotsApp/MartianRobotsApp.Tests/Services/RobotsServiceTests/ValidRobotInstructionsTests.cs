using System;
using System.Diagnostics.Metrics;
using MartianRobotsApp.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.RobotsServiceTests
{
    [TestClass]
	public class ValidRobotInstructionsTests : TestBase
	{
        protected Surface mSurface = new Surface(1, 5, 5);

        [TestMethod]
        public void WhenRobotInstructionsAreValid_ExitIsFalseAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithValidContent();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsFalse(result.Exit);
            Assert.AreEqual(
                ErrorMessages.NO_ERROR,
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInstructionsAreValid_MarsSurfaceServiceAddRobotIsCalled()
        {
            var robotInstructions = GetRobotsInstructionsWithValidContent();

            TestObject.LoadRobots(robotInstructions);

            mMarsSurfaceService.Received().AddRobot(Arg.Any<Robot>());
        }

        protected override void OnInit()
        {
            mMarsSurfaceService.GetSurfaceSize().Returns((mSurface.xSize, mSurface.ySize));
            mInstructionsService.InstructionExists(Arg.Any<char>()).Returns(false);
            mInstructionsService.InstructionExists('L').Returns(true);
            mInstructionsService.InstructionExists('R').Returns(true);
            mInstructionsService.InstructionExists('F').Returns(true);
        }

        private ICollection<string> GetRobotsInstructionsWithValidContent()
        {
            return new List<string>()
            {
                "1 1 N",
                "RLFLRFLFFRFR"
            };
        }
    }
}

