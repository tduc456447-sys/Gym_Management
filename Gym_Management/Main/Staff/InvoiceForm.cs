using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gym_Management.Main.Staff
{
    public partial class InvoiceForm : Form
    {
        public InvoiceForm()
        {
            InitializeComponent();
            this.BackColor = Color.White;
            Label lbl = new Label();
            lbl.Text = "Hóa đơn";
            lbl.Font = new Font("Segoe UI", 16, FontStyle.Bold);
            lbl.AutoSize = true;
            lbl.Location = new Point(30, 30);
            this.Controls.Add(lbl);
        }
    }
}
