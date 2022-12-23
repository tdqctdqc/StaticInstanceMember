using System;
using System.Reflection;

public abstract class ConsumerAbstract<TMember>
{
    public TMember Proxy 
        => this.GetProxyMember<TMember>(nameof(Proxy), ProxyConstructor);
    protected abstract TMember ProxyConstructor();
    public Action<TMember> DelegateProxy 
        => this.GetProxyDelegate<Action<TMember>>(nameof(ProxyMethod), ProxyMethod);
    protected abstract void ProxyMethod(TMember t);
}
