using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_3.expressions;

namespace p4_interpreter_3.Nodes
{
    public class ProgramStructure : Statement
    {
        private Statement _statement1;
        private Statement _statement2;
        private Statement _statement3;
        private Statement _statement4;
        private Statement _statement5;
        private Statement _statement6;



        public ProgramStructure(ParserContext context, Statement s1, Statement s2, Statement s3, Statement s4
                                , Statement s5, Statement s6) : base(context)
        {
            _statement1 = s1;
            _statement2 = s2;
            _statement3 = s3;
            _statement4 = s4;
            _statement5 = s5;
            _statement6 = s6;
        }


        public override string ToString()
        {
            string returnstring = "";

            if (_statement1 != null)
            {
                returnstring += _statement1.ToString() + " ";
            }
            if (_statement2 != null)
            {
                returnstring += _statement2.ToString() + " ";
            }
            if (_statement3 != null)
            {
                returnstring += _statement3.ToString() + " ";
            }
            if (_statement4 != null)
            {
                returnstring += _statement4.ToString() + " ";
            }
            if (_statement5 != null)
            {
                returnstring += _statement5.ToString() + " ";
            }
            if (_statement6 != null)
            {
                returnstring += _statement6.ToString() + " ";
            }

            return returnstring;



            return _statement1.ToString() + " " + _statement2.ToString() + " " + _statement3.ToString() + " " +
                   _statement4.ToString() + " " + _statement5.ToString() + " " + _statement6.ToString() + " ";
        }
    }
}
