using System;

public class Example : IStaticAccess<int>
{
    public int Member1 
        => IStaticAccess<int>.MemberAccessor.Get<Game>();
    public int Member2 
        => this.GetProxyMember<int>(nameof(Member2), Member2Constructor);
    public int Member2Constructor() => 2;

    public Func<int> DelegateMember
        => this.GetProxyDelegate<Func<int>>(nameof(DelegateMemberFunction), DelegateMemberFunction);
    public int DelegateMemberFunction()
    {
        return 3;
    }
    public Example()
    {
        IStaticAccess<int>.MemberAccessor.SetMember<Game>(1);
        
    }
}