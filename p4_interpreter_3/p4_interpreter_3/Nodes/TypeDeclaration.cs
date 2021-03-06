﻿namespace p4_interpreter_3.expressions
{
    public class TypeDeclaration : Statement
    {
        private Statement statement;
        private string v;

        public TypeDeclaration(ParserContext context, Statement statement, string v) : base(context)
        {
            this.statement = statement;
            this.v = v;
        }

        public override string ToString()
        {
            string returnstring = "";
            if (statement != null)
            {
                returnstring = returnstring + " " + statement.ToString() + " ";
            }
            if (v != null)
            {
                returnstring = returnstring + " " + v + " ";
            }
            return returnstring;
        }
    }
}