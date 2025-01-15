using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions;

public class AndConstraint<T>
{
    public T And { get; }

    public AndConstraint(T parentConstraint)
    {
        And = parentConstraint;
    }
}