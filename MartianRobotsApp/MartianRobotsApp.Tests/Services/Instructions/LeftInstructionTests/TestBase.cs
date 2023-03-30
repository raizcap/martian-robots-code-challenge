using System;
using MartianRobotsApp.Services.Instructions;

namespace MartianRobotsApp.Tests.Services.Instructions.LeftInstructionTests
{
	[TestClass]
	public abstract class TestBase
	{
		protected LeftInstruction TestObject;

		public TestBase()
		{
			TestObject = new LeftInstruction();
		}
	}
}

