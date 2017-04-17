﻿namespace p4_interpreter_01
{
    public class TypePrefab : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public TypePrefab(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
            Nodes.Add(this);
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