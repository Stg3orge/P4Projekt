using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class LogicalOperator : SyntaxNode
    {
        private string v;
        //<logicaloperator> ::= or
        //<logicaloperator> ::= and
        public LogicalOperator(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
