using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class BooleanExpressionExtension : SyntaxNode
    {
        private BooleanExpression booleanExpression;
        private LogicalOperator logicalOperator;

        //<BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
        public BooleanExpressionExtension(ParserContext context, LogicalOperator logicalOperator, BooleanExpression booleanExpression) : base(context)
        {
            this.logicalOperator = logicalOperator;
            this.booleanExpression = booleanExpression;
        }

        public override void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
