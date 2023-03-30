using System;
using MartianRobotsApp.Services.Instructions;

namespace MartianRobotsApp.Tests.Services.Instructions.ForwardInstructionTests
{
	[TestClass]
	public abstract class TestBase
	{
		protected ForwardInstruction TestObject;

		public TestBase()
		{
			TestObject = new ForwardInstruction();
		}
	}
}

