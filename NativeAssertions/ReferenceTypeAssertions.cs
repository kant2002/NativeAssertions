﻿using NativeAssertions.Execution;

namespace NativeAssertions;

public abstract class ReferenceTypeAssertions<TSubject, TAssertions>
    where TAssertions : ReferenceTypeAssertions<TSubject, TAssertions>
{
    protected ReferenceTypeAssertions(TSubject? subject)
    {
        Subject = subject;
    }
    public TSubject? Subject { get; }
    protected abstract string Identifier { get; }
    public AndConstraint<TAssertions> BeNull(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(Subject is null)
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier(Identifier)
            .FailWith("Expected result to be <null>{reason}, but found {0}.", Subject);

        return new AndConstraint<TAssertions>((TAssertions)this);
    }

    public AndConstraint<TAssertions> NotBeNull(string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .ForCondition(Subject is not null)
            .BecauseOf(because, becauseArgs)
            .WithDefaultIdentifier(Identifier)
            .FailWith("Expected result not to be <null>{reason}.");

        return new AndConstraint<TAssertions>((TAssertions)this);
    }
}
