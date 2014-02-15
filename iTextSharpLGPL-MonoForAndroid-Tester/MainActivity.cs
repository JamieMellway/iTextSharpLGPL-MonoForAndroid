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
				try {
					string path = System.Environment.GetFolderPath (System.Environment.SpecialFolder.Personal);
					string fileName = System.IO.Path.Combine (path, "Tester.pdf");
					Console.WriteLine (fileName);
					Document document = new Document (PageSize.LETTER);
					using (FileStream fileStream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite)) {
						PdfWriter writer = PdfWriter.GetInstance (document, fileStream);
						writer.ViewerPreferences = PdfWriter.PageModeUseOutlines;
						try {
							document.Open ();
							BaseFont bf = BaseFont.CreateFont (BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
							iTextSharp.text.Font font = new iTextSharp.text.Font (bf);
							document.Add (new Paragraph ("Test", font)); 
						} catch (Exception ex) {
							Console.WriteLine (ex.ToString());
						}
						document.Close ();
						writer.Close ();
					}
				} catch (Exception ex) {
					Console.WriteLine (ex.ToString());
				}
			};
		}
	}
}