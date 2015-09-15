using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Softone;
using System.Windows.Media;//

namespace NetExample2
{
    public class S1Init : TXCode
    {
        public override void Initialize()
        {
            MessageBox.Show("dotNET DLL Loaded OK!");
        }

    }

    [WorksOn("CUSTOMER/S")]
    public class SCustomer : TXCode
    {
        public override void Initialize()
        {
        }

        XTable t;
        public override void BeforePost()
        {
            t = XModule.GetTable("TRDR");
            MessageBox.Show((string)t[0, "CODE"]);
            base.BeforePost();
        }

        public override void AfterPost()
        {
            base.AfterPost();
        }

    }

    [WorksOn("CUSTOMER")]
    public class Customer : TXCode
    {
        XTable CustTable;

        private void NameChanged(object Sender, XEventArgs e)
        {
            MessageBox.Show(" Name Changed");
        }

        public override void Initialize()
        {

            CustTable = XModule.GetTable("TRDR");
            XModule.SetEvent("ON_TRDR_NAME", NameChanged);
            XModule.SetEvent("ON_TRDR_POST", NameChanged);


            string s;
            for (int i = 0; i < XModule.Params.Length; i++)
            {
                s = XModule.Params[i];
                if (!String.IsNullOrEmpty(s))
                {
                    if ((s.Length > 4) && (s.StartsWith("FORM")))
                    {
                        MessageBox.Show(XModule.Params[i]);
                    }
                }
            }
        }
    }
}
