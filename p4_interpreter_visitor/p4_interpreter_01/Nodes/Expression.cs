using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class Expression : SyntaxNode
    {
        private Expression expression;
        private Operator @operator;
        private Value value;

        //<Expression> ::= <operator> <Value> <Expression>
        public Expression(ParserContext context, Operator @operator, Value value, Expression expression) : base(context)
        {
            this.@operator = @operator;
            this.value = value;
            this.expression = expression;
        }
    }
}