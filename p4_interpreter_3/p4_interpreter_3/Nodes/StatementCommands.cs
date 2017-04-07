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
        private Statement _statement1;
        private Statement _statement2;

        public StatementCommands(ParserContext context, Statement statement1, Statement statement2) : base(context)
        {
            this._statement1 = statement1;
            this._statement2 = statement2;
        }

        public override string ToString()
        {
            string returnstring = "";
            if (_statement1 != null)
            {
                returnstring = returnstring + " " + _statement1.ToString() + " ";
            }
            if (_statement2 != null)
            {
                returnstring = returnstring + " " + _statement2.ToString() + " ";
            }
            return returnstring;
        }
    }
}