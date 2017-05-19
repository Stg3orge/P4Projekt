using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using p4_interpreter_01.Nodes;
using Type = p4_interpreter_01.Nodes.Type;

namespace p4_interpreter_01
{
    public class CodeGenVisitor : IVisitor
    {
        // TODO: Add GetList to each syntax node, add foreach in each visit.    add  codeString += " " in each rule;
        // TODO: combine declarations with assignments in codegen.

        private SymbolTable _symbolTable = ContextVisitor._symbolTable;
        private List<string> _instantiateList = new List<string>();
        private bool _preVisit = true;

        public object Visit(SyntaxNode node)
        {
            return null;
        }

        
        public object Visit(StartupStucture obj)
        {
            string codeString = "";

            string[] usingDirectives = { "using System;", "using System.Collections;", "using System.Collections.Generic;",
                                        "using System.Reflection;", "using UnityEngine;", "using UnityEngine.UI;" };

            foreach (string directive in usingDirectives)
                codeString += directive;

            codeString += "public class CompiledScript : MonoBehaviour { ";

            // Awake()
            codeString += obj.Declarations?.Accept(this);
            codeString += obj.Declarations2?.Accept(this);
            codeString += obj.Declarations3?.Accept(this);
            _preVisit = false;
            codeString += "void Awake() {";

            foreach (string type in _instantiateList)
            {
                codeString += type;
            }
            codeString += "}";

            // Start()
            codeString += "void Start(";
            /*            obj.DeclaringParameters?.Accept(this);*/      // Remove?
            codeString += ") {";
            codeString += obj.Commands?.Accept(this);
            _symbolTable.CloseScope();                  //TESTFIX
            codeString += "}";

            // Update()
            codeString += "void Update(";
            /*            obj.DeclaringParameters2?.Accept(this);*/     // REmove?!
            codeString += ") {";
            codeString += obj.Commands2?.Accept(this);
            _symbolTable.CloseScope();                  //TESTFIX
            codeString += "}";

            // Methods
            codeString += obj.Declarations?.Accept(this);
            codeString += obj.Declarations2?.Accept(this);
            codeString += obj.Declarations3?.Accept(this);

            codeString += "}";

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // TODO: Add Better method to fix spaceing in cs file.
            codeString = codeString.Replace(";", ";" + System.Environment.NewLine);
            codeString = codeString.Replace("{", System.Environment.NewLine + "{" + System.Environment.NewLine);
            codeString = codeString.Replace("}", "}" + System.Environment.NewLine);
            Form1.formtest.testString = codeString;
            //////////////////////////////////////////////////////////////////////////// This block is only for test.

            // File Setup
            if(File.Exists("C:/BOOTL/BOOTLUnityProject/Assets/Resources/Scripts/CompiledScript.cs"))
                File.WriteAllText("C:/BOOTL/BOOTLUnityProject/Assets/Resources/Scripts/CompiledScript.cs", String.Empty);

            StreamWriter file = new StreamWriter("C:/BOOTL/BOOTLUnityProject/Assets/Resources/Scripts/CompiledScript.cs", true);
            file.Write(codeString);
            file.Close();

            return null;
        }

        public object Visit(BooleanExpression obj)
        {
            string codeString = "";
            codeString += obj.Value1.Accept(this);
            codeString += obj.Expression1?.Accept(this);
            codeString += obj.ComparisonOperator.Accept(this);
            codeString += obj.Value2.Accept(this);
            codeString += obj.Expression2?.Accept(this);
            codeString += obj.BooleanExpressionExtension?.Accept(this);
            return codeString;
        }

        public object Visit(BooleanExpressionExtension obj)
        {
            string codeString = "";
            codeString += obj.LogicalOperator?.Accept(this);
            codeString += obj.BooleanExpression?.Accept(this);
            return codeString;
        }

        public object Visit(CallingParameter obj)
        {
            string codeString = "";
            codeString += ", ";
            codeString += obj.Value?.Accept(this);
            codeString += obj.Parameter?.Accept(this);
            return codeString;
        }

        public object Visit(CallingParameters obj)
        {
            string codeString = "";
            codeString += obj.Value?.Accept(this);
            codeString += obj.CallingParameter?.Accept(this);
            return codeString;
        }

        public object Visit(Commands obj)
        {
            string codeString = "";

            if (obj.NodeType == Commands.NodeTypes.DeclarationCommands)
                if(obj.Declaration != null)
                    codeString += obj.Declaration.Accept(this) + ";";
            else if (obj.NodeType == Commands.NodeTypes.StatementCommands)
                codeString += obj.Statement?.Accept(this);
            codeString += obj.Commands1?.Accept(this);

            return codeString;
        }

        public object Visit(ComparisonOperator obj)
        {
            string codeString = "";

            switch (obj.ComparisonOperatorType.ToLower())
            {
                case "is=":
                    codeString += " == ";
                    break;
                case "is<=":
                    codeString += " <= ";
                    break;
                case "is>=":
                    codeString += " >= ";
                    break;
                case "is<":
                    codeString += " < ";
                    break;
                case "is>":
                    codeString += " > ";
                    break;
                case "is!=":
                    codeString += " != ";
                    break;
                case "touches":
                    codeString += ".GetComponent<ITouching>().IsTouching == ";
                    break;
            }
            return codeString;
        }

        public object Visit(Declaration obj)
        {
            string codeString = "";
            _symbolTable.AddToTable(obj.IdentifierNode, obj.TypeNode.Accept(this).ToString());////TESTFIX
            string type = (string)obj.TypeNode.Accept(this);

            switch (type.ToLower())
            {
                case "integer":
                    codeString += "int " + obj.IdentifierNode;
                    break;
                case "decimal":
                    codeString += "double " + obj.IdentifierNode;
                    break;
                case "string":
                    codeString += "string " + obj.IdentifierNode;
                    break;
                case "boolean":
                    codeString += "bool " + obj.IdentifierNode;
                    break;
                case "point":
                    codeString += "Vector2 " + obj.IdentifierNode;
                    break;
                case "character":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/CharacterPrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/CharacterPrefab\"))";
                    break;
                case "enemy":
                    throw new NotImplementedException();        // TODO: REMOVE
                case "camera":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/CameraPrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/CameraPrefab\"))";
                    break;
                case "square":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/SquarePrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/SquarePrefab\"))";
                    break;
                case "triangle":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/TrianglePrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/TrianglePrefab\"))";
                    break;
                case "sprite":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/SpritePrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/SpritePrefab\"))";
                    break;
                case "text":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/UITextPrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/UITextPrefab\"))";
                    break;
                case "trigger":
                    codeString += "GameObject " + obj.IdentifierNode;
                    if (_preVisit)
                        _instantiateList.Add(obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/TriggerPrefab\"));");
                    else
                        codeString += "; " + obj.IdentifierNode + " = (GameObject) Instantiate(Resources.Load(\"Prefabs/TriggerPrefab\"))";
                    break;
            }
            return codeString;
        }

        public object Visit(Declarations obj)
        {
            string codeString = "";
            if (_preVisit)
            {
                if (obj.NodeType == Declarations.NodeTypes.DeclarationDeclarations)
                {
                    if(obj.DeclarationNode != null)
                        codeString += obj.DeclarationNode.Accept(this) + ";";
                }
            }
            else if (obj.NodeType == Declarations.NodeTypes.MethodDeclarationDeclarations)
            {
                codeString += obj.MethodDeclarationNode.Accept(this);
            }

            codeString += obj.DeclarationsNode?.Accept(this);

            return codeString;
        }

        public object Visit(DeclaringParameter obj)
        {
            _symbolTable.OpenScope();//////////TESTFIX
            string codeString = "";
            codeString += obj.Declaration?.Accept(this);

            if (obj.Parameter != null)
            {
                codeString += ", ";
                codeString += obj.Parameter.Accept(this);
            }

            return codeString;
        }

        public object Visit(DeclaringParameters obj)
        {
            string codeString = "";

            codeString += obj.Declaration?.Accept(this);

            if (obj.DeclaringParameter != null)
            {
                codeString += ", ";
                codeString += obj.DeclaringParameter.Accept(this);
            }
            return codeString;
        }

        public object Visit(IfStatementExtend obj)
        {
            string codeString = "";

            if (obj.NodeType == IfStatementExtend.NodeTypes.ElseIfStatement)
            {
                codeString += "else if ( ";
                codeString += obj.BooleanExpression?.Accept(this);
                codeString += " ) {";
                codeString += obj.Commands?.Accept(this);
                codeString += "}";
                codeString += obj.StatementExtend?.Accept(this);
            }
            else if (obj.NodeType == IfStatementExtend.NodeTypes.ElseStatement)
            {
                codeString += "else {";
                codeString += obj.Commands?.Accept(this);
                codeString += "}";
            }
            return codeString;
        }

        public object Visit(Expression obj)
        {
            string codeString = "";
            codeString += obj.Operator?.Accept(this);
            codeString += obj.Value?.Accept(this);
            codeString += obj.Expression1?.Accept(this);
            return codeString;
        }

        public object Visit(IdentifiersPrime obj)
        {
            string codeString = "";
            codeString += "." + obj.Identifier;
            codeString += obj.Prime?.Accept(this);
            return codeString;
        }

        public object Visit(LogicalOperator obj)
        {
            string codeString = "";

            switch (obj.LogicalOperatorType.ToLower())
            {
                case "or":
                    codeString += " || ";
                    break;
                case "and":
                    codeString += " && ";
                    break;
            }
            return codeString;
        }

        public object Visit(MethodDeclaration obj)
        {
            string codeString = "";

            codeString += obj.MethodType.Accept(this);
            codeString += " ";
            codeString += obj.Value;
            codeString += "(";
            codeString += obj.DeclaringParameters?.Accept(this);
            codeString += ") {";
            codeString += obj.Commands?.Accept(this);
            codeString += obj.ReturnStatement?.Accept(this);
            codeString += "}";

            _symbolTable.CloseScope();///////////TESTFIX

            return codeString;
        }

        public object Visit(MethodType obj)
        {
            string codeString = "";

            switch (obj.MethodTypeValue.ToLower())
            {
                case "integer":
                    codeString += "int";
                    break;
                case "decimal":
                    codeString += "double";
                    break;
                case "string":
                    codeString += "string";
                    break;
                case "boolean":
                    codeString += "bool";
                    break;
                case "point":
                    codeString += "Vector2";
                    break;
                case "void":
                    codeString += "void";
                    break;
            }
            return codeString;
        }

        public object Visit(Operator obj)
        {
            return obj.MathOperatorType;
        }

        public object Visit(Prefix obj)
        {
            return obj.PrefixSymbol;
        }

        public object Visit(ReturnStatement obj)
        {
            string codeString = "";

            //if (obj.NodeType == ReturnStatement.NodeTypes.ReturnNull)
            //{
            //    // do noting
            //}
            if (obj.NodeType == ReturnStatement.NodeTypes.ReturnValue)
            {
                codeString += "return ";
                codeString += obj.Value?.Accept(this);
                codeString += obj.Expression?.Accept(this);
                codeString += ";";
            }
            return codeString;
        }

        public object Visit(Statement obj)
        {
            string codeString = "";

            if (obj.NodeType == Statement.NodeTypes.Write)
            {
                codeString += "DebugConsole.Log(";
                codeString += obj.Text.Accept(this);
                codeString += ");";
            }       
            
            else if (obj.NodeType == Statement.NodeTypes.Assign)
            {
                codeString += obj.Value1.Accept(this);
                codeString += " = ";
                codeString += obj.Value2.Accept(this);
                codeString += obj.Expression?.Accept(this);
                codeString += ";";
            }  
            
            else if (obj.NodeType == Statement.NodeTypes.Method)
            {
                codeString += obj.Value1.Accept(this);
                codeString += "(";
                codeString += obj.CallingParameters?.Accept(this);
                codeString += ");";
            }    
            
            else if (obj.NodeType == Statement.NodeTypes.PrefabMethod)
            {
                if (obj.PrefabMethods.PrefabMethodType == "Delete")
                {
                    codeString += "Destroy(";
                    codeString += obj.CallingParameters.Accept(this);
                    codeString += ");";
                }
                else
                    throw new Exception(); // PrefabMethod Could not be found
            }

            else if (obj.NodeType == Statement.NodeTypes.AssignMethod) 
            {
                codeString += obj.Value1.Accept(this);
                codeString += " = ";
                codeString += obj.Value2.Accept(this);

                bool test = false;

                if (obj.Value1.Token1 != null && obj.Value1.IdentifiersPrime != null)
                {
                    test = _symbolTable.GetSymbol(obj.Value1.Token1, obj.Value1.IdentifiersPrime.Identifier).Type == "Method";
                }
                if (!test)
                {
                    codeString += "(";
                    codeString += obj.CallingParameters?.Accept(this);
                    codeString += ")";
                }
                codeString += ";";
            }                                           // TODO: FIX

            //<Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'                // TODO: FIX/Delete
            else if (obj.NodeType == Statement.NodeTypes.AssignPrefabMethod)
            {
                // TODO: WTF fix plz
                throw new Exception();
            }

            else if (obj.NodeType == Statement.NodeTypes.If)
            {
                codeString += "if(";
                codeString += obj.BooleanExpression.Accept(this);
                codeString += ") {";
                codeString += obj.Commands?.Accept(this);
                codeString += "}";
                codeString += obj.IfStatementExtend?.Accept(this);
            }

            else if (obj.NodeType == Statement.NodeTypes.While)
            {
                codeString += "while(";
                codeString += obj.BooleanExpression.Accept(this);
                codeString += ") {";
                codeString += obj.Commands?.Accept(this);
                codeString += "}";
            }

            return codeString;
        }

        public object Visit(Text obj)
        {
            string codeString = "";

            if (obj.NodeType == Text.NodeTypes.IdentifiersTextPrime)
                codeString += obj.Value.Accept(this);
            else if (obj.NodeType == Text.NodeTypes.StringValueTextPrime)
                codeString += obj.StringValue;

            if (obj.TextPrime != null)
            {
                codeString += " + ";
                codeString += obj.TextPrime.Accept(this);
            }
            return codeString;
        }

        public object Visit(TextPrime obj)
        {
            string codeString = "";

            if (obj.NodeType == TextPrime.NodeTypes.StringValueTextPrime)
                codeString += obj.StringValue;
            else if (obj.NodeType == TextPrime.NodeTypes.IdentifiersTextPrime)
                codeString += obj.Value.Accept(this);

            if (obj.Prime != null)
            {
                codeString += " + ";
                codeString += obj.Prime.Accept(this);
            }
            return codeString;
        }

        public object Visit(Type obj)
        {
            return obj.ValueType;
        }

        public object Visit(Value obj)
        {
            string codeString = "";

            if (obj.NodeType == Value.NodeTypes.Value)
            {
                if (obj.Token1 == "Time")
                    codeString += "Time.deltaTime";
                else
                    codeString += obj.Token1;
            }

            else if (obj.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                codeString += obj.Token1;

                if (obj.IdentifiersPrime != null)
                {
                    string type = _symbolTable.Variables.Find(x => x.Name == obj.Token1).Type;
                    switch (type)
                    {
                        case "Camera":
                        case "Sprite":
                            type += "Controller";
                            break;
                        case "Text":
                            type = "UI" + type;
                            break;
                    }
                    codeString += ".GetComponent<" + type + ">()";
                    codeString += obj.IdentifiersPrime.Accept(this);
                }
            }

            else if (obj.NodeType == Value.NodeTypes.PrefixValue)
            {
                codeString += obj.Prefix1?.Accept(this);

                if (obj.Type == "Decimal")
                    codeString += obj.Token1 + "f";
                else
                    codeString += obj.Token1;
            }

            else if (obj.NodeType == Value.NodeTypes.PrefixValuePrefixValue)
            {
                codeString += "new Vector2(";
                codeString += obj.Prefix1?.Accept(this);
                codeString += obj.Token1 + "f";
                codeString += ", ";
                codeString += obj.Prefix2?.Accept(this);
                codeString += obj.Token2 + "f";
                codeString += ")";
            }

            return codeString;
        }

        public object Visit(PrefabMethods obj)
        {
            return obj.PrefabMethodType;
        }
    }
}
