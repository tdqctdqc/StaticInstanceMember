using System;

public class ConsumerConcrete<TMember>
    : ConsumerAbstract<TMember>
{
    protected override TMember ProxyConstructor()
    {
        throw new NotImplementedException();
    }

    protected override void ProxyMethod(TMember t)
    {
        throw new NotImplementedException();
    }
}
