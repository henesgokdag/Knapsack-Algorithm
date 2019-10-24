using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SirtCantasi
{
    public class Esya
    {
       
        public TextBox txtagirlik;
        public TextBox txtdeger;
        public decimal agirlik;
        public decimal deger;
        public decimal fayda;
        public Label goster;
        

        public Esya(TextBox _txtagirlik, TextBox _txtdeger,Label label)
        {
            goster = label;
            txtagirlik = _txtagirlik;
            txtdeger = _txtdeger;
            
        }
        public Esya()
        {

        }
        
        public void Atama()
        {
            agirlik = Convert.ToDecimal(txtagirlik.Text);
            deger = Convert.ToDecimal(txtdeger.Text);
            fayda = deger /agirlik;
            goster.Text = fayda.ToString();
            
        }
        
    }
}
