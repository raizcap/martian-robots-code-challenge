using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.RobotInstructionsManagerServiceTests
{
    [TestClass]
    public class ProcessRobotsInstructionsTests : TestBase
    {
        [TestMethod]
        public void WhenRobotInstructionsIsEmpty_NoInstructionActionIsGot()
        {
            var robot = GetRobotWithoutInstructions();
            var surface = GetSurfaceWithoutLostRobots();

            TestObject.ProcessRobotInstructions(robot, surface);

            mInstructionsService.DidNotReceive().GetActionForInstruction(Arg.Any<EInstruction>());
        }

        [TestMethod]
        public void WhenRobotInstructionsIsNotEmptyAndThereAreNotLostRobots_InstructionsServiceGetActionForInstructionIsCalledNTimes()
        {
            var robot = GetRobotWithInstructions();
            var surface = GetSurfaceWithoutLostRobots();

            TestObject.ProcessRobotInstructions(robot, surface);

            mInstructionsService.Received(robot.instructions.Length).GetActionForInstruction(Arg.Any<EInstruction>());
        }

        [TestMethod]
        public void WhenRobotInstructionsIsNotEmptyAndSomeRobotsWereLostPreviously_InstructionsServiceGetActionForInstructionIsCalledNTimesMinusLostRobots()
        {
            var robot = GetRobotWithInstructions();
            var surface = GetSurfaceWithLostRobots();
            mInstructionsService.GetActionForInstruction(Arg.Any<EInstruction>())
                .Returns<Action<Robot>>(robot => robot.yCoordinate++);

            TestObject.ProcessRobotInstructions(robot, surface);

            // Count - 1 because only the first instruction with
            // the starting coordinates is included in the lost robots list
            mInstructionsService.Received(surface.lostRobots.Count - 1).GetActionForInstruction(Arg.Any<EInstruction>());
        }

        [TestMethod]
        public void WhenRobotHasBeenLostDueToNegativeXCoordinate_RobotsConnectorAddLostRobotToSurfaceIsCalled()
        {
            var robot = GetRobotWithInstructions();
            var surface = GetSurfaceWithLostRobots();
            mInstructionsService.GetActionForInstruction(Arg.Any<EInstruction>())
                .Returns<Action<Robot>>(robot => robot.xCoordinate = -1);

            TestObject.ProcessRobotInstructions(robot, surface);

            mRobotsConnector.Received().AddLostRobotToSurface(Arg.Any<LostRobot>());
        }

        [TestMethod]
        public void WhenRobotHasBeenLostDueToNegativeYCoordinate_RobotsConnectorAddLostRobotToSurfaceIsCalled()
        {
            var robot = GetRobotWithInstructions();
            var surface = GetSurfaceWithLostRobots();
            mInstructionsService.GetActionForInstruction(Arg.Any<EInstruction>())
                .Returns<Action<Robot>>(robot => robot.yCoordinate = -1);

            TestObject.ProcessRobotInstructions(robot, surface);

            mRobotsConnector.Received().AddLostRobotToSurface(Arg.Any<LostRobot>());
        }

        [TestMethod]
        public void WhenRobotHasBeenLostDueToXCoordinateGreaterThanSurfaceXSize_RobotsConnectorAddLostRobotToSurfaceIsCalled()
        {
            var robot = GetRobotWithInstructions();
            var surface = GetSurfaceWithLostRobots();
            mInstructionsService.GetActionForInstruction(Arg.Any<EInstruction>())
                .Returns<Action<Robot>>(robot => robot.xCoordinate = surface.xSize + 1);

            TestObject.ProcessRobotInstructions(robot, surface);

            mRobotsConnector.Received().AddLostRobotToSurface(Arg.Any<LostRobot>());
        }

        [TestMethod]
        public void WhenRobotHasBeenLostDueToXCoordinateGreaterThanSurfaceYSize_RobotsConnectorAddLostRobotToSurfaceIsCalled()
        {
            var robot = GetRobotWithInstructions();
            var surface = GetSurfaceWithLostRobots();
            mInstructionsService.GetActionForInstruction(Arg.Any<EInstruction>())
                .Returns<Action<Robot>>(robot => robot.yCoordinate = surface.ySize + 1);

            TestObject.ProcessRobotInstructions(robot, surface);

            mRobotsConnector.Received().AddLostRobotToSurface(Arg.Any<LostRobot>());
        }

        private Robot GetRobotWithoutInstructions()
        {
            return new Robot(1, 1, Orientation.N, "");
        }

        private Robot GetRobotWithInstructions()
        {
            // The first instruction is included in the lost robots list
            return new Robot(1, 1, Orientation.N, "FRF");
        }

        private Surface GetSurfaceWithoutLostRobots()
        {
            return new Surface(1, 5, 5);
        }

        private Surface GetSurfaceWithLostRobots()
        {
            var lostRobots = new List<LostRobot>() {
                new LostRobot()
                {
                    id = 1,
                    xCoordinate = 1,
                    yCoordinate = 1,
                    failedInstruction = "F",
                    orientation = "N",
                    surfaceId = 1
                },
                new LostRobot()
                {
                    id = 2,
                    xCoordinate = 2,
                    yCoordinate = 2,
                    failedInstruction = "F",
                    orientation = "E",
                    surfaceId = 1
                },
                new LostRobot()
                {
                    id = 3,
                    xCoordinate = 3,
                    yCoordinate = 3,
                    failedInstruction = "F",
                    orientation = "S",
                    surfaceId = 1
                }
            };

            return new Surface(1, 5, 5, lostRobots);
        }
    }
}

