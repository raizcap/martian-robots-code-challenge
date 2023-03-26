using System;
namespace MartianRobotsApp.Models
{
	public static class ErrorMessages
	{
		// It's funny but no error can be an error message :)
		public const string NO_ERROR = "";

		// File related messages
		public const string NO_FILE_PROVIDED = "Please, provide a valid file";
		public const string FILE_DOESNT_EXIST = "The provided file doesn't exist";
		public const string INVALID_HOME_PATH = "Please, provide a relative or absolute path, but not a path starting with home directory (~)";

		// Arguments related messages
		public const string INVALID_ARGUMENT = "Invalid argument '{0}'";

        // File content format related messages
        public const string INVALID_SURFACE_SIZE_LINE = "The file has an invalid surface size line";
        public const string INVALID_SURFACE_SIZE = "The surface has an invalid size '{0}'";
		public const string INVALID_ROBOT_COORDINATES_FORMAT = "The robot {0} has invalid starting coordinates format ({1})";
		public const string INVALID_ROBOT_COORDINATES = "The robot {0} has invalid starting coordinates (x={1} y={2})";
		public const string ROBOT_COORDINATES_OUT_OF_BOUNDS = "Robot {0} coordinates are out of bounds (x={1} y={2})";
		public const string INVALID_ROBOT_ORIENTATION = "The robot {0} has an invalid starting orientation ({1})";
		public const string INVALID_ROBOT_INSTRUCTIONS = "The robot {0} has an invalid instructions string ({1})";
        public const string TOO_MUCH_LONG_INSTRUCTIONS = "The robot {0} has too much long instructions string -max. 99 characters- ({1})";
		public const string ERROR_LOADING_CONTENT = "Error loading the file content: [{0}] {1}";
    }
}

