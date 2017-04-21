using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ReturnStatement : SyntaxNode
    {
        private Expression expression;
        private string v;
        private Value value;

        //<returnstatement> ::= return ';'  
        public ReturnStatement(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }

        //<returnstatement> ::= return <Value> <Expression> ';'
        public ReturnStatement(ParserContext context, Value value, Expression expression) : base(context)
        {
            this.value = value;
            this.expression = expression;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
