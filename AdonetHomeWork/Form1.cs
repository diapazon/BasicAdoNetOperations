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

namespace AdonetHomeWork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddTeacher_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\toshiba\documents\visual studio 2017\Projects\AdonetHomeWork\AdonetHomeWork\Data\ManagmentData.mdf;Integrated Security=True";
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var teacherName = textBox3.Text;
            var insertQuery = "INSERT INTO Teachers(name) VALUES('"+ teacherName + "')";
            var insertCommand = new SqlCommand(insertQuery,connect);
            insertCommand.ExecuteNonQuery();
            connect.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'managmentDataDataSet1.Classes' table. You can move, or remove it, as needed.
            this.classesTableAdapter.Fill(this.managmentDataDataSet1.Classes);
            // TODO: This line of code loads data into the 'managmentDataDataSet.Teachers' table. You can move, or remove it, as needed.
            this.teachersTableAdapter.Fill(this.managmentDataDataSet.Teachers);

        }

        private void AddClasses_Click(object sender, EventArgs e)
        {
            var connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=c:\users\toshiba\documents\visual studio 2017\Projects\AdonetHomeWork\AdonetHomeWork\Data\ManagmentData.mdf;Integrated Security=True";
            var connect = new SqlConnection(connectionString);
            connect.Open();
            var className = textBox1.Text;
            var studentCount = textBox2.Text;
            var teacherId = comboBox1.Text;
            var insertQuery = "INSERT INTO Classes(Name, StudentCount,TeacherId) VALUES('" + className + "','" + studentCount + "',(select Id from Teachers where name ='" + teacherId + "'))";
            var insertCommand = new SqlCommand(insertQuery, connect);
            insertCommand.ExecuteNonQuery();
            connect.Close();
        }
    }
}
