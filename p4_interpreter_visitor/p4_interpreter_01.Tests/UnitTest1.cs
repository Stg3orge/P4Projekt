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
            int expected = 0;
            TestMethod1();
            object value = null;
            

            symboltable.AddToTable("Test", "test", null);


            //Act
            
            //Assert
            //Assert.AreEqual(expected, actual);
        }
        public void TestMethod1()
        {
            
            symboltable.OpenScope();
        }
    }
}
