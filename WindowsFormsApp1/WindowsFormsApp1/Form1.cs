using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    // A struct to handle the Groundtruth data
    public struct GT
    {
        int x_start;
        int y_start;
        int x_end;
        int y_end;
        int id;
        public void SetVars(int xs, int ys, int xe, int ye, int idk)
        {
            x_start = xs;
            y_start = ys;
            x_end = xe;
            y_end = ye;
            id = idk;
        }
        public int GetVars()
        {
            return x_start;
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
                        Bitmap bm = new Bitmap(pB1.Image);
                        Color pc = new Color();
                        pc = Color.FromArgb(255, 255, 0, 0);

                        bm.SetPixel(3, 3,pc);
                        pB1.Image = bm;
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

        private void clearButton_Click(object sender, EventArgs e)
        {
            pB1.Image = null;
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
                for( int i = 0;i <numPics;i++)
                {
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
            //Finden der Datei
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Textdateien (*.txt)|*.txt";

            if (ofd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string line = null;
                int counterP = 0;
                try
                {
                    System.IO.StreamReader file = new System.IO.StreamReader(@ofd.FileName);
                    while ((line = file.ReadLine()) != null)
                    {
                        string[] args = line.Split(';');
                        if (args[0] != "img")
                        {
                            while (args[0] != pictureData[counterP].picName && counterP < pictureData.Length)
                            {
                                counterP++;
                            }
                            if (args[0] == pictureData[counterP].picName && counterP < pictureData.Length)
                            {
                                //Keine GT bereits vorhanden
                                if (pictureData[counterP].Gtdaten == null || pictureData[counterP].Gtdaten[0].GetVars()==0)
                                {
                                    pictureData[counterP].Gtdaten = new GT[1];
                                    pictureData[counterP].Gtdaten[0].SetVars(Convert.ToInt32(args[1]), Convert.ToInt32(args[2]), Convert.ToInt32(args[3]), Convert.ToInt32(args[4]), Convert.ToInt32(args[5]));
                                }
                                else// GT vorhanden, also kopieren
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
    }
}
