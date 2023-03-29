using System;
namespace MartianRobotsApp.Tests.Services.FileCheckerServiceTests
{
	[TestClass]
	public class GetValidPathTests : TestBase
	{
		[TestMethod]
		public void WhenPathStartsWithUserFolderShortcutAndUsername_ItIsReplacedByCompleteFolder()
		{
            var pathToFile = "/example/aaa.txt";
            var path = "~" + Environment.UserName + pathToFile;
            var expected = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + pathToFile;

            var validPath = TestObject.GetValidPath(path);

            Assert.AreEqual(validPath, expected);
        }

		[TestMethod]
		public void WhenPathStartsWithUserFolderShortcut_ItIsReplacedByCompleteFolder()
		{
			var pathToFile = "/example/aaa.txt";
			var path = "~" + pathToFile;
			var expected = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + pathToFile;

            var validPath = TestObject.GetValidPath(path);

			Assert.AreEqual(validPath, expected);
		}

		[TestMethod]
		public void WhenPathContainsDoubleSlashes_TheyAreReplacedBySingleSlashes()
		{
			var path = "//example//aaa.txt";
			var expected = "/example/aaa.txt";

            var validPath = TestObject.GetValidPath(path);

			Assert.AreEqual(validPath, expected);
		}

		[TestMethod]
		public void WhenPathContainsDoubleInvertedSlashes_TheyAreReplacedBySingleInvertedSlashes()
		{
			var path = @"C:\\example\\aaa.txt";
			var expected = @"C:\example\aaa.txt";

            var validPath = TestObject.GetValidPath(path);

			Assert.AreEqual(validPath, expected);
		}
	}
}

