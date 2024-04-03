grammar Polski;

program
    : line
    ;
    
line
    : statement SEMICOLON
    ;

statement
    : declaration
    | definition
    | assignment
    | expression
    | printStatement
    | readStatement
    ;

printStatement
    : PRINT '(' expression ')'
    ;

readStatement
    : READ '(' IDENTIFIER ')'
    ;
   
assignment
    : IDENTIFIER ASSIGN expression;
    
expression
    : arithmeticExpression
    ;
    
arithmeticExpression
    : arithmeticExpression MULTIPLY arithmeticExpression
    | arithmeticExpression DIVIDE arithmeticExpression
    | arithmeticExpression PLUS arithmeticExpression
    | arithmeticExpression MINUS arithmeticExpression
    | IDENTIFIER
    | number
    ;

number
    : INTEGER_NUMBER
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
    : INT | FLOAT
    ;    

PRINT: 'print';
READ: 'read';

INT: 'int';
FLOAT: 'float';

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

INTEGER_NUMBER: [1-9][0-9]*;
REAL_NUMBER: [1-9][0-9]*'.'[0-9]+; 

IDENTIFIER: [a-zA-Z][a-zA-Z0-9]*;
SEMICOLON: ';';
