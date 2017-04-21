using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Expression : SyntaxNode
    {
        public Expression Expression1 { get; private set; }
        public Operator Operator { get; private set; }
        public Value Value { get; private set; }


        //<Expression> ::= <operator> <Value> <Expression>
        public Expression(ParserContext context, Operator @operator, Value value, Expression expression) : base(context)
        {
            this.Operator = @operator;
            this.Value = value;
            this.Expression1 = expression;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}