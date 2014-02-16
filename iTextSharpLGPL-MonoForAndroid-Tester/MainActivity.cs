using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Android.Content.PM;
using System.Collections.Generic;

namespace iTextSharpLGPLMonoForAndroidTester
{
	[Activity (Label = "iTextSharpLGPL-MonoForAndroid-Tester", MainLauncher = true)]
	public class TesterActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

			Button button = FindViewById<Button> (Resource.Id.myButton);

			button.Click += delegate {
				string fileLocation = "/sdcard/PDF_Temp.pdf";
				Java.IO.File file = new Java.IO.File (fileLocation);
				this.CreatePDF (fileLocation);

				if (file.Exists ()) {
					Intent intent = DisplayPDF (file);

					IList<ResolveInfo> activities = this.PackageManager.QueryIntentActivities (
						                                intent, 
						                                Android.Content.PM.PackageInfoFlags.Activities);

					if (activities.Count > 0) {
						StartActivity (intent);
					}
				}
			};
		}

		public void CreatePDF (string filePdf)
		{
			var document = new Document (PageSize.LETTER);

			// Create a new PdfWriter object, specifying the output stream
			var output = new FileStream (filePdf, FileMode.Create);
			var writer = PdfWriter.GetInstance (document, output);

			// Open the Document for writing
			document.Open ();

			BaseFont bf = BaseFont.CreateFont (BaseFont.HELVETICA, BaseFont.CP1252, false);
			iTextSharp.text.Font font = new iTextSharp.text.Font (bf, 16, iTextSharp.text.Font.BOLD);
			var p = new Paragraph ("Sample text", font);

			document.Add (p);
			document.Close ();
			writer.Close ();

			//Close the Document - this saves the document contents to the output stream
			document.Close ();
			writer.Close ();
		}

		public Intent DisplayPDF (Java.IO.File file)
		{
			Intent intent = new Intent (Intent.ActionView);
			Android.Net.Uri filepath = Android.Net.Uri.FromFile (file);
			intent.SetDataAndType (filepath, "application/pdf");
			intent.SetFlags (ActivityFlags.ClearTop);
			return intent;
		}
	}
}