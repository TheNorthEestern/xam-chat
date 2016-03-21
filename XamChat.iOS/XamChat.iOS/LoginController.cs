using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using XamChat.Core;

namespace XamChat.iOS
{
	partial class LoginController : UIViewController
	{
		readonly LoginViewModel loginViewModel = ServiceContainer.Resolve<LoginViewModel>();

		public override void ViewDidLoad() {
			base.ViewDidLoad ();
			login.TouchUpInside += async(sender, e) => {
				loginViewModel.Username = username.Text;
				loginViewModel.Password = password.Text;
				try {
					await loginViewModel.Login();
					PerformSegue("OnLogin", this);
				} catch (Exception exc) {
					new UIAlertView("Oops!", exc.Message, null, "Ok").Show();	
				}
			};
		}

		public override void ViewWillAppear(bool animated) {
			base.ViewWillAppear (animated);
			loginViewModel.IsBusyChanged += OnIsBusyChanged;
		}

		public override void ViewWillDisappear(bool animated) {
			base.ViewWillDisappear (animated);
			loginViewModel.IsBusyChanged -= OnIsBusyChanged;
		}

		void OnIsBusyChanged(object sender, EventArgs e) {
			indicator.StartAnimating ();
			username.Enabled = password.Enabled = login.Enabled = indicator.Hidden = !loginViewModel.IsBusy;
		}

		public LoginController (IntPtr handle) : base (handle)
		{
		}
	}
}
