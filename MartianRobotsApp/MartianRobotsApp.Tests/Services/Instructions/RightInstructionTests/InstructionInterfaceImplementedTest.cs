using System;
using MartianRobotsApp.Services.Instructions;

namespace MartianRobotsApp.Tests.Services.Instructions.RightInstructionTests
{
	[TestClass]
	public class InstructionInterfaceImplementedTest : TestBase
	{
		[TestMethod]
		public void WhenLeftInstructionObjectIsCreated_InstructionInterfaceIsImplemented()
		{
			Assert.IsTrue(TestObject is Instruction);
		}
	}
}

