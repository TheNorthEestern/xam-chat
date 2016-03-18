using NUnit.Framework;
using XamChat.Core;
using XamChat.Tests;
using System.Threading.Tasks;

[TestFixture]
public class LoginViewModelTests {
	LoginViewModel loginViewModel;
	ISettings settings;
	[SetUp]
	public void SetUp() {
		Test.SetUp ();
		settings = ServiceContainer.Resolve<ISettings> ();
		loginViewModel = new LoginViewModel ();
	}
	[Test]
	public async Task LoginSuccessfully() {
		loginViewModel.Username = "testuser";
		loginViewModel.Password = "password";
		await loginViewModel.Login ();
		Assert.That (settings.User, Is.Not.Null);
	}
}