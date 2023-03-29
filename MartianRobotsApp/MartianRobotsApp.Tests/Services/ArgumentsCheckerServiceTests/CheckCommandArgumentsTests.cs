using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Tests.Services.ArgumentsCheckerServiceTests
{
	[TestClass]
	public class CheckCommandArgumentsTests : TestBase
	{
		[TestMethod]
		public void WhenArgsLengthIsZero_ExitIsTrueAndNoFileProvidedMessageIsReturned()
		{
			var args = new string[0];

			var result = TestObject.CheckCommandArguments(args);

			Assert.IsTrue(result.Exit);
			Assert.AreEqual(result.Message, ErrorMessages.NO_FILE_PROVIDED);
		}

		[TestMethod]
		public void WhenArgsLengthIsGreaterThanOne_ExitIsTrueAndInvalidArgumentMessageIsReturned()
		{
			var args = new string[2];
			var errorMessage = string.Format(ErrorMessages.INVALID_ARGUMENT, args[1]);

			var result = TestObject.CheckCommandArguments(args);

			Assert.IsTrue(result.Exit);
			Assert.AreEqual(result.Message, errorMessage);
		}

		[TestMethod]
		public void WhenArgsLengthIsOne_ExitIsFalseAndNoErrorMessageIsReturned()
		{
			var args = new string[1];

			var result = TestObject.CheckCommandArguments(args);

			Assert.IsFalse(result.Exit);
			Assert.AreEqual(result.Message, ErrorMessages.NO_ERROR);
		}
	}
}

