﻿using System;
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
            public Dictionary<string, List<Variable>> prefabIdentifiers = new Dictionary<string, List<Variable>>
        {
            {"Character", new List<Variable> { new Variable("Size", "decimal", null), new Variable("Height", "decimal", null) }}
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
                if(prefabIdentifiers.ContainsKey(Name))
                    ClassSymbolTable = prefabIdentifiers[Name];
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

        private Variable retrieveSymbol(string name)
        {
            for (int i = 0; i < Variables.Count; i++)
            {
                if ((Variables[i] as Variable).Name == name)
                {
                    return Variables[i] as Variable;
                }
            }
            return null;
        }

        public bool AddToPrefab(string name, object value, string type)
        {
            string[] nameStrings = name.Split('.');
            for (int i = 0; i < Variables.Count; i++)
            {
                if (Contains(nameStrings[0]))
                {
                    Variable prefab = retrieveSymbol(nameStrings[0]);
                    foreach (Variable VARIABLE in prefab.ClassSymbolTable)
                    {
                        if (VARIABLE.Name == nameStrings[1])
                        {
                            VARIABLE.Value = value;
                            return true;
                        }
                    }
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