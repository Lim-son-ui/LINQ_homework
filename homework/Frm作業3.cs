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
    public partial class Frm作業3 : Form
    {
        public Frm作業3()
        {
            InitializeComponent();


            students_scores = new List<Student>()
            {
                    //new Student{ Name = "",Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                    new Student{ Name = "aaa", Class = "CS_101", Chi = 90, Eng = 63, Math = 74, Gender = "Male" },
                    // new Student{  Class = "CS_101", Chi = 80, Eng = 80, Math = 50, Gender = "Male" },
                    new Student{ Name = "bbb", Class = "CS_102", Chi = 75, Eng = 70, Math = 68, Gender = "Male" },
                    new Student{ Name = "ccc", Class = "CS_101", Chi = 66, Eng = 96, Math = 39, Gender = "Female" },
                    new Student{ Name = "ddd", Class = "CS_102", Chi = 84, Eng = 91, Math = 48, Gender = "Female" },
                    new Student{ Name = "eee", Class = "CS_101", Chi = 65, Eng = 32, Math = 95, Gender = "Female" },
                    new Student{ Name = "fff", Class = "CS_102", Chi = 57, Eng = 58, Math = 72, Gender = "Female" },

            };

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
        }


        private void button36_Click(object sender, EventArgs e)     //搜尋班級學生成績
        {

            //var q;
            if (comboBox1.SelectedIndex == 0)        //全班平均  要先找到 各科平均  國文 英文  數學
            {  //要先搞懂 group 用在什麼情況
                var q = from n in students_scores
                        group n by n.Class into g
                        select new
                        {
                            mykey = g.Key,
                            avg_chi = g.Average(n => n.Chi),
                            avg_eng = g.Average(n => n.Eng),
                            avg_math = g.Average(n => n.Math)
                        };

                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = q.ToList();


                //this.chart1.Series[0].Points.Clear();
                //this.chart1.Series[1].Points.Clear();
                //this.chart1.Series[2].Points.Clear();

                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "mykey";
                this.chart1.Series[0].YValueMembers = "avg_chi";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[1].XValueMember = "mykey";
                this.chart1.Series[1].YValueMembers = "avg_eng";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[2].XValueMember = "mykey";
                this.chart1.Series[2].YValueMembers = "avg_math";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (comboBox1.SelectedIndex == 1)        //全班中位數
            {

            }
            if (comboBox1.SelectedIndex == 2)        //全班最低
            {
                var q = from n in students_scores
                        group n by n.Class into g
                        select new
                        {
                            mykey = g.Key,
                            min_chi = g.Min(n => n.Chi),
                            min_eng = g.Min(n => n.Eng),
                            min_math = g.Min(n => n.Math)
                        };

                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = q.ToList();


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "mykey";
                this.chart1.Series[0].YValueMembers = "min_chi";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[1].XValueMember = "mykey";
                this.chart1.Series[1].YValueMembers = "min_eng";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[2].XValueMember = "mykey";
                this.chart1.Series[2].YValueMembers = "min_math";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }
            if (comboBox1.SelectedIndex == 3)        //全班最高
            {
                var q = from n in students_scores
                        group n by n.Class into g
                        select new
                        {
                            mykey = g.Key,
                            max_chi = g.Max(n => n.Chi),
                            max_eng = g.Max(n => n.Eng),
                            max_math = g.Max(n => n.Math)
                        };

                this.dataGridView1.Columns.Clear();
                this.dataGridView1.DataSource = q.ToList();


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[0].XValueMember = "mykey";
                this.chart1.Series[0].YValueMembers = "max_chi";
                this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[1].XValueMember = "mykey";
                this.chart1.Series[1].YValueMembers = "max_eng";
                this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;


                this.chart1.DataSource = q.ToList();
                this.chart1.Series[2].XValueMember = "mykey";
                this.chart1.Series[2].YValueMembers = "max_math";
                this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            }


        }

        //  選項 哪幾個學生  他會列出各個科目
        private void button37_Click(object sender, EventArgs e)     //每個學生個人成績  就列出國英數
        {                               //再想怎麼分成多個學生  用list記錄他的索引
            var q = from n in students_scores
                    where n.Name == comboBox2.Text
                    select new
                    {
                        name = n.Name,
                        chinese = n.Chi,
                        english = n.Eng,
                        math = n.Math
                    };

            this.dataGridView1.Columns.Clear();

            this.dataGridView1.DataSource = q.ToList();
            #region
            //this.chart1.Series[0].Points.Clear();
            //this.chart1.Series[1].Points.Clear();
            //this.chart1.Series[2].Points.Clear();
            // int scor = chinese; 
            #endregion

            this.chart1.DataSource = q.ToList();
            #region
            //想用
            //chart1.Series[0].Points.AddXY(name , chinese);

            //foreach(Student j in students_scores)
            //{

            //    this.chart1.Series[0].Points.AddXY(j.Name, j.Chi);
            //    this.chart1.Series[1].Points.AddXY(j.Name, j.Eng);
            //    this.chart1.Series[2].Points.AddXY(j.Name, j.Math);

            //    this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //    this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //    this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //}
            #endregion
            this.chart1.Series[0].XValueMember = "name";
            this.chart1.Series[0].YValueMembers = "chinese";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            this.chart1.Series[1].XValueMember = "name";
            this.chart1.Series[1].YValueMembers = "english";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            this.chart1.Series[2].XValueMember = "name";
            this.chart1.Series[2].YValueMembers = "math";
            this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
        }


        public string scr_level(int n)
        {
            if (n < 60)
                return "不太行";
            else if (n <= 69 && n >= 60)
                return "待加強";
            else if (n <= 89 && n >= 70)
                return "佳";
            else
                return "優良";
        }
        private void button33_Click(object sender, EventArgs e)     //要記得修改clear
        {
            // split=> 數學成績 分成 三群 '待加強'(60~69) '佳'(70~89) '優良'(90~100) 

            var q = from n in students_scores
                    group n by scr_level(n.Math) into g
                    select new
                    {
                        mykey = g.Key,
                        mycount = g.Count()
                    };

            this.dataGridView1.Columns.Clear();
            this.dataGridView1.DataSource = q.ToList();

            //this.chart1.Series.Clear();
            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].Points.Clear();
            this.chart1.Series[1].Points.Clear();

            this.chart1.Series[0].XValueMember = "";
            this.chart1.Series[0].YValueMembers = "";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

            this.chart1.Series[1].XValueMember = "";
            this.chart1.Series[1].YValueMembers = "";
            this.chart1.Series[1].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;


            this.chart1.Series[2].XValueMember = "mykey";
            this.chart1.Series[2].YValueMembers = "mycount";
            this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;



            //foreach (Student j in students_scores) {
            //    this.chart1.Series[2].Points.AddXY(j.Name, j.Math);
            //    this.chart1.Series[2].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            //}

        }

        private void Frm作業3_Load(object sender, EventArgs e)
        {
            string[] year = { "全班平均", "全班中位數", "全班最低", "全班最高" };

            foreach (var ro in year)
            {
                this.comboBox1.Items.Add(ro);
            }


            int j = students_scores.Count();
            for (int i = 0; i < students_scores.Count(); i++)
            {
                this.comboBox2.Items.Add(students_scores[i].Name);

            }
        }
    }
}
