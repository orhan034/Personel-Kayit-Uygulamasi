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

namespace Personel_Kayit
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }

        SqlConnection baglanti = new SqlConnection("Data Source=ACERNITRO5;Initial Catalog=PersonelVeriTabani;Integrated Security=True");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            // toplam personel sayısı
            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select Count(*) From Tbl_Personel", baglanti);
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                lblToplamPersonel.Text = dr1[0].ToString();
            }
            baglanti.Close();

            // evli per sayısı
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=1", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
               lblEvliPersonel.Text = dr2[0].ToString();
            }
            baglanti.Close();

            // Bekar personel saytısı
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select count(*) From Tbl_Personel where PerDurum=0", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBekarPersonel.Text = dr3[0].ToString();
            }
            baglanti.Close();

            // Şehir Sayısı
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select count(distinct(PerSehir)) From Tbl_Personel", baglanti);
            SqlDataReader d4 = komut4.ExecuteReader();
            while (d4.Read())
            {
                lblSehirSayisi.Text = d4[0].ToString();
            }
            baglanti.Close();

            // Toplam Maaş 
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select Sum(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblMaas.Text = dr5[0].ToString();   
            }
            baglanti.Close();

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select Avg(PerMaas) From Tbl_Personel", baglanti);
            SqlDataReader d6 = komut6.ExecuteReader();
            while (d6.Read())
            {
                lblOrtalamaMaas.Text = d6[0].ToString();
            }
            baglanti.Close();

        }
    }
}
