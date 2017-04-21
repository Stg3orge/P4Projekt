using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class MethodDeclaration : SyntaxNode
    {
        public Commands Commands { get; private set; }
        public DeclaringParameters DeclaringParameters { get; private set; }
        public MethodType MethodType { get; private set; }
        public ReturnStatement ReturnStatement { get; private set; }
        public string Value { get; private set; }

        //<MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method
        public MethodDeclaration(ParserContext context, MethodType methodType, string v, DeclaringParameters declaringParameters, Commands commands, ReturnStatement returnStatement) : base(context)
        {
            this.MethodType = methodType;
            this.Value = v;
            this.DeclaringParameters = declaringParameters;
            this.Commands = commands;
            this.ReturnStatement = returnStatement;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
