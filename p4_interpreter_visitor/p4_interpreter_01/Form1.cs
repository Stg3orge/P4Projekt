using GoldParser;
using p4_interpreter_01.Nodes;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Application = System.Windows.Forms.Application;

namespace p4_interpreter_01
{
    public partial class Form1 : Form
    {
        private Grammar _grammar;
        private SyntaxNode _program; //'This will point to the tree created by the parser
        private ParserContext _parserContext; // stuff from gold generation

        public Form1()
        {
            InitializeComponent();

            using (Stream stream = File.OpenRead("grammar.cgt"))
            {
                BinaryReader reader = new BinaryReader(stream);
                _grammar = new Grammar(reader);
            }

            formtest = this;
        }

        [STAThread]
        static void Main()
        {
            Application.Run(new Form1());
        }

        private bool DoParse()
        {
            //This procedure starts the GOLD Parser Engine and handles each of the
            //messages it returns. Each time a reduction is made, a new instance of a
            //"Simple" object is created and stored in the parse tree. The resulting tree
            //will be a pure representation of the Simple language and will be ready to
            //implement.
            StringReader reader = new StringReader(richInputBox.Text);
            Parser parser = new Parser(reader, _grammar);
            parser.TrimReductions = true;
            _parserContext = new ParserContext(parser);
            while (true)
            {
                switch (parser.Parse())
                {
                    case ParseMessage.LexicalError:
                        Log("LEXICAL ERROR. Line " + parser.LineNumber + ". Cannot recognize token: " + parser.TokenText);
                        return false;

                    case ParseMessage.SyntaxError:
                        StringBuilder text = new StringBuilder();
                        foreach (Symbol tokenSymbol in parser.GetExpectedTokens())
                        {
                            text.Append(' ');
                            text.Append(tokenSymbol.ToString());
                        }
                        Log("SYNTAX ERROR. Line " + parser.LineNumber + ". Expecting:" + text.ToString());
                        return false;

                    case ParseMessage.Reduction:
                        //== Create a new customized object and replace the
                        //== CurrentReduction with it. This saves memory and allows
                        //== easier interpretation
                        parser.TokenSyntaxNode = _parserContext.GetObject();
                        break;

                    case ParseMessage.Accept:
                        //=== Success!
                        _program = (SyntaxNode) parser.TokenSyntaxNode;
                        Log("-- Program Accepted --");
                        return true;

                    case ParseMessage.TokenRead:
                        //=== Make sure that we store token string for needed tokens.
                        parser.TokenSyntaxNode = _parserContext.GetTokenText();
                        break;

                    case ParseMessage.InternalError:
                        Log("INTERNAL ERROR! Something is horribly wrong");
                        return false;

                    case ParseMessage.NotLoadedError:
                        //=== Due to the if-statement above, this case statement should never be true
                        Log("NOT LOADED ERROR! Compiled Grammar Table not loaded");
                        return false;

                    case ParseMessage.CommentError:
                        Log("COMMENT ERROR! Unexpected end of file");
                        return false;

                    case ParseMessage.CommentBlockRead:
                        //=== Do nothing
                        break;

                    case ParseMessage.CommentLineRead:
                        //=== Do nothing
                        break;
                }
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            lstLog.Items.Clear();
            DoParse();

            if (_program != null)
            {
                //richInputBox.Text = "";

                _program.Accept(new ContextVisitor());

                //_program.Accept(new SemanticCheckVisitor());

                //_program.Accept(new ScopeCheckVisitor());
                //_program.Accept(new TypeCheckVisitor());

                /*richInputBox.Text = (string)*///
                _program.Accept(new CodeGenVisitor());

            }
            //richInputBox.Text = "Test";
        }


        private void Log(string text)
        {
            lstLog.Items.Add(text);
        }

        private void richInputBox_TextChanged_1(object sender, EventArgs e)
        {

        }


        // TODO: TEst

        public static Form1 formtest;


        public string testString
        {
            get { return richInputBox.Text; }
            set { richInputBox.Text = value; }
        }

    }
}