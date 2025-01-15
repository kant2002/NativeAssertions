# NativeAssertion
The assertion library, backward compatible to FluentAssertions.

## Approach

I don't want to fork FluentAssertions, since that library was licensed with Apache 2.0 and I'm not a lawyer. So I decide to take a look at existing projects which run assertions, and make them work with my library.
This would be clean room implementation from scratch. If you want your assertions back, please give it a try. I expect only namespace change for existing projects, and maybe I can create additional package which will use same namespaces, to simplify partial migrations.
