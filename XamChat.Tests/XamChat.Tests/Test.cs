﻿using NUnit.Framework;
using System;

namespace XamChat.Tests
{
	[TestFixture ()]
	public class Test
	{
		[Test ()]
		public void TestCase ()
		{
		}
		public static void SetUp() {
			ServiceContainer.Register<IWebService>(() => new FakeWebService { SleepDuration = 0 });
			ServiceContainer.Register<ISettings>(() => new FakeSettings());
		}
	}
}

