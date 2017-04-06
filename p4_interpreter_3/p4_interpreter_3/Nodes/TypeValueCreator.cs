﻿namespace p4_interpreter_3.expressions
{
    public class TypeValueCreator : Expression
    {
        private Statement statement;
        private string v;

        public TypeValueCreator(ParserContext context, Statement statement, string v) : base(context)
        {
            this.statement = statement;
            this.v = v;
        }

        public override object Value
        {
            get { return v; }
        }

        public override string ToString()
        {
            return statement.ToString() + " " + v + " ";
        }
    }
}