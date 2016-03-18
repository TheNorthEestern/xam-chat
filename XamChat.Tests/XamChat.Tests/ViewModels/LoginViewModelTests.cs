﻿using System;
using System.Threading.Tasks;
using XamChat.Core;
using XamChat.Tests;
using NUnit.Framework;

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
	[Test, ExpectedException(typeof(Exception), ExpectedMessage="Username is blank.")]
	public async Task LoginWithNoUsernameOrPassword() {
		// Throws an exception
		await loginViewModel.Login();
	}
}