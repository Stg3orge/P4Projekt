using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Declarations : SyntaxNode
    {
        private Declaration declaration;
        private Declarations declarations;
        private MethodDeclaration methodDeclaration;

        public string NodeType { get; private set; }

        //<Declarations> ::= <Declaration> ';' <Declarations>
        public Declarations(ParserContext context, Declaration declaration, Declarations declarations) : base(context)
        {
            this.declaration = declaration;
            this.declarations = declarations;
            NodeType = " ";   // TODO:
        }

        //<Declarations> ::= <MethodDeclaration> <Declarations>
        public Declarations(ParserContext context, MethodDeclaration methodDeclaration, Declarations declarations) : base(context)
        {
            this.methodDeclaration = methodDeclaration;
            this.declarations = declarations;
            NodeType = " ";   // TODO:
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
