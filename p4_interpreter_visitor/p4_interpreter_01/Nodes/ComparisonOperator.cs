using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ComparisonOperator : SyntaxNode
    {
        public string ComparisonOperatorType { get; private set; }

        //<comparisonoperator> ::= 'is='
        //<comparisonoperator> ::= 'is<='
        //<comparisonoperator> ::= 'is>='
        //<comparisonoperator> ::= 'is<'
        //<comparisonoperator> ::= 'is>'
        //<comparisonoperator> ::= 'is!='
        //<comparisonoperator> ::= touches    
        public ComparisonOperator(ParserContext context, string comparisonOperator) : base(context)
        {
            this.ComparisonOperatorType = comparisonOperator;
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
