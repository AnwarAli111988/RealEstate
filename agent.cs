using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace doc
{
    public partial class agent : Form
    {
        DAL.DAL dl = new DAL.DAL();

        public agent()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {

            if (textBox2.Text != "")
            {
                SqlConnection con = new SqlConnection(dl.cs);
                SqlCommand cmd = new SqlCommand("INSERT INTO Agent       (Name, Company_name, Address, Location, Sub_location, Mobile, Phone, E_mail, Property_type, Specialisation, Remarks)  VALUES('" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox11.Text + "','" + comboBox4.Text + "')", con);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Data Saved");
            }
            else
            {
                MessageBox.Show("Enter All the Fields");
            }

        }   
           

        private void agent_Load(object sender, EventArgs e)
        {
            agent_id();
        }
       void agent_id() 
       {
           SqlConnection con = new SqlConnection(dl.cs);
           try
           {

               SqlDataAdapter da = new SqlDataAdapter("SELECT        MAX(Agent_ID) AS Expr1 FROM            Agent", con);
               DataTable dt = new DataTable();
               int i = da.Fill(dt);
               if (i > 0)
               {
                   string k = Convert.ToString((Convert.ToInt32(dt.Rows[0][0])) + 1);
                   textBox1.Text = k;
               }
           }
           catch (Exception ex)
           {
               MessageBox.Show(ex.Message);
           }

          
        }

       private void btn_clear_Click(object sender, EventArgs e)
       {
           clear();
       }

       void clear()
       { 
            textBox1.Text="";
            textBox2.Text="";
            textBox3.Text="";
            textBox4.Text="";
            comboBox1.Text="";
            comboBox2.Text="";
            comboBox4.Text="";
            //comboBox3.Text="";
            //richTextBox1.Text="";
            textBox5.Text="";        
            textBox6.Text="";
            textBox11.Text = "";
       }

       private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
       {
           Validation.IsAlpha(e);
       }

       private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
       {
           Validation.IsAlpha(e);
       }

       private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
       {
           Validation.IsAlphaNumeric(e);
       }

       private void richTextBox1_KeyPress(object sender, KeyPressEventArgs e)
       {
           Validation.IsAlphaNumeric(e);
       }

       private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
       {
           Validation.IsInteger(e);
       }

       private void textBox5_TextChanged(object sender, EventArgs e)
       {

       }

       private void textBox6_TextChanged(object sender, EventArgs e)
       {

       }

    }
}
