using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public class ScopeCheckVisitor : IVisitor
    {
        public ScopeCheckVisitor() { }
        public void Visit(StartupStucture obj)
        {
            
        }
        public void Visit(BooleanExpression obj) { }
        public void Visit(BooleanValue obj) { }
        public void Visit(DeclaringParameters obj) { }
        public void Visit(MethodDeclaration obj) { }
        public void Visit(Operator obj) { }
        public void Visit(Prefix obj) { }
        public void Visit(ValueKeywords obj) { }
    }
}
