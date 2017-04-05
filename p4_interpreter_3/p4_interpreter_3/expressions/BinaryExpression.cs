using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GoldParser;

namespace p4_interpreter_3.expressions
{
    public class BinaryExpression : Expression
    {
        private Expression _leftNode;
        private string _operator;
        private Expression _rightNode;

        public BinaryExpression(ParserContext context,
            Expression leftSubtree, string op, Expression rightSubtree)
            : base(context)
        {
            _leftNode = leftSubtree;
            _operator = op;
            _rightNode = rightSubtree;
        }

        public override object Evaluate()
        {
            switch (_operator)
            {
                case "+":
                    return Double.Parse(_leftNode.Evaluate().ToString()) + Double.Parse(_rightNode.Evaluate().ToString()); // Int?
                case "-":
                    return Double.Parse(_leftNode.Evaluate().ToString()) - Double.Parse(_rightNode.Evaluate().ToString());
                case "*":
                    return Double.Parse(_leftNode.Evaluate().ToString()) * Double.Parse(_rightNode.Evaluate().ToString());
                case "/":
                    return Double.Parse(_leftNode.Evaluate().ToString()) / Double.Parse(_rightNode.Evaluate().ToString());
            }
            return null;
        }
    }
}
