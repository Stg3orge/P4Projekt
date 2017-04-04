using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    class Statement : SyntaxNode
    {
        public Statement(ParserContext context) : base(context)
		{
        }

        // 
        public virtual void Execute()
        {
        }

        // code gen
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
