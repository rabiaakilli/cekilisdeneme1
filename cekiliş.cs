using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cekilisprogrami
{
    public partial class Form1 : Form
    {
       

        public Form1()
        {
            InitializeComponent();
        }
        int _cekilisSay = 1;

        private void btnCekilis_Click(object sender, EventArgs e)
        {
            int cekilisSayisi = Convert.ToInt32(nMiktar.Text);
            List<string> ListAdaylar = new List<string>(rtxtAdaylar.Text.Split('\n'));
            if(rtxtAdaylar.Text=="") 
            {
                MessageBox.Show("Adayları Girmelisiniz"); 

            }
            else
            {
                Random uret = new Random(); 
                for (int i = 0; i < cekilisSayisi; i++)
                {
                   int kazananAday= uret.Next(0, ListAdaylar.Count);
                    dtgList.Rows.Add(_cekilisSay++,ListAdaylar[kazananAday]);
                
                }
            
            
            } 

        }

        private void rtxtAdaylar_TextChanged(object sender, EventArgs e)
        {
            lblCekilisSayi.Text = rtxtAdaylar.Lines.Count().ToString(); 
            if (rtxtAdaylar.Lines.Count() > 0)
            {
                nMiktar.Maximum = rtxtAdaylar.Lines.Count()-1;
            }
            else
            {
                nMiktar.Minimum = 1; 
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgList.ColumnCount = 2;

            dtgList.Columns[0].Name = "Sıra No";  
            dtgList.Columns[1].Name = "Ad Soyad";
        }

        private void dtgList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {r
            rtxtAdaylar.Clear();
            dtgList.Rows.Clear();
            _cekilisSay = 1;
            nMiktar.Value = 1;
        }

        private void nMiktar_ValueChanged(object sender, EventArgs e)
        {
            nMiktar.Maximum = rtxtAdaylar.Lines.Count(); 
        }
    }
}
