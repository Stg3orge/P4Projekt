using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class BooleanExpression : SyntaxNode
    {

        public BooleanExpressionExtension BooleanExpressionExtension { get; private set; }
        public ComparisonOperator ComparisonOperator { get; private set; }
        public Expression Expression1 { get; private set; }
        public Expression Expression2 { get; private set; }
        public Value Value1 { get; private set; }
        public Value Value2 { get; private set; }


        //<BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>
        public BooleanExpression(ParserContext context, Value value1, Expression expression1, ComparisonOperator comparisonOperator, Value value2, Expression expression2, BooleanExpressionExtension booleanExpressionExtension) : base(context)
        {
            this.Value1 = value1;
            this.Expression1 = expression1;
            this.ComparisonOperator = comparisonOperator;
            this.Value2 = value2;
            this.Expression2 = expression2;
            this.BooleanExpressionExtension = booleanExpressionExtension;
        }


        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
