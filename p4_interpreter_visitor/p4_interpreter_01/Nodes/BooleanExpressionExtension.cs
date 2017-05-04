using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class BooleanExpressionExtension : SyntaxNode
    {
        public BooleanExpression BooleanExpression { get; private set; }
        public LogicalOperator LogicalOperator { get; private set; }


        //<BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
        public BooleanExpressionExtension(ParserContext context, LogicalOperator logicalOperator, BooleanExpression booleanExpression) : base(context)
        {
            this.LogicalOperator = logicalOperator;
            this.BooleanExpression = booleanExpression;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
