using SQLite.Net;
using SQLite.Net.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLite.Net.Async;


namespace FormPushNotification
{
	public class UserRepository 
	{

		private SQLiteAsyncConnection dbConn;
		public string StatusMessage { get; set; }

		public UserRepository(ISQLitePlatform sqlitePlatform, string dbPath)
		{
			//initialize a new SQLiteConnection 
			if (dbConn == null)
			{
				var connectionFunc = new Func<SQLiteConnectionWithLock>(() =>
					new SQLiteConnectionWithLock
					(
						sqlitePlatform,
						new SQLiteConnectionString(dbPath, storeDateTimeAsTicks: false)
					)
				);

				dbConn = new SQLiteAsyncConnection(connectionFunc);
				dbConn.CreateTableAsync<User>();
			}
		}
		public async Task  AddNewUser(string firstName , string lastName)
		{
			int result = 0;
			try
			{
				//basic validation to ensure a name was entered
				if (string.IsNullOrEmpty(firstName))
					throw new Exception("Valid name required");

				//insert a new person into the Person table
				result = await dbConn.InsertAsync(new User { FirstName = firstName, LastName = lastName});
				StatusMessage = string.Format("{0} record(s) added [Name: {1})", result, firstName);
			}
			catch (Exception ex)
			{
				StatusMessage = string.Format("Failed to add {0}. Error: {1}", firstName, ex.Message);
			}

		}

	}
}


