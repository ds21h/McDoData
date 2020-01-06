using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace McDoData
{
    public partial class Form1 : Form
    {
        private NlData mNlData;

        public Form1()
        {
            InitializeComponent();
            mNlData = new NlData();
            mNlData.eReadComplete += hNlComplete;
        }

        private void BtnNL_Click(object sender, EventArgs e)
        {
            mNlData.xInit();
        }

        private void hNlComplete(Object pSender, EventArgs pArgs)
        {
            mNlData.xProcessData();
        }
    }
}
