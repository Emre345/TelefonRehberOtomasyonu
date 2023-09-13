using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        SqlConnection baglanti;
        SqlCommand komut;
        SqlDataAdapter da;
        DataSet ds;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Listele();
        }

        void Listele()
        {
            baglanti = new SqlConnection("server=.;Initial Catalog=rehber;Integrated Security=SSPI");
            baglanti.Open();
            da = new SqlDataAdapter("Select * from kisiler", baglanti);
            DataTable tablo = new DataTable();
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglanti.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                DialogResult asd = new DialogResult();
                asd = MessageBox.Show("Eklensin Mi?", "",MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asd == DialogResult.Yes)
                {

                    baglanti.Open();

                    string kayit = "Insert into kisiler(kisino,ad,soyad,tel) values (@kisino,@ad,@soyad,@tel)";
                    komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@kisino", textBox1.Text);
                    komut.Parameters.AddWithValue("@ad", textBox2.Text);
                    komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                    komut.Parameters.AddWithValue("@tel", textBox4.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Listele();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            else
            {

                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            
            }




        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                DialogResult asd = new DialogResult();
                asd = MessageBox.Show("Güncellensin Mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asd == DialogResult.Yes)
                {
                    baglanti.Open();
                    string kayit = "update kisiler set ad=@ad,soyad=@soyad,tel=@tel where kisino=@kisino";
                    komut = new SqlCommand(kayit, baglanti);
                    komut.Parameters.AddWithValue("@kisino", textBox1.Text);
                    komut.Parameters.AddWithValue("@ad", textBox2.Text);
                    komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                    komut.Parameters.AddWithValue("@tel", textBox4.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Listele();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
            else
            {

                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Güncellenecek Veri Seçili Değil..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "")
            {
                DialogResult asd = new DialogResult();
                asd = MessageBox.Show("Silinsin Mi?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (asd == DialogResult.Yes)
                {
                    baglanti.Open();
                    string sorgu = "delete from kisiler where kisino=@kisino";
                    komut = new SqlCommand(sorgu, baglanti);
                    komut.Parameters.AddWithValue("@kisino", textBox1.Text);
                    komut.Parameters.AddWithValue("@ad", textBox2.Text);
                    komut.Parameters.AddWithValue("@soyad", textBox3.Text);
                    komut.Parameters.AddWithValue("@tel", textBox4.Text);
                    komut.ExecuteNonQuery();
                    baglanti.Close();
                    Listele();

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox4.Text = "";
                }
            }
             else
            {

                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Lütfen Boş Yer Bırakmayınız", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                da = new SqlDataAdapter("Select * from kisiler where kisino Like '" + textBox1.Text + "%'", baglanti);
                ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "kisiler");
                baglanti.Close();
                dataGridView1.DataSource = ds.Tables["kisiler"];
            }

            else
            {

                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Aranacak Değer Seçili Değil.", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "")
            {
                da = new SqlDataAdapter("Select * from kisiler where ad Like '" + textBox2.Text + "%'", baglanti);
                ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "kisiler");
                baglanti.Close();
                dataGridView1.DataSource = ds.Tables["kisiler"];
            }
            else
            {

                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Aranacak Değer Seçili Değil..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }

        private void button7_Click(object sender, EventArgs e)
        {
            DialogResult asd = new DialogResult();
            asd = MessageBox.Show("Çıkmak İstediğinizden Emin Misiniz?","",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (asd == DialogResult.Yes)
            {
                Application.Exit();
            }
            else if (asd == DialogResult.No)
            {
                
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (textBox3.Text != "")
            {
                da = new SqlDataAdapter("Select * from kisiler where soyad Like '" + textBox3.Text + "%'", baglanti);
                ds = new DataSet();
                baglanti.Open();
                da.Fill(ds, "kisiler");
                baglanti.Close();
                dataGridView1.DataSource = ds.Tables["kisiler"];
            }
            else
            {

                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Aranacak Değer Seçili Değil..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }




        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (textBox4.Text != "")
            {
                da = new SqlDataAdapter("Select * from kisiler where tel Like '" + textBox4.Text + "%'", baglanti);
                ds = new DataSet();
                da.Fill(ds, "kisiler");
                baglanti.Close();
                dataGridView1.DataSource = ds.Tables["kisiler"];
            }

            else
            {
                DialogResult hata = new DialogResult();
                hata = MessageBox.Show("Aranacak Değer Seçili Değil..", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



    }
}
