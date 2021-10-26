using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace DataBase
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            String ConnStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source = C:\Users\monke\Desktop\FarmInfomation.accdb; Persist Security Info = False";
            String q = "";
            OleDbConnection conn = null;
            try
            {
                conn = new OleDbConnection(ConnStr);
                conn.Open();
                //allows for just putting in table name
                q = "Select * from [" + textBox1.Text + "];";
                OleDbCommand cmd = new OleDbCommand(q, conn);
                String str = "";
                //loops through database and adds to text box
                using (OleDbDataReader reader = cmd.ExecuteReader())
                {
                    int count = reader.FieldCount;
                    while (reader.Read())
                    {
                        for (int i = 0; i < count; i++)
                        {
                            str = str + reader.GetValue(i) + "\t";
                        }
                        textBox2.Text += str + "\r\n";
                        str = "";
                    }
                    
                }
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
