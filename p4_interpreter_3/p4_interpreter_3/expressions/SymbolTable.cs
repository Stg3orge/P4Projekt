using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_3.expressions
{
    public class SymbolTable
    {
        //HVAD DER MANGLER:
        //typechecking - gold maybe
        //klasser
        private class Variable
        {
            public string Name;
            public object Value;
            public string Type;
            public int Scope;

            public Variable(string name, string type, object value)
            {
                Name = name;
                Value = value;
                Scope = _currentScope;
                Type = type;
            }
        }

        private ArrayList _globalScope = new ArrayList();
        private ArrayList _methodScope = new ArrayList();
        private ArrayList _Scopebuffer = new ArrayList();

        private static int _currentScope;

        public ArrayList Variables
        {
            get
            {
                ArrayList combined = new ArrayList();
                combined.AddRange(_globalScope);
                combined.AddRange(_methodScope);
                return combined;
            }
        }

        public bool Contains(string name)
        {
            for (int i = 0; i < Variables.Count; i++)
            {
                if ((Variables[i] as Variable).Name == name)
                    return true;
            }
            return false;
        }

        public bool Add(string name, object value, string type)
        {
            if (Contains(name))
                return false;
            if(_currentScope > 0)
                _methodScope.Add(new Variable(name, type, value));
            else
                _globalScope.Add(new Variable(name, type, value));
            return true;
        }

        public void OpenScope()
        {
            _globalScope.AddRange(_methodScope);
            _methodScope.Clear();
            _currentScope += 1;
        }

        public void CloseScope()
        {
            _methodScope.Clear();
            _currentScope -= 1;
            if (_currentScope > 0)
            {
                for (int i = 0; i < Variables.Count; i++)
                {
                    if ((Variables[i] as Variable).Scope == _currentScope)
                    {
                        _methodScope.Add(Variables[i]);
                        _globalScope.RemoveAt(i);
                    }
                }
            }
        }
    }
}