namespace ServiceLibrary
{
    using System;

    public interface ITimeFormatter
    {
        string Format(DateTime dateTime);

        string Format(DateTime dateTime, string format);
    }
}