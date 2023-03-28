using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services.Instructions
{
	public interface Instruction
	{
		EInstruction Instruction { get; }

		Action<Robot> InstructionAction { get; }
	}
}

