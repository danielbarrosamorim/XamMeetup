using SQLite.Net.Interop;
using Xamarin.Forms;

namespace FormPushNotification
{
	public class App : Application
	{
		public static UserRepository UserRepo { get; private set; }

		public App(string dbPath, ISQLitePlatform sqlitePlatform)
		{
			//set database path first, then retrieve main page
			UserRepo = new UserRepository(sqlitePlatform, dbPath);

			this.MainPage = new UserGrid();
		}
	}
}
