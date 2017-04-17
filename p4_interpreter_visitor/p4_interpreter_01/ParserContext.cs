using System;
using System.Net;
using System.Runtime.Serialization;
using GoldParser;
using p4_interpreter_01.Nodes;

namespace p4_interpreter_01
{
    public class ParserContext
    {
        private Parser _parser;
        private SymbolTable _symbolTable = new SymbolTable();

        public ParserContext(Parser parser)
        {
            _parser = parser;
        }

        public SymbolTable symbols
        {
            get {return _symbolTable; }
        }

        public SyntaxNode GetObject()
        {
            switch ((RuleConstants)_parser.ReductionRule.Index)
            {
                case RuleConstants.RULE_S_STARTUP_LPAREN_RPAREN_END_STARTUP_GAMELOOP_LPAREN_RPAREN_END_GAMELOOP:
                    //<S> ::= <Declarations> startup '(' <DeclaringParameters> ')' <Commands> end startup <Declarations> GameLoop '(' <DeclaringParameters> ')' <Commands> end GameLoop <Declarations>
                    return new StartupStucture(this, Node(0), Node(3), Node(5), Node(7), Node(10), Node(12), Node(14));

                case RuleConstants.RULE_COMMANDS:
                    //<Commands> ::= <Statement> <Commands>
                    return new DeclarationCommand(this, Node(0), Node(1));

                case RuleConstants.RULE_COMMANDS_SEMI:
                    //<Commands> ::= <Declaration> ';' <Commands>
                    return new DeclarationCommands(this, Node(0), Node(2));

                case RuleConstants.RULE_STATEMENT_WRITE_LPAREN_RPAREN_SEMI:
                    //<Statement> ::= write '(' <Text> ')' ';'
                    return new WriteStatement(this, Node(2));

                case RuleConstants.RULE_STATEMENT_EQ_SEMI:
                    //<Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
                    return new RuleAssignment(this, Node(0), Node(2), Node(3));

                case RuleConstants.RULE_STATEMENT:
                    //<Statement> ::= <ControlStatements>
                    return new RuleControlStatements(this, Node(0));

                case RuleConstants.RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI:
                    //<Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
                    return new RuleStatementIdentifiers(this, Node(1), Node(3));

                case RuleConstants.RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI2:
                    //<Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'
                    return new RuleStatementPrefabMethods(this, Node(1), Node(3));

                case RuleConstants.RULE_STATEMENT_EQ_CALL_LPAREN_RPAREN_SEMI:
                    //<Statement> ::= <Identifiers> '=' Call <Identifiers> '(' <CallingParameters> ')' ';'
                    return new CallMethod(this, Node(0), Node(3), Node(5));

                case RuleConstants.RULE_STATEMENT_EQ_CALL_LPAREN_RPAREN_SEMI2:
                    //<Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'
                    return new CallPrefabMethod(this, Node(0), Node(3), Node(5));

                case RuleConstants.RULE_CONTROLSTATEMENTS_IF_LPAREN_RPAREN_END_IF:
                    //<ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if
                    return new RuleControlstatementIf(this, Node(2), Node(4), Node(5));

                case RuleConstants.RULE_CONTROLSTATEMENTS_WHILE_LPAREN_RPAREN_END_WHILE:
                    //<ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while
                    return new RuleControlstatementWhile(this, Node(2), Node(4));

                case RuleConstants.RULE_ELSEIFSTATEMENTEXTEND_ELSEIF_LPAREN_RPAREN:
                    //<ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
                    return new RuleElseifStatementElseif(this, Node(2), Node(4), Node(5));

                case RuleConstants.RULE_ELSEIFSTATEMENTEXTEND:
                    //<ElseIfStatementExtend> ::= <ElseStatementExtend>
                    return new RuleElseifStatementExtend(this, Node(0));

                case RuleConstants.RULE_ELSESTATEMENTEXTEND_ELSE:
                    //<ElseStatementExtend> ::= else <Commands>
                    return new RuleElseStatementExtendElse(this, Node(1));

                case RuleConstants.RULE_DECLARATION_IDENTIFIER:
                    //<Declaration> ::= <Type> Identifier
                    return new TypeDeclaration(this, Node(0), Token(1));

                case RuleConstants.RULE_DECLARATIONS_SEMI:
                    //<Declarations> ::= <Declaration> ';' <Declarations>
                    return new DeclarationList(this, Node(0), Node(2));

                case RuleConstants.RULE_DECLARATIONS:
                    //<Declarations> ::= <MethodDeclaration> <Declarations>
                    return new MethodDeclarationDeclarations(this, Node(0), Node(1));

                case RuleConstants.RULE_METHODDECLARATION_METHOD_IDENTIFIER_LPAREN_RPAREN_END_METHOD:
                    //<MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method
                    return new MethodDeclaration(this, Node(1), Node(4), Node(6), Node(7));

                case RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI:
                    //<returnstatement> ::= return <Value> <Expression> ';'
                    return new Return(this, Node(1), Node(2));

                case RuleConstants.RULE_RETURNSTATEMENT_RETURN_SEMI2:
                    //<returnstatement> ::= return ';'                                                         // TODO: FIX
                    return new ReturnNull(this, Token(0));                                                         // TODO: FIX

                case RuleConstants.RULE_CALLINGPARAMETERS:
                    //<CallingParameters> ::= <Value> <CallingParameter>
                    return new MethodParameter(this, Node(0), Node(1));

                case RuleConstants.RULE_CALLINGPARAMETER_COMMA:
                    //<CallingParameter> ::= ',' <Value> <CallingParameter>
                    return new MethodParameterComma(this, Node(0), Node(1));

                case RuleConstants.RULE_DECLARINGPARAMETERS:
                    //<DeclaringParameters> ::= <Declaration> <DeclaringParameter>
                    return new DeclaringParameters(this, Node(0), Node(1));

                case RuleConstants.RULE_DECLARINGPARAMETER_COMMA:
                    //<DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
                    return new DeclaringParameterComma(this, Node(1), Node(2));

                case RuleConstants.RULE_EXPRESSION:
                    //<Expression> ::= <operator> <Value> <Expression>
                    return new OperatorExpression(this, Node(0), Node(1), Node(2));   

                case RuleConstants.RULE_BOOLEANEXPRESSION:
                    //<BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>
                    return new BooleanExpression(this, Node(0), Node(1), Node(2), Node(3), Node(4), Node(5));

                case RuleConstants.RULE_BOOLEANEXPRESSIONEXTENSION:
                    //<BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
                    return new BooleanExpressionExtention(this, Node(0), Node(1));

                case RuleConstants.RULE_LOGICALOPERATOR_OR:
                    //<logicaloperator> ::= or
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_LOGICALOPERATOR_AND:
                    //<logicaloperator> ::= and
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_OPERATOR_TIMES:
                    //<operator> ::= '*'
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_OPERATOR_PLUS:
                    //<operator> ::= '+'
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_OPERATOR_DIV:
                    //<operator> ::= '/'
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_OPERATOR_MINUS:
                    //<operator> ::= '-'
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_ISEQ:
                    //<comparisonoperator> ::= 'is='
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_ISLTEQ:
                    //<comparisonoperator> ::= 'is<='
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_ISGTEQ:
                    //<comparisonoperator> ::= 'is>='
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_ISLT:
                    //<comparisonoperator> ::= 'is<'
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_ISGT:
                    //<comparisonoperator> ::= 'is>'
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_ISEXCLAMEQ:
                    //<comparisonoperator> ::= 'is!='
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_COMPARISONOPERATOR_TOUCHES:
                    //<comparisonoperator> ::= touches                                                        // TODO: FIX
                    return new Operator(this, Token(0));

                case RuleConstants.RULE_TEXT_STRINGVALUE:
                    //<Text> ::= StringValue <TextPrime>
                    return new TextValue(this, Token(0), Node(1));

                case RuleConstants.RULE_TEXT:
                    //<Text> ::= <Identifiers> <TextPrime>
                    return new TextIdentifiers(this, Node(0), Node(1));

                case RuleConstants.RULE_TEXTPRIME_PLUS:
                    //<TextPrime> ::= '+' <Identifiers> <TextPrime>
                    return new TextPrimeIdentifiers(this, Node(1), Node(2));

                case RuleConstants.RULE_TEXTPRIME_PLUS_STRINGVALUE:
                    //<TextPrime> ::= '+' StringValue <TextPrime>
                    return new TextPrimeStringValue(this, Token(0), Node(1), Node(2));

                case RuleConstants.RULE_TYPE_INTEGER:
                    //<Type> ::= Integer
                    return new TypeCreator(this, Token(0));

                case RuleConstants.RULE_TYPE_DECIMAL:
                    //<Type> ::= Decimal
                    return new TypeCreator(this, Token(0));

                case RuleConstants.RULE_TYPE_STRING:
                    //<Type> ::= String
                    return new TypeCreator(this, Token(0));

                case RuleConstants.RULE_TYPE_BOOLEAN:
                    //<Type> ::= Boolean
                    return new TypeCreator(this, Token(0));

                case RuleConstants.RULE_TYPE_POINT:
                    //<Type> ::= Point
                    return new TypeCreator(this, Token(0));

                case RuleConstants.RULE_TYPE:
                    //<Type> ::= <PrefabClasses>                                                         // TODO: Note:
                    return new TypePrefab(this, Node(0));

                case RuleConstants.RULE_METHODTYPE_INTEGER:
                    //<Methodtype> ::= Integer
                    return new MethodTypeCreator(this, Token(0));

                case RuleConstants.RULE_METHODTYPE_DECIMAL:
                    //<Methodtype> ::= Decimal
                    return new MethodTypeCreator(this, Token(0));

                case RuleConstants.RULE_METHODTYPE_STRING:
                    //<Methodtype> ::= String
                    return new MethodTypeCreator(this, Token(0));

                case RuleConstants.RULE_METHODTYPE_BOOLEAN:
                    //<Methodtype> ::= Boolean
                    return new MethodTypeCreator(this, Token(0));

                case RuleConstants.RULE_METHODTYPE_POINT:
                    //<Methodtype> ::= Point
                    return new MethodTypeCreator(this, Token(0));

                case RuleConstants.RULE_METHODTYPE_VOID:
                    //<Methodtype> ::= void
                    return new MethodTypeCreator(this, Token(0));

                case RuleConstants.RULE_METHODTYPE:
                    //<Methodtype> ::= <PrefabClasses>                                                          // TODO: Note
                    return new MethodTypePrefab(this, Node(0));

                case RuleConstants.RULE_VALUE:
                    //<Value> ::= <Identifiers>
                    return new TypeValueIdentifier(this, Node(0));

                case RuleConstants.RULE_VALUE_INTEGERVALUE:
                    //<Value> ::= <Prefix> IntegerValue
                    return new TypeValueInteger(this, Node(0), Token(1));
                                                                                                             // TODO: Note
                case RuleConstants.RULE_VALUE_DECIMALVALUE:
                    //<Value> ::= <Prefix> DecimalValue
                    return new TypeValueDecimal(this, Node(0), Token(1));

                case RuleConstants.RULE_VALUE_STRINGVALUE:
                    //<Value> ::= StringValue
                    return new TypeValueString(this, Token(0));

                case RuleConstants.RULE_VALUE2:
                    //<Value> ::= <BooleanValue>                                                         // TODO: Note
                    return new TypeValueBoolean(this, Node(0));

                case RuleConstants.RULE_VALUE_LPAREN_DECIMALVALUE_COMMA_DECIMALVALUE_RPAREN:
                    //<Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'              // TODO: Note
                    return new TypeValueCreatorPoint(this, Node(1), Token(2), Node(4), Token(5));

                case RuleConstants.RULE_VALUE3:
                    //<Value> ::= <ValueKeywords>
                    return new TypeValueKeywords(this, Node(0));

                case RuleConstants.RULE_VALUEKEYWORDS_TIME:
                    //<ValueKeywords> ::= Time
                    return new ValueKeywords(this, Token(0));

                case RuleConstants.RULE_PREFIX_MINUS:
                    //<Prefix> ::= '-'
                    return new Prefix(this, Token(0));

                case RuleConstants.RULE_BOOLEANVALUE_TRUE:
                    //<BooleanValue> ::= true
                    return new BooleanValue(this, Token(0));

                case RuleConstants.RULE_BOOLEANVALUE_FALSE:
                    //<BooleanValue> ::= false
                    return new BooleanValue(this, Token(0));

                case RuleConstants.RULE_IDENTIFIERS_IDENTIFIER:
                    //<Identifiers> ::= Identifier <IdentifiersPrime>
                    return new IdentifiersStatement(this, Token(1), Node(2));

                case RuleConstants.RULE_IDENTIFIERSPRIME_DOT_IDENTIFIER:
                    //<IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
                    return new IdentifiersPrimeStatement(this, Token(1), Node(2));

                case RuleConstants.RULE_PREFABCLASSES_CHARACTER:
                    //<PrefabClasses> ::= Character
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_ENEMY:
                    //<PrefabClasses> ::= Enemy
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_CAMERA:
                    //<PrefabClasses> ::= Camera
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_SQUARE:
                    //<PrefabClasses> ::= Square
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_TRIANGLE:
                    //<PrefabClasses> ::= Triangle
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_SPRITE:
                    //<PrefabClasses> ::= Sprite
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_TEXT:
                    //<PrefabClasses> ::= Text
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABCLASSES_TRIGGER:
                    //<PrefabClasses> ::= Trigger
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABMETHODS_MOVE:
                    //<PrefabMethods> ::= Move
                    return new PrefabCreator(this, Token(0));

                case RuleConstants.RULE_PREFABMETHODS_DELETE:
                    //<PrefabMethods> ::= Delete
                    return new PrefabCreator(this, Token(0));



    
                    // TODO: WhatToDO?
                case RuleConstants.RULE_COMMANDS2:
                    //<Commands> ::=                                                                          
                case RuleConstants.RULE_ELSESTATEMENTEXTEND:                             
                    //<ElseStatementExtend> ::= 
                case RuleConstants.RULE_DECLARATIONS2:
                    //<Declarations> ::=                                                 
                case RuleConstants.RULE_CALLINGPARAMETERS2:
                    //<CallingParameters> ::=                                            
                case RuleConstants.RULE_CALLINGPARAMETER:
                    //<CallingParameter> ::=                                            
                case RuleConstants.RULE_DECLARINGPARAMETERS2:
                    //<DeclaringParameters> ::=                                              
                case RuleConstants.RULE_DECLARINGPARAMETER:
                    //<DeclaringParameter> ::=                                              
                case RuleConstants.RULE_EXPRESSION2:
                    //<Expression> ::=                                                   
                case RuleConstants.RULE_BOOLEANEXPRESSIONEXTENSION2:
                    //<BooleanExpressionExtension> ::=               
                case RuleConstants.RULE_PREFIX:
                    //<Prefix> ::= 
                case RuleConstants.RULE_TEXT2:
                    //<Text> ::=                                                     
                case RuleConstants.RULE_TEXTPRIME:
                    //<TextPrime> ::=                                                  
                case RuleConstants.RULE_IDENTIFIERSPRIME:
                    //<IdentifiersPrime> ::=                                                
                    return null;

                default:
                    throw new RuleException("Unknown rule: Does your CGT Match your Code Revision?");
            }
        }




        public string GetTokenText()
        {
            // delete any of these that are non-terminals.

            switch (_parser.TokenSymbol.Index)
            {

                case (int)SymbolConstants.SYMBOL_EOF:
                    //(EOF)
                    //Token Kind: 3
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_ERROR:
                    //(Error)
                    //Token Kind: 7
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_WHITESPACE:
                    //Whitespace
                    //Token Kind: 2
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_MINUS:
                    //'-'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                

                case (int)SymbolConstants.SYMBOL_LPAREN:
                    //'('
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_RPAREN:
                    //')'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TIMES:
                    //'*'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_COMMA:
                    //','
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_DOT:
                    //'.'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_DIV:
                    //'/'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_SEMI:
                    //';'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_PLUS:
                    //'+'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_EQ:
                    //'='
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_AND:
                    //and
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_BOOLEAN:
                    //Boolean
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_CALL:
                    //Call
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_CAMERA:
                    //Camera
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_CHARACTER:
                    //Character
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_DECIMAL:
                    //Decimal
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_DECIMALVALUE:
                    //DecimalValue
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_DELETE:
                    //Delete
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ELSE:
                    //else
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ELSEIF:
                    //'else if'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_END:
                    //end
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ENEMY:
                    //Enemy
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_FALSE:
                    //false
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_GAMELOOP:
                    //GameLoop
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_IDENTIFIER:
                    //Identifier
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_IF:
                    //if
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_INTEGER:
                    //Integer
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_INTEGERVALUE:
                    //IntegerValue
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ISEXCLAMEQ:
                    //'is!='
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ISLT:
                    //'is<'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ISLTEQ:
                    //'is<='
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ISEQ:
                    //'is='
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ISGT:
                    //'is>'
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_ISGTEQ:
                    //'is>='
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_METHOD:
                    //method
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_MOVE:
                    //Move
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_OR:
                    //or
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_POINT:
                    //Point
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_RETURN:
                    //return
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_SPRITE:
                    //Sprite
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_SQUARE:
                    //Square
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_STARTUP:
                    //startup
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_STRING:
                    //String
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_STRINGVALUE:
                    //StringValue
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TEXT:
                    //Text
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TIME:
                    //Time
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TOUCHES:
                    //touches
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TRIANGLE:
                    //Triangle
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TRIGGER:
                    //Trigger
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_TRUE:
                    //true
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_VOID:
                    //void
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_WHILE:
                    //while
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_WRITE:
                    //write
                    //Token Kind: 1
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    return _parser.TokenString;
                    

                case (int)SymbolConstants.SYMBOL_BOOLEANEXPRESSION:
                    //<BooleanExpression>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_BOOLEANEXPRESSIONEXTENSION:
                    //<BooleanExpressionExtension>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_BOOLEANVALUE:
                    //<BooleanValue>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_CALLINGPARAMETER:
                    //<CallingParameter>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_CALLINGPARAMETERS:
                    //<CallingParameters>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_COMMANDS:
                    //<Commands>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_COMPARISONOPERATOR:
                    //<comparisonoperator>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_CONTROLSTATEMENTS:
                    //<ControlStatements>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARATION:
                    //<Declaration>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARATIONS:
                    //<Declarations>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARINGPARAMETER:
                    //<DeclaringParameter>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_DECLARINGPARAMETERS:
                    //<DeclaringParameters>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSEIFSTATEMENTEXTEND:
                    //<ElseIfStatementExtend>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_ELSESTATEMENTEXTEND:
                    //<ElseStatementExtend>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_EXPRESSION:
                    //<Expression>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIERS:
                    //<Identifiers>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_IDENTIFIERSPRIME:
                    //<IdentifiersPrime>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_LOGICALOPERATOR:
                    //<logicaloperator>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_METHODDECLARATION:
                    //<MethodDeclaration>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_METHODTYPE:
                    //<Methodtype>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_OPERATOR:
                    //<operator>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_PREFABCLASSES:
                    //<PrefabClasses>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_PREFABMETHODS:
                    //<PrefabMethods>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_PREFIX:
                    //<Prefix>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_RETURNSTATEMENT:
                    //<returnstatement>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_S:
                    //<S>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_STATEMENT:
                    //<Statement>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_TEXT2:
                    //<Text>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_TEXTPRIME:
                    //<TextPrime>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_TYPE:
                    //<Type>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_VALUE:
                    //<Value>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                case (int)SymbolConstants.SYMBOL_VALUEKEYWORDS:
                    //<ValueKeywords>
                    //Token Kind: 0
                    //todo: uncomment the next line if it's a terminal token ( if Token Kind = 1 )
                    // return m_parser.TokenString;
                    return null;

                default:
                    throw new SymbolException("You don't want the text of a non-terminal symbol");

            }
        }






        // TODO: DO not Edit
        #region MyRegion

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
            SYMBOL_RETURN = 41, // return
            SYMBOL_SPRITE = 42, // Sprite
            SYMBOL_SQUARE = 43, // Square
            SYMBOL_STARTUP = 44, // startup
            SYMBOL_STRING = 45, // String
            SYMBOL_STRINGVALUE = 46, // StringValue
            SYMBOL_TEXT = 47, // Text
            SYMBOL_TIME = 48, // Time
            SYMBOL_TOUCHES = 49, // touches
            SYMBOL_TRIANGLE = 50, // Triangle
            SYMBOL_TRIGGER = 51, // Trigger
            SYMBOL_TRUE = 52, // true
            SYMBOL_VOID = 53, // void
            SYMBOL_WHILE = 54, // while
            SYMBOL_WRITE = 55, // write
            SYMBOL_BOOLEANEXPRESSION = 56, // <BooleanExpression>
            SYMBOL_BOOLEANEXPRESSIONEXTENSION = 57, // <BooleanExpressionExtension>
            SYMBOL_BOOLEANVALUE = 58, // <BooleanValue>
            SYMBOL_CALLINGPARAMETER = 59, // <CallingParameter>
            SYMBOL_CALLINGPARAMETERS = 60, // <CallingParameters>
            SYMBOL_COMMANDS = 61, // <Commands>
            SYMBOL_COMPARISONOPERATOR = 62, // <comparisonoperator>
            SYMBOL_CONTROLSTATEMENTS = 63, // <ControlStatements>
            SYMBOL_DECLARATION = 64, // <Declaration>
            SYMBOL_DECLARATIONS = 65, // <Declarations>
            SYMBOL_DECLARINGPARAMETER = 66, // <DeclaringParameter>
            SYMBOL_DECLARINGPARAMETERS = 67, // <DeclaringParameters>
            SYMBOL_ELSEIFSTATEMENTEXTEND = 68, // <ElseIfStatementExtend>
            SYMBOL_ELSESTATEMENTEXTEND = 69, // <ElseStatementExtend>
            SYMBOL_EXPRESSION = 70, // <Expression>
            SYMBOL_IDENTIFIERS = 71, // <Identifiers>
            SYMBOL_IDENTIFIERSPRIME = 72, // <IdentifiersPrime>
            SYMBOL_LOGICALOPERATOR = 73, // <logicaloperator>
            SYMBOL_METHODDECLARATION = 74, // <MethodDeclaration>
            SYMBOL_METHODTYPE = 75, // <Methodtype>
            SYMBOL_OPERATOR = 76, // <operator>
            SYMBOL_PREFABCLASSES = 77, // <PrefabClasses>
            SYMBOL_PREFABMETHODS = 78, // <PrefabMethods>
            SYMBOL_PREFIX = 79, // <Prefix>
            SYMBOL_RETURNSTATEMENT = 80, // <returnstatement>
            SYMBOL_S = 81, // <S>
            SYMBOL_STATEMENT = 82, // <Statement>
            SYMBOL_TEXT2 = 83, // <Text>
            SYMBOL_TEXTPRIME = 84, // <TextPrime>
            SYMBOL_TYPE = 85, // <Type>
            SYMBOL_VALUE = 86, // <Value>
            SYMBOL_VALUEKEYWORDS = 87  // <ValueKeywords>
        };

        enum RuleConstants : int
        {
            RULE_S_STARTUP_LPAREN_RPAREN_END_STARTUP_GAMELOOP_LPAREN_RPAREN_END_GAMELOOP = 0, // <S> ::= <Declarations> startup '(' <DeclaringParameters> ')' <Commands> end startup <Declarations> GameLoop '(' <DeclaringParameters> ')' <Commands> end GameLoop <Declarations>
            RULE_COMMANDS = 1, // <Commands> ::= <Statement> <Commands>
            RULE_COMMANDS_SEMI = 2, // <Commands> ::= <Declaration> ';' <Commands>
            RULE_COMMANDS2 = 3, // <Commands> ::= 
            RULE_STATEMENT_WRITE_LPAREN_RPAREN_SEMI = 4, // <Statement> ::= write '(' <Text> ')' ';'
            RULE_STATEMENT_EQ_SEMI = 5, // <Statement> ::= <Identifiers> '=' <Value> <Expression> ';'
            RULE_STATEMENT = 6, // <Statement> ::= <ControlStatements>
            RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI = 7, // <Statement> ::= Call <Identifiers> '(' <CallingParameters> ')' ';'
            RULE_STATEMENT_CALL_LPAREN_RPAREN_SEMI2 = 8, // <Statement> ::= Call <PrefabMethods> '(' <CallingParameters> ')' ';'
            RULE_STATEMENT_EQ_CALL_LPAREN_RPAREN_SEMI = 9, // <Statement> ::= <Identifiers> '=' Call <Identifiers> '(' <CallingParameters> ')' ';'
            RULE_STATEMENT_EQ_CALL_LPAREN_RPAREN_SEMI2 = 10, // <Statement> ::= <Identifiers> '=' Call <PrefabMethods> '(' <CallingParameters> ')' ';'
            RULE_CONTROLSTATEMENTS_IF_LPAREN_RPAREN_END_IF = 11, // <ControlStatements> ::= if '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend> end if
            RULE_CONTROLSTATEMENTS_WHILE_LPAREN_RPAREN_END_WHILE = 12, // <ControlStatements> ::= while '(' <BooleanExpression> ')' <Commands> end while
            RULE_ELSEIFSTATEMENTEXTEND_ELSEIF_LPAREN_RPAREN = 13, // <ElseIfStatementExtend> ::= 'else if' '(' <BooleanExpression> ')' <Commands> <ElseIfStatementExtend>
            RULE_ELSEIFSTATEMENTEXTEND = 14, // <ElseIfStatementExtend> ::= <ElseStatementExtend>
            RULE_ELSESTATEMENTEXTEND_ELSE = 15, // <ElseStatementExtend> ::= else <Commands>
            RULE_ELSESTATEMENTEXTEND = 16, // <ElseStatementExtend> ::= 
            RULE_DECLARATION_IDENTIFIER = 17, // <Declaration> ::= <Type> Identifier
            RULE_DECLARATIONS_SEMI = 18, // <Declarations> ::= <Declaration> ';' <Declarations>
            RULE_DECLARATIONS = 19, // <Declarations> ::= <MethodDeclaration> <Declarations>
            RULE_DECLARATIONS2 = 20, // <Declarations> ::= 
            RULE_METHODDECLARATION_METHOD_IDENTIFIER_LPAREN_RPAREN_END_METHOD = 21, // <MethodDeclaration> ::= method <Methodtype> Identifier '(' <DeclaringParameters> ')' <Commands> <returnstatement> end method
            RULE_RETURNSTATEMENT_RETURN_SEMI = 22, // <returnstatement> ::= return <Value> <Expression> ';'
            RULE_RETURNSTATEMENT_RETURN_SEMI2 = 23, // <returnstatement> ::= return ';'
            RULE_CALLINGPARAMETERS = 24, // <CallingParameters> ::= <Value> <CallingParameter>
            RULE_CALLINGPARAMETERS2 = 25, // <CallingParameters> ::= 
            RULE_CALLINGPARAMETER_COMMA = 26, // <CallingParameter> ::= ',' <Value> <CallingParameter>
            RULE_CALLINGPARAMETER = 27, // <CallingParameter> ::= 
            RULE_DECLARINGPARAMETERS = 28, // <DeclaringParameters> ::= <Declaration> <DeclaringParameter>
            RULE_DECLARINGPARAMETERS2 = 29, // <DeclaringParameters> ::= 
            RULE_DECLARINGPARAMETER_COMMA = 30, // <DeclaringParameter> ::= ',' <Declaration> <DeclaringParameter>
            RULE_DECLARINGPARAMETER = 31, // <DeclaringParameter> ::= 
            RULE_EXPRESSION = 32, // <Expression> ::= <operator> <Value> <Expression>
            RULE_EXPRESSION2 = 33, // <Expression> ::= 
            RULE_BOOLEANEXPRESSION = 34, // <BooleanExpression> ::= <Value> <Expression> <comparisonoperator> <Value> <Expression> <BooleanExpressionExtension>
            RULE_BOOLEANEXPRESSIONEXTENSION = 35, // <BooleanExpressionExtension> ::= <logicaloperator> <BooleanExpression>
            RULE_BOOLEANEXPRESSIONEXTENSION2 = 36, // <BooleanExpressionExtension> ::= 
            RULE_LOGICALOPERATOR_OR = 37, // <logicaloperator> ::= or
            RULE_LOGICALOPERATOR_AND = 38, // <logicaloperator> ::= and
            RULE_OPERATOR_TIMES = 39, // <operator> ::= '*'
            RULE_OPERATOR_PLUS = 40, // <operator> ::= '+'
            RULE_OPERATOR_DIV = 41, // <operator> ::= '/'
            RULE_OPERATOR_MINUS = 42, // <operator> ::= '-'
            RULE_COMPARISONOPERATOR_ISEQ = 43, // <comparisonoperator> ::= 'is='
            RULE_COMPARISONOPERATOR_ISLTEQ = 44, // <comparisonoperator> ::= 'is<='
            RULE_COMPARISONOPERATOR_ISGTEQ = 45, // <comparisonoperator> ::= 'is>='
            RULE_COMPARISONOPERATOR_ISLT = 46, // <comparisonoperator> ::= 'is<'
            RULE_COMPARISONOPERATOR_ISGT = 47, // <comparisonoperator> ::= 'is>'
            RULE_COMPARISONOPERATOR_ISEXCLAMEQ = 48, // <comparisonoperator> ::= 'is!='
            RULE_COMPARISONOPERATOR_TOUCHES = 49, // <comparisonoperator> ::= touches
            RULE_TEXT_STRINGVALUE = 50, // <Text> ::= StringValue <TextPrime>
            RULE_TEXT = 51, // <Text> ::= <Identifiers> <TextPrime>
            RULE_TEXT2 = 52, // <Text> ::= 
            RULE_TEXTPRIME_PLUS = 53, // <TextPrime> ::= '+' <Identifiers> <TextPrime>
            RULE_TEXTPRIME_PLUS_STRINGVALUE = 54, // <TextPrime> ::= '+' StringValue <TextPrime>
            RULE_TEXTPRIME = 55, // <TextPrime> ::= 
            RULE_TYPE_INTEGER = 56, // <Type> ::= Integer
            RULE_TYPE_DECIMAL = 57, // <Type> ::= Decimal
            RULE_TYPE_STRING = 58, // <Type> ::= String
            RULE_TYPE_BOOLEAN = 59, // <Type> ::= Boolean
            RULE_TYPE_POINT = 60, // <Type> ::= Point
            RULE_TYPE = 61, // <Type> ::= <PrefabClasses>
            RULE_METHODTYPE_INTEGER = 62, // <Methodtype> ::= Integer
            RULE_METHODTYPE_DECIMAL = 63, // <Methodtype> ::= Decimal
            RULE_METHODTYPE_STRING = 64, // <Methodtype> ::= String
            RULE_METHODTYPE_BOOLEAN = 65, // <Methodtype> ::= Boolean
            RULE_METHODTYPE_POINT = 66, // <Methodtype> ::= Point
            RULE_METHODTYPE_VOID = 67, // <Methodtype> ::= void
            RULE_METHODTYPE = 68, // <Methodtype> ::= <PrefabClasses>
            RULE_VALUE = 69, // <Value> ::= <Identifiers>
            RULE_VALUE_INTEGERVALUE = 70, // <Value> ::= <Prefix> IntegerValue
            RULE_VALUE_DECIMALVALUE = 71, // <Value> ::= <Prefix> DecimalValue
            RULE_VALUE_STRINGVALUE = 72, // <Value> ::= StringValue
            RULE_VALUE2 = 73, // <Value> ::= <BooleanValue>
            RULE_VALUE_LPAREN_DECIMALVALUE_COMMA_DECIMALVALUE_RPAREN = 74, // <Value> ::= '(' <Prefix> DecimalValue ',' <Prefix> DecimalValue ')'
            RULE_VALUE3 = 75, // <Value> ::= <ValueKeywords>
            RULE_VALUEKEYWORDS_TIME = 76, // <ValueKeywords> ::= Time
            RULE_PREFIX_MINUS = 77, // <Prefix> ::= '-'
            RULE_PREFIX = 78, // <Prefix> ::= 
            RULE_BOOLEANVALUE_TRUE = 79, // <BooleanValue> ::= true
            RULE_BOOLEANVALUE_FALSE = 80, // <BooleanValue> ::= false
            RULE_IDENTIFIERS_IDENTIFIER = 81, // <Identifiers> ::= Identifier <IdentifiersPrime>
            RULE_IDENTIFIERSPRIME_DOT_IDENTIFIER = 82, // <IdentifiersPrime> ::= '.' Identifier <IdentifiersPrime>
            RULE_IDENTIFIERSPRIME = 83, // <IdentifiersPrime> ::= 
            RULE_PREFABCLASSES_CHARACTER = 84, // <PrefabClasses> ::= Character
            RULE_PREFABCLASSES_ENEMY = 85, // <PrefabClasses> ::= Enemy
            RULE_PREFABCLASSES_CAMERA = 86, // <PrefabClasses> ::= Camera
            RULE_PREFABCLASSES_SQUARE = 87, // <PrefabClasses> ::= Square
            RULE_PREFABCLASSES_TRIANGLE = 88, // <PrefabClasses> ::= Triangle
            RULE_PREFABCLASSES_SPRITE = 89, // <PrefabClasses> ::= Sprite
            RULE_PREFABCLASSES_TEXT = 90, // <PrefabClasses> ::= Text
            RULE_PREFABCLASSES_TRIGGER = 91, // <PrefabClasses> ::= Trigger
            RULE_PREFABMETHODS_MOVE = 92, // <PrefabMethods> ::= Move
            RULE_PREFABMETHODS_DELETE = 93  // <PrefabMethods> ::= Delete
        };

        private SyntaxNode Node(int index)
        {
            return (SyntaxNode)_parser.GetReductionSyntaxNode(index);
        }

        private string Token(int index)
        {
            return (string)_parser.GetReductionSyntaxNode(index);
        }


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
        
        #endregion

    }
}