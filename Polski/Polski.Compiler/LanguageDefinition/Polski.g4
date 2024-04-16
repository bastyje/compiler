grammar Polski;

program
    : line+
    ;
    
line
    : statement SEMICOLON
    | block
    | functionDeclaration
    | if
    | while
    ;

statement
    : declaration
    | definition
    | assignment
    | expression
    | print
    | read
    ;
    
block
    : '{' line* '}'
    ;
    
functionDeclaration
    : 'niech będzie operacja' IDENTIFIER ('na wartościach' declaration+)? 'której rezultatem jest' type 'to' block
    ;
    
if
    : 'jeżeli' booleanOrExpression 'to' block (ELSE block)?
    | 'wykonaj' block ('jeżeli' | 'pod warunkiem, że') booleanOrExpression
    ;
    
while
    : 'dopóki' booleanOrExpression ('wykonuj' | 'kręć' | 'to') block
    ;
    
print
    : ('pokaż mi' | 'zaprezentuj') expression
    ;
    
read
    : 'zczytaj' IDENTIFIER
    ;
    
assignment
    : IDENTIFIER ASSIGN expression
    ;
    
booleanOrExpression
    : booleanAndExpression (OR booleanAndExpression)*
    ;
    
booleanAndExpression
    : booleanXorExpression (AND booleanXorExpression)*
    ;
    
booleanXorExpression
    : booleanPrimaryExpression (XOR booleanPrimaryExpression)*
    ;
    
booleanPrimaryExpression
    : booleanValue
    | NOT booleanPrimaryExpression
    ;
    
booleanValue
    : expression EQUALS expression
    | expression NOT_EQUALS expression
    | expression GREATER expression
    | expression GREATER_OR_EQUALS expression
    | expression LESS expression
    | expression LESS_OR_EQUALS expression
    ;
    
expression
    : additiveExpression
    ;
    
additiveExpression
    : multiplicativeExpression ((PLUS | MINUS) multiplicativeExpression)*
    ;

multiplicativeExpression
    : unaryExpression ((MULTIPLY | DIVIDE) unaryExpression)*
    ;

unaryExpression
    : primaryExpression
    ;

primaryExpression
    : IDENTIFIER
    | number
    ;

number
    : INTEGER_NUMBER
    | BIG_INTEGER_NUMBER
    | REAL_NUMBER
    ;
    
declaration
    : LET? type IDENTIFIER
    ;

definition
    : declaration ASSIGN expression
    ;
    
type
    : numericType
    ;

numericType
    : INT | INT64 | DOUBLE
    ;
    
ELSE: 'w przeciwnym razie';
SEMICOLON: ';';
INT64: 'duża liczba całkowita';
INT: 'liczba całkowita';
DOUBLE: 'liczba rzeczywista';

LET : 'niech' | 'niech będzie';
AND: 'oraz' | 'tudzież' | 'i' | 'i zarazem';
EQUALS: 'jest ' ('równy' | 'równa' | 'równe');
GREATER_OR_EQUALS: 'jest ' ('większy lub równy' | 'większa lub równa' | 'większe lub równe');
GREATER: 'jest ' ('większy niż' | 'większa niż' | 'większe niż');
LESS_OR_EQUALS: 'jest ' ('mniejszy lub równy' | 'mniejsza lub równa' | 'mniejsze lub równe');
LESS: 'jest ' ('mniejszy niż' | 'mniejsza niż' | 'mniejsze niż');
NOT: 'nieprawdą jest, że';
NOT_EQUALS: 'nie jest ' ('równy' | 'równa' | 'równe');
OR: 'i/lub';
XOR: 'lub' | 'albo';

ASSIGN: '=' | 'będzie';
DIVIDE: '/';
MINUS: '-';
MULTIPLY: '*';
PLUS: '+';

WHITESPACE: [ \t\r\n]+ -> skip;
BIG_REAL_NUMBER: ('0' | [1-9][0-9]*) '.' [0-9]+ 'b';
REAL_NUMBER: ('0' | [1-9][0-9]*) '.' [0-9]+;
BIG_INTEGER_NUMBER: ('0' | [1-9][0-9]*) 'b';
INTEGER_NUMBER: '0' | [1-9][0-9]*;

IDENTIFIER: [a-zA-Z][a-zA-Z0-9]*;
