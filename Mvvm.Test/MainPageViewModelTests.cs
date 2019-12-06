using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mvvm.Test
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        public void OnButtonIncrementClickedCommand_IncrementsResult()
        {
            var vm = new MainPageViewModel();

            vm.OnIncrementCommand.Execute(null);

            Assert.AreEqual("1", vm.Result);
        }
    }
}
