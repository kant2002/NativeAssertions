using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions.Execution;

public record FailReason(string Message, params object[] Args);
