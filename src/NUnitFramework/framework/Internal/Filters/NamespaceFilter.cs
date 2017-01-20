// ***********************************************************************
// Copyright (c) 2015 Charlie Poole
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// ***********************************************************************

using System;
using NUnit.Framework.Interfaces;

namespace Foo
{
    
}

namespace Bar
{
    
}

namespace NUnit.Framework.Internal.Filters
{
    /// <summary>
    /// ClassName filter selects tests based on the class FullName
    /// </summary>
#if !PORTABLE && !NETSTANDARD1_6
    [Serializable]
#endif
    public class NamespaceFilter : ValueMatchFilter
    {
        /// <summary>
        /// Construct a NamespaceFilter for a single namespace
        /// </summary>
        /// <param name="expectedValue">The namespace the filter will recognize.</param>
        public NamespaceFilter(string expectedValue) : base(expectedValue) { }

        /// <summary>
        /// Match a test against a single value.
        /// </summary>
        public override bool Match(ITest test)
        {
            string containingNamespace = null;

            if (test is Test)
            {
                containingNamespace = test.TypeInfo.Namespace;
            }
            else if (test is TestFixture)
            {
                ((TestFixture)test)
            }
            else if (test is TestSuite)
            {
                
            }

                if (test.IsSuite && (test.Tests.Count > 0))
                {
                    containingNamespace = test.Tests[0].TypeInfo.Namespace;
                }
                else
                {
                    var className = test.ToString();
                    containingNamespace = className.Substring(0, className.LastIndexOf("."));
                }

            return Match(containingNamespace);
        }

        /// <summary>
        /// Gets the element name
        /// </summary>
        /// <value>Element name</value>
        protected override string ElementName
        {
            get { return "namespace"; }
        }
    }
}
