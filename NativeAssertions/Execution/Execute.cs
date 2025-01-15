using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions.Execution;

public static class Execute
{
    public static AssertionScope Assertion => AssertionScope.Current;
}
