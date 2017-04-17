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
        private class Variable
        {
            public static Dictionary<string, Variable> prefabIdentifiers = new Dictionary<string, Variable>
        {
            {"Character", new Variable("Size", "decimal", null) },
            {"Character", new Variable("Height", "decimal", null) }
        };
            public ArrayList ClassSymbolTable = new ArrayList();

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

        public bool AddToPrefab(string name, object value, string type)         //poop
        {
            string[] nameStrings = name.Split('.');
            for (int i = 0; i < Variables.Count; i++)
            {
                if (nameStrings[0] == (Variables[i] as Variable).Name)
                {
                    string key = (Variables[i] as Variable).Name;
                    if (key == "lul")
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
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
                for (int i = 0; i < _scopeBuffer.Count; i++)
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