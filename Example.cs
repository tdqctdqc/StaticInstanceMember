using System;

public class Example : IStaticAccess<int>
{
    //two styles of accessing 
    //first is for when you want to set the member by reflection 
    //second is for when you want implementing class to set member
    
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