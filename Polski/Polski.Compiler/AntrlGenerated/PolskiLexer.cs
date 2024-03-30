//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.13.1
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from /home/sebastian/studia/curr/jfk/proj/Polski/Polski.Compiler/LanguageDefinition/Polski.g4 by ANTLR 4.13.1

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
using Antlr4.Runtime;
using Antlr4.Runtime.Atn;
using Antlr4.Runtime.Misc;
using DFA = Antlr4.Runtime.Dfa.DFA;

[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.13.1")]
[System.CLSCompliant(false)]
public partial class PolskiLexer : Lexer {
	protected static DFA[] decisionToDFA;
	protected static PredictionContextCache sharedContextCache = new PredictionContextCache();
	public const int
		INT=1, FLOAT=2, AND=3, EQUALS=4, GREATER_OR_EQUALS=5, GREATER=6, LESS_OR_EQUALS=7, 
		LESS=8, NOT=9, NOT_EQUALS=10, OR=11, XOR=12, ASSIGN=13, DIVIDE=14, MINUS=15, 
		MULTIPLY=16, PLUS=17, WHITESPACE=18, INTEGER_NUMBER=19, REAL_NUMBER=20, 
		IDENTIFIER=21, SEMICOLON=22;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"INT", "FLOAT", "AND", "EQUALS", "GREATER_OR_EQUALS", "GREATER", "LESS_OR_EQUALS", 
		"LESS", "NOT", "NOT_EQUALS", "OR", "XOR", "ASSIGN", "DIVIDE", "MINUS", 
		"MULTIPLY", "PLUS", "WHITESPACE", "INTEGER_NUMBER", "REAL_NUMBER", "IDENTIFIER", 
		"SEMICOLON"
	};


	public PolskiLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public PolskiLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'int'", "'float'", "'&&'", "'=='", "'>='", "'>'", "'<='", "'<'", 
		"'!'", "'!='", "'||'", "'^'", "'='", "'/'", "'-'", "'*'", "'+'", null, 
		null, null, null, "';'"
	};
	private static readonly string[] _SymbolicNames = {
		null, "INT", "FLOAT", "AND", "EQUALS", "GREATER_OR_EQUALS", "GREATER", 
		"LESS_OR_EQUALS", "LESS", "NOT", "NOT_EQUALS", "OR", "XOR", "ASSIGN", 
		"DIVIDE", "MINUS", "MULTIPLY", "PLUS", "WHITESPACE", "INTEGER_NUMBER", 
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

	public override string[] ChannelNames { get { return channelNames; } }

	public override string[] ModeNames { get { return modeNames; } }

	public override int[] SerializedAtn { get { return _serializedATN; } }

	static PolskiLexer() {
		decisionToDFA = new DFA[_ATN.NumberOfDecisions];
		for (int i = 0; i < _ATN.NumberOfDecisions; i++) {
			decisionToDFA[i] = new DFA(_ATN.GetDecisionState(i), i);
		}
	}
	private static int[] _serializedATN = {
		4,0,22,127,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,1,0,1,0,1,0,1,0,1,1,1,1,1,1,1,1,1,1,1,1,1,2,1,2,1,2,1,3,1,3,1,3,1,
		4,1,4,1,4,1,5,1,5,1,6,1,6,1,6,1,7,1,7,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,
		10,1,11,1,11,1,12,1,12,1,13,1,13,1,14,1,14,1,15,1,15,1,16,1,16,1,17,4,
		17,93,8,17,11,17,12,17,94,1,17,1,17,1,18,1,18,5,18,101,8,18,10,18,12,18,
		104,9,18,1,19,1,19,5,19,108,8,19,10,19,12,19,111,9,19,1,19,1,19,4,19,115,
		8,19,11,19,12,19,116,1,20,1,20,5,20,121,8,20,10,20,12,20,124,9,20,1,21,
		1,21,0,0,22,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,
		25,13,27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,1,0,5,3,0,
		9,10,13,13,32,32,1,0,49,57,1,0,48,57,2,0,65,90,97,122,3,0,48,57,65,90,
		97,122,131,0,1,1,0,0,0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,
		0,11,1,0,0,0,0,13,1,0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,
		1,0,0,0,0,23,1,0,0,0,0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,
		0,0,33,1,0,0,0,0,35,1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,
		1,0,0,0,1,45,1,0,0,0,3,49,1,0,0,0,5,55,1,0,0,0,7,58,1,0,0,0,9,61,1,0,0,
		0,11,64,1,0,0,0,13,66,1,0,0,0,15,69,1,0,0,0,17,71,1,0,0,0,19,73,1,0,0,
		0,21,76,1,0,0,0,23,79,1,0,0,0,25,81,1,0,0,0,27,83,1,0,0,0,29,85,1,0,0,
		0,31,87,1,0,0,0,33,89,1,0,0,0,35,92,1,0,0,0,37,98,1,0,0,0,39,105,1,0,0,
		0,41,118,1,0,0,0,43,125,1,0,0,0,45,46,5,105,0,0,46,47,5,110,0,0,47,48,
		5,116,0,0,48,2,1,0,0,0,49,50,5,102,0,0,50,51,5,108,0,0,51,52,5,111,0,0,
		52,53,5,97,0,0,53,54,5,116,0,0,54,4,1,0,0,0,55,56,5,38,0,0,56,57,5,38,
		0,0,57,6,1,0,0,0,58,59,5,61,0,0,59,60,5,61,0,0,60,8,1,0,0,0,61,62,5,62,
		0,0,62,63,5,61,0,0,63,10,1,0,0,0,64,65,5,62,0,0,65,12,1,0,0,0,66,67,5,
		60,0,0,67,68,5,61,0,0,68,14,1,0,0,0,69,70,5,60,0,0,70,16,1,0,0,0,71,72,
		5,33,0,0,72,18,1,0,0,0,73,74,5,33,0,0,74,75,5,61,0,0,75,20,1,0,0,0,76,
		77,5,124,0,0,77,78,5,124,0,0,78,22,1,0,0,0,79,80,5,94,0,0,80,24,1,0,0,
		0,81,82,5,61,0,0,82,26,1,0,0,0,83,84,5,47,0,0,84,28,1,0,0,0,85,86,5,45,
		0,0,86,30,1,0,0,0,87,88,5,42,0,0,88,32,1,0,0,0,89,90,5,43,0,0,90,34,1,
		0,0,0,91,93,7,0,0,0,92,91,1,0,0,0,93,94,1,0,0,0,94,92,1,0,0,0,94,95,1,
		0,0,0,95,96,1,0,0,0,96,97,6,17,0,0,97,36,1,0,0,0,98,102,7,1,0,0,99,101,
		7,2,0,0,100,99,1,0,0,0,101,104,1,0,0,0,102,100,1,0,0,0,102,103,1,0,0,0,
		103,38,1,0,0,0,104,102,1,0,0,0,105,109,7,1,0,0,106,108,7,2,0,0,107,106,
		1,0,0,0,108,111,1,0,0,0,109,107,1,0,0,0,109,110,1,0,0,0,110,112,1,0,0,
		0,111,109,1,0,0,0,112,114,5,46,0,0,113,115,7,2,0,0,114,113,1,0,0,0,115,
		116,1,0,0,0,116,114,1,0,0,0,116,117,1,0,0,0,117,40,1,0,0,0,118,122,7,3,
		0,0,119,121,7,4,0,0,120,119,1,0,0,0,121,124,1,0,0,0,122,120,1,0,0,0,122,
		123,1,0,0,0,123,42,1,0,0,0,124,122,1,0,0,0,125,126,5,59,0,0,126,44,1,0,
		0,0,6,0,94,102,109,116,122,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}