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
        public Bitmap MainHandler(Image<Bgr, Byte> input)
        {
            Bitmap result = input.ToBitmap();

            //Cut out the Motor


            //Create HSV Image
            Image<Hsv,Byte > Im_Hsv = input.Convert<Hsv, byte>();

            //Create Red mask
            Hsv redu = new Hsv(0, 100, 100); Hsv redo = new Hsv(10, 255, 255);
            Image<Gray,byte> undercut = Im_Hsv.InRange(redu, redo);
            redu = new Hsv(160, 100, 100); redo = new Hsv(179, 255, 255);
            Image<Gray, byte> uppercut = Im_Hsv.InRange(redu, redo);

            Image<Gray, byte> redcut = undercut.Add(uppercut);
            result = redcut.ToBitmap();

            return result;
        }

    }
}
