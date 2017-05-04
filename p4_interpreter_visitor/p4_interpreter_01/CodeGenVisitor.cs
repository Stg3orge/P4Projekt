using System;
using System.CodeDom;
using System.Collections.Generic;
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

        private SymbolTable _symbolTable = new SymbolTable();

        public object Visit(SyntaxNode node)
        {
            return null;
        }

        public object Visit(StartupStucture obj)
        {
            string codeString = "";

            //<S> ::= <Declarations> startup '(' <DeclaringParameters> ')' <Commands> end startup <Declarations> GameLoop '(' <DeclaringParameters> ')' <Commands> end GameLoop <Declarations>


            if (obj.Declarations != null)
                codeString += (string)obj.Declarations.Accept(this);

            codeString += "void Start(";
            if(obj.DeclaringParameters != null)
                codeString += (string)obj.DeclaringParameters.Accept(this);

            codeString += ") {";

            if (obj.Commands != null)
                codeString += (string)obj.Commands.Accept(this);

            codeString += "}";

            if (obj.Declarations2 != null)
                codeString += (string)obj.Declarations2.Accept(this);

            codeString += "void Update(";
            if (obj.DeclaringParameters2 != null)
                codeString += (string)obj.DeclaringParameters2.Accept(this);

            codeString += ") {";

            if (obj.Commands2 != null)
                codeString += (string)obj.Commands2.Accept(this);

            codeString += "}";

            if (obj.Declarations3 != null)
                codeString += (string)obj.Declarations3.Accept(this);


            ////////////////////////////////////////////////////////////////////////////////////////////////////////////
            // TODO: Add Better method to fix spaceing in cs file.
            codeString = codeString.Replace(";", ";" + System.Environment.NewLine);
            codeString = codeString.Replace("{", System.Environment.NewLine + "{" + System.Environment.NewLine);
            codeString = codeString.Replace("}", "}" + System.Environment.NewLine);
            Form1.formtest.testString = codeString;
            //////////////////////////////////////////////////////////////////////////// This block is only for test.

            return codeString;
        }

        public object Visit(BooleanExpression obj)
        {
            string codeString = "";

            //<BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>

            codeString += (string)obj.Value1.Accept(this);

            if(obj.Expression1 != null)
                codeString += (string) obj.Expression1.Accept(this);

            codeString += (string)obj.ComparisonOperator.Accept(this);
            codeString += (string)obj.Value2.Accept(this);

            if (obj.Expression2 != null)
                codeString += (string)obj.Expression2.Accept(this);

            if (obj.BooleanExpressionExtension != null)
                codeString += (string)obj.BooleanExpressionExtension.Accept(this);

            return codeString;
        }

        public object Visit(BooleanExpressionExtension obj)
        {
            string codeString = "";

            //<BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
            if (obj.LogicalOperator != null)
                codeString += (string)obj.LogicalOperator.Accept(this);

            if (obj.BooleanExpression != null)
                codeString += (string)obj.BooleanExpression.Accept(this);

            return codeString;
        }

        public object Visit(CallingParameter obj)
        {
            string codeString = "";

            //<CallingParameter> ::= ',' <Value> <CallingParameter>
            codeString += ", ";

            if (obj.Value != null)
                codeString += (string)obj.Value.Accept(this);

            if (obj.Parameter != null)
                codeString += (string)obj.Parameter.Accept(this);

            return codeString;
        }

        public object Visit(CallingParameters obj)
        {
            string codeString = "";

            //<CallingParameters> ::= <Value> <CallingParameter>
            if (obj.Value != null)
                codeString += (string)obj.Value.Accept(this);

            if (obj.CallingParameter != null)
                codeString += (string)obj.CallingParameter.Accept(this);

            return codeString;
        }

        public object Visit(Commands obj)
        {
            string codeString = "";

            //<Commands> ::= <Declaration> ';' <Commands>
            if (obj.NodeType == Commands.NodeTypes.DeclarationCommands)
            {
                if (obj.Declaration != null)
                {
                    codeString += (string)obj.Declaration.Accept(this);
                    codeString += ";";
                }
            }

            //<Commands> ::= <Statement> <Commands>
            else if (obj.NodeType == Commands.NodeTypes.StatementCommands)
            {
                if (obj.Statement != null)
                    codeString += (string)obj.Statement.Accept(this);
            }

            if (obj.Commands1 != null)
                codeString += (string)obj.Commands1.Accept(this);

            return codeString;
        }

        public object Visit(ComparisonOperator obj)
        {
            string codeString = "";

            //<comparisonoperator> ::= 'is='
            //<comparisonoperator> ::= 'is<='
            //<comparisonoperator> ::= 'is>='
            //<comparisonoperator> ::= 'is<'
            //<comparisonoperator> ::= 'is>'
            //<comparisonoperator> ::= 'is!='
            //<comparisonoperator> ::= touches    

            string tempSwtichString = obj.ComparisonOperatorType.ToLower();

            switch (tempSwtichString)
            {
                case "is=":
                    codeString += " = ";
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
                    throw new NotImplementedException();
                    break;
            }

            return codeString;
        }

        public object Visit(Declaration obj)
        {
            string codeString = "";

            string tempSwitchString = (string) obj.TypeNode.Accept(this);

            //<Declaration> ::= <Type> Identifier
            switch (tempSwitchString.ToLower())
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
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" + 
                        obj.IdentifierNode + ".AddComponent<Character>()";
                    break;
                case "enemy":
                    throw new NotImplementedException();
                case "camera":
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" +
                        obj.IdentifierNode + ".AddComponent<CameraController>()";
                    break;
                case "square":
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" +
                        obj.IdentifierNode + ".AddComponent<Square>()";
                    break;
                case "triangle":
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" +
                        obj.IdentifierNode + ".AddComponent<Triangle>()";
                    break;
                case "sprite":
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" +
                        obj.IdentifierNode + ".AddComponent<SpriteController>()";
                    break;
                case "text":
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" +
                        obj.IdentifierNode + ".AddComponent<UIText>()";
                    break;
                case "trigger":
                    codeString += "GameObject " + obj.IdentifierNode + " = new GameObject();" +
                        obj.IdentifierNode + ".AddComponent<Trigger>()";
                    break;
            }
            return codeString;
        }               

        public object Visit(Declarations obj)
        {
            string codeString = "";

            //<Declarations> ::= <Declaration> ';' <Declarations>
            if (obj.NodeType == Declarations.NodeTypes.DeclarationDeclarations)
            {
                codeString += (string)obj.DeclarationNode.Accept(this);
                codeString += ";";
            }

            //<Declarations> ::= <MethodDeclaration> <Declarations>
            else if (obj.NodeType == Declarations.NodeTypes.MethodDeclarationDeclarations)
                codeString += (string)obj.MethodDeclarationNode.Accept(this);

            if(obj.DeclarationsNode != null)
                codeString += (string)obj.DeclarationsNode.Accept(this);

            return codeString;
        }

        public object Visit(DeclaringParameter obj)
        {
            string codeString = "";
            //<DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>

            if (obj.Declaration != null)
            {
                codeString += (string)obj.Declaration.Accept(this);
            }

            if (obj.Parameter != null)
            {
                codeString += ", ";
                codeString += (string)obj.Parameter.Accept(this);
            }


            return codeString;
        }

        public object Visit(DeclaringParameters obj)
        {
            string codeString = "";
            //<DeclaringParameters> ::= <Declaration> <DeclaringParameter>

            if (obj.Declaration != null)
            {
                codeString += (string)obj.Declaration.Accept(this);
            }

            if (obj.DeclaringParameter != null)
            {
                codeString += ", ";
                codeString += (string)obj.DeclaringParameter.Accept(this);
            }

            return codeString;
        }

        public object Visit(IfStatementExtend obj)
        {
            string codeString = "";

            //<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
            if (obj.NodeType == IfStatementExtend.NodeTypes.ElseIfStatement)
            {
                codeString += "else if ( ";

                if (obj.BooleanExpression != null)
                    codeString += (string) obj.BooleanExpression.Accept(this);

                codeString += " )";
                codeString += "{";

                if(obj.Commands != null)
                    codeString += (string)obj.Commands.Accept(this);

                codeString += "}";

                if (obj.StatementExtend != null)
                    codeString += (string)obj.StatementExtend.Accept(this);
            }

            //<ElseStatementExtend> ::= else <Commands>
            else if (obj.NodeType == IfStatementExtend.NodeTypes.ElseStatement)
            {
                codeString += "else {";

                if (obj.Commands != null)
                    codeString += (string)obj.Commands.Accept(this);

                codeString += "}";
            }

            return codeString;
        }

        public object Visit(Expression obj)
        {
            string codeString = "";

            //<Expression> ::= <operator> <Value> <Expression>
            if (obj.Operator != null)
                codeString += (string)obj.Operator.Accept(this);

            if (obj.Value != null)
                codeString += (string)obj.Value.Accept(this);

            if (obj.Expression1 != null)
                codeString += (string)obj.Expression1.Accept(this);

            return codeString;
        }

        public object Visit(IdentifiersPrime obj)
        {
            string codeString = "";

            //<IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
            codeString += "." + obj.Identifier;

            if (obj.Prime != null)
                codeString += (string)obj.Prime.Accept(this);

            return codeString;
        }

        public object Visit(LogicalOperator obj)
        {
            string codeString = "";

            //<logicaloperator> ::= or
            //<logicaloperator> ::= and
            codeString += obj.LogicalOperatorType;

            return codeString;
        }

        public object Visit(MethodDeclaration obj)
        {
            string codeString = "";

            //<MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method
            codeString += (string)obj.MethodType.Accept(this);
            codeString += " ";
            codeString += obj.Value;
            codeString += "(";
            if (obj.DeclaringParameters != null)
                codeString += (string) obj.DeclaringParameters.Accept(this);

            codeString += ") {";
            if (obj.Commands != null)
                codeString += (string)obj.Commands.Accept(this);

            if (obj.ReturnStatement != null)
                codeString += (string)obj.ReturnStatement.Accept(this);

            codeString += "}";

            return codeString;
        }

        public object Visit(MethodType obj)
        {
            string codeString = "";

            //<Methodtype> ::= Integer
            //<Methodtype> ::= Decimal
            //<Methodtype> ::= String
            //<Methodtype> ::= Boolean
            //<Methodtype> ::= Point
            //<Methodtype> ::= void

            string tempSwitchString = obj.MethodTypeValue.ToLower();

            switch (tempSwitchString)
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
            string codeString = "";

            //<operator> ::= '*'
            //<operator> ::= '+'
            //<operator> ::= '/'
            //<operator> ::= '-'
            codeString += obj.MathOperatorType;

            return codeString;
        }

        public object Visit(Prefix obj)
        {
            string codeString = "";

            //<Prefix> ::= '-'
            codeString += obj.PrefixSymbol;

            return codeString;
        }

        public object Visit(ReturnStatement obj)
        {
            string codeString = "";

            //<returnstatement> ::= return ';' 
            if (obj.NodeType == ReturnStatement.NodeTypes.ReturnNull)
            {
                // do noting
            }

            //<returnstatement> ::= return <Value> <Expression> ';'
            else if (obj.NodeType == ReturnStatement.NodeTypes.ReturnValue)
            {
                codeString += "return ";

                if (obj.Value != null)
                   codeString += (string)obj.Value.Accept(this);

                if (obj.Expression != null)
                    codeString += (string)obj.Expression.Accept(this);

                codeString += ";";
            }

            return codeString;
        }

        public object Visit(Statement obj)
        {
            string codeString = "";

            //<Statement> ::= write '(' <Text> ')' ';'                                                  // TODO: DONE
            if (obj.NodeType == Statement.NodeTypes.Write)
            {
                codeString += "Debug.Log(";
                codeString += (string)obj.Text.Accept(this);
                codeString += ");";
            }

            //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'                                // TODO: DONE
            else if (obj.NodeType == Statement.NodeTypes.Assign)
            {
                codeString += (string)obj.Value1.Accept(this);
                codeString += " = ";
                codeString += (string)obj.Value2.Accept(this);

                if(obj.Expression != null)
                    codeString += (string)obj.Expression.Accept(this);

                codeString += ";";
            }

            //<Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'                        // TODO: DONE
            else if (obj.NodeType == Statement.NodeTypes.Method)
            {
                codeString += (string)obj.Value1.Accept(this) + "(";

                if (obj.CallingParameters != null)
                    codeString += (string)obj.CallingParameters.Accept(this);

                codeString += ");";
            }

            //<Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'                      // TODO: FIX
            else if (obj.NodeType == Statement.NodeTypes.PrefabMethod)
            {
                if (obj.PrefabMethods.PrefabMethodType == "Move")           // TODO::::::::::::::: NEED FIX
                {
                    // TODO: Add Method to callingparameters to get all parameters &&&&& Returns only id and not .id.id
                    //Vector2 v2Start = new Vector2(obj.Position);
                    //Vector2 v2End = new Vector2(endPoint);
                    //float speed = 2f;
                    //Vector2.MoveTowards(v2Start, v2End, speed * Time.deltaTime);
                    codeString += "Vector2 v2Start = new Vector2(" + obj.CallingParameters.Value.Token1 + ");";                // Parameter1 
                    codeString += "Vector2 v2End = new Vector2(" + obj.CallingParameters.CallingParameter.Value.Token1 + ");"; // Parameter2
                    codeString += "float speed = " + obj.CallingParameters.CallingParameter.Parameter.Value.Token1 + "f;";     // Parameter3
                    codeString += "Vector2.MoveTowards(v2Start, v2End, speed + * Time.deltaTime);";                             // Done
                }
                else if (obj.PrefabMethods.PrefabMethodType == "Delete")
                {
                    codeString += "Destroy(";
                    codeString += (string)obj.CallingParameters.Accept(this);
                    codeString += ");";
                }
                else
                {
                    throw new Exception(); // PrefabMethod Could not be found
                }
            }

            //<Statement> ::= <Identifiers> '=' Call <Identifiers> '(' <CallingParameters> ')' ';'      // TODO: DONE
            else if (obj.NodeType == Statement.NodeTypes.AssignMethod)
            {
                codeString += (string)obj.Value1.Accept(this);
                codeString += " = ";
                codeString += (string) obj.Value2.Accept(this) + "(";

                if (obj.CallingParameters != null)
                    codeString += (string) obj.CallingParameters.Accept(this);

                codeString += ");";
            }

            //<Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'                // TODO: FIX/Delete
            else if (obj.NodeType == Statement.NodeTypes.AssignPrefabMethod)
            {
                // TODO: WTF fix plz
                throw new Exception();
            }

            //<ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if      // TODO: DONE I guess
            else if (obj.NodeType == Statement.NodeTypes.If)
            {
                codeString += "if(";
                codeString += (string) obj.BooleanExpression.Accept(this);
                codeString += ") {";
                codeString += (string)obj.Commands.Accept(this);
                codeString += "}";

                if (obj.IfStatementExtend != null)
                    codeString += (string)obj.IfStatementExtend.Accept(this);
            }

            //<ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while                        // TODO: DONE
            else if (obj.NodeType == Statement.NodeTypes.While)
            {
                codeString += "while(";
                codeString += (string) obj.BooleanExpression.Accept(this);
                codeString += ") {";
                codeString += (string) obj.Commands.Accept(this);
                codeString += "}";
            }

            return codeString;
        }

        public object Visit(Text obj)
        {
            string codeString = "";

            //<Text> ::= <Identifiers> <TextPrime>
            if (obj.NodeType == Text.NodeTypes.IdentifiersTextPrime)
                codeString += (string) obj.Value.Accept(this);

            //<Text> ::= StringValue <TextPrime>
            else if (obj.NodeType == Text.NodeTypes.StringValueTextPrime)
                codeString += obj.StringValue;

            // Used in both Rules
            if (obj.TextPrime != null)
            {
                codeString += " + ";
                codeString += (string)obj.TextPrime.Accept(this);
            }

            return codeString;
        }

        public object Visit(TextPrime obj)
        {
            string codeString = "";

            //<TextPrime> ::= '+' StringValue <TextPrime>
            if (obj.NodeType == TextPrime.NodeTypes.StringValueTextPrime)
                codeString += obj.StringValue;

            //<TextPrime> ::= '+' <Identifiers> <TextPrime>
            else if (obj.NodeType == TextPrime.NodeTypes.IdentifiersTextPrime)
                codeString += obj.Value.Accept(this);

            // Used in both Rules
            if (obj.Prime != null)
            {
                codeString += " + ";
                codeString += (string)obj.Prime.Accept(this);
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

            //<ValueKeywords> ::= Time
            //<Value> ::= StringValue
            //<BooleanValue> ::= false
            //<BooleanValue> ::= true
            if (obj.NodeType == Value.NodeTypes.Value)
                codeString += obj.Token1;

            //<Identifiers> ::= Identifier <IdentifiersPrime>
            else if (obj.NodeType == Value.NodeTypes.IdentifierIdentifiersPrime)
            {
                // ID.GetComponent<PrefabType>().PrimeID

                //codeString += obj.Token1;

                codeString += obj.Token1 + ".GetComponent<" + _symbolTable.Variables.Find(x => x.Name == obj.Token1).Type + ">()"; // TODO: add a way to add type. getparrent?


                if (obj.IdentifiersPrime != null)
                    codeString += (string)obj.IdentifiersPrime.Accept(this);
            }

            //<Value> ::= <Prefix> IntegerValue
            //<Value> ::= <Prefix> DecimalValue
            else if (obj.NodeType == Value.NodeTypes.PrefixValue)
            {
                if (obj.Prefix1 != null)
                    codeString += obj.Prefix1.Accept(this);

                codeString += obj.Token1;
            }

            //<Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'               // TODO: Note, skal måske laves om til en vector2
            else if (obj.NodeType == Value.NodeTypes.PrefixValuePrefixValue)
            {
                if(obj.Prefix1 != null)
                    codeString += obj.Prefix1.Accept(this);

                codeString += obj.Token1;

                codeString += ", ";

                if (obj.Prefix2 != null)
                    codeString += obj.Prefix2.Accept(this);

                codeString += obj.Token2;
            }

            return codeString;
        }

        public object Visit(PrefabMethods obj)
        {
            return obj.PrefabMethodType;
        }
    }
}
