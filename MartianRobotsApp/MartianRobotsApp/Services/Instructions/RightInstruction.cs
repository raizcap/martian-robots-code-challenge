using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services.Instructions
{
	public class RightInstruction : IRightInstruction
	{
        public EInstruction Instruction => EInstruction.R;

        public Action<Robot> InstructionAction
        {
            get
            {
                return robot => ExecuteInstruction(robot);
            }
        }

        private void ExecuteInstruction(Robot robot)
        {
            robot.orientation = (Orientation)Enum.GetValues<Orientation>()
                .GetValue(((int)robot.orientation + 1) % Enum.GetValues<Orientation>().Length);
        }
    }
}

