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
    public partial class Admin : Form
    {
        MongoManager db;

        public Admin(MongoManager db)
        {
            InitializeComponent();

            this.db = db;

            loadOrderList();
        }

        private void loadOrderList()
        {
            List<BsonDocument> orders = db.GetOrderList();
            foreach (BsonDocument doc in orders)
            {
                comboBox1.Items.Add(doc.GetElement("_id").Value.AsString);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string orderID = ((ComboBox)sender).SelectedItem.ToString();

            BsonDocument customer = db.getOrderCustomer(orderID);
            BsonDocument order = db.getOrder(orderID);

            BsonArray items = order.GetElement("items").Value.AsBsonArray;

            foreach (BsonDocument item in items)
            {

            }

            RowStyle copy = tblAdmin.RowStyles[0];
            tblAdmin.RowCount++;
            tblAdmin.RowStyles.Add(new RowStyle(copy.SizeType));

            
        }
    }
}
