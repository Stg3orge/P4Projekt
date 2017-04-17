﻿namespace p4_interpreter_01
{
    public class MethodTypeCreator : SyntaxNode
    {
        private ParserContext parserContext;
        private string v;

        public MethodTypeCreator(ParserContext parserContext, string v) : base(parserContext)
        {
            this.parserContext = parserContext;
            this.v = v;
            Nodes.Add(this);
        }

        public override string ToString()
        {
            string returnstring = "";
            if (v != null)
            {
                returnstring = returnstring + " " + v.ToString() + " ";
            }
            return returnstring;
        }
    }
}