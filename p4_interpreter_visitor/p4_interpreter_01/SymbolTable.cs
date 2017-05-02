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
        public readonly Dictionary<string, List<Variable>> prefabIdentifiers = new Dictionary<string, List<Variable>>
            {
                {
                    "Character",
                    new List<Variable>
                    {
                        new Variable("Size", "Decimal", null),
                        new Variable("Location", "Point", null),
                        new Variable("Speed", "Decimal",null),
                        new Variable("MoveLeftKey", "String", null),
                        new Variable("MoveRightKey", "String", null),
                        new Variable("JumpKey", "String", null),
                        new Variable("Alive", "Boolean", null)
                        // add Life, lose, 
                    }
                },
                {
                    "Camera",
                    new List<Variable>
                    {
                        new Variable ("Location", "Point", null),
                        new Variable("Target", "Point", null),
                        new Variable("DistanceToTarget", "Decimal", null)
                        // add maincamara bool? Enable bool.
                    }
                },
                {
                    "Sprite",
                    new List<Variable>
                    {
                        new Variable ("Height", "Decimal", null),
                        new Variable ("Width", "Decimal", null),
                        new Variable("Location", "Point", null),
                        new Variable("Picture", "String", null),
                        new Variable("Speed", "Decimal", null),
                        new Variable("Visible", "Boolean", null)
                        // add Damage, StartMoveLeft/right , 
                    }
                },
                {
                    "Square",
                    new List<Variable>
                    {
                        new Variable ("Height", "Decimal", null),
                        new Variable ("Width", "Decimal", null),
                        new Variable("Location", "Point", null),
                        new Variable("Picture", "String", null),
                        new Variable("Visible", "Boolean", null)
                        // add trigger?, 
                    }
                },
                {
                    "Triangle",
                    new List<Variable>
                    {
                        new Variable ("Height", "Decimal", null),
                        new Variable ("Width", "Decimal", null),
                        new Variable("Location", "Point", null),
                        new Variable("Picture", "String", null),
                        new Variable("Visible", "Boolean", null)
                        // add trigger?, 
                    }
                },
                {
                    "Text",
                    new List<Variable>
                    {
                        new Variable ("TextSize", "Decimal", null),
                        new Variable("Location", "Point", null),
                        new Variable("DisplayText", "String", null),
                        new Variable("Visible", "Boolean", null)
                        // add textbox Size?
                    }
                },
                {
                    "Trigger",
                    new List<Variable>
                    {
                        new Variable ("Height", "Decimal", null),
                        new Variable ("Width", "Decimal", null),
                        new Variable("Location", "Point", null),
                        new Variable("Enabled", "Boolean", null)
                        // add Damage tick?
                    }
},
            {
                    "Move",
                    new List<Variable>
                    {
                        new Variable(null, "Sprite", null),
                        new Variable(null, "Point", null),
                        new Variable(null, "Decimal", null)
                    }
                },
                        {
                    "Delete",
                    new List<Variable>
                    {
                        new Variable(null, "Sprite", null),
                    }
                }
            };
        public class Variable
        {
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

        public Variable GetSymbol(string name1, string name2)
        {
            if (Variables.Find(x => x.Name == name1) != null)
            {
                if (name2 != null)
                {
                    return Variables.Find(x => x.Name == name1).ClassSymbolTable.Find(x => x.Name == name2);
                }
                    return Variables.Find(x => x.Name == name1);
            }
                return null;
        }

        public void AddToTable(string name, string type, object value)
        {
            Variable variable1 = new Variable(name, type, value);
            if (_currentScope > 0)
            {
                _methodScope.Add(variable1);
                if (prefabIdentifiers.ContainsKey(type))
                    variable1.ClassSymbolTable = prefabIdentifiers[type];
            }
            else if (_currentScope == 0)
            {
                _globalScope.Add(variable1);
                if (prefabIdentifiers.ContainsKey(type))
                    variable1.ClassSymbolTable = prefabIdentifiers[type];
            }
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
                return false;
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
                foreach (Variable variable in _scopeBuffer.FindAll(x => x.Scope == _currentScope))
                {
                    _methodScope.Add(variable);
                    _scopeBuffer.Remove(variable);
                }
        }
        public List<Method> Methods = new List<Method>();
        public class Method
        {
            public List<Variable> Parameters = new List<Variable>();

            public string Name;
            public string Type;

            public Method(string name, string type, List<Variable> parameters)
            {
                Name = name;
                Type = type;
                Parameters = parameters;
            }
        }
    }
}