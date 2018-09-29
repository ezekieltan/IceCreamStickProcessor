using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ServiceModel;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using Emgu.Util;
using System.Threading;


namespace IceCreamStickProcessor
{
    public partial class Form1 : Form
    {
        //CAPTURE VARIABLES
        private VideoCapture _capture = null;
        private Mat _frame;
         
        //COLOUR GRAPH LABELS
        Label[] colourGraphLabels = new Label[8] { new Label(), new Label(), new Label(), new Label(), new Label(), new Label(), new Label(), new Label() };

        //PROCESSING VARIABLES
        int maxValue = 255;
        int blackThreshold = 5;
        Mat grayscaleFrame, thresholdFrame, erodeDilateFrame;
        Bitmap colourBitmap, thresholdBitmap;
        int[] colourArray;
        int totalStickPixels;
        Color displayPixel;
        Bitmap colourGraphBitmap, grayscaleBitmap;
        Graphics colourGraphics;
        int graphWidth;
        Rectangle bounds;
        Mat throwAway;
        Mat red, orange, green, blue, purple, yellow, white, black;

        //FINAL VARIABLES
        int numberOfObjects;
        int[] stickTotalArray;
        int[] stickColourArray;
        double spotPercentage;
        int dominantColour;
        double lengthPixel;
        double lengthCM;
        double correctWrongRatio;
        MCvScalar averageBrightness;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized; //MAXIMIZE BY DEFAULT
            
            try
            {
                _capture = new VideoCapture();
                _capture.ImageGrabbed += ProcessFrame; 
            }
            catch (NullReferenceException excpt)
            {
                MessageBox.Show(excpt.Message);
            }

            _frame = new Mat();
            _capture.Start(); //START CAPTURE

            //TURN OFF DEBUG MODE
            debugCheckBox.Checked = true;
            debugCheckBox.Checked = false;


            //INITIALIZE COLOUR GRAPH LABELS
            for (int i = 0; i < colourGraphLabels.Length; i++)
            {
                colourGraphLabels[i] = new Label();
                colourGraphLabels[i].Text = colourString(i);
                colourGraphLabels[i].Font = new Font(new FontFamily("Arial"), 16, FontStyle.Regular, GraphicsUnit.Pixel);
                colourGraphLabels[i].ForeColor = colourRGBreturn(7);
                colourGraphLabels[i].Size = new Size(60, colourPictureBox.Height / colourGraphLabels.Length);
                colourGraphLabels[i].Location = new System.Drawing.Point(20, colourPictureBox.Location.Y + i * colourPictureBox.Height / colourGraphLabels.Length);

                this.Controls.Add(colourGraphLabels[i]);
                colourGraphLabels[i].BringToFront();
                colourGraphLabels[i].Visible = false;
            }

            //INITIALIZE COLOUR GRAPH WIDTH
            colourArray = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            graphWidth = colourPictureBox.Height / colourArray.Length;
        }
         

        private void ProcessFrame(object sender, EventArgs arg)
        {
            //RESET COLOUR ARRAY AND COLOUR GRAPH   
            colourArray = new int[8] { 0, 0, 0, 0, 0, 0, 0, 0 };
            colourGraphBitmap = new Bitmap(colourPictureBox.Width, colourPictureBox.Height);
            colourGraphics = Graphics.FromImage(colourGraphBitmap);
            

            if (_capture != null && _capture.Ptr != IntPtr.Zero)
            {
                //CAPTURE NEW FRAME
                _capture.Retrieve(_frame, 0);

                //EROSION AND DILATION
                Mat element = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new System.Drawing.Size(3, 3), new System.Drawing.Point(-1, -1));
                erodeDilateFrame = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, 3);
                CvInvoke.Erode(_frame, erodeDilateFrame, element, new System.Drawing.Point(-1, -1), 5, BorderType.Default, new MCvScalar(1.0));
                CvInvoke.Dilate(erodeDilateFrame, erodeDilateFrame, element, new System.Drawing.Point(-1, -1), 5, BorderType.Default, new MCvScalar(1.0));

                //GRAYSCALE AND THRESHOLD
                grayscaleFrame = new Mat(_frame.Rows, _frame.Cols, DepthType.Cv8U, 1);
                thresholdFrame = new Mat(grayscaleFrame.Rows, grayscaleFrame.Cols, grayscaleFrame.Depth, grayscaleFrame.NumberOfChannels); 
                CvInvoke.CvtColor(erodeDilateFrame, grayscaleFrame, ColorConversion.Bgr2Gray);
                CvInvoke.Threshold(grayscaleFrame, thresholdFrame, blackThreshold, maxValue, ThresholdType.Binary);
                grayscaleBitmap = grayscaleFrame.Bitmap; 
                colourBitmap = erodeDilateFrame.Bitmap;
                thresholdBitmap = thresholdFrame.Bitmap;

                //BOUNDING RECTANGLE
                bounds = CvInvoke.BoundingRectangle(thresholdFrame);

                //COLOUR DETECTION
                red = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(17, 17, 150)), new ScalarArray(new MCvScalar(60, 80, 255)), red);
                colourArray[0] = CvInvoke.CountNonZero(red);

                orange = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(5, 80, 180)), new ScalarArray(new MCvScalar(50, 205, 255)), orange);
                colourArray[1] = CvInvoke.CountNonZero(orange);

                green = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(15, 55, 30)), new ScalarArray(new MCvScalar(65, 185, 90)), green);
                colourArray[2] = CvInvoke.CountNonZero(green);

                blue = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(35, 5, 0)), new ScalarArray(new MCvScalar(145, 108, 5)), blue);
                colourArray[3] = CvInvoke.CountNonZero(blue);

                purple = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(15, 10, 5)), new ScalarArray(new MCvScalar(80, 65, 90)), purple);
                colourArray[4] = CvInvoke.CountNonZero(purple);
                
                yellow = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(5, 160, 180)), new ScalarArray(new MCvScalar(75, 255, 255)), yellow);
                colourArray[5] = CvInvoke.CountNonZero(yellow);

                white = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(230, 230, 230)), new ScalarArray(new MCvScalar(255, 255, 255)), white);
                colourArray[6] = CvInvoke.CountNonZero(white);

                black = new Mat(_frame.Rows, _frame.Cols, _frame.Depth, _frame.NumberOfChannels);
                CvInvoke.InRange(_frame, new ScalarArray(new MCvScalar(0, 0, 0)), new ScalarArray(new MCvScalar(blackThreshold, blackThreshold, blackThreshold)), black);
                colourArray[7] = CvInvoke.CountNonZero(black);

                //NUMBER OF OBJECTS
                throwAway = new Mat(grayscaleFrame.Rows, grayscaleFrame.Cols, grayscaleFrame.Depth, grayscaleFrame.NumberOfChannels);
                numberOfObjects = CvInvoke.ConnectedComponents(thresholdFrame, throwAway, LineType.EightConnected, DepthType.Cv16U);

                //COLOUR ANALYSIS
                stickTotalArray = new int[7] { colourArray[0], colourArray[1], colourArray[2], colourArray[3], colourArray[4], colourArray[5], colourArray[6] }; 
                stickColourArray = new int[6] { colourArray[0], colourArray[1], colourArray[2], colourArray[3], colourArray[4], colourArray[5] };
                spotPercentage = 1.0 * colourArray[6] / stickTotalArray.Sum();
                dominantColour = Array.IndexOf(stickColourArray, stickColourArray.Max());
                
                //LENGTH MEASUREMENT
                lengthPixel = Math.Sqrt(bounds.Width * bounds.Width + bounds.Height * bounds.Height);
                lengthCM = lengthPixel * 11.5 / 615;

                //RATIO MEASUREMENT
                totalStickPixels = _frame.Width * _frame.Height - colourArray[7];
                correctWrongRatio = totalStickPixels / lengthPixel;

                //OBJECT CLASSIFICATION
                if (lengthPixel < 100) // NO OBJECT, OR OBJECT TOO SMALL
                {
                    colourLabel.Text = "Stick not present";
                    colourLabel.ForeColor = colourRGBreturn(7);
                    spotLabel.Text = "";
                    lengthLabel.Text = "";
                    goodLabel.Text = "";
                }
                else if (lengthPixel > 100 && lengthPixel < 700 && correctWrongRatio > 45 && correctWrongRatio < 75 && numberOfObjects == 2) //OBJECT IS A STICK
                {
                    if (spotPercentage < 0.001 && dominantColour == 2 && lengthPixel > 590) //CORRECT STICK
                    {
                        goodLabel.Text = "OK";
                        goodLabel.ForeColor = colourRGBreturn(2);
                        spotLabel.Text = "Spots present: No";
                        spotLabel.ForeColor = colourRGBreturn(7);
                    }
                    else //NOT CORRECT STICK
                    {
                        goodLabel.Text = "NG";
                        goodLabel.ForeColor = colourRGBreturn(0);
                         
                        if (spotPercentage > 0.001) //CHECK FOR SPOTS
                        {
                            spotLabel.Text = "Spots present: Yes";
                            spotLabel.ForeColor = colourRGBreturn(0);
                        }
                        else
                        {
                            spotLabel.Text = "Spots present: No";
                            spotLabel.ForeColor = colourRGBreturn(7);
                        } 
                    }
                    lengthLabel.Text = "Length: " + Convert.ToString(Math.Round(lengthPixel, 2)) + " Pixels, " + Convert.ToString(Math.Round(lengthCM, 2)) + " CM";
                    if (lengthPixel > 590) //CHECK LENGTH (BROKEN OR NOT)
                    {
                        lengthLabel.Text = lengthLabel.Text + " (OK)";
                        lengthLabel.ForeColor = colourRGBreturn(7); 
                    }
                    else
                    {
                        lengthLabel.Text = lengthLabel.Text + " (Broken)";
                        lengthLabel.ForeColor = colourRGBreturn(0);
                    }
                    //DISPLAY COLOUR
                    colourLabel.Text = "Colour: " + colourString(dominantColour);
                    colourLabel.ForeColor = colourRGBreturn(dominantColour);
                    
                    //DISPLAY BOUNDING RECTANGLE
                    CvInvoke.Rectangle(_frame, bounds, colourMCVreturn(dominantColour), 10);
                }
                else //OBJECT TOO BIG TO BE A STICK, OR OTHER OBJECTS PRESENT
                {
                    colourLabel.Text = "Other sticks/objects present";
                    colourLabel.ForeColor = colourRGBreturn(7);
                    spotLabel.Text = "";
                    lengthLabel.Text = "";
                    goodLabel.Text = "";
                }

                if (debugCheckBox.Checked) //DEBUG MODE PRINTOUT
                {
                    //EYEDROPPER
                    displayPixel = colourBitmap.GetPixel(_frame.Width * xTrackBar.Value / xTrackBar.Maximum, _frame.Height * yTrackBar.Value / yTrackBar.Maximum);
                    CvInvoke.Circle(_frame, new Point(_frame.Width * xTrackBar.Value / xTrackBar.Maximum, _frame.Height * yTrackBar.Value / yTrackBar.Maximum), 5, new MCvScalar(255, 255, 255), 5);
                    CvInvoke.Circle(_frame, new Point(_frame.Width * xTrackBar.Value / xTrackBar.Maximum, _frame.Height * yTrackBar.Value / yTrackBar.Maximum), 10, new MCvScalar(0, 0, 0), 5);
                    debugRGBLabel.Text = Convert.ToString("Eyedropper: R:" + displayPixel.R + " G:" + displayPixel.G + " B:" + displayPixel.B);

                    //ESSENTIAL READOUTS (NUMBER OF PIXELS OF COLOUR, SPOT PERCENTAGE, AVERAGE RGB, AVERAGE BRIGHTNESS)
                    colourValuesLabel.Text = "R:" + Convert.ToString(colourArray[0]) + " O:" + Convert.ToString(colourArray[1]) +
                        " G:" + Convert.ToString(colourArray[2]) + " B:" + Convert.ToString(colourArray[3]) +
                        " P:" + Convert.ToString(colourArray[4]) + "\n" + "Y" + Convert.ToString(colourArray[5]) +
                        " W:" + Convert.ToString(colourArray[6]) + " D:" + Convert.ToString(colourArray[7]) +
                        " S:" + Convert.ToString(totalStickPixels) + "\n" + "Ratio: " + Convert.ToString(Math.Round(correctWrongRatio, 4)) +
                        " Objects: " + Convert.ToString(numberOfObjects);
                    spotPercentageLabel.Text = "Spot percentage: " + Convert.ToString(Math.Round(spotPercentage * 100, 5)) + "%";
                    averageBrightness = CvInvoke.Mean(_frame);
                    averageBrightnessLabel.Text = "Average: R:" + Convert.ToString(Math.Round(averageBrightness.V2, 4))
                        + " G:" + Convert.ToString(Math.Round(averageBrightness.V1, 4))
                        + " B:" + Convert.ToString(Math.Round(averageBrightness.V0, 4))
                        + " \nOverall Average: " + Convert.ToString(Math.Round((averageBrightness.V0 + averageBrightness.V1 + averageBrightness.V2) / 3, 4));

                    //COLOUR DISTRIBUTION GRAPH
                    for (int i = 0; i < colourArray.Length; i++)
                    {
                        colourGraphics.DrawLine(new Pen(colourRGBreturn(i), graphWidth), new Point(0, i * graphWidth + graphWidth / 2), new Point(Convert.ToInt32((colourArray[i] * 1.0 / (_frame.Width * _frame.Height)) * colourPictureBox.Width), i * graphWidth + graphWidth / 2));
                    }
                    colourGraphics.DrawLine(new Pen(colourRGBreturn(7), 1), new Point(Convert.ToInt32((_frame.Width * _frame.Height - 36000.0) * colourPictureBox.Width / (_frame.Width * _frame.Height)), 0), new Point(Convert.ToInt32((_frame.Width * _frame.Height - 36000.0) * colourPictureBox.Width / (_frame.Width * _frame.Height)), colourPictureBox.Height));
                    colourGraphics.DrawLine(new Pen(colourRGBreturn(7), 1), new Point(colourPictureBox.Width - 1, 0), new Point(colourPictureBox.Width - 1, colourPictureBox.Height));
                    colourGraphics.DrawLine(new Pen(colourRGBreturn(7), 1), new Point(0, 0), new Point(0, colourPictureBox.Height));
                    colourPictureBox.Image = colourGraphBitmap;
                    
                    //ERODE/DILATE AND THRESHOLD FRAME
                    CvInvoke.Resize(thresholdFrame, thresholdFrame, new Size(0, 0), 1.0 * blackWhiteImageBox.Width / _frame.Width, 1.0 * blackWhiteImageBox.Height / _frame.Height);
                    blackWhiteImageBox.Image = thresholdFrame;
                    CvInvoke.Resize(erodeDilateFrame, erodeDilateFrame, new Size(0, 0), 1.0 * processedImageBox.Width / _frame.Width, 1.0 * processedImageBox.Height / _frame.Height);
                    processedImageBox.Image = erodeDilateFrame;
                } 
                captureImageBox.Image = _frame; 
            }
            Thread.Sleep(10); //TO PREVENT STUTTERING
        }
        private void captureButton_Click(object sender, EventArgs e)
        { 
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void snapButton_Click(object sender, EventArgs e)
        {
            CvInvoke.Imwrite(fileNameBox.Text, _frame);
        }

        private void grayscaleImageBox_Click(object sender, EventArgs e)
        {

        }
        public string colourString(int i)
        {
            switch (i)
            {
                case 0: return "Red";
                case 1: return "Orange";
                case 2: return "Green";
                case 3: return "Blue";
                case 4: return "Purple";
                case 5: return "Yellow";
                case 6: return "White";
                case 7: return "Black";
                default: return "";
            }
        }
        public MCvScalar colourMCVreturn(int i)
        {
            switch (i)
            {
                case 0: return new MCvScalar(0, 0, 255);
                case 1: return new MCvScalar(0, 128, 255);
                case 2: return new MCvScalar(0, 255, 0);
                case 3: return new MCvScalar(255, 0, 0);
                case 4: return new MCvScalar(255, 0, 255);
                case 5: return new MCvScalar(0, 255, 255);
                case 6: return new MCvScalar(255, 255, 255);
                case 7: return new MCvScalar(0, 0, 0);
                default: return new MCvScalar(255, 255, 255);
            }

        }

        private void erodeDilateSnapButton_Click(object sender, EventArgs e)
        {
            CvInvoke.Imwrite(fileNameBox.Text, erodeDilateFrame);
        }

        private void bwThresholdSnapButton_Click(object sender, EventArgs e)
        {
            CvInvoke.Imwrite(fileNameBox.Text, thresholdFrame);
        }

        public Color colourRGBreturn(int i)
        {
            switch (i)
            {
                case 0: return Color.FromArgb(255, 0, 0);
                case 1: return Color.FromArgb(255, 128, 0);
                case 2: return Color.FromArgb(0, 255, 0);
                case 3: return Color.FromArgb(0, 0, 255);
                case 4: return Color.FromArgb(255, 0, 255);
                case 5: return Color.FromArgb(255, 255, 0);
                case 6: return Color.FromArgb(255, 255, 255);
                case 7: return Color.FromArgb(0, 0, 0);
                default: return Color.FromArgb(255, 255, 255);
            }
        }


        private void debugCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (debugCheckBox.Checked)
            {
                xTrackBar.Visible = true;
                yTrackBar.Visible = true;
                fileNameBox.Visible = true;
                snapButton.Visible = true;
                debugRGBLabel.Visible = true;
                colourValuesLabel.Visible = true;
                spotPercentageLabel.Visible = true;
                averageBrightnessLabel.Visible = true;
                for (int i = 0; i < colourGraphLabels.Length; i++)
                {
                    colourGraphLabels[i].Visible = true;
                }
                blackWhiteImageBox.Visible = true;
                processedImageBox.Visible = true;
                colourPictureBox.Visible = true;
                colourDistributionLabel.Visible = true;
                erosionDilationLabel.Visible = true;
                blackWhiteLabel.Visible = true;
                erodeDilateSnapButton.Visible = true;
                bwThresholdSnapButton.Visible = true;

            }
            else
            {
                xTrackBar.Visible = false;
                yTrackBar.Visible = false;
                fileNameBox.Visible = false;
                snapButton.Visible = false;
                debugRGBLabel.Visible = false;
                colourValuesLabel.Visible = false;
                spotPercentageLabel.Visible = false;
                averageBrightnessLabel.Visible = false;
                for (int i = 0; i < colourGraphLabels.Length; i++)
                {
                    colourGraphLabels[i].Visible = false;
                }
                blackWhiteImageBox.Visible = false;
                processedImageBox.Visible = false;
                colourPictureBox.Visible = false;
                colourDistributionLabel.Visible = false;
                erosionDilationLabel.Visible = false;
                blackWhiteLabel.Visible = false;
                erodeDilateSnapButton.Visible = false;
                bwThresholdSnapButton.Visible = false;

            }
        }

        private void callibrateButton_Click(object sender, EventArgs e)
        {

        }

        private void processedImageBox_Click(object sender, EventArgs e)
        {

        }

        private void colourPictureBox_Click(object sender, EventArgs e)
        {

        }
    }
}