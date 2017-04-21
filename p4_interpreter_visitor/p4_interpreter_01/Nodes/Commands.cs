using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Commands : SyntaxNode
    {
        private Commands commands;
        private Declaration declaration;
        private Statement statement;


        

        public Statement Statement2
        {
            set
            {
                if (value != null)
                {
                    statement = value;
                }


            }
            get { return statement; }
        }



        public string NodeType { get; private set; }

        //<Commands> ::= <Declaration> ';' <Commands>
        public Commands(ParserContext context, Declaration declaration, Commands commands) : base(context)
        {
            this.declaration = declaration;
            this.commands = commands;
            NodeType = " ";   // TODO:
        }
        //<Commands> ::= <Statement> <Commands>
        public Commands(ParserContext context, Statement statement, Commands commands) : base(context)
        {
            this.statement = statement;
            this.commands = commands;
            NodeType = " ";   // TODO:
        }


        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }


        public List<SyntaxNode> ReturnNodes(string NodeType)
        {
            List<SyntaxNode> templList = new List<SyntaxNode>();

            if (NodeType == "<Declaration> ';' <Commands>")
            {
                templList.Add(declaration);
                templList.Add(commands);
            }
            else if (NodeType == " <Statement> <Commands>")
            {
                templList.Add(statement);
                templList.Add(commands);
            }
            return templList;
        }



    }
}
