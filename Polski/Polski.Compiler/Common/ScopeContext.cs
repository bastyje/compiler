namespace Polski.Compiler.Common;

public class ScopeContext
{
    private ICollection<Member> CurrentScopeMembers
    {
        get
        {
            if (_stack.Count == 0)
            {
                throw new InvalidOperationException("There is no defined scope");
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
    
    public void PopScope()
    {
        if (_stack.Count == 0)
        {
            throw new InvalidOperationException("There is no defined scope");
        }
        
        _stack.Pop();
    }
    
    public Member AddMember(PolskiMember polskiMember, bool stackAllocated = false)
    {
        if (_stack.Count == 0)
        {
            throw new InvalidOperationException("There is no defined scope");
        }
        
        if (CurrentScopeMembers.Any(m => m.PolskiMember.Name == polskiMember.Name))
        {
            throw new InvalidOperationException($"Variable {polskiMember.Name} is already defined in this scope");
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
    
    public Member GetMember(string name)
    {
        return CurrentScopeMembers.SingleOrDefault(m => m.PolskiMember.Name == name)
               ?? CurrentScopeMembers.SingleOrDefault(m => m.PolskiMember.Name == InternalMemberName(name))
               ?? throw new InvalidOperationException($"Variable {name} is not defined in this scope");
    }
    
    public bool TryGetMember(string name, out Member member)
    {
        try
        {
            member = GetMember(name);
        }
        catch (InvalidOperationException)
        {
            member = null;
        }
        return member is not null;
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