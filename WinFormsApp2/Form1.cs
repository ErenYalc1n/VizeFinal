using Microsoft.Data.SqlClient;
using NPOI.SS.Formula.Functions;
using System.Data.SqlClient;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source = localhost; Initial Catalog=Bilgiler; Integrated Security=True; TrustServerCertificate=True");

        private void verilerigoster()
        {
            baglanti.Open();
            SqlCommand sqlKomut = new SqlCommand(" SELECT no, adi, soyadi, vize, final, ort, durum FROM Sinav", baglanti);
            SqlDataReader sqlDR = sqlKomut.ExecuteReader();
            while (sqlDR.Read())
            {
                string no = sqlDR[0].ToString();
                string adi = sqlDR[1].ToString();
                string soyadi = sqlDR[2].ToString();
                string vize = sqlDR[3].ToString();
                string final = sqlDR[4].ToString();
                string ort = sqlDR[5].ToString();
                string durum = sqlDR[6].ToString();
                richTextBox1.Text = richTextBox1.Text + no + "\n";
                richTextBox9.Text = richTextBox9.Text + adi + "\n";
                richTextBox10.Text = richTextBox10.Text + soyadi + "\n";
                richTextBox11.Text = richTextBox11.Text + vize + "\n";
                richTextBox12.Text = richTextBox12.Text + final + "\n";
                richTextBox13.Text = richTextBox13.Text + ort + "\n";
                richTextBox14.Text = richTextBox14.Text + durum + "\n";
            }
            baglanti.Close();
        }


        private void kaydet()
        {
            double v = Convert.ToDouble(textBox3.Text);
            double f = Convert.ToDouble(textBox4.Text);
            double o = (v*4/10) +(f * 6 / 10);
            o = Math.Round(o, 2);
            textBox5.Text = Convert.ToString(o);
            textBox6.Text = "AA";
            if (0>=85)
            {
                textBox6.Text = "AA";
            }
            else if(o>=70 && o<85)
            {
                textBox6.Text = "BB";
            }
            else if (o >= 55 && o < 70)
            {
                textBox6.Text = "CC";
            }
            else if (o >= 40 && o < 55)
            {
                textBox6.Text = "DD";
            }
            else if (o<40)
            {
                textBox6.Text = "FF";
            }
            baglanti.Open();
            SqlCommand kaydet = new SqlCommand("Insert into Sinav(no, adi, soyadi, vize, final, ort, durum) Values(@n, @a, @b, @c, @d, @e, @f)", baglanti);
            kaydet.Parameters.AddWithValue("@n", textBox7.Text);
            kaydet.Parameters.AddWithValue("@a",textBox1.Text);
            kaydet.Parameters.AddWithValue("@b", textBox2.Text);
            kaydet.Parameters.AddWithValue("@c", textBox3.Text);
            kaydet.Parameters.AddWithValue("@d", textBox4.Text);
            kaydet.Parameters.AddWithValue("@e", textBox5.Text);
            kaydet.Parameters.AddWithValue("@f", textBox6.Text);
            kaydet.ExecuteNonQuery();
            baglanti.Close();
        }
        private void temizle()  
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox7.Clear();

        }

        private void sorgula()
        {            
            baglanti.Open();
            SqlCommand sorgu = new SqlCommand("Select adi, soyadi, vize, final From Sinav Where no= @n ", baglanti);
            sorgu.Parameters.AddWithValue("@n", textBox7.Text);
            SqlDataReader sqlDR = sorgu.ExecuteReader();
            while (sqlDR.Read())
            {
                string adi = sqlDR[0].ToString();
                string soyadi = sqlDR[1].ToString();
                string vize = sqlDR[2].ToString();
                string final = sqlDR[3].ToString();
                textBox1.Text = adi;
                textBox2.Text = soyadi;
                textBox3.Text = vize;
                textBox4.Text = final;
            }
            baglanti.Close();               
        }
        private void guncelle()
        {
            double v = Convert.ToDouble(textBox3.Text);
            double f = Convert.ToDouble(textBox4.Text);
            double o = (v * 4 / 10) + (f * 6 / 10);
            o = Math.Round(o, 2);
            textBox5.Text = Convert.ToString(o);
            textBox6.Text = "AA";
            if (0 >= 85)
            {
                textBox6.Text = "AA";
            }
            else if (o >= 70 && o < 85)
            {
                textBox6.Text = "BB";
            }
            else if (o >= 55 && o < 70)
            {
                textBox6.Text = "CC";
            }
            else if (o >= 40 && o < 55)
            {
                textBox6.Text = "DD";
            }
            else if (o < 40)
            {
                textBox6.Text = "FF";
            }
            baglanti.Open();
            SqlCommand guncelle = new SqlCommand("Update Sinav SET no=@n, adi=@a, soyadi=@b, vize=@c, final=@d, ort=@e, durum=@f Where no=@n", baglanti);
            guncelle.Parameters.AddWithValue("@n", textBox7.Text);
            guncelle.Parameters.AddWithValue("@a", textBox1.Text);
            guncelle.Parameters.AddWithValue("@b", textBox2.Text);
            guncelle.Parameters.AddWithValue("@c", textBox3.Text);
            guncelle.Parameters.AddWithValue("@d", textBox4.Text);
            guncelle.Parameters.AddWithValue("@e", textBox5.Text);
            guncelle.Parameters.AddWithValue("@f", textBox6.Text);
            guncelle.ExecuteNonQuery();
            baglanti.Close();
        }
        private void sil()
        {
            baglanti.Open();
            SqlCommand sil = new SqlCommand("Delete From Sinav Where no=@n", baglanti);
            sil.Parameters.AddWithValue("@n", textBox7.Text);
            sil.ExecuteNonQuery();
            baglanti.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            kaydet();
            temizle();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            verilerigoster();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            sorgula();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            guncelle();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            richTextBox9.Clear();
            richTextBox10.Clear();
            richTextBox11.Clear();
            richTextBox12.Clear();
            richTextBox13.Clear();
            richTextBox14.Clear();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            sil();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            temizle();
        }
    }
}