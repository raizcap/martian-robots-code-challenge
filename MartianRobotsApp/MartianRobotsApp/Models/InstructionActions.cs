using System;
namespace MartianRobotsApp.Models
{
    public static class InstructionActions
    {
        private const int ORIENTATIONS_QUANTITY = 4;

        public static Dictionary<Instruction, Action<Robot>> Dictionary
            = new Dictionary<Instruction, Action<Robot>>()
            {
                {
                    Instruction.L,
                    (Robot robot) =>
                    {
                        robot.orientation = (Orientation)Enum.GetValues<Orientation>()
                                            .GetValue(((int)robot.orientation - 1) % Enum.GetValues<Orientation>().Length);
                    }
                },
                {
                    Instruction.R,
                    (Robot robot) =>
                    {
                        robot.orientation = (Orientation)Enum.GetValues<Orientation>()
                                            .GetValue(((int)robot.orientation + 1) % Enum.GetValues<Orientation>().Length);
                    }
                },
                {
                    Instruction.F,
                    (Robot robot) =>
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
                },
            };
    }
}

