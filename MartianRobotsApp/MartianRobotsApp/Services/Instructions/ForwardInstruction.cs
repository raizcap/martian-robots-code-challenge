using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services.Instructions
{
	public class ForwardInstruction : IForwardInstruction
	{
		public EInstruction Instruction => EInstruction.F;

		public Action<Robot> InstructionAction
        {
            get
            {
                return robot => ExecuteInstruction(robot);
            }
        }

        private void ExecuteInstruction(Robot robot)
		{
            switch (robot.orientation)
            {
                case (Orientation.N):
                    robot.yCoordinate += 1;
                    break;
                case (Orientation.E):
                    robot.xCoordinate += 1;
                    break;
                case (Orientation.S):
                    robot.yCoordinate -= 1;
                    break;
                case (Orientation.W):
                    robot.xCoordinate -= 1;
                    break;
                default:
                    break;
            }
        }
    }
}

