﻿namespace p4_interpreter_01
{
    public class TypeValueIdentifier : SyntaxNode, IVisitable
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public TypeValueIdentifier(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
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
            if (syntaxNode != null)
            {
                returnstring = returnstring + " " + syntaxNode.ToString() + " ";
            }
            return returnstring;
        }
    }
}