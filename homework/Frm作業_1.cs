using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework
{
    public partial class Frm作業_1 : Form
    {
        public Frm作業_1()
        {
            InitializeComponent();


            students_scores = new List<Student>()
                                         {
                                            //new Student{ Name = "",Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "aaa", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                           // new Student{  Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                                            new Student{ Name = "bbb", Class = "CS_102", Chi = 80, Eng = 80, Math = 100, Gender = "Male" },
                                            new Student{ Name = "ccc", Class = "CS_101", Chi = 60, Eng = 50, Math = 75, Gender = "Female" },
                                            new Student{ Name = "ddd", Class = "CS_102", Chi = 80, Eng = 70, Math = 85, Gender = "Female" },
                                            new Student{ Name = "eee", Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Female" },
                                            new Student{ Name = "fff", Class = "CS_102", Chi = 80, Eng = 80, Math = 80, Gender = "Female" },

                                          };

        }

        private void Frm作業_1_Load(object sender, EventArgs e)
        {
            this.ordersTableAdapter1.Fill(this.north_wind1.Orders);
            this.order_DetailsTableAdapter1.Fill(this.north_wind1.Order_Details);
            this.productsTableAdapter1.Fill(this.north_wind1.Products);


            string[] choose = { "共幾個 學員成績 ?",
                "找出 前面三個 的學員所有科目成績",
                "找出 後面兩個 的學員所有科目成績",
                "找出 Name 'aaa','bbb','ccc' 的學成績",
                "找出學員 'bbb' 的成績",
                "找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)",
                "數學不及格 ... 是誰 ",
                "透過 類別中的屬性" };

            string[] choose1 = { "找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績",
                "個人 所有科的  sum, min, max, avg" };

            foreach (var ro in choose)
            {
                this.comboBox2.Items.Add(ro);
            }

            foreach (var ro in choose1)
            {
                this.comboBox3.Items.Add(ro);
            }

        }

        List<Student> students_scores;


        public class Student
        {
            public string Name { get; set; }
            public string Class { get; set; }
            public int Chi { get; set; }
            public int Eng { get; internal set; }
            public int Math { get; set; }
            public string Gender { get; set; }

            //public int count {
            //    get { }
            //    set { 

            //    }
            //        }
        }



        private void button36_Click(object sender, EventArgs e)
        {
            #region
            Student stu = new Student();

            List<Student> stud = students_scores;

            //stu.


            // MessageBox.Show(" "+students_scores[0].Name);

            //var 





            //MessageBox.Show(" " + comboBox2.SelectedItem);

            //var q;
            #endregion

            //MessageBox.Show("" +students_scores[][2]);


            if (comboBox2.SelectedIndex == 0)
            {
                // var q = students_scores.Where(a => a.Name != null && a.Name != "" );

                var q = students_scores.Count();
                //this.dataGridView1.DataSource = q.ToString();
                MessageBox.Show("" + students_scores.Count());
            }

            #region
            /*  this.dataGridView1.DataSource = q.ToList();*/

            //var a = from q
            //        select

            // this.dataGridView1.DataSource = students_scores.Count().ToString();
            //stud[0].Name.eleme
            //MessageBox.Show("" + students_scores);
            #endregion

            if (comboBox2.SelectedIndex == 1)
            {
                var q = students_scores.Take(3);

                this.dataGridView1.DataSource = q.ToList();
            }

            if (comboBox2.SelectedIndex == 2)
            {
                // var q = students_scores.;

                //this.dataGridView1.DataSource = q.ToList();

                int i;
                for (i = 0; i < (students_scores.Count - 1); i++)
                {

                }
                var q = students_scores.Skip(i - 1).Take(2);
                this.dataGridView1.DataSource = q.ToList();
            }


            if (comboBox2.SelectedIndex == 3)
            {
                var q = students_scores.Where<Student>(x => (x.Name.Equals("aaa") || x.Name.Equals("bbb") || x.Name.Equals("ccc")))
                    .Select(x => new { x.Chi, x.Eng, x.Math });


                this.dataGridView1.DataSource = q.ToList();

            }


            if (comboBox2.SelectedIndex == 5)
            {
                var a = students_scores.Select(x => new { x.Chi, x.Eng, x.Math });
                var q = students_scores.Where<Student>(x => x.Name.Equals("bbb"))
                    .Select(x => new { x.Chi, x.Eng, x.Math });

                var convert = a.Except(q);


                this.dataGridView1.DataSource = convert.ToList();

            }

            if (comboBox2.SelectedIndex == 6)
            {
                var q = students_scores.Where(x => x.Math < 60).Select(x => new { x.Name });


                this.dataGridView1.DataSource = q.ToList();

            }

            #region
            // 
            // 共幾個 學員成績 ?						

            // 找出 前面三個 的學員所有科目成績					
            // 找出 後面兩個 的學員所有科目成績					

            // 找出 Name 'aaa','bbb','ccc' 的學成績						

            // 找出學員 'bbb' 的成績	                          

            // 找出除了 'bbb' 學員的學員的所有成績 ('bbb' 退學)	


            // 數學不及格 ... 是誰 


            // 透過 類別中的屬性
            #endregion
        }

        private void button37_Click(object sender, EventArgs e)
        {
            //new {.....  Min=33, Max=34.}
            // 找出 'aaa', 'bbb' 'ccc' 學員 國文數學兩科 科目成績  |		

            //個人 所有科的  sum, min, max, avg

            // List<Student> stud = students_scores;

            if (comboBox3.SelectedIndex == 1)
            {
                var q = students_scores.Select(
                    x => new {
                        sum = x.Chi + x.Eng + x.Math,
                        avg = ((x.Chi + x.Eng + x.Math) / 3),

                        //maxma = (new {x.Chi,x.Eng,x.Math})
                    });

                //for (int i = 0; i < stud.Count(0); i++)
                //{
                //    for (int j = 0; j < stud.Count(1))
                //}



                this.dataGridView1.DataSource = q.ToList();
            }
        }



        private void button14_Click(object sender, EventArgs e)     //.log檔案
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();


            var a = from fi in files
                    where fi.Name.Contains(".log")
                    select fi;

            this.dataGridView1.DataSource = a.ToList();



            #region
            //foreach(DataGridViewRow r in dataGridView1.Rows)
            //{

            //    if (r.Cells[7].Value.ToString().ToLower().Contains(".log"))
            //    {

            //        foreach(DataGridViewCell c in r.Cells)
            //        {
            //            c.Style.BackColor = Color.Yellow;
            //        }
            //    }

            //}
            #endregion

        }

        private void button2_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();


            var a = from fi in files
                    where fi.CreationTime.ToString().Substring(0, 4) == "2019"
                    select fi;

            this.dataGridView1.DataSource = a.ToList();

            #region
            //foreach (DataGridViewRow r in dataGridView1.Rows)
            //{

            //    if (r.Cells[8].Value.ToString().Substring(0,4) == "2020" )
            //    {

            //        foreach (DataGridViewCell c in r.Cells)
            //        {
            //            c.Style.BackColor = Color.Yellow;
            //        }
            //    }

            //}
            #endregion


        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] files = dir.GetFiles();


            var a = from fi in files
                    where fi.Length > 200000
                    select fi;

            this.dataGridView1.DataSource = a.ToList();
        }



        private void button1_Click(object sender, EventArgs e)      //印出某年訂單
        {


            //this.ordersTableAdapter1.Fill(this.north_wind1.Orders);
            //MessageBox.Show("" + comboBox1.Text);

            var q = from p in this.north_wind1.Orders
                    where p.OrderDate.Year.ToString() == comboBox1.Text
                    select p;


            this.dataGridView1.DataSource = q.ToList();

            var r = from a in north_wind1.Order_Details
                    join b in north_wind1.Orders
                    on a.OrderID equals b.OrderID
                    where b.OrderDate.Year.ToString() == comboBox1.Text
                    select a;

            //new
            //{
            //    //a.OrderID,
            //    //a.ProductID,
            //    //a.UnitPrice,
            //    //a.Quantity,
            //    //a.Discount
            //};


            this.dataGridView2.DataSource = r.ToList();

        }

        int row = 0, page = 0;

        //object 

        private void button6_Click(object sender, EventArgs e)          //all訂單
        {

            var q = from p in this.north_wind1.Orders
                    where !p.IsShipRegionNull() && !p.IsShippedDateNull() && !p.IsShipPostalCodeNull()
                    select p;



            var a = (from p in this.north_wind1.Orders
                     select p.OrderDate.Year).Distinct();


            foreach (var ro in a)
            {
                this.comboBox1.Items.Add(ro);
            }




            this.dataGridView1.DataSource = q.ToList();
        }
        #region
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        #endregion



        #region
        private void comboBox1_Click(object sender, EventArgs e)
        {

        }
        #endregion

        private void button13_Click(object sender, EventArgs e)     //下一頁
        {
            //this.nwDataSet1.Products.Take(10);//Top 10 Skip(10)
            //Distinct()
            // var q
            //var que = this.north_wind1.Products.Take(row).Skip(page*row);

            page++;
            row = int.Parse(textBox1.Text);

            var que = this.north_wind1.Products.Skip((page - 1) * row).Take(row);
            this.dataGridView1.DataSource = que.ToList();


        }

        private void button12_Click(object sender, EventArgs e)     //上一頁
        {
            row = int.Parse(textBox1.Text);
            page--;

            var que = this.north_wind1.Products.Skip((page - 1) * row).Take(row);
            this.dataGridView1.DataSource = que.ToList();

        }

        #region
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        #endregion


    }
}
