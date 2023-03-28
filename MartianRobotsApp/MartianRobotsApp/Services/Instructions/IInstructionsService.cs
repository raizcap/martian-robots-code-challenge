using MartianRobotsApp.Models;

namespace MartianRobotsApp.Services.Instructions
{
    public interface IInstructionsService
    {
        Action<Robot> GetActionForInstruction(EInstruction instruction);

        void RegisterInstructionAction(EInstruction instruction, Action<Robot> action);

        bool InstructionExists(char instructionChar);
    }
}