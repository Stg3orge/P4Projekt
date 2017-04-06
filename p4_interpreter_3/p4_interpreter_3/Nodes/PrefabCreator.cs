namespace p4_interpreter_3.expressions
{
    public class PrefabCreator : Statement
    {

        private string v;

        public PrefabCreator(ParserContext context, string v) : base(context)
        {
            this.v = v;
        }

        public override void Execute()
        {
            if (v == "Character")
            {
                //TODO: STUFF
            }
        }

        public override string ToString()
        {
            return v + " ";
        }
    }
}