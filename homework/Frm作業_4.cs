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
    public partial class Frm作業_4 : Form
    {
        public Frm作業_4()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int[] nums = { 11, 27, 35, 44, 53, 68, 74, 86, 98 };

            var q = from n in nums
                    group n by grp(n) into g
                    select new { mykey = g.Key, mycount = g.Count(), myavg = g.Average(), mymax = g.Max(), mygroup = g };

            this.dataGridView1.DataSource = q.ToList();

            this.treeView1.Nodes.Clear();

            foreach (var group in q)
            {
                string s = $"{group.mykey}" +
                    $"({group.mycount})" +
                    $"({group.myavg})" +
                    $"({group.mymax})";

                TreeNode x = this.treeView1.Nodes.Add(s);

                foreach (var item in group.mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

        }

        private string grp(int n)
        {
            if (n < 60) return "不及格";
            else if (n < 80) return "普通";
            else return "不錯";
        }

        private void button38_Click(object sender, EventArgs e)
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] file = dir.GetFiles();

            var q = from f in file
                    group f by f.Length > 10000 ? "大檔案" : "小檔案" into g
                    select new { mykey = g.Key, mycount = g.Count(), mygroup = g };

            this.dataGridView1.DataSource = q.ToList();

            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                string s = $"{group.mykey} ( {group.mycount} )";
                TreeNode x = this.treeView1.Nodes.Add(s);// group.MyKey.ToString());

                foreach (var item in group.mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)      //想試試依照不同年份分群
        {
            System.IO.DirectoryInfo dir = new System.IO.DirectoryInfo(@"c:\windows");

            System.IO.FileInfo[] file = dir.GetFiles();

            var q = from f in file
                    group f by f.CreationTime.Year < 2020 ? "舊檔案" : "新檔案" into g
                    //select f;
                    select new { mykey = g.Key, mycount = g.Count(), mygroup = g };

            this.dataGridView1.DataSource = q.ToList();

            this.treeView1.Nodes.Clear();
            foreach (var group in q)
            {
                string s = $"{group.mykey} ( {group.mycount} )";
                TreeNode x = this.treeView1.Nodes.Add(s);// group.MyKey.ToString());

                foreach (var item in group.mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }
        }

        NorthwindEntities dbContext = new NorthwindEntities();
        private void button8_Click(object sender, EventArgs e)
        {

            var q = from p in dbContext.Products.AsEnumerable()
                    group p by price(p.UnitPrice) into g
                    select new
                    {
                        mykey = g.Key,
                        mycount = g.Count(),
                        myavg = g.Average(p => p.UnitPrice),
                        mymax = g.Max(p => p.UnitPrice),
                        mymin = g.Min(p => p.UnitPrice),
                        mygroup = g
                    };


            this.dataGridView1.DataSource = q.ToList();


            this.treeView1.Nodes.Clear();

            foreach (var group in q)
            {
                string s = $"{group.mykey}" +
                    $"({group.mycount})" +
                    $"({group.myavg})" +
                    $"({group.mymax})";

                TreeNode x = this.treeView1.Nodes.Add(s);

                foreach (var item in group.mygroup)
                {
                    x.Nodes.Add(item.ProductName.ToString());
                }
            }
        }

        public string price(decimal? n)
        {
            if (n < 60) return "低";
            else if (n < 80) return "中";
            else return "高";
        }

        private void Frm作業_4_Load(object sender, EventArgs e)
        {
            //dbContext.Database.Log = Console.WriteLine;
        }

        private void button10_Click(object sender, EventArgs e)     //訂單group by 年月
        {
            //var q = from p in dbContext.Orders
            //        group p by (p.OrderDate.Value.Year,p.OrderDate.Value.Month) into g
            //        select new { mykey = g.Key, mycount = g.Count(), mygroup = g };


            var q = dbContext.Orders.GroupBy(x => new { x.OrderDate.Value.Year, x.OrderDate.Value.Month })
                    .Select(g => new { mykey = g.Key, count = g.Count(), mygroup = g })
                    .OrderBy(y => y.mykey.Year)
                    .ThenBy(y => y.mykey.Month);


            this.dataGridView1.DataSource = q.ToList();


            this.treeView1.Nodes.Clear();

            foreach (var group in q)
            {
                string s = $"{group.mykey}";

                TreeNode x = this.treeView1.Nodes.Add(s);

                foreach (var item in group.mygroup)
                {
                    x.Nodes.Add(item.ToString());
                }
            }

            //var a = from r in q
            //        group r by 
        }

        private void button15_Click(object sender, EventArgs e)   //訂單group by 年
        {
            var q = from p in dbContext.Orders
                    group p by p.OrderDate.Value.Year into g
                    select new { mykey = g.Key, mycount = g.Count(), mygroup = g };

            this.dataGridView1.DataSource = q.ToList();


            this.treeView1.Nodes.Clear();

            foreach (var group in q)
            {
                string s = $"{group.mykey} ( {group.mycount} )";
                TreeNode x = this.treeView1.Nodes.Add(s);// group.MyKey.ToString());

                foreach (var item in group.mygroup)
                {
                    x.Nodes.Add(item.OrderID.ToString());
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)      //總銷售額
        {
            var q = from p in dbContext.Order_Details.AsEnumerable()
                    group p by p.OrderID into g
                    select new
                    {
                        g.Key,
                        sum = g.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount))
                    };


            // var q = from p in dbContext.Order_Details.AsEnumerable()
            // select new { p.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount)) };

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button1_Click(object sender, EventArgs e)      //銷售最好前五名員工
        {
            //var q = (from p in dbContext.Orders
            //         select p.EmployeeID).Distinct();

            var q = (from p in dbContext.Order_Details.AsEnumerable()
                     group p by p.Order.EmployeeID into g
                     orderby g.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount)) descending
                     select new
                     {
                         mykey = g.Key,
                         count = g.Count(),
                         max = g.Max(p => p.UnitPrice),
                         sum = g.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount))
                     }).Take(5);


            //select p.EmployeeID

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button9_Click(object sender, EventArgs e)  //產品最高單價 前五比 含類別名稱
        {
            var q = (from p in dbContext.Products
                     orderby p.UnitPrice descending
                     select new
                     {
                         unit_price = p.UnitPrice,
                         cate_id = p.CategoryID,
                         product_name = p.ProductName,
                         category_name = p.Category.CategoryName

                     }).Take(5);

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button3_Click(object sender, EventArgs e)  //有任何一筆單價大於300
        {
            var q = from p in dbContext.Products
                    where p.UnitPrice > 50
                    select new
                    {
                        product_name = p.ProductName,
                        product_id = p.ProductID
                    };

            this.dataGridView1.DataSource = q.ToList();
        }

        private void button34_Click(object sender, EventArgs e)     //分析 項目
                                                                    //單一訂單加總   單一員工銷量
                                                                    //每年的 最大 最小 平均 數量
        {


            var q = from p in dbContext.Order_Details
                    group p by p.Order.OrderDate.Value.Year into g
                    select new
                    {
                        key = g.Key,
                        sum = g.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount))
                    };


            this.dataGridView1.DataSource = q.ToList();


            this.chart1.DataSource = q.ToList();
            this.chart1.Series[0].XValueMember = "key";
            this.chart1.Series[0].YValueMembers = "sum";
            this.chart1.Series[0].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            //for (int i = 0; i < 3; i++)
            //{
            //    th
            //    //this.chart1.Series[i].XValueMember = "key";
            //    //this.chart1.Series[i].YValueMembers = "sum";
            //    this.chart1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;

            //}

        }

        private void button5_Click(object sender, EventArgs e)      //成長率
        {
            var q = from p in dbContext.Order_Details

                    group p by p.Order.OrderDate.Value.Year into g
                    //orderby p.Order.OrderDate.Value.Year descending
                    select new
                    {
                        key = g.Key,
                        sum = g.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount))
                    };

            this.dataGridView1.DataSource = q.ToList();

            var q1 = from p in dbContext.Order_Details
                     group p by p.Order.OrderDate.Value.Year into g
                     select new
                     {
                         key = (g.Key + 1),
                         sum = g.Sum(p => (float)p.UnitPrice * p.Quantity * (1 - p.Discount))
                     };

            //this.dataGridView2.DataSource = q1.ToList();


            //var dif = from a in q
            //          join b in q1
            //          on a.key equals b.key into g
            //          select new
            //          {
            //             key = g,
            //             sum = g.Sum()
            //          };

            //this.dataGridView2.DataSource = q1.ToList();

        }
    }
}
