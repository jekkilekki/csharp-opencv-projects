using System;
using OpenCvSharp;

namespace Project
{
    class Program4
    {
        static void Main(string[] args)
        {
            Mat salt = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/lena_salt.jpg");
            Mat pepper = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/lena_pepper.jpg");

            // RemoveSalt(salt);
            RemovePepper(pepper);
            
            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        private static void RemoveSalt(Mat src)
        {
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Cross, new Size(2, 2));

            Cv2.Erode(src, dst, kernel, new Point(-1, -1), 3, BorderTypes.Isolated, new Scalar(0));
            Cv2.ImShow("dst", dst);
        }

        private static void RemovePepper(Mat src)
        {
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);
            Mat kernel = Cv2.GetStructuringElement(MorphShapes.Cross, new Size(2, 2));

            Cv2.Dilate(src, dst, kernel, new Point(-1, -1), 3, BorderTypes.Isolated, new Scalar(0));
            Cv2.ImShow("dst", dst);
        }
    }
}