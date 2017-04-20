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

        List<SyntaxNode> NodeList = new List<SyntaxNode>();

        public SyntaxNode Visit(SyntaxNode node)
        {
            return node;
        }





        public void Visit(StartupStucture obj)
        {
            obj.Declarations.Accept(this);
            obj.Commands.Accept(this);
            obj.Commands2.Accept(this);
            obj.Declarations2.Accept(this);
            obj.Declarations3.Accept(this);
            obj.DeclaringParameters.Accept(this);
            obj.DeclaringParameters2.Accept(this);



            NodeList = obj.Commands.ReturnNodes(obj.Commands.NodeType);

            if (obj.Commands.NodeType == "<Declaration> ';' <Commands>")
            {
                

            }
            else if (obj.Commands.NodeType == " <Statement> <Commands>")
            {

            }


        }


        public void Visit(BooleanExpression obj)
        {
        }
        public void Visit(BooleanValue obj) { }
        public void Visit(DeclaringParameters obj) { }
        public void Visit(MethodDeclaration obj) { }
        public void Visit(Operator obj) { }
        public void Visit(Prefix obj) { }
        public void Visit(ValueKeywords obj) { }


    }
}
