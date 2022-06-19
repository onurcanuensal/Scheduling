using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Terminkalender
{
    public partial class EventForm : Form
    {
        //create a connectionstring
        String connString = "server=localhost;user id=root;database=db_calendar;sslmode=none";
        //creating database with xampp


        public EventForm()
        {
            InitializeComponent();
        }

        private void EventForm_Load(object sender, EventArgs e)
        {
            //call static variable
            txtdate.Text = UserControlDays.static_day+"."+ FrmMain.static_month+"."+FrmMain.static_year;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            string sql = "INSERT INTO tbl_calndar(date,time,event)values(?,?,?)";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", txtdate.Text);
            cmd.Parameters.AddWithValue("time", txttime.Text);
            cmd.Parameters.AddWithValue("event", txtevent.Text);
            cmd.ExecuteNonQuery();
            MessageBox.Show("Gespeichert");
            cmd.Dispose();
            conn.Close();

        }
    }
}
