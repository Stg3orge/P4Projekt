﻿namespace p4_interpreter_01
{
    public class MethodTypePrefab : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public MethodTypePrefab(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}