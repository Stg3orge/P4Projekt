using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class BooleanExpression : SyntaxNode
    {
        private BooleanExpressionExtension booleanExpressionExtension;
        private ComparisonOperator comparisonOperator;
        private Expression expression1;
        private Expression expression2;
        private Value value1;
        private Value value2;

        //<BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>
        public BooleanExpression(ParserContext context, Value value1, Expression expression1, ComparisonOperator comparisonOperator, Value value2, Expression expression2, BooleanExpressionExtension booleanExpressionExtension) : base(context)
        {
            this.value1 = value1;
            this.expression1 = expression1;
            this.comparisonOperator = comparisonOperator;
            this.value2 = value2;
            this.expression2 = expression2;
            this.booleanExpressionExtension = booleanExpressionExtension;
        }


        public override SyntaxNode Accept(IVisitor visitor)
        {

            visitor.Visit(this);


        }

    }
}
