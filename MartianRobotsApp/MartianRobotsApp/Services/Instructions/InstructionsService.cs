using System;
using System.Diagnostics.Metrics;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services.Instructions
{
    public class InstructionsService : IInstructionsService
    {
        private Dictionary<EInstruction, Action<Robot>> Dictionary;

        public InstructionsService(
            IForwardInstruction forwardInstruction,
            ILeftInstruction leftInstruction,
            IRightInstruction rightInstruction)
        {
            Dictionary = new Dictionary<EInstruction, Action<Robot>>();

            Dictionary.Add(forwardInstruction.Instruction, forwardInstruction.InstructionAction);
            Dictionary.Add(leftInstruction.Instruction, leftInstruction.InstructionAction);
            Dictionary.Add(rightInstruction.Instruction, rightInstruction.InstructionAction);
        }

        public void RegisterInstructionAction(EInstruction instruction, Action<Robot> action)
        {
            Dictionary.Add(instruction, action);
        }

        public Action<Robot> GetActionForInstruction(EInstruction instruction)
        {
            return Dictionary[instruction];
        }

        public bool InstructionExists(char instructionChar)
        {
            return Dictionary.ContainsKey(Enum.Parse<EInstruction>(char.ToString(instructionChar)));
        }
    }
}

