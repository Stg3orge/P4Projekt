using GoldParser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms.PropertyGridInternal;
using System.Xml.Serialization;
using p4_interpreter_3.Nodes;

namespace p4_interpreter_3.expressions
{
    public class ParserContext
    {
        private VariableList _variables = new VariableList();
        private Parser _parser;

        public ParserContext(Parser parser)
        {
            _parser = parser;
        }

        public VariableList Variables
        {
            get { return _variables; }
        }



        public SyntaxNode GetObject() // TODO: DELETE INT CAST? && AND EXPRESSIONS
        {
            switch ((RuleConstants)_parser.ReductionRule.Index)
            {
                case RuleConstants.RULE_S_PROGRAM_LPAREN_RPAREN_END_PROGRAM_GAMELOOP_END_GAMELOOP:
                    //<S> ::= <Declarations> program '(' <DeclaringParameters> ')' <Commands> end program <Declarations> GameLoop <Commands> end GameLoop <Declarations>
                    return new ProgramStructure(this, Statement(0), Statement(3), Statement(5), Statement(8), Statement(10), Statement(13));



                case RuleConstants.RULE_COMMANDS:
                    //<Commands> ::= <Statement1> <Commands>
                    return new StatementCommands(this,Statement(0), Statement(1));

                case RuleConstants.RULE_COMMANDS_SEMI:
                    //<Commands> ::= <Declaration> ';' <Commands>
                    return new DeclarationCommands(this,Statement(0), Statement(2));

                //case RuleConstants.RULE_STATEMENT_WRITE_LPAREN_RPAREN_SEMI:
                //    //<Statement> ::= write '(' <Text> ')' ';'
                //    return new WriteStatement(this,Expression(2));

                case RuleConstants.RULE_STATEMENT_EQ_SEMI:
                    //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
                    return new AssignmentStatement(this,Statement(0), Statement(2), Expression(3));

                //case (int)RuleConstants.RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI:
                //    //<Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
                //    return new CallMethod(this,Statement(1), Statement(3));

                //case (int)RuleConstants.RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI2:
                //    //<Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'
                //    return new CallPrefabMethod(this,Statement(1), Statement(3));

                //case (int)RuleConstants.RULE_CONTROLSTATEMENTS_IF_LPAREN_RPAREN_END_IF:
                //    //<ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if
                //    return new IfControlStatement(this, Expression(2), Statement(4), Statement(5));

                //case (int)RuleConstants.RULE_CONTROLSTATEMENTS_WHILE_LPAREN_RPAREN_END_WHILE:
                //    //<ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while
                //    return new WhileControlStatement(this, Expression(2), Statement(4));

                //case (int)RuleConstants.RULE_ELSEIFSTATEMENTEXTEND_ELSEIF_LPAREN_RPAREN:
                //    //<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
                //    return new ElseIfControlStatement(this, Expression(2), Statement(4), Statement(5));

                //case (int)RuleConstants.RULE_ELSESTATEMENTEXTEND_ELSE:
                //    //<ElseStatementExtend> ::= else <Commands>
                //    return new ElseControlStatement(this,Statement(1));

                case RuleConstants.RULE_DECLARATION_IDENTIFIER:
                    //<Declaration> ::= <Type> Identifier
                    //Variables.Add(Token(1), null);
                    return new TypeDeclaration(this,Statement(0), Token(1));

                case RuleConstants.RULE_DECLARATIONS_SEMI:
                    //<Declarations> ::= <Declaration> ';' <Declarations>
                    return new DeclarationList(this,Statement(0), Statement(2));

                //case (int)RuleConstants.RULE_DECLARATIONS:
                //    //<Declarations> ::= <MethodDeclaration> <Declarations>
                //    return new DeclarationMethodDeclarationList(this,Statement(0), Statement(1));

                //case (int)RuleConstants.RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_END_METHOD:
                //    //<MethodDeclaration> ::= Identifier '(' <DeclaringParameters> ')' <Commands> end method
                //    return new MethodDeclaration(this,Token(0), Statement(2), Statement(4));
                      
                    

                    // TODO: Make To one
                //case (int)RuleConstants.RULE_CALLINGPARAMETERS:
                //    //<CallingParameters> ::= <Value> <CallingParameter>
                //    return new MethodParameter(this,Expression(0), Statement(1));
                                                                                                    
                //case (int)RuleConstants.RULE_CALLINGPARAMETER_COMMA:
                //    //<CallingParameter> ::= ',' <Value> <CallingParameter>
                //    return MethodParameter(this,Expression(1), Statement(2));                       // TODO: is Type/Value an Expression/Statement or a Token

                    // TODO: Make to one
                case RuleConstants.RULE_DECLARINGPARAMETERS:
                    //<DeclaringParameters> ::= <Declaration> <DeclaringParameter>
                    return new DeclaringParameter(this, Statement(0), Statement(1));

                case RuleConstants.RULE_DECLARINGPARAMETER_COMMA:
                    //<DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
                    return new DeclaringParameter(this, Statement(1), Statement(2));





                case RuleConstants.RULE_EXPRESSION:
                    //<Expression> ::= <operator> <Value> <Expression>
                    return new OperatorExpression(this, Statement(0), Statement(1), Expression(2));

                //case (int)RuleConstants.RULE_BOOLEANEXPRESSION:
                //    //<BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>
                //    return new BooleanExpression(this, Statement(0), Expression(1), Statement(2), Expression(3), Expression(4), Statement(5));

                //case (int)RuleConstants.RULE_BOOLEANEXPRESSIONEXTENSION:
                //    //<BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
                //    return new BooleanExpressionExtension(Statement(0), Expression(1));





                // TODO: Remove Single Tokens rules?
                //case (int)RuleConstants.RULE_LOGICALOPERATOR_OR:
                //    //<logicaloperator> ::= or
                //    return null;

                //case (int)RuleConstants.RULE_LOGICALOPERATOR_AND:
                //    //<logicaloperator> ::= and
                //    return null;

                //case (int)RuleConstants.RULE_OPERATOR_TIMES:
                //    //<operator> ::= '*'
                //    return null;



                // TODO: Return Token.TextString
                case RuleConstants.RULE_OPERATOR_PLUS:
                    //<operator> ::= '+'
                    return new Operator(this, Token(0));






                //case (int)RuleConstants.RULE_OPERATOR_DIV:
                //    //<operator> ::= '/'
                //    return null;

                //case (int)RuleConstants.RULE_OPERATOR_MINUS:
                //    //<operator> ::= '-'
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_ISEQ:
                //    //<comparisonoperator> ::= 'is='
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_ISLTEQ:
                //    //<comparisonoperator> ::= 'is<='
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_ISGTEQ:
                //    //<comparisonoperator> ::= 'is>='
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_ISLT:
                //    //<comparisonoperator> ::= 'is<'
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_ISGT:
                //    //<comparisonoperator> ::= 'is>'
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_ISEXCLAMEQ:
                //    //<comparisonoperator> ::= 'is!='
                //    return null;

                //case (int)RuleConstants.RULE_COMPARISONOPERATOR_TOUCHES:
                //    //<comparisonoperator> ::= touches
                //    return null;




                //case (int)RuleConstants.RULE_TEXT_STRINGVALUE:
                //    //<Text> ::= StringValue <TextPrime>
                //    return new StringValue(this, Token(0), Statement(1));

                //case (int)RuleConstants.RULE_TEXT:
                //    //<Text> ::= <Identifiers> <TextPrime>
                //    return new TextStatement(this, Statement(0), Statement(1) );

                //case (int)RuleConstants.RULE_TEXTPRIME_PLUS:
                //    //<TextPrime> ::= '+' <Identifiers> <TextPrime>
                //    return new TextPrime(this, Statement(1), Statement(2));

                //case (int)RuleConstants.RULE_TEXTPRIME_PLUS_STRINGVALUE:
                //    //<TextPrime> ::= '+' StringValue <TextPrime>
                //    return new TextPrime(this, Token(1), Statement(2));




                // TODO: Return Token.TextString
                case RuleConstants.RULE_TYPE_INTEGER:
                    //<Type> ::= Integer
                    return new ValueCreator(this, Token(0));

                case RuleConstants.RULE_TYPE_DECIMAL:
                    //<Type> ::= Decimal
                    return new ValueCreator(this, Token(0));





                //case (int)RuleConstants.RULE_TYPE_STRING:
                //    //<Type> ::= String
                //    return null;

                //case (int)RuleConstants.RULE_TYPE_BOOLEAN:
                //    //<Type> ::= Boolean
                //    return null;

                //case (int)RuleConstants.RULE_TYPE_POINT:
                //    //<Type> ::= Point
                //    return null;

                // TODO: DELETE
                case RuleConstants.RULE_TYPE:
                    //<Type> ::= <PrefabClasses>
                    return Statement(0);

                //case (int)RuleConstants.RULE_VALUE:
                //    //<Value> ::= <Identifiers>
                //    return null;



                case RuleConstants.RULE_VALUE_INTEGERVALUE:
                    //<Value> ::= <Prefix> IntegerValue
                    return new TypeValueCreator(this, Statement(0), Token(1));

                case RuleConstants.RULE_VALUE_DECIMALVALUE:
                    //<Value> ::= <Prefix> DecimalValue
                    return new TypeValueCreator(this, Statement(0), Token(1));

                //case (int)RuleConstants.RULE_VALUE_STRINGVALUE:
                //    //<Value> ::= StringValue
                //    return null;

                //case (int)RuleConstants.RULE_VALUE2:
                //    //<Value> ::= <BooleanValue>
                //    return null;

                //case (int)RuleConstants.RULE_VALUE_LPAREN_DECIMALVALUE_COMMA_DECIMALVALUE_RPAREN:
                //    //<Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'
                //    return null;

                //case (int)RuleConstants.RULE_VALUE3:
                //    //<Value> ::= <ValueKeywords>
                //    return null;

                //case (int)RuleConstants.RULE_VALUEKEYWORDS_TIME:
                //    //<ValueKeywords> ::= Time
                //    return null;

                //case RuleConstants.RULE_PREFIX_MINUS:
                //    //<Prefix> ::= '-'
                //    return Token(0);

                //case (int)RuleConstants.RULE_BOOLEANVALUE_TRUE:
                //    //<BooleanValue> ::= true
                //    return null;

                //case (int)RuleConstants.RULE_BOOLEANVALUE_FALSE:
                //    //<BooleanValue> ::= false
                //    return null;

                case RuleConstants.RULE_IDENTIFIERS_IDENTIFIER:
                    //<Identifiers> ::= Identifier <IdentifiersPrime>
                    Variables.Add(Token(0), null);
                    return new IdentifiersStatement(this, Token(0), Statement(1));

                case RuleConstants.RULE_IDENTIFIERSPRIME_DOT_IDENTIFIER:
                    //<IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
                    Variables.Add(Token(1), null);
                    return new IdentifiersPrimeStatement(this, Token(1), Statement(2));

                case RuleConstants.RULE_PREFABCLASSES_CHARACTER:
                    //<PrefabClasses> ::= Character
                    return new PrefabCreator(this, Token(0));

                //case (int)RuleConstants.RULE_PREFABCLASSES_ENEMY:
                //    //<PrefabClasses> ::= Enemy
                //    return null;

                //case (int)RuleConstants.RULE_PREFABCLASSES_CAMERA:
                //    //<PrefabClasses> ::= Camera
                //    return null;

                //case (int)RuleConstants.RULE_PREFABCLASSES_SQUARE:
                //    //<PrefabClasses> ::= Square
                //    return null;

                //case (int)RuleConstants.RULE_PREFABCLASSES_TRIANGLE:
                //    //<PrefabClasses> ::= Triangle
                //    return null;

                //case (int)RuleConstants.RULE_PREFABCLASSES_SPRITE:
                //    //<PrefabClasses> ::= Sprite
                //    return null;

                //case (int)RuleConstants.RULE_PREFABCLASSES_TEXT:
                //    //<PrefabClasses> ::= Text
                //    return null;

                //case (int)RuleConstants.RULE_PREFABCLASSES_TRIGGER:
                //    //<PrefabClasses> ::= Trigger
                //    return null;

                //case (int)RuleConstants.RULE_PREFABMETHODS_MOVE:
                //    //<PrefabMethods> ::= Move
                //    return null;

                //case (int)RuleConstants.RULE_PREFABMETHODS_DELETE:
                //    //<PrefabMethods> ::= Delete
                //    return null;

                default:
                    return null;
                //throw new RuleException("Unknown rule: Does your CGT Match your Code Revision?");
            }

        }





        private Expression Expression(int index)
        {
            return (Expression)_parser.GetReductionSyntaxNode(index);
        }

        private Statement Statement(int index)
        {
            return (Statement)_parser.GetReductionSyntaxNode(index);
        }

        private string Token(int index)
        {
            return (string)_parser.GetReductionSyntaxNode(index);
        }

        public string GetTokenText() // TODO: DELETE INT CAST?
        {
            // We need text of the following tokens for synatx tree creation.
            switch (_parser.TokenSymbol.Index)
            {
                case (int)SymbolConstants.SYMBOL_MINUS:
                case (int)SymbolConstants.SYMBOL_LPAREN:
                case (int)SymbolConstants.SYMBOL_RPAREN:
                case (int)SymbolConstants.SYMBOL_TIMES:
                case (int)SymbolConstants.SYMBOL_COMMA:
                case (int)SymbolConstants.SYMBOL_DOT:
                case (int)SymbolConstants.SYMBOL_DIV:
                case (int)SymbolConstants.SYMBOL_SEMI:
                case (int)SymbolConstants.SYMBOL_PLUS:
                case (int)SymbolConstants.SYMBOL_EQ:
                case (int)SymbolConstants.SYMBOL_AND:
                case (int)SymbolConstants.SYMBOL_BOOLEAN:
                case (int)SymbolConstants.SYMBOL_CALL:
                case (int)SymbolConstants.SYMBOL_CAMERA:
                case (int)SymbolConstants.SYMBOL_CHARACTER:              
                case (int)SymbolConstants.SYMBOL_DECIMAL:
                case (int)SymbolConstants.SYMBOL_DECIMALVALUE:
                case (int)SymbolConstants.SYMBOL_DELETE:
                case (int)SymbolConstants.SYMBOL_ELSE:
                case (int)SymbolConstants.SYMBOL_ELSEIF:
                case (int)SymbolConstants.SYMBOL_END:
                case (int)SymbolConstants.SYMBOL_ENEMY:
                case (int)SymbolConstants.SYMBOL_FALSE:
                case (int)SymbolConstants.SYMBOL_GAMELOOP:
                case (int)SymbolConstants.SYMBOL_IDENTIFIER:
                case (int)SymbolConstants.SYMBOL_IF:
                case (int)SymbolConstants.SYMBOL_INTEGER:
                case (int)SymbolConstants.SYMBOL_INTEGERVALUE:
                case (int)SymbolConstants.SYMBOL_ISEXCLAMEQ:
                case (int)SymbolConstants.SYMBOL_ISLT:
                case (int)SymbolConstants.SYMBOL_ISLTEQ:
                case (int)SymbolConstants.SYMBOL_ISEQ:
                case (int)SymbolConstants.SYMBOL_ISGT:
                case (int)SymbolConstants.SYMBOL_ISGTEQ:
                case (int)SymbolConstants.SYMBOL_METHOD:
                case (int)SymbolConstants.SYMBOL_MOVE:
                case (int)SymbolConstants.SYMBOL_OR:
                case (int)SymbolConstants.SYMBOL_POINT:
                case (int)SymbolConstants.SYMBOL_PROGRAM:
                case (int)SymbolConstants.SYMBOL_SPRITE:
                case (int)SymbolConstants.SYMBOL_SQUARE:
                case (int)SymbolConstants.SYMBOL_STRING:
                case (int)SymbolConstants.SYMBOL_STRINGVALUE:
                case (int)SymbolConstants.SYMBOL_TEXT:
                case (int)SymbolConstants.SYMBOL_TIME:
                case (int)SymbolConstants.SYMBOL_TOUCHES:
                case (int)SymbolConstants.SYMBOL_TRIANGLE:
                case (int)SymbolConstants.SYMBOL_TRIGGER:
                case (int)SymbolConstants.SYMBOL_TRUE:
                case (int)SymbolConstants.SYMBOL_WHILE:
                case (int)SymbolConstants.SYMBOL_WRITE:
                    return _parser.TokenText;

                //default:
                //    throw new SymbolException("You don't want the text of a non-terminal symbol");
            }
            return null;
        }




        enum SymbolConstants : int
        {
            SYMBOL_EOF = 0, // (EOF)
            SYMBOL_ERROR = 1, // (Error)
            SYMBOL_WHITESPACE = 2, // Whitespace
            SYMBOL_MINUS = 3, // '-'
            SYMBOL_LPAREN = 4, // '('
            SYMBOL_RPAREN = 5, // ')'
            SYMBOL_TIMES = 6, // '*'
            SYMBOL_COMMA = 7, // ','
            SYMBOL_DOT = 8, // '.'
            SYMBOL_DIV = 9, // '/'
            SYMBOL_SEMI = 10, // ';'
            SYMBOL_PLUS = 11, // '+'
            SYMBOL_EQ = 12, // '='
            SYMBOL_AND = 13, // and
            SYMBOL_BOOLEAN = 14, // Boolean
            SYMBOL_CALL = 15, // Call
            SYMBOL_CAMERA = 16, // Camera
            SYMBOL_CHARACTER = 17, // Character
            SYMBOL_DECIMAL = 18, // Decimal
            SYMBOL_DECIMALVALUE = 19, // DecimalValue
            SYMBOL_DELETE = 20, // Delete
            SYMBOL_ELSE = 21, // else
            SYMBOL_ELSEIF = 22, // 'else if'
            SYMBOL_END = 23, // end
            SYMBOL_ENEMY = 24, // Enemy
            SYMBOL_FALSE = 25, // false
            SYMBOL_GAMELOOP = 26, // GameLoop
            SYMBOL_IDENTIFIER = 27, // Identifier
            SYMBOL_IF = 28, // if
            SYMBOL_INTEGER = 29, // Integer
            SYMBOL_INTEGERVALUE = 30, // IntegerValue
            SYMBOL_ISEXCLAMEQ = 31, // 'is!='
            SYMBOL_ISLT = 32, // 'is<'
            SYMBOL_ISLTEQ = 33, // 'is<='
            SYMBOL_ISEQ = 34, // 'is='
            SYMBOL_ISGT = 35, // 'is>'
            SYMBOL_ISGTEQ = 36, // 'is>='
            SYMBOL_METHOD = 37, // method
            SYMBOL_MOVE = 38, // Move
            SYMBOL_OR = 39, // or
            SYMBOL_POINT = 40, // Point
            SYMBOL_PROGRAM = 41, // program
            SYMBOL_SPRITE = 42, // Sprite
            SYMBOL_SQUARE = 43, // Square
            SYMBOL_STRING = 44, // String
            SYMBOL_STRINGVALUE = 45, // StringValue
            SYMBOL_TEXT = 46, // Text
            SYMBOL_TIME = 47, // Time
            SYMBOL_TOUCHES = 48, // touches
            SYMBOL_TRIANGLE = 49, // Triangle
            SYMBOL_TRIGGER = 50, // Trigger
            SYMBOL_TRUE = 51, // true
            SYMBOL_WHILE = 52, // while
            SYMBOL_WRITE = 53, // write
            SYMBOL_BOOLEANEXPRESSION = 54, // <BooleanExpression>
            SYMBOL_BOOLEANEXPRESSIONEXTENSION = 55, // <BooleanExpressionExtension>
            SYMBOL_BOOLEANVALUE = 56, // <BooleanValue>
            SYMBOL_CALLINGPARAMETER = 57, // <CallingParameter>
            SYMBOL_CALLINGPARAMETERS = 58, // <CallingParameters>
            SYMBOL_COMMANDS = 59, // <Commands>
            SYMBOL_COMPARISONOPERATOR = 60, // <comparisonoperator>
            SYMBOL_CONTROLSTATEMENTS = 61, // <ControlStatements>
            SYMBOL_DECLARATION = 62, // <Declaration>
            SYMBOL_DECLARATIONS = 63, // <Declarations>
            SYMBOL_DECLARINGPARAMETER = 64, // <DeclaringParameter>
            SYMBOL_DECLARINGPARAMETERS = 65, // <DeclaringParameters>
            SYMBOL_ELSEIFSTATEMENTEXTEND = 66, // <ElseIfStatementExtend>
            SYMBOL_ELSESTATEMENTEXTEND = 67, // <ElseStatementExtend>
            SYMBOL_EXPRESSION = 68, // <Expression>
            SYMBOL_IDENTIFIERS = 69, // <Identifiers>
            SYMBOL_IDENTIFIERSPRIME = 70, // <IdentifiersPrime>
            SYMBOL_LOGICALOPERATOR = 71, // <logicaloperator>
            SYMBOL_METHODDECLARATION = 72, // <MethodDeclaration>
            SYMBOL_OPERATOR = 73, // <operator>
            SYMBOL_PREFABCLASSES = 74, // <PrefabClasses>
            SYMBOL_PREFABMETHODS = 75, // <PrefabMethods>
            SYMBOL_PREFIX = 76, // <Prefix>
            SYMBOL_S = 77, // <S>
            SYMBOL_STATEMENT = 78, // <Statement>
            SYMBOL_TEXT2 = 79, // <Text>
            SYMBOL_TEXTPRIME = 80, // <TextPrime>
            SYMBOL_TYPE = 81, // <Type>
            SYMBOL_VALUE = 82, // <Value>
            SYMBOL_VALUEKEYWORDS = 83  // <ValueKeywords>
        };

        enum RuleConstants : int
        {
            RULE_S_PROGRAM_LPAREN_RPAREN_END_PROGRAM_GAMELOOP_END_GAMELOOP = 0, // <S> ::= <Declarations> program '(' <DeclaringParameters> ')' <Commands> end program <Declarations> GameLoop <Commands> end GameLoop <Declarations>
            RULE_COMMANDS = 1, // <Commands> ::= <Statement> <Commands>
            RULE_COMMANDS_SEMI = 2, // <Commands> ::= <Declaration> ';' <Commands>
            RULE_COMMANDS2 = 3, // <Commands> ::= 
            RULE_STATEMENT_WRITE_LPAREN_RPAREN_SEMI = 4, // <Statement> ::= write '(' <Text> ')' ';'
            RULE_STATEMENT_EQ_SEMI = 5, // <Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
            RULE_STATEMENT = 6, // <Statement> ::= <ControlStatements>
            RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI = 7, // <Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
            RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI2 = 8, // <Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'
            RULE_CONTROLSTATEMENTS_IF_LPAREN_RPAREN_END_IF = 9, // <ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if
            RULE_CONTROLSTATEMENTS_WHILE_LPAREN_RPAREN_END_WHILE = 10, // <ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while
            RULE_ELSEIFSTATEMENTEXTEND_ELSEIF_LPAREN_RPAREN = 11, // <ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
            RULE_ELSEIFSTATEMENTEXTEND = 12, // <ElseIfStatementExtend> ::= <ElseStatementExtend>
            RULE_ELSESTATEMENTEXTEND_ELSE = 13, // <ElseStatementExtend> ::= else <Commands>
            RULE_ELSESTATEMENTEXTEND = 14, // <ElseStatementExtend> ::= 
            RULE_DECLARATION_IDENTIFIER = 15, // <Declaration> ::= <Type> Identifier
            RULE_DECLARATIONS_SEMI = 16, // <Declarations> ::= <Declaration> ';' <Declarations>
            RULE_DECLARATIONS = 17, // <Declarations> ::= <MethodDeclaration> <Declarations>
            RULE_DECLARATIONS2 = 18, // <Declarations> ::= 
            RULE_METHODDECLARATION_IDENTIFIER_LPAREN_RPAREN_END_METHOD = 19, // <MethodDeclaration> ::= Identifier '(' <DeclaringParameters> ')' <Commands> end method
            RULE_CALLINGPARAMETERS = 20, // <CallingParameters> ::= <Value> <CallingParameter>
            RULE_CALLINGPARAMETERS2 = 21, // <CallingParameters> ::= 
            RULE_CALLINGPARAMETER_COMMA = 22, // <CallingParameter> ::= ',' <Value> <CallingParameter>
            RULE_CALLINGPARAMETER = 23, // <CallingParameter> ::= 
            RULE_DECLARINGPARAMETERS = 24, // <DeclaringParameters> ::= <Declaration> <DeclaringParameter>
            RULE_DECLARINGPARAMETERS2 = 25, // <DeclaringParameters> ::= 
            RULE_DECLARINGPARAMETER_COMMA = 26, // <DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
            RULE_DECLARINGPARAMETER = 27, // <DeclaringParameter> ::= 
            RULE_EXPRESSION = 28, // <Expression> ::= <operator> <Value> <Expression>
            RULE_EXPRESSION2 = 29, // <Expression> ::= 
            RULE_BOOLEANEXPRESSION = 30, // <BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>
            RULE_BOOLEANEXPRESSIONEXTENSION = 31, // <BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
            RULE_BOOLEANEXPRESSIONEXTENSION2 = 32, // <BooleanExpressionExtension> ::= 
            RULE_LOGICALOPERATOR_OR = 33, // <logicaloperator> ::= or
            RULE_LOGICALOPERATOR_AND = 34, // <logicaloperator> ::= and
            RULE_OPERATOR_TIMES = 35, // <operator> ::= '*'
            RULE_OPERATOR_PLUS = 36, // <operator> ::= '+'
            RULE_OPERATOR_DIV = 37, // <operator> ::= '/'
            RULE_OPERATOR_MINUS = 38, // <operator> ::= '-'
            RULE_COMPARISONOPERATOR_ISEQ = 39, // <comparisonoperator> ::= 'is='
            RULE_COMPARISONOPERATOR_ISLTEQ = 40, // <comparisonoperator> ::= 'is<='
            RULE_COMPARISONOPERATOR_ISGTEQ = 41, // <comparisonoperator> ::= 'is>='
            RULE_COMPARISONOPERATOR_ISLT = 42, // <comparisonoperator> ::= 'is<'
            RULE_COMPARISONOPERATOR_ISGT = 43, // <comparisonoperator> ::= 'is>'
            RULE_COMPARISONOPERATOR_ISEXCLAMEQ = 44, // <comparisonoperator> ::= 'is!='
            RULE_COMPARISONOPERATOR_TOUCHES = 45, // <comparisonoperator> ::= touches
            RULE_TEXT_STRINGVALUE = 46, // <Text> ::= StringValue <TextPrime>
            RULE_TEXT = 47, // <Text> ::= <Identifiers> <TextPrime>
            RULE_TEXT2 = 48, // <Text> ::= 
            RULE_TEXTPRIME_PLUS = 49, // <TextPrime> ::= '+' <Identifiers> <TextPrime>
            RULE_TEXTPRIME_PLUS_STRINGVALUE = 50, // <TextPrime> ::= '+' StringValue <TextPrime>
            RULE_TEXTPRIME = 51, // <TextPrime> ::= 
            RULE_TYPE_INTEGER = 52, // <Type> ::= Integer
            RULE_TYPE_DECIMAL = 53, // <Type> ::= Decimal
            RULE_TYPE_STRING = 54, // <Type> ::= String
            RULE_TYPE_BOOLEAN = 55, // <Type> ::= Boolean
            RULE_TYPE_POINT = 56, // <Type> ::= Point
            RULE_TYPE = 57, // <Type> ::= <PrefabClasses>
            RULE_VALUE = 58, // <Value> ::= <Identifiers>
            RULE_VALUE_INTEGERVALUE = 59, // <Value> ::= <Prefix> IntegerValue
            RULE_VALUE_DECIMALVALUE = 60, // <Value> ::= <Prefix> DecimalValue
            RULE_VALUE_STRINGVALUE = 61, // <Value> ::= StringValue
            RULE_VALUE2 = 62, // <Value> ::= <BooleanValue>
            RULE_VALUE_LPAREN_DECIMALVALUE_COMMA_DECIMALVALUE_RPAREN = 63, // <Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'
            RULE_VALUE3 = 64, // <Value> ::= <ValueKeywords>
            RULE_VALUEKEYWORDS_TIME = 65, // <ValueKeywords> ::= Time
            RULE_PREFIX_MINUS = 66, // <Prefix> ::= '-'
            RULE_PREFIX = 67, // <Prefix> ::= 
            RULE_BOOLEANVALUE_TRUE = 68, // <BooleanValue> ::= true
            RULE_BOOLEANVALUE_FALSE = 69, // <BooleanValue> ::= false
            RULE_IDENTIFIERS_IDENTIFIER = 70, // <Identifiers> ::= Identifier <IdentifiersPrime>
            RULE_IDENTIFIERSPRIME_DOT_IDENTIFIER = 71, // <IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
            RULE_IDENTIFIERSPRIME = 72, // <IdentifiersPrime> ::= 
            RULE_PREFABCLASSES_CHARACTER = 73, // <PrefabClasses> ::= Character
            RULE_PREFABCLASSES_ENEMY = 74, // <PrefabClasses> ::= Enemy
            RULE_PREFABCLASSES_CAMERA = 75, // <PrefabClasses> ::= Camera
            RULE_PREFABCLASSES_SQUARE = 76, // <PrefabClasses> ::= Square
            RULE_PREFABCLASSES_TRIANGLE = 77, // <PrefabClasses> ::= Triangle
            RULE_PREFABCLASSES_SPRITE = 78, // <PrefabClasses> ::= Sprite
            RULE_PREFABCLASSES_TEXT = 79, // <PrefabClasses> ::= Text
            RULE_PREFABCLASSES_TRIGGER = 80, // <PrefabClasses> ::= Trigger
            RULE_PREFABMETHODS_MOVE = 81, // <PrefabMethods> ::= Move
            RULE_PREFABMETHODS_DELETE = 82  // <PrefabMethods> ::= Delete
        };

        [Serializable()]
        public class SymbolException : System.Exception
        {
            public SymbolException(string message) : base(message)
            {
            }

            public SymbolException(string message,
                Exception inner) : base(message, inner)
            {
            }

            protected SymbolException(SerializationInfo info,
                StreamingContext context) : base(info, context)
            {
            }

        }

        [Serializable()]
        public class RuleException : System.Exception
        {

            public RuleException(string message) : base(message)
            {
            }

            public RuleException(string message,
                                 Exception inner) : base(message, inner)
            {
            }

            protected RuleException(SerializationInfo info,
                                    StreamingContext context) : base(info, context)
            {
            }

        }
    }
}
