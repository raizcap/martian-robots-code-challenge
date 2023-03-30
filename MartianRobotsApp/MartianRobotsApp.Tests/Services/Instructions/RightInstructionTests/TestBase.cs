using System;
using MartianRobotsApp.Services.Instructions;

namespace MartianRobotsApp.Tests.Services.Instructions.RightInstructionTests
{
	[TestClass]
	public abstract class TestBase
	{
		protected RightInstruction TestObject;

		public TestBase()
		{
			TestObject = new RightInstruction();
		}
	}
}

