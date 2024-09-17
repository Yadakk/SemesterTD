using System;

public interface ICounterOutput
{
    public event Action<string> OnOutput;
}
