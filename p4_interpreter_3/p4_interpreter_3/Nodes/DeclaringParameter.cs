﻿namespace p4_interpreter_3.expressions
{
    public class DeclaringParameter : Statement
    {
        private Statement statement1;
        private Statement statement2;

        public DeclaringParameter(ParserContext context, Statement statement1, Statement statement2) : base(context)
        {
            this.statement1 = statement1;
            this.statement2 = statement2;
        }
    }
}