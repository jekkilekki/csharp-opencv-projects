using System;
using OpenCvSharp;

namespace Project
{
    class Program1
    {
        static void Main(string[] args)
        {
            int red = 89;
            int green = 48;
            int blue = 77;

            Cv2.NamedWindow("Palette");
            Cv2.CreateTrackbar("Red", "Palette", ref red, 255);
            Cv2.CreateTrackbar("Green", "Palette", ref green, 255);
            Cv2.CreateTrackbar("Blue", "Palette", ref blue, 255);

            while (true)
            {
                int px_red = Cv2.GetTrackbarPos("Red", "Palette");
                int px_green = Cv2.GetTrackbarPos("Green", "Palette");
                int px_blue = Cv2.GetTrackbarPos("Blue", "Palette");
                Mat src = new Mat(new Size(1600, 800), MatType.CV_8UC3, new Scalar(px_red, px_green, px_blue));

                Cv2.ImShow("Palette", src);
                if (Cv2.WaitKey(33) == 'q') break;
            }

            Cv2.DestroyAllWindows();
        }
    }
}