namespace grading_tab.application.Extensions;

public static class StringExtensions
{
    public static Guid ToGuid(this string str) => Guid.Parse(str);
}