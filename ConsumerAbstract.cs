using System;
using System.Reflection;

public abstract class ConsumerAbstract<TMember>
{
    public TMember Proxy 
        => this.GetSetProxy<TMember>(nameof(Proxy), ProxyConstructor);
    protected abstract TMember ProxyConstructor();
    public Action<TMember> DelegateProxy 
        => this.GetSetDelegate<Action<TMember>>(nameof(ProxyMethod), ProxyMethod);
    protected abstract void ProxyMethod(TMember t);
}
