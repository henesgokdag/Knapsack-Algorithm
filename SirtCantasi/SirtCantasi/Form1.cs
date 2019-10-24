using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirtCantasi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<TextBox> kutular = new List<TextBox>();
        List<TextBox> kutular2 = new List<TextBox>();
        List<Esya> esyalar = new List<Esya>();
        int x = 100;
        int y_agirlik = 100;
        int y_deger = 230;
        int bosluk = 25;
        public decimal enbuyuk = 0;
        public decimal toplamfayda = 0;
        public decimal kilo;
        public Esya enbuyukEsya = new Esya();


        private void button1_Click(object sender, EventArgs e)
        {
            label6.Visible = false;
            label5.Visible = false;
            label7.Visible = false;
            foreach (var item in esyalar)
            {
                Controls.Remove(item.txtagirlik);
                Controls.Remove(item.txtdeger);
                Controls.Remove(item.goster);
            }
            enbuyukEsya = new Esya();
            esyalar = new List<Esya>();
            decimal indis = Convert.ToDecimal(textBox1.Text);
            for (int i = 0; i < indis; i++)
            {
                TextBox kutu = new TextBox();
                kutular.Add(kutu);
                kutu.Top = x +( bosluk*i);
                kutu.Left = y_agirlik;
                TextBox kutu2 = new TextBox();
                kutular2.Add(kutu2);
                kutu2.Top = x +(bosluk * i);
                kutu2.Left = y_deger;
                this.Controls.Add(kutu);
                Label gosterme = new Label();
                gosterme.Top=(x+ bosluk*i);
                gosterme.Left = 340;
                this.Controls.Add(kutu2);
                this.Controls.Add(gosterme);
                esyalar.Add( new Esya(kutu,kutu2,gosterme));
            }
            textBox2.Visible = true;

            label2.Visible = true;

            button2.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            toplamfayda = 0;
            kilo = Convert.ToDecimal(textBox2.Text);
            foreach (var item in esyalar)
            {
                item.Atama();
               
            }
            List<Esya> kopya = new List<Esya>(esyalar);
            Hesapla(kopya);
            label6.Visible = true;
            label7.Visible = true;
            
        }
        public void Hesapla(List<Esya> esya)
        {
            enbuyuk = 0;
            
            foreach (var item in esya)
            {

                if(item.fayda > enbuyuk)
                {
                    enbuyuk = item.fayda;
                    enbuyukEsya = item;
                    
                }
               
            }
            kilo = kilo - enbuyukEsya.agirlik;
            if (kilo <= 0)
            {
                decimal gereken = kilo + enbuyukEsya.agirlik;
                
                toplamfayda += enbuyukEsya.fayda * gereken;

                esya.Remove(enbuyukEsya);
                label7.Text = toplamfayda.ToString();
                return;
            }
            else
            {
                toplamfayda += enbuyukEsya.fayda * enbuyukEsya.agirlik;
                esya.Remove(enbuyukEsya);
            }
            label7.Text = toplamfayda.ToString();
            Hesapla(esya);
            


        }
    }
}
