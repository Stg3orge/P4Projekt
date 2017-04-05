using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    public abstract class Expression : SyntaxNode
    {
        protected Expression(ParserContext context) : base(context)
		{
        }

        //public abstract object Value();

        public abstract object Evaluate();






    }
}
