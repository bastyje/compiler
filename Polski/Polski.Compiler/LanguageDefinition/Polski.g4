grammar Polski;

program
    : line+
    ;
    
line
    : statement SEMICOLON
    ;

statement
    : declaration
    | definition
    | assignment
    | expression
    | print
    | read
    ;
    
print
    : 'print' expression
    ;
    
read
    : 'read' IDENTIFIER
    ;
    
assignment
    : IDENTIFIER ASSIGN expression;
    
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
    : type IDENTIFIER
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
    


SEMICOLON: ';';
INT: 'int';
INT64: 'bigint';
DOUBLE: 'double';

AND: '&&';
EQUALS: '==';
GREATER_OR_EQUALS: '>=';
GREATER: '>';
LESS_OR_EQUALS: '<=';
LESS: '<';
NOT: '!';
NOT_EQUALS: '!=';
OR: '||';
XOR: '^';

ASSIGN: '=';
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
