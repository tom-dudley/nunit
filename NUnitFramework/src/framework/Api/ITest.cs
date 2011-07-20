// ***********************************************************************
// Copyright (c) 2007 Charlie Poole
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

namespace NUnit.Framework.Api
{
	/// <summary>
	/// Common interface supported by all representations
	/// of a test. Only includes informational fields.
	/// The Run method is specifically excluded to allow
	/// for data-only representations of a test.
	/// </summary>
	public interface ITest : IXmlNodeBuilder
    {
        /// <summary>
        /// Gets or sets the id of the test
        /// </summary>
        int Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the test
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Gets or sets the fully qualified name of the test
        /// </summary>
        string FullName { get; }

        /// <summary>
        /// Indicates whether the test can be run using
        /// the RunState enum.
        /// </summary>
		RunState RunState { get; set; }

        /// <summary>
        /// A string representing the type of test. Used as an attribute
        /// value in the XML representation of a test and has no other
        /// function in the framework.
        /// </summary>
        //string TestKind { get; }

        /// <summary>
        /// Count of the test cases ( 1 if this is a test case )
        /// </summary>
		int TestCaseCount { get; }

		/// <summary>
		/// Gets the properties of the test
		/// </summary>
		IPropertyBag Properties { get; }

        /// <summary>
        /// Gets the parent test, if any.
        /// </summary>
        /// <value>The parent test or null if none exists.</value>
        ITest Parent { get; }

        /// <summary>
        /// Gets a bool indicating whether the current test
        /// has any descendant tests.
        /// </summary>
        bool HasChildren { get; }

        /// <summary>
        /// Gets this test's child tests
        /// </summary>
        /// <value>A list of child tests</value>
#if CLR_2_0 || CLR_4_0
        System.Collections.Generic.IList<ITest> Tests { get; }
#else
        System.Collections.IList Tests { get; }
#endif
    }
}
