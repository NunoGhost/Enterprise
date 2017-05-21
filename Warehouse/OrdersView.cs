using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Messaging;

namespace Warehouse
{
    public partial class OrdersView : Form
    {
        private MessageQueue messageQueue1;

        public OrdersView()
        {
            InitializeComponent();
        }

        private void OrdersView_Load(object sender, EventArgs e)
        {
            try
            {
                messageQueue1.Path = ".\\private$\\testmsmq";
                System.Messaging.Message[] msqs = messageQueue1.GetAllMessages();
                foreach (System.Messaging.Message msq in msqs)
                {
                    msq.Formatter = new XmlMessageFormatter(new Type[] { typeof(System.String) });
                    this.checkedListBox1.Items.Add(msq.Body);
                }
                messageQueue1.Purge();
            }
            catch (MessageQueueException ex)
            {
                statusBar1.Text = "";
                statusBar1.Text = ex.Message;
            }
            catch (Exception ex1)
            {
                statusBar1.Text = "";
                statusBar1.Text = ex1.Message;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            messageQueue1.Path = ".\\private$\\testmsmq";
            System.Messaging.Message[] msqs = messageQueue1.GetAllMessages();
            foreach (System.Messaging.Message msq in msqs)
            {
                msq.Formatter = new XmlMessageFormatter(new Type[] { typeof(System.String) });
                this.checkedListBox1.Items.Add(msq.Body);
            }
            messageQueue1.Purge();
        }
    }
}
