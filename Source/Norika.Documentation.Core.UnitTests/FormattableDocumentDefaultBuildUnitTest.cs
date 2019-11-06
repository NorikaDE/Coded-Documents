using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Norika.Documentation.Core.Types;

namespace Norika.Documentation.Core.UnitTests
{
    [TestClass]
    public class FormattableDocumentDefaultBuildUnitTest
    {
        [TestMethod]
        public void GetAssignableClassForInterface_WithInterfaceFormattableDocument_ShouldReturnMatchingClassTestPrintableDocument()
        {
            FormattableDocumentDefaultBuilder defaultBuilder = new FormattableDocumentDefaultBuilder();

            Type returnType = defaultBuilder.GetAssignableClassForInterface(typeof(IPrintableDocument));
            
            Assert.AreEqual(typeof(TestPrintableDocument), returnType);
        }
        
        [TestMethod]
        public void Build_WithInterfaceFormattableDocument_ShouldReturnInstanceOfTestPrintableDocument()
        {
            FormattableDocumentDefaultBuilder defaultBuilder = new FormattableDocumentDefaultBuilder();

            IPrintableDocument returnType = defaultBuilder.Build<IPrintableDocument>();
            
            Assert.IsInstanceOfType(returnType, typeof(TestPrintableDocument));
        }
        
        [TestMethod]
        [ExpectedException(typeof(TypeLoadException))]
        public void GetAssignableClassForInterface_WithClassType_ShouldThrowException()
        {
            FormattableDocumentDefaultBuilder defaultBuilder = new FormattableDocumentDefaultBuilder();

            defaultBuilder.GetAssignableClassForInterface(typeof(FormattableDocumentDefaultBuildUnitTest));

        }
    }
}