# RNG-Bug-in-.NET-Core

This is demonstration of the bug in the standard .NET 5 (3.1 Core as well) Random Number Generator. When trying to
sample geometric distribution in the straightforward way, bin #55 for item=54 would have very low count. If one
 run code sample with .NET 5 (rc1 or preview), as well as .NET Core 3.1,

> dotnet build

> dotnet run

it will produce something like

...

51 1374675

52 1341288

53 1309615

54 652945   !NB

55 1275427

56 1241591

57 1210362

58 1179689

...

Curve should be following exponential law, because geometric distribution is discrete analog of the exponential distribution.

# Moral of the story

Avoid .NET build-in random number generator for any serious work, maybe good for demos/teaching.

# References

Originally read it [here](https://stackoverflow.com/questions/63276505/why-is-the-pseudo-random-number-generator-less-likely-to-generate-54-big-numbers). Tested with .NET Core 3.1 and 5 and reported to MS [here](https://github.com/dotnet/runtime/issues/40490), and MS folks said they are aware of the issue. General discussion of the whole mess is [here](https://github.com/dotnet/runtime/issues/23198).
