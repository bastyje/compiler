//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from D:/Projects/compiler/Polski/Polski.Compiler/LanguageDefinition/Polski.g4 by ANTLR 4.13.1

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using System;
using System.IO;
using System.Text;
using System.Diagnostics;
using System.Collections.Generic;
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class PolskiParser : Parser {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		T__0=1, T__1=2, PRINT=3, READ=4, INT=5, FLOAT=6, AND=7, EQUALS=8, GREATER_OR_EQUALS=9, 
		GREATER=10, LESS_OR_EQUALS=11, LESS=12, NOT=13, NOT_EQUALS=14, OR=15, 
		XOR=16, ASSIGN=17, DIVIDE=18, MINUS=19, MULTIPLY=20, PLUS=21, WHITESPACE=22, 
		INTEGER_NUMBER=23, REAL_NUMBER=24, IDENTIFIER=25, SEMICOLON=26;
	public const int
		RULE_program = 0, RULE_line = 1, RULE_statement = 2, RULE_printStatement = 3, 
		RULE_readStatement = 4, RULE_assignment = 5, RULE_expression = 6, RULE_arithmeticExpression = 7, 
		RULE_number = 8, RULE_declaration = 9, RULE_definition = 10, RULE_type = 11, 
		RULE_numericType = 12;
	public static readonly string[] ruleNames = {
		"program", "line", "statement", "printStatement", "readStatement", "assignment", 
		"expression", "arithmeticExpression", "number", "declaration", "definition", 
		"type", "numericType"
	};

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'print'", "'read'", "'int'", "'float'", "'&&'", "'=='", 
		"'>='", "'>'", "'<='", "'<'", "'!'", "'!='", "'||'", "'^'", "'='", "'/'", 
		"'-'", "'*'", "'+'", null, null, null, null, "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "PRINT", "READ", "INT", "FLOAT", "AND", "EQUALS", "GREATER_OR_EQUALS", 
		"GREATER", "LESS_OR_EQUALS", "LESS", "NOT", "NOT_EQUALS", "OR", "XOR", 
		"ASSIGN", "DIVIDE", "MINUS", "MULTIPLY", "PLUS", "WHITESPACE", "INTEGER_NUMBER", 
		"REAL_NUMBER", "IDENTIFIER", "SEMICOLON"
	};
	public static readonly IVocabulary DefaultVocabulary = new Vocabulary(_LiteralNames, _SymbolicNames);

	[NotNull]
	public override IVocabulary Vocabulary
	{
		get
		{
			return DefaultVocabulary;
		}
	}

	public override string GrammarFileName { get { return "Polski.g4"; } }

	public override string[] RuleNames { get { return ruleNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static PolskiParser() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}

		public PolskiParser(ITokenStream input) : this(input, Console.Out, Console.Error) { }

		public PolskiParser(ITokenStream input, TextWriter output, TextWriter errorOutput)
		: base(input, output, errorOutput)
	{
		Interpreter = new ParserATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	public partial class ProgramContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public LineContext line() {
			return GetRuleContext<LineContext>(0);
		}
		public ProgramContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_program; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitProgram(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitProgram(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ProgramContext program() {
		ProgramContext _localctx = new ProgramContext(Context, State);
		EnterRule(_localctx, 0, RULE_program);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 26;
			line();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class LineContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public StatementContext statement() {
			return GetRuleContext<StatementContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode SEMICOLON() { return GetToken(PolskiParser.SEMICOLON, 0); }
		public LineContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_line; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitLine(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitLine(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public LineContext line() {
		LineContext _localctx = new LineContext(Context, State);
		EnterRule(_localctx, 2, RULE_line);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 28;
			statement();
			State = 29;
			Match(SEMICOLON);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class StatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public DeclarationContext declaration() {
			return GetRuleContext<DeclarationContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public DefinitionContext definition() {
			return GetRuleContext<DefinitionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public AssignmentContext assignment() {
			return GetRuleContext<AssignmentContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public PrintStatementContext printStatement() {
			return GetRuleContext<PrintStatementContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ReadStatementContext readStatement() {
			return GetRuleContext<ReadStatementContext>(0);
		}
		public StatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_statement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public StatementContext statement() {
		StatementContext _localctx = new StatementContext(Context, State);
		EnterRule(_localctx, 4, RULE_statement);
		try {
			State = 37;
			ErrorHandler.Sync(this);
			switch ( Interpreter.AdaptivePredict(TokenStream,0,Context) ) {
			case 1:
				EnterOuterAlt(_localctx, 1);
				{
				State = 31;
				declaration();
				}
				break;
			case 2:
				EnterOuterAlt(_localctx, 2);
				{
				State = 32;
				definition();
				}
				break;
			case 3:
				EnterOuterAlt(_localctx, 3);
				{
				State = 33;
				assignment();
				}
				break;
			case 4:
				EnterOuterAlt(_localctx, 4);
				{
				State = 34;
				expression();
				}
				break;
			case 5:
				EnterOuterAlt(_localctx, 5);
				{
				State = 35;
				printStatement();
				}
				break;
			case 6:
				EnterOuterAlt(_localctx, 6);
				{
				State = 36;
				readStatement();
				}
				break;
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class PrintStatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PRINT() { return GetToken(PolskiParser.PRINT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public PrintStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_printStatement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterPrintStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitPrintStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitPrintStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public PrintStatementContext printStatement() {
		PrintStatementContext _localctx = new PrintStatementContext(Context, State);
		EnterRule(_localctx, 6, RULE_printStatement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 39;
			Match(PRINT);
			State = 40;
			Match(T__0);
			State = 41;
			expression();
			State = 42;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ReadStatementContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode READ() { return GetToken(PolskiParser.READ, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(PolskiParser.IDENTIFIER, 0); }
		public ReadStatementContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_readStatement; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterReadStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitReadStatement(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitReadStatement(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ReadStatementContext readStatement() {
		ReadStatementContext _localctx = new ReadStatementContext(Context, State);
		EnterRule(_localctx, 8, RULE_readStatement);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 44;
			Match(READ);
			State = 45;
			Match(T__0);
			State = 46;
			Match(IDENTIFIER);
			State = 47;
			Match(T__1);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class AssignmentContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(PolskiParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ASSIGN() { return GetToken(PolskiParser.ASSIGN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public AssignmentContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_assignment; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterAssignment(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitAssignment(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitAssignment(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public AssignmentContext assignment() {
		AssignmentContext _localctx = new AssignmentContext(Context, State);
		EnterRule(_localctx, 10, RULE_assignment);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 49;
			Match(IDENTIFIER);
			State = 50;
			Match(ASSIGN);
			State = 51;
			expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ExpressionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ArithmeticExpressionContext arithmeticExpression() {
			return GetRuleContext<ArithmeticExpressionContext>(0);
		}
		public ExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_expression; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterExpression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitExpression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ExpressionContext expression() {
		ExpressionContext _localctx = new ExpressionContext(Context, State);
		EnterRule(_localctx, 12, RULE_expression);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 53;
			arithmeticExpression(0);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class ArithmeticExpressionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(PolskiParser.IDENTIFIER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public NumberContext number() {
			return GetRuleContext<NumberContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ArithmeticExpressionContext[] arithmeticExpression() {
			return GetRuleContexts<ArithmeticExpressionContext>();
		}
		[System.Diagnostics.DebuggerNonUserCode] public ArithmeticExpressionContext arithmeticExpression(int i) {
			return GetRuleContext<ArithmeticExpressionContext>(i);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MULTIPLY() { return GetToken(PolskiParser.MULTIPLY, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode DIVIDE() { return GetToken(PolskiParser.DIVIDE, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode PLUS() { return GetToken(PolskiParser.PLUS, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode MINUS() { return GetToken(PolskiParser.MINUS, 0); }
		public ArithmeticExpressionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_arithmeticExpression; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterArithmeticExpression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitArithmeticExpression(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitArithmeticExpression(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public ArithmeticExpressionContext arithmeticExpression() {
		return arithmeticExpression(0);
	}

	private ArithmeticExpressionContext arithmeticExpression(int _p) {
		ParserRuleContext _parentctx = Context;
		int _parentState = State;
		ArithmeticExpressionContext _localctx = new ArithmeticExpressionContext(Context, _parentState);
		ArithmeticExpressionContext _prevctx = _localctx;
		int _startState = 14;
		EnterRecursionRule(_localctx, 14, RULE_arithmeticExpression, _p);
		try {
			int _alt;
			EnterOuterAlt(_localctx, 1);
			{
			State = 58;
			ErrorHandler.Sync(this);
			switch (TokenStream.LA(1)) {
			case IDENTIFIER:
				{
				State = 56;
				Match(IDENTIFIER);
				}
				break;
			case INTEGER_NUMBER:
			case REAL_NUMBER:
				{
				State = 57;
				number();
				}
				break;
			default:
				throw new NoViableAltException(this);
			}
			Context.Stop = TokenStream.LT(-1);
			State = 74;
			ErrorHandler.Sync(this);
			_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
			while ( _alt!=2 && _alt!=global::Antlr4.Runtime.Atn.ATN.INVALID_ALT_NUMBER ) {
				if ( _alt==1 ) {
					if ( ParseListeners!=null )
						TriggerExitRuleEvent();
					_prevctx = _localctx;
					{
					State = 72;
					ErrorHandler.Sync(this);
					switch ( Interpreter.AdaptivePredict(TokenStream,2,Context) ) {
					case 1:
						{
						_localctx = new ArithmeticExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_arithmeticExpression);
						State = 60;
						if (!(Precpred(Context, 6))) throw new FailedPredicateException(this, "Precpred(Context, 6)");
						State = 61;
						Match(MULTIPLY);
						State = 62;
						arithmeticExpression(7);
						}
						break;
					case 2:
						{
						_localctx = new ArithmeticExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_arithmeticExpression);
						State = 63;
						if (!(Precpred(Context, 5))) throw new FailedPredicateException(this, "Precpred(Context, 5)");
						State = 64;
						Match(DIVIDE);
						State = 65;
						arithmeticExpression(6);
						}
						break;
					case 3:
						{
						_localctx = new ArithmeticExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_arithmeticExpression);
						State = 66;
						if (!(Precpred(Context, 4))) throw new FailedPredicateException(this, "Precpred(Context, 4)");
						State = 67;
						Match(PLUS);
						State = 68;
						arithmeticExpression(5);
						}
						break;
					case 4:
						{
						_localctx = new ArithmeticExpressionContext(_parentctx, _parentState);
						PushNewRecursionContext(_localctx, _startState, RULE_arithmeticExpression);
						State = 69;
						if (!(Precpred(Context, 3))) throw new FailedPredicateException(this, "Precpred(Context, 3)");
						State = 70;
						Match(MINUS);
						State = 71;
						arithmeticExpression(4);
						}
						break;
					}
					} 
				}
				State = 76;
				ErrorHandler.Sync(this);
				_alt = Interpreter.AdaptivePredict(TokenStream,3,Context);
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			UnrollRecursionContexts(_parentctx);
		}
		return _localctx;
	}

	public partial class NumberContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INTEGER_NUMBER() { return GetToken(PolskiParser.INTEGER_NUMBER, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode REAL_NUMBER() { return GetToken(PolskiParser.REAL_NUMBER, 0); }
		public NumberContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_number; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterNumber(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitNumber(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumber(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public NumberContext number() {
		NumberContext _localctx = new NumberContext(Context, State);
		EnterRule(_localctx, 16, RULE_number);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 77;
			_la = TokenStream.LA(1);
			if ( !(_la==INTEGER_NUMBER || _la==REAL_NUMBER) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DeclarationContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public TypeContext type() {
			return GetRuleContext<TypeContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode IDENTIFIER() { return GetToken(PolskiParser.IDENTIFIER, 0); }
		public DeclarationContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_declaration; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterDeclaration(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitDeclaration(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDeclaration(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DeclarationContext declaration() {
		DeclarationContext _localctx = new DeclarationContext(Context, State);
		EnterRule(_localctx, 18, RULE_declaration);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 79;
			type();
			State = 80;
			Match(IDENTIFIER);
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class DefinitionContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public DeclarationContext declaration() {
			return GetRuleContext<DeclarationContext>(0);
		}
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode ASSIGN() { return GetToken(PolskiParser.ASSIGN, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ExpressionContext expression() {
			return GetRuleContext<ExpressionContext>(0);
		}
		public DefinitionContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_definition; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterDefinition(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitDefinition(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitDefinition(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public DefinitionContext definition() {
		DefinitionContext _localctx = new DefinitionContext(Context, State);
		EnterRule(_localctx, 20, RULE_definition);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 82;
			declaration();
			State = 83;
			Match(ASSIGN);
			State = 84;
			expression();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class TypeContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public NumericTypeContext numericType() {
			return GetRuleContext<NumericTypeContext>(0);
		}
		public TypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_type; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public TypeContext type() {
		TypeContext _localctx = new TypeContext(Context, State);
		EnterRule(_localctx, 22, RULE_type);
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 86;
			numericType();
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public partial class NumericTypeContext : ParserRuleContext {
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode INT() { return GetToken(PolskiParser.INT, 0); }
		[System.Diagnostics.DebuggerNonUserCode] public ITerminalNode FLOAT() { return GetToken(PolskiParser.FLOAT, 0); }
		public NumericTypeContext(ParserRuleContext parent, int invokingState)
			: base(parent, invokingState)
		{
		}
		public override int RuleIndex { get { return RULE_numericType; } }
		[System.Diagnostics.DebuggerNonUserCode]
		public override void EnterRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.EnterNumericType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override void ExitRule(IParseTreeListener listener) {
			IPolskiListener typedListener = listener as IPolskiListener;
			if (typedListener != null) typedListener.ExitNumericType(this);
		}
		[System.Diagnostics.DebuggerNonUserCode]
		public override TResult Accept<TResult>(IParseTreeVisitor<TResult> visitor) {
			IPolskiVisitor<TResult> typedVisitor = visitor as IPolskiVisitor<TResult>;
			if (typedVisitor != null) return typedVisitor.VisitNumericType(this);
			else return visitor.VisitChildren(this);
		}
	}

	[RuleVersion(0)]
	public NumericTypeContext numericType() {
		NumericTypeContext _localctx = new NumericTypeContext(Context, State);
		EnterRule(_localctx, 24, RULE_numericType);
		int _la;
		try {
			EnterOuterAlt(_localctx, 1);
			{
			State = 88;
			_la = TokenStream.LA(1);
			if ( !(_la==INT || _la==FLOAT) ) {
			ErrorHandler.RecoverInline(this);
			}
			else {
				ErrorHandler.ReportMatch(this);
			    Consume();
			}
			}
		}
		catch (RecognitionException re) {
			_localctx.exception = re;
			ErrorHandler.ReportError(this, re);
			ErrorHandler.Recover(this, re);
		}
		finally {
			ExitRule();
		}
		return _localctx;
	}

	public override bool Sempred(RuleContext _localctx, int ruleIndex, int predIndex) {
		switch (ruleIndex) {
		case 7: return arithmeticExpression_sempred((ArithmeticExpressionContext)_localctx, predIndex);
		}
		return true;
	}
	private bool arithmeticExpression_sempred(ArithmeticExpressionContext _localctx, int predIndex) {
		switch (predIndex) {
		case 0: return Precpred(Context, 6);
		case 1: return Precpred(Context, 5);
		case 2: return Precpred(Context, 4);
		case 3: return Precpred(Context, 3);
		}
		return true;
	}

	private static int[] _serializedATN = {
		4,1,26,91,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,6,2,7,
		7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,1,0,1,0,1,1,1,1,1,1,
		1,2,1,2,1,2,1,2,1,2,1,2,3,2,38,8,2,1,3,1,3,1,3,1,3,1,3,1,4,1,4,1,4,1,4,
		1,4,1,5,1,5,1,5,1,5,1,6,1,6,1,7,1,7,1,7,3,7,59,8,7,1,7,1,7,1,7,1,7,1,7,
		1,7,1,7,1,7,1,7,1,7,1,7,1,7,5,7,73,8,7,10,7,12,7,76,9,7,1,8,1,8,1,9,1,
		9,1,9,1,10,1,10,1,10,1,10,1,11,1,11,1,12,1,12,1,12,0,1,14,13,0,2,4,6,8,
		10,12,14,16,18,20,22,24,0,2,1,0,23,24,1,0,5,6,87,0,26,1,0,0,0,2,28,1,0,
		0,0,4,37,1,0,0,0,6,39,1,0,0,0,8,44,1,0,0,0,10,49,1,0,0,0,12,53,1,0,0,0,
		14,58,1,0,0,0,16,77,1,0,0,0,18,79,1,0,0,0,20,82,1,0,0,0,22,86,1,0,0,0,
		24,88,1,0,0,0,26,27,3,2,1,0,27,1,1,0,0,0,28,29,3,4,2,0,29,30,5,26,0,0,
		30,3,1,0,0,0,31,38,3,18,9,0,32,38,3,20,10,0,33,38,3,10,5,0,34,38,3,12,
		6,0,35,38,3,6,3,0,36,38,3,8,4,0,37,31,1,0,0,0,37,32,1,0,0,0,37,33,1,0,
		0,0,37,34,1,0,0,0,37,35,1,0,0,0,37,36,1,0,0,0,38,5,1,0,0,0,39,40,5,3,0,
		0,40,41,5,1,0,0,41,42,3,12,6,0,42,43,5,2,0,0,43,7,1,0,0,0,44,45,5,4,0,
		0,45,46,5,1,0,0,46,47,5,25,0,0,47,48,5,2,0,0,48,9,1,0,0,0,49,50,5,25,0,
		0,50,51,5,17,0,0,51,52,3,12,6,0,52,11,1,0,0,0,53,54,3,14,7,0,54,13,1,0,
		0,0,55,56,6,7,-1,0,56,59,5,25,0,0,57,59,3,16,8,0,58,55,1,0,0,0,58,57,1,
		0,0,0,59,74,1,0,0,0,60,61,10,6,0,0,61,62,5,20,0,0,62,73,3,14,7,7,63,64,
		10,5,0,0,64,65,5,18,0,0,65,73,3,14,7,6,66,67,10,4,0,0,67,68,5,21,0,0,68,
		73,3,14,7,5,69,70,10,3,0,0,70,71,5,19,0,0,71,73,3,14,7,4,72,60,1,0,0,0,
		72,63,1,0,0,0,72,66,1,0,0,0,72,69,1,0,0,0,73,76,1,0,0,0,74,72,1,0,0,0,
		74,75,1,0,0,0,75,15,1,0,0,0,76,74,1,0,0,0,77,78,7,0,0,0,78,17,1,0,0,0,
		79,80,3,22,11,0,80,81,5,25,0,0,81,19,1,0,0,0,82,83,3,18,9,0,83,84,5,17,
		0,0,84,85,3,12,6,0,85,21,1,0,0,0,86,87,3,24,12,0,87,23,1,0,0,0,88,89,7,
		1,0,0,89,25,1,0,0,0,4,37,58,72,74
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}
