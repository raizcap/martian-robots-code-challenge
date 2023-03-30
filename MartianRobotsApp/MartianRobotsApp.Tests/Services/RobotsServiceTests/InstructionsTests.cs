using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.RobotsServiceTests
{
	[TestClass]
	public class InstructionsTests : TestBase
	{
        protected Surface mSurface = new Surface(1, 5, 5);

        [TestMethod]
        public void WhenInstructionsLineIsGreaterThan99Characters_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithMoreThan99Characters();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.TOO_MUCH_LONG_INSTRUCTIONS, 1, robotInstructions.ElementAt(1)),
                result.Message);
        }

        [TestMethod]
        public void WhenInstructionsLineContainsANonExistingInstruction_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithANonExistingInstruction();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.INVALID_ROBOT_INSTRUCTIONS, 1, robotInstructions.ElementAt(1)),
                result.Message);
        }

        protected override void OnInit()
        {
            mMarsSurfaceService.GetSurfaceSize().Returns((mSurface.xSize, mSurface.ySize));
            mInstructionsService.InstructionExists(Arg.Any<char>()).Returns(false);
            mInstructionsService.InstructionExists('L').Returns(true);
            mInstructionsService.InstructionExists('R').Returns(true);
            mInstructionsService.InstructionExists('F').Returns(true);
        }

        private ICollection<string> GetRobotsInstructionsWithMoreThan99Characters()
        {
            return new List<string>()
            {
                "1 1 N",
                "FFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFFF"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithANonExistingInstruction()
        {
            return new List<string>()
            {
                "1 1 N",
                "RLFLRFALFFRFR"
            };
        }
    }
}

