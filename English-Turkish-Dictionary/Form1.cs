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

namespace English_Turkish_Dictionary
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        OleDbConnection baglantim = new OleDbConnection("Provider=Microsoft.ACE.OleDb.12.0;Data Source=" + Application.StartupPath + "\\dictionary.accdb");

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand eklekomutu = new OleDbCommand("insert into ingturk (English,Turkish) values('" + textBox1.Text + "','" + textBox2.Text + "')", baglantim);
                eklekomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("The word is added to the database ...", "Database operation");
                textBox1.Clear();
                textBox2.Clear();

            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Database operation");
                baglantim.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand guncellekomutu = new OleDbCommand("update into ingturk set ,Turkish='" + textBox2.Text + "' where English ='" + textBox1.Text + "'", baglantim);
                guncellekomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("Updated in word database...", "Database operation");
                textBox1.Clear();
                textBox2.Clear();

            }
            catch (Exception acıklama)
            {
                MessageBox.Show(acıklama.Message, "Database operation");
                baglantim.Close();
                
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                baglantim.Open();
                OleDbCommand silkomutu = new OleDbCommand("delete from ingturk where English='"+textBox1.Text+"'" , baglantim);
                silkomutu.ExecuteNonQuery();
                baglantim.Close();
                MessageBox.Show("Delete in word database...", "Database operation");
                textBox1.Clear();
                textBox2.Clear();

            }
            catch (Exception acıklama)
            {
                MessageBox.Show(acıklama.Message, "Database operation");
                baglantim.Close();

            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                listBox1.Items.Clear();
                baglantim.Open();
                OleDbCommand aramakomutu = new OleDbCommand("select English,Turkish from ingturk where English like'" + textBox1.Text + "%'", baglantim);
                OleDbDataReader oku =aramakomutu.ExecuteReader();
                while (oku.Read())
                {
                    listBox1.Items.Add(oku["English"].ToString() + " = " + oku["Turkish"].ToString());
                }
                baglantim.Close();
            }
            catch (Exception aciklama)
            {
                MessageBox.Show(aciklama.Message, "Database operation");
                baglantim.Close();
            }
        }
    }
}
