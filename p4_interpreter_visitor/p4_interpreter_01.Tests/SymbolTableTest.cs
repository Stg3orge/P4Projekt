using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Tests
{
    [TestClass]
    public class SymbolTableTest
    {
        [TestMethod]
        public void OpenScopeTesting()
        {
            //Arrange 
            SymbolTable symboltable = new SymbolTable();
            symboltable.AddToTable("global1", "Character", 0);
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
        }
    }
}
