﻿namespace p4_interpreter_01
{
    public class TextPrimeStringValue : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;
        private string v;

        public TextPrimeStringValue(ParserContext parserContext, string v, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
            this.syntaxNode = syntaxNode;
            Nodes.Add(this);

        }

        public new void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (v != null)
            {
                returnstring = returnstring + " " + v.ToString() + " ";
            }
            if (syntaxNode != null)
            {
                returnstring = returnstring + " " + syntaxNode.ToString() + " ";
            }
            return returnstring;
        }
    }
}