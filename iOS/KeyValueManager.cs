using System;

using UIKit;
using Security;
using Foundation;

using Debug = System.Diagnostics.Debug;

namespace Liddle.iOS
{
	public class KeyValueManager
	{

		public void SaveRecord (string key, string item)
		{

			var record = new SecRecord (SecKind.GenericPassword) {
				ValueData = NSData.FromString (item),
				Generic = NSData.FromString (key)
			};

			var status = SecKeyChain.Add (record);

			if (SecStatusCode.Success == status) {
				Debug.WriteLine ("Keychain Saved!");
			} else if (SecStatusCode.DuplicateItem == status || SecStatusCode.DuplicateKeyChain == status) {
				Debug.WriteLine ("Duplicate !");
				SecKeyChain.Remove (record);
			} else {
				Debug.WriteLine ($"{ status }");
			}

		}

		public string QueryRecord (string key)
		{

			SecStatusCode status;

			var rec = new SecRecord (SecKind.GenericPassword) {
				Generic = NSData.FromString (key)
			};

			var match = SecKeyChain.QueryAsRecord (rec, out status);

			if (SecStatusCode.Success == status && null != match) {

				Debug.WriteLine ($"{match.Account};{match.ValueData.ToString ()}");

				return match.Account;
			}

			Debug.WriteLine ("Nothing found.");
			return string.Empty;

		}

		public void SaveNSDefaults (string key, string item)
		{
			NSUserDefaults.StandardUserDefaults.SetString (item, key);
			NSUserDefaults.StandardUserDefaults.Synchronize ();

			Debug.WriteLine ($"{ item } Saved!");
		}

		public string ReadNSDefaults (string key)
		{
			var stored = NSUserDefaults.StandardUserDefaults.StringForKey (key);

			Debug.WriteLine ($"stored:{stored}!");

			return stored;
		}
	}
}

