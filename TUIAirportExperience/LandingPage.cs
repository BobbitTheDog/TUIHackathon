using System;
using System.Drawing;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using ZXing;
using MongoDB.Bson;
using System.Threading.Tasks;

namespace TUIAirportExperience
{
    public partial class LandingPage : Form
    {
        FilterInfoCollection captureDevices;
        VideoCaptureDevice cam;
        Result res;
        Timer timer;
        BarcodeReader reader;
        MongoManager db;
        string custID;

        public LandingPage()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            captureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            cam = new VideoCaptureDevice(captureDevices[0].MonikerString);
            cam.NewFrame += Cam_NewFrame;
            cam.Start();

            reader = new BarcodeReader();
            timer = new Timer();
            timer.Interval = 1000;
            timer.Start();
            timer.Tick += timer_Tick;
            db = new MongoManager();
        }

        private void Cam_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            pictureBox1.Image = bitmap;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (pictureBox1.Image != null)
            {
                res = reader.Decode((Bitmap)pictureBox1.Image);
            }

            try
            {
                BarcodeFormat format = res.BarcodeFormat;
                Console.WriteLine("Barcode found?" + format.ToString());     

                if (format == BarcodeFormat.QR_CODE)
                {
                    string result = res.ToString().Trim();
                    Console.WriteLine("checking db for:" + result);

                    string[] customer = db.getCustomer(result);

                    timer.Stop();
                    cam.Stop();

                    if (customer != null)
                    {
                        custID = result;

                        lblDetails.Visible = true;

                        lblCustName.Text = customer[0];
                        lblCustName.Visible = true;

                        lblCustFlight.Text = "Flight: " + customer[1];
                        lblCustFlight.Visible = true;

                        lblCustSeat.Text = "Seat: " + customer[2];
                        lblCustSeat.Visible = true;

                        lblCorrect.Visible = true;

                        btnYes.Visible = true;
                        btnRetry.Visible = true;
                    }
                    else
                    {
                        lblCustName.Text = "Unable to find an entry\nfor that code.";
                        lblCustName.Visible = true;

                        btnRetry.Visible = true;
                    }
                }
                else {
                    string barcode = res.ToString().Trim();
                    Console.WriteLine("checking db for:" + barcode + ".");

                    BsonDocument item = db.getItemByBarcode(barcode);

                    timer.Stop();
                    cam.Stop();

                    if (item != null)
                    {
                        MessageBox.Show("We have this product in stock! Our price is £" + item.GetElement("price").Value.AsDouble.ToString(), "Item found", MessageBoxButtons.OK);
                    }
                    else
                    {
                        if (MessageBox.Show("Unfortunately, we don't have this item in stock, however, your interest in this item is noted, and perhaps we may have it in the future!", "Item not found", MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            db.logItemRequest(barcode);
                            timer.Start();
                            cam.Start();
                        }
                    }
                }
            }
            catch (Exception exc)
            {
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            Store storePage = new Store(db, custID);
            storePage.Location = this.Location;
            storePage.StartPosition = FormStartPosition.Manual;
            storePage.FormClosing += delegate { this.Show(); this.btnRetry.PerformClick(); };
            storePage.Show();
            cam.Stop();
            this.Hide();
        }

        private void btnRetry_Click(object sender, EventArgs e)
        {
            lblDetails.Visible = false;

            lblCustName.Text = "";
            lblCustName.Visible = false;

            lblCustFlight.Text = "";
            lblCustFlight.Visible = false;

            lblCustSeat.Text = "";
            lblCustSeat.Visible = false;

            lblCorrect.Visible = false;

            btnYes.Visible = false;
            btnRetry.Visible = false;

            timer.Start();
            cam.Start();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Admin adminForm = new Admin(db);
            adminForm.Location = this.Location;
            adminForm.StartPosition = FormStartPosition.Manual;
            adminForm.FormClosing += delegate { this.Show(); this.btnRetry.PerformClick(); };
            adminForm.Show();
            cam.Stop();
            this.Hide();
        }
    }
}
