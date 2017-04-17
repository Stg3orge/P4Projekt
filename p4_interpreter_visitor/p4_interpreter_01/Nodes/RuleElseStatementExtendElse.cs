﻿namespace p4_interpreter_01
{
    public class RuleElseStatementExtendElse : SyntaxNode
    {
        private ParserContext parserContext;
        private SyntaxNode syntaxNode;

        public RuleElseStatementExtendElse(ParserContext parserContext, SyntaxNode syntaxNode) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.syntaxNode = syntaxNode;
        }
    }
}