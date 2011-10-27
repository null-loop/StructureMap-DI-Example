namespace ServiceLibrary
{
    using System;

    public interface ITimeProvider
    {
        DateTime ServerTime { get; }
    }
}