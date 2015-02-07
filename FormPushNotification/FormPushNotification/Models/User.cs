using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite.Net.Attributes;

namespace FormPushNotification
{
	[Table("User")]
	public class User
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set; }

		[MaxLength(100), Unique]
		public string FirstName { get; set; }

		[MaxLength(100), Unique]
		public string LastName { get; set; }

	}
}

