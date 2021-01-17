using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Employees
{
    public partial class frmEmployee : Form
    {
        private DataSet dataSet = new DataSet();
        System.Data.DataTable table = new DataTable("EmployeeTable");
        DataColumn column;
        DataRow row;
        

        public frmEmployee()
        {
            InitializeComponent();
            CreateEmployeeTable();
            BindData();
        }
        public void CreateEmployeeTable()
        {


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.Int32");
            column.ColumnName = "id";
            column.ReadOnly = true;
            column.Unique = true;
            // Add the Column to the DataColumnCollection.
            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "First_name";
            column.AutoIncrement = false;
            column.Caption = "First_name";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Last_name";
            column.AutoIncrement = false;
            column.Caption = "Last_name";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Dept";
            column.AutoIncrement = false;
            column.Caption = "Dept";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);


            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Bdate";
            column.AutoIncrement = false;
            column.Caption = "Bdate";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            column = new DataColumn();
            column.DataType = System.Type.GetType("System.String");
            column.ColumnName = "Address";
            column.AutoIncrement = false;
            column.Caption = "Address";
            column.ReadOnly = false;
            column.Unique = false;
            table.Columns.Add(column);

            // Make the ID column the primary key column.
            DataColumn[] PrimaryKeyColumns = new DataColumn[1];
            PrimaryKeyColumns[0] = table.Columns["id"];
            table.PrimaryKey = PrimaryKeyColumns;
            dataSet.Tables.Add(table);
        }

        public void BindData() {

            dataGridView1.DataSource = table ;

        }




        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

            
        }



        private void button4_Click(object sender, EventArgs e)
        {
            string name = search.Text;
            
            var results = table.AsEnumerable()
            .Where(row => !String.IsNullOrWhiteSpace(search.Text) && row.Field<String>("First_name").Contains(search.Text.Trim()));
            table = results.CopyToDataTable();
            dataGridView2.DataSource = table;
            search.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {

            // Add the new DataTable to the DataSet.
            
            
            row = table.NewRow();
            row["id"] =     textBox1.Text;
            row["First_name"] = textBox2.Text;
            row["Last_name"] =  textBox3.Text;
            row["Address"] =    textBox4.Text;
            row["Dept"] =   deptComboBox.SelectedValue;
            row["Bdate"] = dateTimePicker1.Value;
            table.Rows.Add(row);
            foreach (TextBox txtbar in Controls.OfType<TextBox>())
            {
                txtbar.Text = "";
            }


        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
    