// This file is used by Code Analysis to maintain SuppressMessage 
// attributes that are applied to this project.
// Project-level suppressions either have no target or are given 
// a specific target and scoped to a namespace, type, member, etc.
//
// To add a suppression to this file, right-click the message in the 
// Code Analysis results, point to "Suppress Message", and click 
// "In Suppression File".
// You do not need to add suppressions to this file manually.

[assembly:
	System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1020:AvoidNamespacesWithFewTypes",
		Scope = "namespace", Target = "BasicLib.Forms.Scroll")]
[assembly:
	System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly",
		MessageId = "x", Scope = "member",
		Target = "BasicLib.Util.ArrayUtils.#MaxInd(System.Collections.Generic.IList`1<System.Double>)")]
[assembly:
	System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance",
		"CA1814:PreferJaggedArraysOverMultidimensional", MessageId = "Return", Scope = "member",
		Target = "BasicLib.Util.ArrayUtils.#ExtractColumns`1(!!0[,],System.Collections.Generic.IList`1<System.Int32>)")]
[assembly:
	System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "indices",
		Scope = "member",
		Target =
			"BasicLib.Util.ArrayUtils.#SubArray`1(System.Collections.Generic.IList`1<!!0>,System.Collections.Generic.IList`1<System.Int32>)"
		)]
[assembly:
	System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1726:UsePreferredTerms", MessageId = "indices",
		Scope = "member",
		Target = "BasicLib.Util.ArrayUtils.#SubList`1(System.Collections.Generic.List`1<!!0>,System.Int32[])")]