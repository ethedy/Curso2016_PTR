using System;
using System.Linq;
using Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace OMB_Tests.Test.Services
{
  [TestClass]
  public class ProductServicesFixture
  {
    [TestMethod]
    public void AccesoCorrectoAEditoriales()
    {
      var edit = OMBContext.DB.Editoriales;

      Assert.IsNotNull(edit);
      Assert.IsTrue(edit.Count() >= 0);
    }
  }
}
