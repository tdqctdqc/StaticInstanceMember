using System;

public class Example : IStaticAccess<int>
{
    
    public int Member2Constructor() => 2;
    public int Delegate2Function()
    {
        return 3;
    }
    public Example()
    {
    }
}