using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services.Instructions
{
	public class LeftInstruction : ILeftInstruction
	{
		public EInstruction Instruction => EInstruction.L;

        public Action<Robot> InstructionAction
		{
			get
			{
				return robot => ExecuteInstruction(robot);
            }
		}

        private void ExecuteInstruction(Robot robot)
        {
            var newElementIndex = ((int)robot.orientation - 1) % Enum.GetValues<Orientation>().Length;
            if (newElementIndex < 0) newElementIndex += Enum.GetValues<Orientation>().Length;

            robot.orientation = (Orientation)Enum.GetValues<Orientation>().
                    GetValue(newElementIndex);
        }
    }
}

