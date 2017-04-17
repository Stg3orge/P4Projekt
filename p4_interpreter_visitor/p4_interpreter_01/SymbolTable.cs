using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace p4_interpreter_01
{
    public class SymbolTable
    {
        enum types //skal måske bruges senere
        {
            Integer, Decimal, String, Boolean, Point, Character, Enemy, Camera, Square, Triangle, Sprite, Text, Trigger
        };
        public class Variable
        {
            public static Dictionary<string, List<Variable>> prefabIdentifiers = new Dictionary<string, List<Variable>> //den her skal fyldes ud
            {
                {
                    "Character",
                    new List<Variable> {new Variable("Size", "decimal", null), new Variable("Height", "decimal", null)}
                }
            };
            public List<Variable> ClassSymbolTable = new List<Variable>();

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
                if (prefabIdentifiers.ContainsKey(Type))
                    ClassSymbolTable = prefabIdentifiers[Type];
            }
        }

        private List<Variable> _globalScope = new List<Variable>();
        private List<Variable> _methodScope = new List<Variable>();
        private List<Variable> _scopeBuffer = new List<Variable>();
        private static int _currentScope;

        public List<Variable> Variables
        {
            get
            {
                List<Variable> combined = new List<Variable>();
                combined.AddRange(_globalScope);
                combined.AddRange(_methodScope);
                return combined;
            }
        }

        public bool ContainsName(string name)
        {
            foreach (Variable variable in Variables)
            {
                if (variable.Name == name)
                    return true;
            }
            return false;
        }

        public void AddToTable(string name, string type, object value)
        {
            if(_currentScope > 0)
                _methodScope.Add(new Variable(name, type, value));
            else if(_currentScope == 0)
                _globalScope.Add(new Variable(name, type, value));
        }

        public bool AddToPrefab(string name, object value)
        {
            string[] nameStrings = name.Split('.');
            if (ContainsName(nameStrings[0]))
            {
                foreach (Variable variable in Variables.Find(x => x.Name == nameStrings[0]).ClassSymbolTable)
                {
                    if (variable.Name == nameStrings[1])
                    {
                        variable.Value = value;
                        return true;
                    }
                }
                return false; //klassens identifier eller metode kunne ikke findes
            }
            return false; //klassen er ikke defineret
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
                foreach (Variable variable in _scopeBuffer.FindAll(x => x.Scope == _currentScope))
                {
                    _methodScope.Add(variable);
                    _scopeBuffer.Remove(variable);
                }
        }
    }
}