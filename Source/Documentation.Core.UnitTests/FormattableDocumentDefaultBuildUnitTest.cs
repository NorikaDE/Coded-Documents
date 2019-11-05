using System;
using Documentation.Core.Types;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Documentation.Core.UnitTests
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
    }
}