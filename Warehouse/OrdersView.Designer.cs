namespace Warehouse
{
    partial class OrdersView
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
            this.ShipOrders = new System.Windows.Forms.Button();
            this.checkedListBox1 = new System.Windows.Forms.CheckedListBox();
            this.CheckOrders = new System.Windows.Forms.Button();
            this.statusBar1 = new System.Windows.Forms.StatusStrip();
            this.SuspendLayout();
            // 
            // ShipOrders
            // 
            this.ShipOrders.Location = new System.Drawing.Point(335, 393);
            this.ShipOrders.Name = "ShipOrders";
            this.ShipOrders.Size = new System.Drawing.Size(153, 23);
            this.ShipOrders.TabIndex = 1;
            this.ShipOrders.Text = "Ship Checked Orders";
            this.ShipOrders.UseVisualStyleBackColor = true;
            this.ShipOrders.Click += new System.EventHandler(this.button1_Click);
            // 
            // checkedListBox1
            // 
            this.checkedListBox1.FormattingEnabled = true;
            this.checkedListBox1.Location = new System.Drawing.Point(12, 12);
            this.checkedListBox1.Name = "checkedListBox1";
            this.checkedListBox1.Size = new System.Drawing.Size(642, 364);
            this.checkedListBox1.TabIndex = 2;
            // 
            // CheckOrders
            // 
            this.CheckOrders.Location = new System.Drawing.Point(503, 393);
            this.CheckOrders.Name = "CheckOrders";
            this.CheckOrders.Size = new System.Drawing.Size(151, 23);
            this.CheckOrders.TabIndex = 3;
            this.CheckOrders.Text = "Check for new Orders";
            this.CheckOrders.UseVisualStyleBackColor = true;
            this.CheckOrders.Click += new System.EventHandler(this.button2_Click);
            // 
            // statusBar1
            // 
            this.statusBar1.Location = new System.Drawing.Point(0, 422);
            this.statusBar1.Name = "statusBar1";
            this.statusBar1.Size = new System.Drawing.Size(666, 22);
            this.statusBar1.TabIndex = 4;
            this.statusBar1.Text = "statusStrip1";
            // 
            // OrdersView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(666, 444);
            this.Controls.Add(this.statusBar1);
            this.Controls.Add(this.CheckOrders);
            this.Controls.Add(this.checkedListBox1);
            this.Controls.Add(this.ShipOrders);
            this.Name = "OrdersView";
            this.Text = "Orders";
            this.Load += new System.EventHandler(this.OrdersView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button ShipOrders;
        private System.Windows.Forms.CheckedListBox checkedListBox1;
        private System.Windows.Forms.Button CheckOrders;
        private System.Windows.Forms.StatusStrip statusBar1;
    }
}