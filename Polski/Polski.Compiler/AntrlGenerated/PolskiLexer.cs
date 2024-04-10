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
		T__0=1, T__1=2, PRINT=3, READ=4, SEMICOLON=5, INT=6, INT64=7, FLOAT=8, 
		DOUBLE=9, AND=10, EQUALS=11, GREATER_OR_EQUALS=12, GREATER=13, LESS_OR_EQUALS=14, 
		LESS=15, NOT=16, NOT_EQUALS=17, OR=18, XOR=19, ASSIGN=20, DIVIDE=21, MINUS=22, 
		MULTIPLY=23, PLUS=24, WHITESPACE=25, INTEGER_NUMBER=26, REAL_NUMBER=27, 
		QUOTED_STRING=28, IDENTIFIER=29;
	public static string[] channelNames = {
		"DEFAULT_TOKEN_CHANNEL", "HIDDEN"
	};

	public static string[] modeNames = {
		"DEFAULT_MODE"
	};

	public static readonly string[] ruleNames = {
		"T__0", "T__1", "PRINT", "READ", "SEMICOLON", "INT", "INT64", "FLOAT", 
		"DOUBLE", "AND", "EQUALS", "GREATER_OR_EQUALS", "GREATER", "LESS_OR_EQUALS", 
		"LESS", "NOT", "NOT_EQUALS", "OR", "XOR", "ASSIGN", "DIVIDE", "MINUS", 
		"MULTIPLY", "PLUS", "WHITESPACE", "INTEGER_NUMBER", "REAL_NUMBER", "QUOTED_STRING", 
		"IDENTIFIER"
	};


	public PolskiLexer(ICharStream input)
	: this(input, Console.Out, Console.Error) { }

	public PolskiLexer(ICharStream input, TextWriter output, TextWriter errorOutput)
	: base(input, output, errorOutput)
	{
		Interpreter = new LexerATNSimulator(this, _ATN, decisionToDFA, sharedContextCache);
	}

	private static readonly string[] _LiteralNames = {
		null, "'('", "')'", "'print'", "'read'", "';'", "'int'", "'bigint'", "'float'", 
		"'double'", "'&&'", "'=='", "'>='", "'>'", "'<='", "'<'", "'!'", "'!='", 
		"'||'", "'^'", "'='", "'/'", "'-'", "'*'", "'+'"
	};
	private static readonly string[] _SymbolicNames = {
		null, null, null, "PRINT", "READ", "SEMICOLON", "INT", "INT64", "FLOAT", 
		"DOUBLE", "AND", "EQUALS", "GREATER_OR_EQUALS", "GREATER", "LESS_OR_EQUALS", 
		"LESS", "NOT", "NOT_EQUALS", "OR", "XOR", "ASSIGN", "DIVIDE", "MINUS", 
		"MULTIPLY", "PLUS", "WHITESPACE", "INTEGER_NUMBER", "REAL_NUMBER", "QUOTED_STRING", 
		"IDENTIFIER"
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
		4,0,29,181,6,-1,2,0,7,0,2,1,7,1,2,2,7,2,2,3,7,3,2,4,7,4,2,5,7,5,2,6,7,
		6,2,7,7,7,2,8,7,8,2,9,7,9,2,10,7,10,2,11,7,11,2,12,7,12,2,13,7,13,2,14,
		7,14,2,15,7,15,2,16,7,16,2,17,7,17,2,18,7,18,2,19,7,19,2,20,7,20,2,21,
		7,21,2,22,7,22,2,23,7,23,2,24,7,24,2,25,7,25,2,26,7,26,2,27,7,27,2,28,
		7,28,1,0,1,0,1,1,1,1,1,2,1,2,1,2,1,2,1,2,1,2,1,3,1,3,1,3,1,3,1,3,1,4,1,
		4,1,5,1,5,1,5,1,5,1,6,1,6,1,6,1,6,1,6,1,6,1,6,1,7,1,7,1,7,1,7,1,7,1,7,
		1,8,1,8,1,8,1,8,1,8,1,8,1,8,1,9,1,9,1,9,1,10,1,10,1,10,1,11,1,11,1,11,
		1,12,1,12,1,13,1,13,1,13,1,14,1,14,1,15,1,15,1,16,1,16,1,16,1,17,1,17,
		1,17,1,18,1,18,1,19,1,19,1,20,1,20,1,21,1,21,1,22,1,22,1,23,1,23,1,24,
		4,24,138,8,24,11,24,12,24,139,1,24,1,24,1,25,1,25,5,25,146,8,25,10,25,
		12,25,149,9,25,1,26,1,26,5,26,153,8,26,10,26,12,26,156,9,26,1,26,1,26,
		4,26,160,8,26,11,26,12,26,161,1,27,1,27,1,27,1,27,5,27,168,8,27,10,27,
		12,27,171,9,27,1,27,1,27,1,28,1,28,5,28,177,8,28,10,28,12,28,180,9,28,
		0,0,29,1,1,3,2,5,3,7,4,9,5,11,6,13,7,15,8,17,9,19,10,21,11,23,12,25,13,
		27,14,29,15,31,16,33,17,35,18,37,19,39,20,41,21,43,22,45,23,47,24,49,25,
		51,26,53,27,55,28,57,29,1,0,6,3,0,9,10,13,13,32,32,1,0,49,57,1,0,48,57,
		2,0,34,34,92,92,2,0,65,90,97,122,3,0,48,57,65,90,97,122,187,0,1,1,0,0,
		0,0,3,1,0,0,0,0,5,1,0,0,0,0,7,1,0,0,0,0,9,1,0,0,0,0,11,1,0,0,0,0,13,1,
		0,0,0,0,15,1,0,0,0,0,17,1,0,0,0,0,19,1,0,0,0,0,21,1,0,0,0,0,23,1,0,0,0,
		0,25,1,0,0,0,0,27,1,0,0,0,0,29,1,0,0,0,0,31,1,0,0,0,0,33,1,0,0,0,0,35,
		1,0,0,0,0,37,1,0,0,0,0,39,1,0,0,0,0,41,1,0,0,0,0,43,1,0,0,0,0,45,1,0,0,
		0,0,47,1,0,0,0,0,49,1,0,0,0,0,51,1,0,0,0,0,53,1,0,0,0,0,55,1,0,0,0,0,57,
		1,0,0,0,1,59,1,0,0,0,3,61,1,0,0,0,5,63,1,0,0,0,7,69,1,0,0,0,9,74,1,0,0,
		0,11,76,1,0,0,0,13,80,1,0,0,0,15,87,1,0,0,0,17,93,1,0,0,0,19,100,1,0,0,
		0,21,103,1,0,0,0,23,106,1,0,0,0,25,109,1,0,0,0,27,111,1,0,0,0,29,114,1,
		0,0,0,31,116,1,0,0,0,33,118,1,0,0,0,35,121,1,0,0,0,37,124,1,0,0,0,39,126,
		1,0,0,0,41,128,1,0,0,0,43,130,1,0,0,0,45,132,1,0,0,0,47,134,1,0,0,0,49,
		137,1,0,0,0,51,143,1,0,0,0,53,150,1,0,0,0,55,163,1,0,0,0,57,174,1,0,0,
		0,59,60,5,40,0,0,60,2,1,0,0,0,61,62,5,41,0,0,62,4,1,0,0,0,63,64,5,112,
		0,0,64,65,5,114,0,0,65,66,5,105,0,0,66,67,5,110,0,0,67,68,5,116,0,0,68,
		6,1,0,0,0,69,70,5,114,0,0,70,71,5,101,0,0,71,72,5,97,0,0,72,73,5,100,0,
		0,73,8,1,0,0,0,74,75,5,59,0,0,75,10,1,0,0,0,76,77,5,105,0,0,77,78,5,110,
		0,0,78,79,5,116,0,0,79,12,1,0,0,0,80,81,5,98,0,0,81,82,5,105,0,0,82,83,
		5,103,0,0,83,84,5,105,0,0,84,85,5,110,0,0,85,86,5,116,0,0,86,14,1,0,0,
		0,87,88,5,102,0,0,88,89,5,108,0,0,89,90,5,111,0,0,90,91,5,97,0,0,91,92,
		5,116,0,0,92,16,1,0,0,0,93,94,5,100,0,0,94,95,5,111,0,0,95,96,5,117,0,
		0,96,97,5,98,0,0,97,98,5,108,0,0,98,99,5,101,0,0,99,18,1,0,0,0,100,101,
		5,38,0,0,101,102,5,38,0,0,102,20,1,0,0,0,103,104,5,61,0,0,104,105,5,61,
		0,0,105,22,1,0,0,0,106,107,5,62,0,0,107,108,5,61,0,0,108,24,1,0,0,0,109,
		110,5,62,0,0,110,26,1,0,0,0,111,112,5,60,0,0,112,113,5,61,0,0,113,28,1,
		0,0,0,114,115,5,60,0,0,115,30,1,0,0,0,116,117,5,33,0,0,117,32,1,0,0,0,
		118,119,5,33,0,0,119,120,5,61,0,0,120,34,1,0,0,0,121,122,5,124,0,0,122,
		123,5,124,0,0,123,36,1,0,0,0,124,125,5,94,0,0,125,38,1,0,0,0,126,127,5,
		61,0,0,127,40,1,0,0,0,128,129,5,47,0,0,129,42,1,0,0,0,130,131,5,45,0,0,
		131,44,1,0,0,0,132,133,5,42,0,0,133,46,1,0,0,0,134,135,5,43,0,0,135,48,
		1,0,0,0,136,138,7,0,0,0,137,136,1,0,0,0,138,139,1,0,0,0,139,137,1,0,0,
		0,139,140,1,0,0,0,140,141,1,0,0,0,141,142,6,24,0,0,142,50,1,0,0,0,143,
		147,7,1,0,0,144,146,7,2,0,0,145,144,1,0,0,0,146,149,1,0,0,0,147,145,1,
		0,0,0,147,148,1,0,0,0,148,52,1,0,0,0,149,147,1,0,0,0,150,154,7,1,0,0,151,
		153,7,2,0,0,152,151,1,0,0,0,153,156,1,0,0,0,154,152,1,0,0,0,154,155,1,
		0,0,0,155,157,1,0,0,0,156,154,1,0,0,0,157,159,5,46,0,0,158,160,7,2,0,0,
		159,158,1,0,0,0,160,161,1,0,0,0,161,159,1,0,0,0,161,162,1,0,0,0,162,54,
		1,0,0,0,163,169,5,34,0,0,164,165,5,92,0,0,165,168,5,34,0,0,166,168,8,3,
		0,0,167,164,1,0,0,0,167,166,1,0,0,0,168,171,1,0,0,0,169,167,1,0,0,0,169,
		170,1,0,0,0,170,172,1,0,0,0,171,169,1,0,0,0,172,173,5,34,0,0,173,56,1,
		0,0,0,174,178,7,4,0,0,175,177,7,5,0,0,176,175,1,0,0,0,177,180,1,0,0,0,
		178,176,1,0,0,0,178,179,1,0,0,0,179,58,1,0,0,0,180,178,1,0,0,0,8,0,139,
		147,154,161,167,169,178,1,6,0,0
	};

	public static readonly ATN _ATN =
		new ATNDeserializer().Deserialize(_serializedATN);


}