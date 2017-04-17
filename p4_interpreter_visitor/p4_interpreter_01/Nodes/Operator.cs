﻿namespace p4_interpreter_01
{
    public class Operator : SyntaxNode
    {
        private ParserContext parserContext;
        private string v;

        public Operator(ParserContext parserContext, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
        }
    }
}