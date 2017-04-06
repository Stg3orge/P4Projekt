namespace p4_interpreter_3.expressions
{
    public class PrefabCreator : Statement
    {

        private string v;

        public PrefabCreator(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }

        public override string ToString()
        {
            string returnstring = "";

            if (v != null)
            {
                returnstring = returnstring + " " + v + " ";
            }

            return returnstring;
        }
    }
}