using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Declarations : SyntaxNode
    {
        public Declaration DeclarationNode { get; private set; }
        public Declarations DeclarationsNode { get; private set; }
        public MethodDeclaration MethodDeclarationNode { get; private set; }

        public string NodeType { get; private set; }

        //<Declarations> ::= <Declaration> ';' <Declarations>
        public Declarations(ParserContext context, Declaration declaration, Declarations declarations) : base(context)
        {
            this.DeclarationNode = declaration;
            this.DeclarationsNode = declarations;
            NodeType = "<Declarations> ::= <Declaration> ';' <Declarations>";   // TODO:
        }

        //<Declarations> ::= <MethodDeclaration> <Declarations>
        public Declarations(ParserContext context, MethodDeclaration methodDeclaration, Declarations declarations) : base(context)
        {
            this.MethodDeclarationNode = methodDeclaration;
            this.DeclarationsNode = declarations;
            NodeType = "<Declarations> ::= <MethodDeclaration> <Declarations>";   // TODO:
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
