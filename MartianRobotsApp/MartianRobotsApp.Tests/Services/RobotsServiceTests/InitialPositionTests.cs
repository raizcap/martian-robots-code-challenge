using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.RobotsServiceTests
{
    [TestClass]
    public class InitialPositionTests : TestBase
    {
        protected Surface mSurface = new Surface(1, 5, 5);

        [TestMethod]
        public void WhenRobotInitialPositionFormatIsNotValid_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionFormat();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(
                    ErrorMessages.INVALID_ROBOT_COORDINATES_FORMAT,
                    1,
                    robotInstructions.ElementAt(0)),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidXLesserThanZero_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionXLesserThanZero();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.INVALID_ROBOT_COORDINATES, 1, -1, 1),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidXGreaterThan50_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionXGreaterThan50();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.INVALID_ROBOT_COORDINATES, 1, 51, 1),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidYLesserThanZero_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionYLesserThanZero();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.INVALID_ROBOT_COORDINATES_FORMAT, 1, robotInstructions.ElementAt(0)),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidYGreaterThan50_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionYGreaterThan50();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.INVALID_ROBOT_COORDINATES, 1, 1, 51),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidXGreaterThanSurfaceXSize_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionXGreaterThanSurfaceX();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.ROBOT_COORDINATES_OUT_OF_BOUNDS, 1, mSurface.xSize + 1, 1),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidYGreaterThanSurfaceYSize_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionYGreaterThanSurfaceY();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.ROBOT_COORDINATES_OUT_OF_BOUNDS, 1, 1, mSurface.xSize + 1),
                result.Message);
        }

        [TestMethod]
        public void WhenRobotInitialPositionValuesAreNotValidOrientationNotExisting_ExitIsTrueAndCorrectMessageIsReturned()
        {
            var robotInstructions = GetRobotsInstructionsWithNotValidInitialPositionOrientationNotExisting();

            var result = TestObject.LoadRobots(robotInstructions);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(
                string.Format(ErrorMessages.INVALID_ROBOT_ORIENTATION, 1, "Z"),
                result.Message);
        }

        protected override void OnInit()
        {
            mMarsSurfaceService.GetSurfaceSize().Returns((mSurface.xSize, mSurface.ySize));
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionFormat()
        {
            return new List<string>()
            {
                "a b N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionValues()
        {
            return new List<string>()
            {
                "a b N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionXLesserThanZero()
        {
            return new List<string>()
            {
                "-1 1 N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionXGreaterThan50()
        {
            return new List<string>()
            {
                "51 1 N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionYLesserThanZero()
        {
            return new List<string>()
            {
                "1 -1 N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionYGreaterThan50()
        {
            return new List<string>()
            {
                "1 51 N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionXGreaterThanSurfaceX()
        {
            return new List<string>()
            {
                $"{mSurface.xSize + 1} 1 N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionYGreaterThanSurfaceY()
        {
            return new List<string>()
            {
                $"1 {mSurface.ySize + 1} N",
                "FLRLFRRR"
            };
        }

        private ICollection<string> GetRobotsInstructionsWithNotValidInitialPositionOrientationNotExisting()
        {
            return new List<string>()
            {
                $"1 1 Z",
                "FLRLFRRR"
            };
        }
    }
}

