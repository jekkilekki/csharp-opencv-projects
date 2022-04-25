using System;
using OpenCvSharp;

namespace Project
{
    class Program3
    {
        static void Main(string[] args)
        {
            Mat src0 = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/injongs0.jpg");
            Mat src1 = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/injongs1.jpg");
            Mat src2 = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/injongs2.jpg");
            Mat src3 = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/injongs3.jpg");
            Mat src4 = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/injongs4.jpg");
            Mat src5 = Cv2.ImRead("C:/Users/ADMIN/Desktop/Dev/Hanbat/c#/중간고사/중간고사문제및이미지들/injongs5.jpg");

            FindSkin(src0);

            Cv2.WaitKey(0);
            Cv2.DestroyAllWindows();
        }

        private static void FindSkin(Mat src)
        {
            Mat hsv = new Mat(src.Size(), MatType.CV_8UC3);
            Mat lower_skin = new Mat(hsv.Size(), MatType.CV_8UC3);
            Mat upper_skin = new Mat(hsv.Size(), MatType.CV_8UC3);
            Mat added_skin = new Mat(src.Size(), MatType.CV_8UC3);
            Mat dst = new Mat(src.Size(), MatType.CV_8UC3);

            Cv2.CvtColor(src, hsv, ColorConversionCodes.BGR2HSV);

            // Hue range reference: https://stackoverflow.com/a/69462437
            Cv2.InRange(hsv, new Scalar(0, 30, 53), new Scalar(20, 180, 255), lower_skin);
            Cv2.InRange(hsv, new Scalar(172, 30, 53), new Scalar(180, 180, 210), upper_skin);
            Cv2.AddWeighted(lower_skin, 1.0, upper_skin, 1.0, 0.0, added_skin);

            Cv2.BitwiseAnd(hsv, hsv, dst, added_skin);
            Cv2.CvtColor(dst, dst, ColorConversionCodes.HSV2BGR);

            Cv2.ImShow("dst", dst);
        }
    }
}