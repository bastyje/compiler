using Antlr4.Runtime;
using Polski.Compiler.Error;
using Polski.Compiler.LanguageDefinition;

namespace Polski.Compiler.Common;

public class ScopeContext
{
    private ICollection<Member> CurrentScopeMembers
    {
        get
        {
            if (_stack.Count == 0)
            {
                throw new SemanticErrorInternalException("There is no defined scope");
            }
            
            return _stack.Peek();
        }
    }
    
    private readonly Stack<ICollection<Member>> _stack = new();

    public void PushScope()
    {
        if (_stack.Count > 0)
        {
            var currentScope = _stack.Peek();
            _stack.Push(new HashSet<Member>(currentScope));
            return;    
        }
        
        _stack.Push(new HashSet<Member>());
    }
    
    public void PopScope(ParserRuleContext context)
    {
        if (_stack.Count == 0)
        {
            throw new SemanticErrorException("There is no defined scope", context);
        }
        
        _stack.Pop();
    }
    
    public Member AddMember(PolskiMember polskiMember, ParserRuleContext context, bool stackAllocated = false)
    {
        if (_stack.Count == 0)
        {
            throw new SemanticErrorException("There is no defined scope", context);
        }
        
        if (CurrentScopeMembers.Any(m => m.PolskiMember.Name == polskiMember.Name))
        {
            throw new SemanticErrorException($"Variable {polskiMember.Name} is already defined in this scope", context);
        }
        
        var member = GenerateMember(polskiMember, stackAllocated);
        CurrentScopeMembers.Add(member);
        return member;
    }

    public Member AddMember(string type, bool stackAllocated = false)
    {
        var member = GenerateMember(type, stackAllocated);
        CurrentScopeMembers.Add(member);
        return member;
    }
    
    public Member GetMember(string name, ParserRuleContext context)
    {
        return CurrentScopeMembers.SingleOrDefault(m => m.PolskiMember.Name == name)
               ?? CurrentScopeMembers.SingleOrDefault(m => m.PolskiMember.Name == InternalMemberName(name))
               ?? throw new SemanticErrorException($"Variable {name} is not defined in this scope", context);
    }
    
    public bool TryGetMember(string name, ParserRuleContext context, out Member member)
    {
        try
        {
            member = GetMember(name, context);
        }
        catch (InvalidOperationException)
        {
            member = null;
        }
        return member is not null;
    }
    
    public void AddAnonymousMember()
    {
        CurrentScopeMembers.Add(GenerateMember(PolskiDataType.Anonymous, true));
    }

    private Member GenerateMember(PolskiMember polskiMember, bool stackAllocated)
    {
        var llvmName = GenerateMemberName();
        return new Member(polskiMember, llvmName, polskiMember.Type, stackAllocated);
    }

    private Member GenerateMember(string type, bool stackAllocated)
    {
        var llvmName = GenerateMemberName();
        return new Member(
            new PolskiMember(InternalMemberName(llvmName), type),
            llvmName,
            type,
            stackAllocated);
    }

    private string GenerateMemberName() => $"{CurrentScopeMembers.Count + 1}";
    private static string InternalMemberName(string memberName) => $"#{memberName}";
}