using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace FormPushNotification
{
	public partial class UserGrid : ContentPage
	{
		public UserGrid ()
		{
			InitializeComponent ();
		}

		public async void OnSendButtonClicked(object sender, EventArgs args){
		
			await App.UserRepo.AddNewUser (newFirstName.Text, newLastName.Text);


		}

		public void OnSyncButtonClicked(object sender, EventArgs args){
		
			//FormPushNotification.App.UserRepo.AddNewUser (newPerson.Text);


		}

	}
}

