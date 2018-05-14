using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomPictureFunctions; //Used to define Custome Functions
using Emgu.CV.Structure;
using Emgu.CV;

namespace WindowsFormsApp1
{
    // A struct to handle the Groundtruth data
    public struct GT
    {
        public int x_start;
        public int y_start;
        public int x_end;
        public int y_end;
        public int id;
        public void SetVars(int xs, int ys, int xe, int ye, int idk)
        {
            x_start = xs;
            y_start = ys;
            x_end = xe;
            y_end = ye;
            id = idk;
        }

    }
    //A struct to combine GT and the picture
    public struct picGT
    {
       public String picPfadName;
        public String picName;
       public GT[] Gtdaten;

        public picGT(string Name)
        {
            picName = "";
            picPfadName = "";
            Gtdaten = null;
        }
    }

    public partial class Form1 : Form
    {
        //Global Variables
        String[] FileNames = null;
        picGT[] pictureData = null;
        FunctionHandler PFH = new FunctionHandler();

        public Form1()
        {
            InitializeComponent();

        }

        private void showButton_Click(object sender, EventArgs e)
        {
            //Check if our Array was initialized
            if (FileNames != null)
            {
                int picNumSelected = Convert.ToInt32(PicNumberTaker.Value);
                if ( (FileNames.Length >= picNumSelected) && (FileNames[picNumSelected] != null))
                {
                    try
                    {
                        pB1.Load(pictureData[picNumSelected].picPfadName);

                    }
                    catch(Exception ex)
                    {
                        Console.WriteLine("Error: Couldn't read file!");
                    }
                    
                }
            }
            else
            {
                Console.WriteLine("Zuerst muss eine Anzahl von Bildern ausgewählt werden.");
            }
                       
        }




        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BChooseFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Bilder (*.bmp; *.jpg; *.png)|*.bmp;*.jpg;*.png";
            //Multiselect
            ofd.Multiselect = true;

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                int numPics = ofd.FileNames.Length;
                pictureData = new picGT[numPics];
                //Speichere alle Bilder als Referenzen in der globalen Variable ab
                for( int i = 0;i <numPics;i++)
                {
                    //Isoliere den Bildnamen
                    string[] parts = ofd.FileNames[i].Split('\\');
                    pictureData[i].picPfadName = ofd.FileNames[i];
                    pictureData[i].picName = parts[parts.Length - 1];
                }

                FileNames = ofd.FileNames;
                PicNumberTaker.Maximum = (ofd.FileNames.Length - 1);
            }
        }

        private void BGTeinlesen_Click(object sender, EventArgs e)
        {
            //Löschen eventueller GT Daten
            for(int i = 0; i < pictureData.Length;i++)
            {
                pictureData[i].Gtdaten = null;
            }

            //Finden der Datei
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textdateien (*.txt)|*.txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line = null;
                try
                {   
                    System.IO.StreamReader file = new System.IO.StreamReader(@ofd.FileName);
                    while ((line = file.ReadLine()) != null && line != "")
                    {
                        //Auftrennen in die Bestandteile Bildname;xs;xe;ys;ye;id
                        string[] args = line.Split(';');
                        if (args.Length == 6 && args[0] != "img") //Fehler abfangen;überspringen der ersten Zeile
                        {
                            //Berechnen der Position aus dem Namen der Datei
                            string[] splitter = args[0].Split('.');
                            int counterP = Convert.ToInt32(splitter[0]); 
                            //Falls Berechnung fehl schlägt suche linear nach dem index mit dem Dateinamen
                            if (counterP >= pictureData.Length || args[0] != pictureData[counterP].picName)
                            {
                                counterP = 0;
                                while (counterP < pictureData.Length && args[0] != pictureData[counterP].picName)
                                {
                                    counterP++;
                                }
                            }                      
                            //Überprüfung ob gültiger Index gefunden wurde oder ob einÜberlauf statt fand
                            if (counterP < pictureData.Length && args[0] == pictureData[counterP].picName)
                            {
                                //Keine GT bereits vorhanden -erstelle Array
                                if (pictureData[counterP].Gtdaten == null || pictureData[counterP].Gtdaten[0].x_start==0)
                                {
                                    pictureData[counterP].Gtdaten = new GT[1];
                                    pictureData[counterP].Gtdaten[0].SetVars(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToInt32(args[5]));
                                }
                                else// GT vorhanden, also kopieren und neues hinzufügen
                                {
                                    GT[] zwischen = pictureData[counterP].Gtdaten;
                                    pictureData[counterP].Gtdaten = new GT[zwischen.Length + 1];
                                    //kopieren
                                    int i;
                                    for (i = 0; i < zwischen.Length; i++)
                                    {
                                        pictureData[counterP].Gtdaten[i] = zwischen[i];
                                    }
                                    //Neues hinzufügen
                                    if (args.Length >= 6)
                                        pictureData[counterP].Gtdaten[i].SetVars(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToInt32(args[5]));
                                    else
                                        Console.WriteLine("Fehler im Lesen... Zu wenig Argumente");
                                }
                            }
                        }
                    }
                    file.Close();
                    file.Dispose();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Fehler:Lesen von GT");
                }
            }
          
        }

        private void BShowGT_Click(object sender, EventArgs e)
        {
            //Einlesen aktuelles Bild
            int index = Convert.ToInt32(PicNumberTaker.Value);
            pB1.Load(pictureData[index].picPfadName);
            LName.Text = pictureData[index].picName;
            if (pictureData[index].Gtdaten == null) return;
           
            //Bild als neues Bild mit Rechteck ausgeben
            pB1.Image = DrawRectangle(new Bitmap(pB1.Image), pictureData[index].Gtdaten, 3);
        }

        private Bitmap DrawRectangle(Bitmap pic,GT[] GTDaten ,int border)
        {
            Bitmap bm = pic;

            //Draw a rectangle
            //Iteriere GT Daten
            for (int i = 0; i < GTDaten.Length; i++)
            {
                int median = Convert.ToInt32(border / 2);
                for (int x = GTDaten[i].x_start; x <= GTDaten[i].x_end; x++)
                {
                    
                    //untere Kante
                    for(int b = GTDaten[i].y_end-median; b < GTDaten[i].y_end + median;b++)
                    {
                        bm.SetPixel(x, b, Color.Red);
                    }
                    //obere Kante
                    for (int b = GTDaten[i].y_start - median; b < GTDaten[i].y_start + median; b++)
                    {
                        bm.SetPixel(x, b, Color.Red);
                    }
                }
                for (int x = GTDaten[i].y_start; x <= GTDaten[i].y_end; x++)
                {
                    //untere Kante
                    for (int b = GTDaten[i].x_end - median; b < GTDaten[i].x_end + median; b++)
                    {
                        bm.SetPixel(b, x, Color.Red);
                    }
                    //obere Kante
                    for (int b = GTDaten[i].x_start - median; b < GTDaten[i].x_start + median; b++)
                    {
                        bm.SetPixel(b, x, Color.Red);
                    }
                }
        }

            return bm;
        }

        private void B_StartSearch_Click(object sender, EventArgs e)
        {
            //Einlesen aktuelles Bild
            int index = Convert.ToInt32(PicNumberTaker.Value);
            pB1.Load(pictureData[index].picPfadName);
            LName.Text = pictureData[index].picName;

            int step = Convert.ToInt32(StepperShowerTaker.Value);

            pB1.Image = PFH.MainHandler(new Image<Bgr,byte>(pictureData[index].picPfadName),step);
        }

        private void pB1_Click(object sender, EventArgs e)
        {
          /*  MouseEventArgs me = (MouseEventArgs)e;
            int x = me.X;
            int y = me.Y;
            LName.Text = PFH.GetHue(new Image<Bgr, Byte>(new Bitmap(pB1.Image)), x, y).ToString();
            Bitmap test = new Bitmap(pB1.Image);
            GT[] testi = new GT[1];
            GT testi1 = new GT();
            testi1.x_start = x - 2;testi1.x_end = x + 2;
            testi1.y_start = y - 2;testi1.y_end = y + 2;
            testi[0] = testi1;
            
            pB1.Image = DrawRectangle(test, testi, 5);*/
        }
    }
}
