using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions;

public class StringCollectionAssertions<TCollection>
    : StringCollectionAssertions<TCollection, StringCollectionAssertions<TCollection>>
    where TCollection : IEnumerable<string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringCollectionAssertions{TCollection}"/> class.
    /// </summary>
    public StringCollectionAssertions(TCollection? actualValue)
        : base(actualValue)
    {
    }
}