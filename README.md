
This little project was inspired by section 10.1.2, "Caching results using memoization"
in the book, "Real-World Functional Programming" by Tomas Petricek and Jon Skeet.

In particular, I was interested in the following bit:

> Another option to make the Memoize method work with functions with multiple parameters
> would be to overload it for Func&lt;T1, T2, R&gt;, Func&lt;T1, T2, T3, R&gt; and so on.
> We would still use tuple as a key in the cache, but this would be hidden from the user
> of the method.

I have added such overloads for multiple parameters and implemented them in terms
of the overload that takes a single parameter. I have included unit tests too.

