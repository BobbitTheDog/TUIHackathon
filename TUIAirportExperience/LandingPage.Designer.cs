namespace TUIAirportExperience
{
    partial class LandingPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LandingPage));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblDetails = new System.Windows.Forms.Label();
            this.lblCustName = new System.Windows.Forms.Label();
            this.lblCorrect = new System.Windows.Forms.Label();
            this.btnYes = new System.Windows.Forms.Button();
            this.btnRetry = new System.Windows.Forms.Button();
            this.lblCustFlight = new System.Windows.Forms.Label();
            this.lblCustSeat = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(464, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(299, 73);
            this.label1.TabIndex = 0;
            this.label1.Text = "Welcome";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(228, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(765, 58);
            this.label2.TabIndex = 0;
            this.label2.Text = "To order items for your flight, please scan your ticket\'s QR code below!\r\nOr scan" +
    " a barcode to check if we have it in stock!";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(233, 135);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(640, 480);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblDetails
            // 
            this.lblDetails.AutoSize = true;
            this.lblDetails.BackColor = System.Drawing.Color.Transparent;
            this.lblDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDetails.ForeColor = System.Drawing.Color.White;
            this.lblDetails.Location = new System.Drawing.Point(953, 170);
            this.lblDetails.Name = "lblDetails";
            this.lblDetails.Size = new System.Drawing.Size(150, 29);
            this.lblDetails.TabIndex = 0;
            this.lblDetails.Text = "Your Details:";
            this.lblDetails.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblDetails.Visible = false;
            // 
            // lblCustName
            // 
            this.lblCustName.AutoSize = true;
            this.lblCustName.BackColor = System.Drawing.Color.Transparent;
            this.lblCustName.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustName.ForeColor = System.Drawing.Color.White;
            this.lblCustName.Location = new System.Drawing.Point(953, 212);
            this.lblCustName.Name = "lblCustName";
            this.lblCustName.Size = new System.Drawing.Size(61, 29);
            this.lblCustName.TabIndex = 0;
            this.lblCustName.Text = "Test";
            this.lblCustName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCustName.Visible = false;
            // 
            // lblCorrect
            // 
            this.lblCorrect.AutoSize = true;
            this.lblCorrect.BackColor = System.Drawing.Color.Transparent;
            this.lblCorrect.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCorrect.ForeColor = System.Drawing.Color.White;
            this.lblCorrect.Location = new System.Drawing.Point(953, 319);
            this.lblCorrect.Name = "lblCorrect";
            this.lblCorrect.Size = new System.Drawing.Size(166, 29);
            this.lblCorrect.TabIndex = 0;
            this.lblCorrect.Text = "Is this correct?";
            this.lblCorrect.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCorrect.Visible = false;
            // 
            // btnYes
            // 
            this.btnYes.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYes.Location = new System.Drawing.Point(958, 351);
            this.btnYes.Name = "btnYes";
            this.btnYes.Size = new System.Drawing.Size(150, 40);
            this.btnYes.TabIndex = 3;
            this.btnYes.Text = "Yes";
            this.btnYes.UseVisualStyleBackColor = true;
            this.btnYes.Visible = false;
            this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
            // 
            // btnRetry
            // 
            this.btnRetry.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRetry.Location = new System.Drawing.Point(958, 397);
            this.btnRetry.Name = "btnRetry";
            this.btnRetry.Size = new System.Drawing.Size(150, 40);
            this.btnRetry.TabIndex = 3;
            this.btnRetry.Text = "Retry";
            this.btnRetry.UseVisualStyleBackColor = true;
            this.btnRetry.Visible = false;
            this.btnRetry.Click += new System.EventHandler(this.btnRetry_Click);
            // 
            // lblCustFlight
            // 
            this.lblCustFlight.AutoSize = true;
            this.lblCustFlight.BackColor = System.Drawing.Color.Transparent;
            this.lblCustFlight.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustFlight.ForeColor = System.Drawing.Color.White;
            this.lblCustFlight.Location = new System.Drawing.Point(953, 241);
            this.lblCustFlight.Name = "lblCustFlight";
            this.lblCustFlight.Size = new System.Drawing.Size(61, 29);
            this.lblCustFlight.TabIndex = 0;
            this.lblCustFlight.Text = "Test";
            this.lblCustFlight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCustFlight.Visible = false;
            // 
            // lblCustSeat
            // 
            this.lblCustSeat.AutoSize = true;
            this.lblCustSeat.BackColor = System.Drawing.Color.Transparent;
            this.lblCustSeat.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCustSeat.ForeColor = System.Drawing.Color.White;
            this.lblCustSeat.Location = new System.Drawing.Point(953, 270);
            this.lblCustSeat.Name = "lblCustSeat";
            this.lblCustSeat.Size = new System.Drawing.Size(61, 29);
            this.lblCustSeat.TabIndex = 0;
            this.lblCustSeat.Text = "Test";
            this.lblCustSeat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCustSeat.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(233, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "Enter Admin";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LandingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TUIAirportExperience.Properties.Resources.Background_Smaller;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1272, 681);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnRetry);
            this.Controls.Add(this.btnYes);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblCustSeat);
            this.Controls.Add(this.lblCustFlight);
            this.Controls.Add(this.lblCustName);
            this.Controls.Add(this.lblCorrect);
            this.Controls.Add(this.lblDetails);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LandingPage";
            this.Text = "TUI Airport Experience";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblDetails;
        private System.Windows.Forms.Label lblCustName;
        private System.Windows.Forms.Label lblCorrect;
        private System.Windows.Forms.Button btnYes;
        private System.Windows.Forms.Button btnRetry;
        private System.Windows.Forms.Label lblCustFlight;
        private System.Windows.Forms.Label lblCustSeat;
        private System.Windows.Forms.Button button1;
    }
}

