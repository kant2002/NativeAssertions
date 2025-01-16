using System;
#if USE_MSTEST
using ProducedAssertionException = Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException;
#else
#error "Unknown test framework"
#endif

namespace NativeAssertions.Tests;

[TestClass]
public sealed class StringCollectionsAssertionTests
{
    [TestMethod]
    public void NotNull_DoNothingWhenNotNull()
    {
        var result = new string[0];
        result.Should().NotBeNull();
    }

    [TestMethod]
    public void NotNull_ThrowWhenNull()
    {
        string[]? result = null;
        try
        {
            //FluentAssertions.AssertionExtensions.Should(result).NotBeNull();
            result.Should().NotBeNull();
            Assert.Fail("Test failed");
        }
        catch(ProducedAssertionException afe)
        {
            // "context"
            Assert.AreEqual("Expected result not to be <null>.", afe.Message);
        }
    }

    [TestMethod]
    public void BeNull_DoNothingWhenNull()
    {
        string[]? result = null;
        result.Should().BeNull();
    }

    [TestMethod]
    public void Null_ThrowWhenNotNull()
    {
        string[]? result = ["test"];
        try
        {
            result.Should().BeNull();
            Assert.Fail("Test failed");
        }
        catch (ProducedAssertionException afe)
        {
            // "context"
            Assert.AreEqual("Expected result to be <null>, but found {\"test\"}.", afe.Message);
        }
    }
}
