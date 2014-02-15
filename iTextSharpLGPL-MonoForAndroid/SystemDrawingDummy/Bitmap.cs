using System;

namespace System.Drawing
{
	public class Bitmap : Image
	{
		public void SetPixel (int i, int h, System.Drawing.Color c)
		{
			throw new NotImplementedException ();
		}

		public Bitmap (int fullWidth, int height)
		{
			throw new NotImplementedException ();
		}

		public Color GetPixel (int x, int y)
		{
			throw new NotImplementedException ();
		}

		public int Height {
			get;
			set;
		}

		public int Width {
			get;
			set;
		}
//		public Bitmap ()
//		{
		//		}
	}
}

