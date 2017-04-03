using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    public class VariableList
    {
        private ArrayList _variables = new ArrayList();

        public bool Add(string name, object value)
        {
            if (VariableIndex(name) != -1)
            {
                return false;
            }
            _variables.Add(new Variable(name, value));
            return true;
        }

        public void ClearValues()
        {
            foreach (Variable variable in _variables)
            {
                variable.Value = null;
            }
        }

        public int Count
        {
            get { return _variables.Count; }
        }


        public string GetName(int index)
        {
            if (0 <= index && index < Count)
            {
                return (_variables[index] as Variable).Name;
            }
            return String.Empty;
        }

        public object this[string name]
        {
            get { return this[VariableIndex(name)]; }
            set { this[VariableIndex(name)] = value; }
        }

        public object this[int index]
        {
            get
            {
                if (0 <= index && index < Count)
                {
                    return (_variables[index] as Variable).Value;
                }
                return null;
            }
            set
            {
                if (0 <= index && index < Count)
                {
                    (_variables[index] as Variable).Value = value;
                }
            }
        }

        private int VariableIndex(string name)
        {
            for (int i = 0; i < _variables.Count; i++)
            {
                if (String.Compare((_variables[i] as Variable).Name, name, true) == 0)
                {
                    return i;
                }
            }
            return -1;
        }

        private class Variable
        {
            public string Name;
            public object Value;

            public Variable(string name, object value)
            {
                Name = name;
                Value = value;
            }
        }
    }
}
