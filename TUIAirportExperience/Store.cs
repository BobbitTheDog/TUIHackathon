using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB;
using MongoDB.Bson;
using MongoDB.Driver;

namespace TUIAirportExperience
{
    public partial class Store : Form
    {
        MongoManager db;
        string custID;

        public Store(MongoManager db, string custID)
        {
            InitializeComponent();
            this.db = db;
            this.custID = custID;

            loadStore();
        }

        private void loadStore()
        {
            List<BsonDocument> collection = db.getItems();

            foreach (BsonDocument doc in collection)
            {
                RowStyle copy = tblStore.RowStyles[0];
                tblStore.RowCount++;
                tblStore.RowStyles.Add(new RowStyle(copy.SizeType));
                
                //create objects to add
                string id = doc.GetValue("_id").AsString;
                PictureBox pic = new PictureBox();
                pic.Width = pic.Height = 150;
                pic.SizeMode = PictureBoxSizeMode.StretchImage;
                pic.Anchor = AnchorStyles.Top;
                pic.Image = (Image)Properties.Resources.ResourceManager.GetObject(id);
                //TODO: maybe need to set size and stretch, etc?

                string name = doc.GetValue("name").AsString;
                Label lblName = new Label();
                lblName.Text = name;
                lblName.Anchor = AnchorStyles.Bottom;

                FlowLayoutPanel pnlNamePicture = new FlowLayoutPanel();
                pnlNamePicture.FlowDirection = FlowDirection.TopDown;
                pnlNamePicture.Padding = new Padding(5);
                pnlNamePicture.AutoSize = true;
                pnlNamePicture.Dock = DockStyle.Fill;

                pnlNamePicture.Controls.Add(pic);
                pnlNamePicture.Controls.Add(lblName);

                string description = doc.GetValue("description").AsString;
                Label lblDesc = new Label();
                lblDesc.Dock = DockStyle.Fill;
                lblDesc.Text = description;

                string price = "£" + doc.GetValue("price").AsDouble.ToString();
                Label lblPrice = new Label();
                lblPrice.Name = "lblPrice";
                lblPrice.Text = price;

                NumericUpDown setQuantity = new NumericUpDown();
                setQuantity.Tag = id;
                setQuantity.Maximum = 10;
                setQuantity.Width = 40;
                setQuantity.TextAlign = HorizontalAlignment.Center;

                tblStore.Controls.Add(pnlNamePicture, 0, tblStore.RowCount - 1);
                tblStore.Controls.Add(lblDesc, 1, tblStore.RowCount - 1);
                tblStore.Controls.Add(lblPrice, 2, tblStore.RowCount - 1);
                tblStore.Controls.Add(setQuantity, 3, tblStore.RowCount - 1);
            }
        }

        private void tblStore_SizeChanged(object sender, EventArgs e)
        {
            btnCheckout.Location = new Point(btnCheckout.Location.X, tblStore.Location.Y + tblStore.Height + 5);
        }

        private void btnCheckout_Click(object sender, EventArgs e)
        {
            Dictionary<string, int> order = new Dictionary<string, int>();

            for (int i = 1; i < tblStore.RowCount; i++)
            {
                NumericUpDown spinner = (NumericUpDown)tblStore.GetControlFromPosition(tblStore.ColumnCount - 1, i);
                int quantity = (int)spinner.Value;
                if (quantity > 0)
                {
                    string id = (string)spinner.Tag;
                    Double price = Double.Parse(tblStore.GetControlFromPosition(2, i).Text.Substring(1));
                    order.Add(id, quantity);
                }
            }

            if (order.Count > 0) {
                Checkout checkout = new Checkout(db, custID, order);
                checkout.Location = this.Location;
                checkout.StartPosition = FormStartPosition.Manual;
                checkout.FormClosing += delegate { this.Show(); this.Close(); };
                checkout.Show();
                this.Hide();
            }
        }
    }
}
