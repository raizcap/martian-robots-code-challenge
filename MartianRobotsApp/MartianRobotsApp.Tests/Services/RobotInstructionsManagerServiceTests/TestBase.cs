using System;
using MartianRobotsApp.Communication;
using MartianRobotsApp.Services;
using MartianRobotsApp.Services.Instructions;
using NSubstitute;

namespace MartianRobotsApp.Tests.Services.RobotInstructionsManagerServiceTests
{
    [TestClass]
    public class TestBase
    {
        protected IRobotInstructionsManagerService TestObject;
        protected IRobotsConnector mRobotsConnector;
        protected IInstructionsService mInstructionsService;

        public TestBase()
        {
            mRobotsConnector = Substitute.For<IRobotsConnector>();
            mInstructionsService = Substitute.For<IInstructionsService>();

            TestObject = new RobotInstructionsManagerService(mRobotsConnector, mInstructionsService);
        }
    }
}

