using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class MethodDeclaration : SyntaxNode
    {
        private Commands commands;
        private DeclaringParameters declaringParameters;
        private MethodType methodType;
        private ReturnStatement returnStatement;
        private string v;
        //<MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method
        public MethodDeclaration(ParserContext context, MethodType methodType, string v, DeclaringParameters declaringParameters, Commands commands, ReturnStatement returnStatement) : base(context)
        {
            this.methodType = methodType;
            this.v = v;
            this.declaringParameters = declaringParameters;
            this.commands = commands;
            this.returnStatement = returnStatement;
        }
    }
}
