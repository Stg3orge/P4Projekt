using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    public class Statement : SyntaxNode
    {
        public Statement(ParserContext context) : base(context)
		{
        }


        public void Execute()
        {
            TypeCheck();
            ScopeCheck();
        }

        public virtual void TypeCheck()
        {
            
        }

        public virtual void ScopeCheck()
        {
            
        }
        // code gen
        public override string ToString()
        {
            return base.ToString();
        }
    }
}
