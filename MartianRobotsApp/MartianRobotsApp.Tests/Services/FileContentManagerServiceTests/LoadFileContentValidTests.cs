using System;
using MartianRobotsApp.Models;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.FileContentManagerServiceTests
{
	[TestClass]
	public class LoadFileContentValidTests : TestBase
	{
        private string mFilePath = "test.txt";

        [TestMethod]
        public void WhenLoadFileContentIsCalledWithValidSurface_MarsSurfaceServiceCreateMarsSurfaceIsCalled()
        {
            var result = TestObject.LoadFileContent(mFilePath);

            mMarsSurfaceService.Received().CreateMarsSurface(5, 3);
        }

        [TestMethod]
        public void WhenLoadFileContentIsCalledWithValidSurface_ExitIsFalseAndNoErrorMessageIsReturned()
        {
            var result = TestObject.LoadFileContent(mFilePath);

            Assert.IsFalse(result.Exit);
            Assert.AreEqual(ErrorMessages.NO_ERROR, result.Message);
        }

        [TestMethod]
        public void WhenLoadFileContentIsCalledWithValidSurface_RobotsServiceLoadRobotsIsCalled()
        {
            var fileContentLines = GetValidFileContent();
            fileContentLines = fileContentLines.Where(line => line.Length > 0).ToList();
            var desiredLines = new Range(1, fileContentLines.ToList().Count);
            var robotsLines = fileContentLines.Take(desiredLines).ToList();

            TestObject.LoadFileContent(mFilePath);

            mRobotsService.Received().LoadRobots(
                Arg.Is<ICollection<string>>(
                    lines => Enumerable.SequenceEqual(lines, robotsLines)
                )
            );
        }

        public override void OnInit()
        {
            mFileReaderService.ReadAllLines(mFilePath).Returns(GetValidFileContent());
        }

        private IEnumerable<string> GetValidFileContent()
        {
            return new string[]{
                "5 3",
                "1 1 E",
                "RFRFRFRF",
                "3 2 N",
                "FRRFLLFFRRFLL",
                "0 3 W",
                "LLFFFRFLFL"
            };
        }
    }
}

