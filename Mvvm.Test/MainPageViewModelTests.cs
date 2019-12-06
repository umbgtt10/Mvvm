using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mvvm.Test
{
    [TestClass]
    public class MainPageViewModelTests
    {
        [TestMethod]
        public void OnButtonIncrementClickedCommand_IncrementsResult()
        {
            // Arrange
            MainPageViewModel vm = new MainPageViewModel();

            // Act
            vm.OnIncrementCommand.Execute(null);

            // Assert
            Assert.AreEqual("1", vm.Result);
        }
    }
}
