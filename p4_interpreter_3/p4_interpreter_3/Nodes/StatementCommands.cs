using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_3.expressions;


namespace p4_interpreter_3.Nodes
{
    public class StatementCommands : Statement
    {
        private Statement statement1;
        private Statement statement2;

        public StatementCommands(ParserContext context, Statement statement1, Statement statement2) : base(context)
        {
            this.statement1 = statement1;
            this.statement2 = statement2;
        }

        public override string ToString()
        {
            return statement1.ToString() + " " + statement2.ToString() + " ";
        }
    }
}