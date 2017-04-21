using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ReturnStatement : SyntaxNode
    {
        public Expression Expression { get; private set; }
        public Value Value { get; private set; }
 

        //<returnstatement> ::= return ';'  
        public ReturnStatement(ParserContext context, string v) : base(context)             // TODO FIX THIS SHIT!!!!!!!!!!!!!!!!!
        {
            throw NotImplementedException();
        }

        //<returnstatement> ::= return <Value> <Expression> ';'
        public ReturnStatement(ParserContext context, Value value, Expression expression) : base(context)
        {
            this.Value = value;
            this.Expression = expression;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
