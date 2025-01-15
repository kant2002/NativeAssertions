using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions.Execution;

[Serializable]
public class AssertionFailedException : Exception
{
    public AssertionFailedException(string message)
        : base(message)
    {
    }

    protected AssertionFailedException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}