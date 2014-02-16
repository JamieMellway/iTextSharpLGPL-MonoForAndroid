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

			string path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Desktop);
						if (!Directory.Exists(path)) {
							Directory.CreateDirectory(path);
						}
			
						string filePdf = Path.Combine (path, "PDF_Temp.pdf");

			Java.IO.File file = new Java.IO.File(filePdf);
						this.CreatePDF (filePdf);

			if (file.Exists())
			{
				Intent intent = DisplayPDF (file);
				StartActivity(intent);
			}
		}

		public void CreatePDF(string filePdf){
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

		public Intent DisplayPDF(Java.IO.File file)
		{
			Intent intent = new Intent(Intent.ActionView);
			Android.Net.Uri filepath = Android.Net.Uri.FromFile(file);
			intent.SetDataAndType(filepath, "application/pdf");
			intent.SetFlags(ActivityFlags.ClearTop);
			return intent;
		}
	}
}