using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions;

public class StringCollectionAssertions(IEnumerable<string>? target) : StringCollectionAssertions<IEnumerable<string>>(target)
{
}
