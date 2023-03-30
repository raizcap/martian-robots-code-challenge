using System;
using MartianRobotsApp.Models;

namespace MartianRobotsApp.Tests.Services.FileCheckerServiceTests
{
	[TestClass]
	public class CheckFileNameTests : TestBase
	{
		[TestMethod]
		public void WhenPathDoesntExist_ExitTrueAndInvalidPathMessageIsReturned()
		{
			var path = "C://blablabla.txt";

			var result = TestObject.CheckFileName(path);

			Assert.IsTrue(result.Exit);
			Assert.AreEqual(ErrorMessages.INVALID_PATH, result.Message);
		}

        [TestMethod]
        public void WhenDirectoryDoesntExist_ExitTrueAndInvalidPathMessageIsReturned()
        {
            var path = "./blablabla/bla.txt";

            var result = TestObject.CheckFileName(path);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(ErrorMessages.INVALID_PATH, result.Message);
        }
    }
}

