using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;

namespace TUIAirportExperience
{
    public partial class Checkout : Form
    {
        MongoManager db;
        string custID;
        Dictionary<string, int> order;
        double total;

        public Checkout(MongoManager db, string custID, Dictionary<string,int> order)
        {
            InitializeComponent();
            this.db = db;
            this.order = order;
            this.total = 0d;
            this.custID = custID;

            loadOrder();
        }

        private void loadOrder()
        {
            List<BsonDocument> collection = db.getItems();

            Console.WriteLine("Order contains:");
            foreach (string id in order.Keys)
            {
                Console.WriteLine(id);
            }

            int numItems = 0;

            foreach (BsonDocument doc in collection)
            {
                string id = doc.GetValue("_id").AsString;

                Console.WriteLine("Checking if order contains" + id);
                if (order.Keys.Contains(id))
                {
                    Console.WriteLine("id found");
                    RowStyle copy = tblCheckout.RowStyles[0];
                    tblCheckout.RowCount++;
                    tblCheckout.RowStyles.Add(new RowStyle(copy.SizeType));

                    //create objects to add
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

                    double price = doc.GetValue("price").AsDouble;
                    Label lblPrice = new Label();
                    lblPrice.Name = "lblPrice";
                    lblPrice.Text = "£" + price.ToString();

                    Label lblQuantity = new Label();
                    int quantity = order[id];
                    lblQuantity.Text = quantity.ToString();

                    numItems += quantity;
                    total += price * quantity;

                    tblCheckout.Controls.Add(pnlNamePicture, 0, tblCheckout.RowCount - 1);
                    tblCheckout.Controls.Add(lblDesc, 1, tblCheckout.RowCount - 1);
                    tblCheckout.Controls.Add(lblPrice, 2, tblCheckout.RowCount - 1);
                    tblCheckout.Controls.Add(lblQuantity, 3, tblCheckout.RowCount - 1);

                    Invalidate();
                }
            }
            //insert final row, containing order summary

            Label lblItems = new Label();
            lblItems.Text = numItems.ToString() + " items.";

            Label lblTotal = new Label();
            lblTotal.Text = "£" + total.ToString();

            RowStyle style = tblCheckout.RowStyles[0];
            tblCheckout.RowCount++;
            tblCheckout.RowStyles.Add(new RowStyle(style.SizeType));

            tblCheckout.Controls.Add(lblItems, 0, tblCheckout.RowCount-1);
            tblCheckout.Controls.Add(lblTotal, 2, tblCheckout.RowCount-1);
            tblCheckout.SetColumnSpan(lblItems, 2);
            //tblCheckout.SetColumnSpan(lblTotal, 2);
        }

        private void tblCheckout_SizeChanged(object sender, EventArgs e)
        {
            btnPlaceOrder.Location = new Point(btnPlaceOrder.Location.X, tblCheckout.Location.Y + tblCheckout.Height + 5);
        }

        private void btnPlaceOrder_Click(object sender, EventArgs e)
        {
            try
            {
                db.placeOrder(custID, order, total);
                if (MessageBox.Show("Your order has been placed.\nPlease note, if you have purchased any alcohol, tobacco products, or similar, you will be required to show proof of age prior to delivery of goods.", "Order Placed", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    this.Close();
                }
            }
            catch (Exception exc)
            {

            }
        }
    }
}
