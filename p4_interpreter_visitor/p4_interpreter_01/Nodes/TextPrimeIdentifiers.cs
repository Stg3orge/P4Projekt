﻿namespace p4_interpreter_01
{
    public class TextPrimeIdentifiers : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode1;
        private SyntaxNode syntaxNode2;

        public TextPrimeIdentifiers(ParserContext parserContext, SyntaxNode syntaxNode1, SyntaxNode syntaxNode2) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode1 = syntaxNode1;
            this.syntaxNode2 = syntaxNode2;
        }
    }
}