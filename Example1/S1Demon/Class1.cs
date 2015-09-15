using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Softone;

namespace S1Demon
{
    static public class Example : Object
    {
        static public XSupport XSupport;
        static public Timer myTimer;
        static public XTable myData;


        static void timer1_Tick(object sender, EventArgs e)
        {
            myTimer.Enabled = false;
            if (MessageBox.Show("Message form DLL. Press Cancel to Stop Timer", "SoftOne", MessageBoxButtons.OKCancel) == DialogResult.OK)
                myTimer.Enabled = true;
        }

        static public void Initialize()
        {
            myTimer = new Timer();
            myTimer.Interval = 8000;
            myTimer.Tick += timer1_Tick;
            myTimer.Enabled = true;
            myData = XSupport.GetSQLDataSet("Select code, Name from trdr where sodtype=13", null);
        }
    }



    public class S1Init : TXCode
    {
        public override void Initialize()
        {
            Example.XSupport = XSupport;
            Example.Initialize();
            MessageBox.Show("Start Demon!");
        }

    }
}










