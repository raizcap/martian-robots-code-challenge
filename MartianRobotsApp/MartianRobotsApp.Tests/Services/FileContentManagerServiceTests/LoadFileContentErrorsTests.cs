using System;
using MartianRobotsApp.Models;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.FileContentManagerServiceTests
{
    [TestClass]
	public class LoadFileContentErrorsTests : TestBase
	{
        private string mFilePath = "test.txt";

        [TestMethod]
        public void WhenFilePathIsNull_ExitIsTrueAndErrorLoadingContentMessageIsReturned()
        {
            string filePath = null;

            var result = TestObject.LoadFileContent(filePath);

            Assert.IsTrue(result.Exit);
            Assert.IsTrue(result.Message.Contains(nameof(ArgumentNullException)));
        }

        [TestMethod]
        public void WhenLoadFileContentIsCalledWithInvalidSurface_ExitIsTrueAndCorrectMessageIsReturned()
        {
            mFileReaderService.ReadAllLines(mFilePath).Returns(GetInvalidSurfaceContent());

            var result = TestObject.LoadFileContent(mFilePath);

            Assert.IsTrue(result.Exit);
            Assert.AreEqual(ErrorMessages.INVALID_SURFACE_SIZE_LINE, result.Message);
        }

        

        public override void OnInit()
        {
            mFileReaderService.When(service => service.ReadAllLines(null))
                .Do(callInfo =>
                    throw new ArgumentNullException("path")
                );
        }

        private IEnumerable<string> GetInvalidSurfaceContent()
        {
            return new string[]{
                "",
                "1 1 E",
                "RFRFRFRF"
            };
        }
    }
}

