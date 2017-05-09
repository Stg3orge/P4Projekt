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

        public NodeTypes NodeType { get; private set; }

        public enum NodeTypes
        {
            DeclarationDeclarations, MethodDeclarationDeclarations
        }

        //<Declarations> ::= <Declaration> ';' <Declarations>
        public Declarations(ParserContext context, Declaration declaration, Declarations declarations) : base(context)
        {
            this.DeclarationNode = declaration;
            this.DeclarationsNode = declarations;
            NodeType = NodeTypes.DeclarationDeclarations;
        }

        //<Declarations> ::= <MethodDeclaration> <Declarations>
        public Declarations(ParserContext context, MethodDeclaration methodDeclaration, Declarations declarations) : base(context)
        {
            this.MethodDeclarationNode = methodDeclaration;
            this.DeclarationsNode = declarations;
            NodeType = NodeTypes.MethodDeclarationDeclarations;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
