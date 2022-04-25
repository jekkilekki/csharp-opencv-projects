using System;
using OpenCvSharp;

namespace Project
{
    class Program2
    {
        static int r = 130;
        static int g = 102;
        static int b = 47;

        static void Main(string[] args)
        {
            Mat src = new Mat(new Size(500, 500), MatType.CV_8UC3);
            TrackbarCallbackNative trackbarCBr = new TrackbarCallbackNative(EventR);
            TrackbarCallbackNative trackbarCBg = new TrackbarCallbackNative(EventG);
            TrackbarCallbackNative trackbarCBb = new TrackbarCallbackNative(EventB);

            Cv2.NamedWindow("Palette");
            Cv2.CreateTrackbar("Red", "Palette", ref r, 255, trackbarCBr, src.CvPtr);
            Cv2.CreateTrackbar("Green", "Palette", ref g, 255, trackbarCBg, src.CvPtr);
            Cv2.CreateTrackbar("Blue", "Palette", ref b, 255, trackbarCBb, src.CvPtr);

            Cv2.WaitKey();
            Cv2.DestroyAllWindows();
        }

        private static void EventR(int pos, IntPtr userdata)
        {
            Mat color = new Mat(userdata);
            r = pos;
            color.SetTo(new Scalar(b, g, r));
            Cv2.ImShow("Palette", color);
        }

        private static void EventG(int pos, IntPtr userdata)
        {
            Mat color = new Mat(userdata);
            g = pos;
            color.SetTo(new Scalar(b, g, r));
            Cv2.ImShow("Palette", color);
        }

        private static void EventB(int pos, IntPtr userdata)
        {
            Mat color = new Mat(userdata);
            b = pos;
            color.SetTo(new Scalar(b, g, r));
            Cv2.ImShow("Palette", color);
        }
    }
}