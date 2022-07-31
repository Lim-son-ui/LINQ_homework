using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework{
    public partial class Frm作業_2 : Form
    {
        public Frm作業_2()
        {
            InitializeComponent();
        }

        private void button11_Click(object sender, EventArgs e)
        {
            this.dataGridView1.DataSource = this.adventure1.ProductPhoto.ToList();
        }

        private void Frm作業_2_Load(object sender, EventArgs e)
        {
            this.productPhotoTableAdapter1.Fill(this.adventure1.ProductPhoto);

            string[] year = {"2008","2011","2012","2013"};

            foreach (var ro in year)
            {
                this.comboBox3.Items.Add(ro);
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)  //區間所以比對會從年月日
        {
            //MessageBox.Show("" + dateTimePicker1.Value.Year);
            //MessageBox.Show("" + dateTimePicker1.Value.Month);
            //MessageBox.Show("" + dateTimePicker1.Value.Day);

            //var q = from a in this.adventure1.ProductPhoto
            //        where ((dateTimePicker1.Value.Year <= a.ModifiedDate.Year) && (dateTimePicker2.Value.Year >= a.ModifiedDate.Year))
            //        select a;

            //var r = from b in q
            //        where ((dateTimePicker1.Value.Month <= a.ModifiedDate.Year) && (dateTimePicker2.Value.Year >= a.ModifiedDate.Year))

            var a = this.adventure1.ProductPhoto.Where(x => x.ModifiedDate > dateTimePicker2.Value || x.ModifiedDate < dateTimePicker1.Value);

            var b = this.adventure1.ProductPhoto;

            var convert = b.Except(a);


            this.dataGridView1.DataSource = convert.ToList();
        }

        private void button5_Click(object sender, EventArgs e)  //  比對哪一個年 全部資料
        {
            var q = from a in this.adventure1.ProductPhoto
                    where a.ModifiedDate.Year.ToString() == comboBox3.Text
                    select a;

            this.dataGridView1.DataSource = q.ToList();
        }


        //public int Counti(int[] id)
        //{

        //}

        //static List<int> count(int)

        private void button10_Click(object sender, EventArgs e)     //比對某一季  計算count筆數
        {

            if(comboBox2.SelectedIndex == 0)
            {
                
                var q = from a in this.adventure1.ProductPhoto
                        group a by a into gro
                        select new {count = gro.Count() };

             

                this.dataGridView1.DataSource = q.ToList();
            }


            if (comboBox2.SelectedIndex == 1)
            {
                var q = from a in this.adventure1.ProductPhoto
                        where ((a.ModifiedDate.Month == 4)
                        || (a.ModifiedDate.Month == 5)
                        || (a.ModifiedDate.Month == 6))
                        select a;


                MessageBox.Show("" + q.Count());
               

                this.dataGridView1.DataSource = q.ToList();
            }

            if (comboBox2.SelectedIndex == 2)
            {
                var q = from a in this.adventure1.ProductPhoto
                        where ((a.ModifiedDate.Month == 7)
                        || (a.ModifiedDate.Month == 8)
                        || (a.ModifiedDate.Month == 9))
                        select a;

                this.dataGridView1.DataSource = q.ToList();
            }

            if (comboBox2.SelectedIndex == 3)
            {
                var q = from a in this.adventure1.ProductPhoto
                        where ((a.ModifiedDate.Month == 10)
                        || (a.ModifiedDate.Month == 11)
                        || (a.ModifiedDate.Month == 12))
                        select a;

                this.dataGridView1.DataSource = q.ToList();
            }



        }
    }
}
