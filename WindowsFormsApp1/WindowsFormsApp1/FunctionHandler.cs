using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using Emgu;
using Emgu.CV;
using Emgu.Util;
using Emgu.CV.Structure;

namespace CustomPictureFunctions
{

    public class FunctionHandler
    {
        public Bitmap MainHandler(Image<Bgr, Byte> input, int showStep)
        {
            Bitmap result = input.ToBitmap();

            //TODO Cut out the Motor

            //Create HSV Image
            Image<Hsv, Byte> Im_Hsv = input.Convert<Hsv, byte>();

            //Histogrammlinearisierung der Satuierung
            Image<Gray, Byte> Linchan = Im_Hsv[1];
            Linchan._EqualizeHist();
            Im_Hsv[1] = Linchan;
            Linchan.Dispose();
            if (showStep==0) result = Im_Hsv.ToBitmap();

            //Define Color Masks
            Image<Gray, byte> redcut;
            Image<Gray, byte> bluecut;
            Image<Gray, byte> yellcut;
            //Create Red mask
            Hsv redu = new Hsv(0, 220, 0); Hsv redo = new Hsv(10, 255, 255);
            Image<Gray,byte> undercut = Im_Hsv.InRange(redu, redo);
            redu = new Hsv(160, 220, 0); redo = new Hsv(179, 255, 255);
            Image<Gray, byte> uppercut = Im_Hsv.InRange(redu, redo);
            redcut = undercut.Add(uppercut);
            undercut.Dispose();uppercut.Dispose();
            //Create Blue Mask
            redu = new Hsv(110, 220, 0); redo = new Hsv(130, 255, 255);
            bluecut = Im_Hsv.InRange(redu, redo);
            //Create Yellow Mask
            redu = new Hsv(25, 130, 0); redo = new Hsv(35, 255, 255);
            yellcut = Im_Hsv.InRange(redu, redo);

            //Median on Masks -not necessary
            Image<Gray, Byte> totalcutMed= redcut.SmoothMedian(3);
            totalcutMed = totalcutMed.Add(yellcut.SmoothMedian(3)).Add(bluecut.SmoothMedian(3));

            //Edge Detection - Sobel
            Image<Gray, Single> IM_Edge = Im_Hsv.Convert<Gray, Single>();
            IM_Edge = IM_Edge.Sobel(1, 0, 3);


            switch (showStep)
            {
                case 1: result = redcut.ToBitmap(); break;
                case 2: result = yellcut.ToBitmap(); break;
                case 3: result = bluecut.ToBitmap(); break;
                case 4: result = redcut.Add(yellcut).Add(bluecut).ToBitmap(); break;
                case 5: result = totalcutMed.ToBitmap();break;
                case 6: result = IM_Edge.ToBitmap();break;
               
                default: result = Im_Hsv.ToBitmap(); break;
            }

            return result;
        }

        public double GetHue(Image<Bgr,Byte> input, int x, int y)
        {
            Image<Hsv, Byte> Hsv_Im = input.Convert<Hsv, Byte>();
            return Hsv_Im[x, y].Hue;
        }

    }
}
