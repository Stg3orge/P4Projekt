namespace p4_interpreter_3.expressions
{
    public class PrefabCreator : Expression
    {

        private string v;

        public PrefabCreator(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }


        public override object Value
        {
            get { return v; }
        }


    }
}