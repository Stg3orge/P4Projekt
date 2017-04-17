﻿namespace p4_interpreter_01
{
    public class WriteStatement : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public WriteStatement(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }

        public new void Accept(IVisitor visitor)
        {
            visitor.Visit(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (syntaxNode != null)
            {
                returnstring = returnstring + " " + syntaxNode.ToString() + " ";
            }
            return returnstring;
        }
    }
}