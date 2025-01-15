using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeAssertions;

public class GenericCollectionAssertions<TCollection, T, TAssertions> : ReferenceTypeAssertions<TCollection, TAssertions>
    where TCollection : IEnumerable<T>
    where TAssertions : GenericCollectionAssertions<TCollection, T, TAssertions>
{
    public GenericCollectionAssertions(TCollection? actualValue)
        : base(actualValue)
    {
    }
    protected override string Identifier => "collection";
}
