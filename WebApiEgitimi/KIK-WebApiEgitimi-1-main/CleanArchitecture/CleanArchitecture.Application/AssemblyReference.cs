using System.Reflection;

namespace CleanArchitecture.Application;

public static class AssemblyReference
{
    public static Assembly Assembly = typeof(Assembly).Assembly;
}
