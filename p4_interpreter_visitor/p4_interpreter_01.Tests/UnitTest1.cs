using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace p4_interpreter_01.Tests
{
    [TestClass]
    public class UnitTest1
    {
        SymbolTable symboltable = new SymbolTable();
        [TestMethod]
        public void OpenScopeTesting()
        {
            //Arrange 
            symboltable.AddToTable("global1", "integer", 0);
            symboltable.AddToTable("global2", "integer", 0);
            symboltable.OpenScope();
            symboltable.AddToTable("metode1", "integer", 0);
            symboltable.OpenScope();
            symboltable.AddToTable("metode2", "integer", 0);
            
            //Act

            //Assert
            Assert.AreEqual(false, symboltable.ContainsName("metode1"));
            //assert at global1, global2, metode2 kan findes
            //assert at global1, global2 har scope == 0
            //assert at metode2 har scope == 2
        }
        public void TestMethod1()
        {
            
            symboltable.OpenScope();
        }
    }
}
