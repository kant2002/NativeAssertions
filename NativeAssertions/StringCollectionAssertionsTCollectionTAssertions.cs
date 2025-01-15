using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions;

public class StringCollectionAssertions<TCollection, TAssertions> : GenericCollectionAssertions<TCollection, string, TAssertions>
    where TCollection : IEnumerable<string>
    where TAssertions : StringCollectionAssertions<TCollection, TAssertions>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringCollectionAssertions{TCollection, TAssertions}"/> class.
    /// </summary>
    public StringCollectionAssertions(TCollection? actualValue)
        : base(actualValue)
    {
    }
}