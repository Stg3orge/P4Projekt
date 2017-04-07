using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    public class Expression : SyntaxNode
    {
        public Expression(ParserContext context) : base(context)
		{
        }

        public virtual object Value
        {
            get { return null; }
        }




    }
}
