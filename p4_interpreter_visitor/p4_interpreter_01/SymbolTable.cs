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
        public class Variable
        {
            public List<Variable> ClassSymbolTable = new List<Variable>();
            public string Name { get; }
            public string Type { get; }
            public Variable(string name, string type)
            {
                Name = name;
                Type = type;
            }
        }
        public class Method
        {
            public List<Variable> Parameters { get; }
            public string Name { get; }
            public string Type { get; }

            public Method(string name, string type, List<Variable> parameters)
            {
                Name = name;
                Type = type;
                Parameters = parameters;
            }
        }
        public List<Method> Methods = new List<Method>();
        private readonly List<Variable> _globalScope = new List<Variable>();
        private readonly List<Variable> _methodScope = new List<Variable>();
        private static bool _inMethodScope;

        public SymbolTable()
        {
            Methods.Add(new Method("Move", "Void", PrefabParameters["Move"]));
            Methods.Add(new Method("Delete", "Void", PrefabParameters["Delete"]));
        }

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

        public Variable GetSymbol(string name1, string name2)
        {
            if (Variables.Find(x => x.Name == name1) == null)
                return null;
            if (name2 != null)
                return Variables.Find(x => x.Name == name1).ClassSymbolTable.Find(x => x.Name == name2);
            return Variables.Find(x => x.Name == name1);
        }

        public void AddToTable(string name, string type)
        {
            Variable variable1 = new Variable(name, type);
            if (_inMethodScope)
                _methodScope.Add(variable1);
            else
                _globalScope.Add(variable1);
            if (PrefabIdentifiers.ContainsKey(type))
                variable1.ClassSymbolTable = PrefabIdentifiers[type];
        }

        public void OpenScope()
        {
            _inMethodScope = true;
        }

        public void CloseScope()
        {
            _methodScope.Clear();
            _inMethodScope = false;
        }

        public readonly Dictionary<string, List<Variable>> PrefabIdentifiers = new Dictionary<string, List<Variable>>
            {
                {
                    "Character",
                    new List<Variable>
                    {
                        new Variable ("Size", "Point"),
                        new Variable("Location", "Point"),
                        new Variable("Speed", "Decimal"),
                        new Variable("MoveLeftKey", "String"),
                        new Variable("MoveRightKey", "String"),
                        new Variable("JumpKey", "String"),
                        new Variable("Alive", "Boolean")
                        // add Life, lose, 
                    }
                },
                {
                    "Camera",
                    new List<Variable>
                    {
                        new Variable ("Location", "Point"),
                        new Variable("Target", "PrefabClass"),
                        new Variable("DistanceToTarget", "Decimal")
                        // add maincamara bool? Enable bool.
                    }
                },
                {
                    "Sprite",
                    new List<Variable>
                    {
                        new Variable ("Size", "Point"),
                        new Variable("Location", "Point"),
                        new Variable("Picture", "String"),
                        new Variable("Speed", "Decimal"),
                        new Variable("Visible", "Boolean")
                        // add Damage, StartMoveLeft/right , 
                    }
                },
                {
                    "Square",
                    new List<Variable>
                    {
                        new Variable ("Size", "Point"),
                        new Variable("Location", "Point"),
                        new Variable("Picture", "String"),
                        new Variable("Visible", "Boolean")
                        // add trigger?, 
                    }
                },
                {
                    "Triangle",
                    new List<Variable>
                    {
                        new Variable ("Size", "Point"),
                        new Variable("Location", "Point"),
                        new Variable("Picture", "String"),
                        new Variable("Visible", "Boolean")
                        // add trigger?, 
                    }
                },
                {
                    "Text",
                    new List<Variable>
                    {
                        new Variable ("TextSize", "Integer"),
                        new Variable("Location", "Point"),
                        new Variable("DisplayText", "String"),
                        new Variable("Visible", "Boolean")
                        // add textbox Size?
                    }
                },
                {
                    "Trigger",
                    new List<Variable>
                    {
                        new Variable ("Size", "Point"),
                        new Variable("Location", "Point"),
                        new Variable("Enabled", "Boolean")
                        // add Damage tick?
                    }
                }
        };

        public readonly Dictionary<string, List<Variable>> PrefabParameters = new Dictionary<string, List<Variable>>
        {
            {
                "Move",
                new List<Variable>
                {
                    new Variable(null, "Prefab"),
                    new Variable(null, "Point"),
                    new Variable(null, "Decimal")

                }

            },
            {
                   "Delete",
                   new List<Variable>
                   {
                       new Variable(null, "Prefab")
                   }
            }
        };
    }
}