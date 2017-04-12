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
        //klass.stuff = check om klasse er der
        private class Variable
        {
            public string[] _FullName;
            public string Name;
            public object Value;
            public string Type;
            public int Scope;

            public Variable(string name, string type, object value)
            {
                if (name.Contains('.'))
                    _FullName = name.Split('.');
                else
                    Name = name;
                Value = value;
                Scope = _currentScope;
                Type = type;
            }
        }

        private ArrayList _globalScope = new ArrayList();
        private ArrayList _methodScope = new ArrayList();
        private ArrayList _scopeBuffer = new ArrayList();

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
            _scopeBuffer.AddRange(_methodScope);
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
                    if ((_scopeBuffer[i] as Variable).Scope == _currentScope)
                    {
                        _methodScope.Add(_scopeBuffer[i]);
                        _scopeBuffer.RemoveAt(i);
                        i -= 1;
                    }
                }
            }
        }
    }
}