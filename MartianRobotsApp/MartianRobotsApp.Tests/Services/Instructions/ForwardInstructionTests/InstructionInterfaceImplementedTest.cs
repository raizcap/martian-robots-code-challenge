using System;
using MartianRobotsApp.Services.Instructions;

namespace MartianRobotsApp.Tests.Services.Instructions.ForwardInstructionTests
{
	[TestClass]
	public class InstructionInterfaceImplementedTest : TestBase
	{
		[TestMethod]
		public void WhenForwardInstructionObjectIsCreated_InstructionInterfaceIsImplemented()
		{
			Assert.IsTrue(TestObject is Instruction);
		}
	}
}

