using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01.Nodes
{
    public class ComparisonOperator : SyntaxNode
    {
        private string comparisonOperator;

        public string NodeType { get; private set; }
        //<comparisonoperator> ::= 'is='
        //<comparisonoperator> ::= 'is<='
        //<comparisonoperator> ::= 'is>='
        //<comparisonoperator> ::= 'is<'
        //<comparisonoperator> ::= 'is>'
        //<comparisonoperator> ::= 'is!='
        //<comparisonoperator> ::= touches    
        public ComparisonOperator(ParserContext context, string comparisonOperator) : base(context)
        {
            this.comparisonOperator = comparisonOperator;
            NodeType = " ";   // TODO:
        }

        public override object Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
