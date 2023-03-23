using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services
{
    public class RobotInstructionsManagerService : IRobotInstructionsManagerService
    {
        //private readonly IRobotsConnector mRobotsConnector;

        public RobotInstructionsManagerService(/*IRobotsConnector robotsConnector*/)
        {
            //if (robotsConnector == null) throw new ArgumentException(nameof(robotsConnector));
            //mRobotsConnector = robotsConnector;
        }

        public void ProcessRobotInstructions(Robot robot, Surface surface)
        {
            foreach (var instructionChar in robot.instructions)
            {
                var previousX = robot.xCoordinate;
                var previousY = robot.yCoordinate;
                var instruction = Enum.Parse<Instruction>(char.ToString(instructionChar));

                if (RobotWasLostPreviously(robot, surface, instructionChar))
                {
                    continue;
                }

                InstructionActions.Dictionary[instruction].Invoke(robot);

                if (RobotHasBeenLost(robot, surface))
                {
                    robot.xCoordinate = previousX;
                    robot.yCoordinate = previousY;
                    robot.status = RobotStatus.LOST;

                    //AddLostRobotToSurface(robot, surface);

                    break;
                }
            }
        }

        private bool RobotWasLostPreviously(Robot robot, Surface surface, char instruction)
        {
            return surface.lostRobots.Any(
                    lostRobot =>
                        lostRobot.xCoordinate == robot.xCoordinate
                        && lostRobot.yCoordinate == robot.yCoordinate
                        && lostRobot.orientation == robot.orientation.ToString()
                        && lostRobot.failedInstruction == char.ToString(instruction));
        }

        private bool RobotHasBeenLost(Robot robot, Surface surface)
        {
            return robot.xCoordinate < 0
                    || robot.xCoordinate > surface.xSize
                    || robot.yCoordinate < 0
                    || robot.yCoordinate > surface.ySize;
        }
    }
}

