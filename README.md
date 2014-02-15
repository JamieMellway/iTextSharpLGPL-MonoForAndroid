

Mono has not implemented all of System.Drawing on Mono for Android.  There is some in Mono.Android and some similar classes in OpenTK.

Parts that are needed in iTextSharpLGPL that are missing include:
System.Drawing.Image;
System.Drawing.Imaging.ImageFormat;
System.Drawing.Drawing2d.Matrix;
System.Drawing.Bitmap

To get the solution to compile, I have added these classes in the SystemDrawingDummy folder.  These have the bare minimal amount of code to get it compile.  Do not expect images to work in the PDF.