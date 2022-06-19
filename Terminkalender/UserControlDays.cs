using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Terminkalender
{
    public partial class UserControlDays : UserControl
    {
        //create another static variable for day
        public static string static_day;
        //create a connectionstring
        String connString = "server=localhost;user id=root;database=db_calendar;sslmode=none";


        public UserControlDays()
        {
            InitializeComponent();
        }

        private void UserControlDays_Load(object sender, EventArgs e)
        {

        }

        public void days(int numday)
        {
            lbdays.Text = numday + "";
        }

        private void UserControlDays_Click(object sender, EventArgs e)
        {
            static_day = lbdays.Text;
            //start timer if user controldays is clicked
            timer1.Start();
            EventForm eventform = new EventForm();
            eventform.Show();
        }


        //Create new methode to display event
        private void displayEvent()
        {
            MySqlConnection conn = new MySqlConnection(connString);
            conn.Open();
            String sql = "SELECT * FROM tbl_calendar where date = ?";
            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            cmd.Parameters.AddWithValue("date", FrmMain.static_month + "." + FrmMain.static_year + "." + lbdays.Text);
            MySqlDataReader reader = cmd.ExecuteReader();
            if(reader.Read())
            {
                lbevent.Text = reader["event"].ToString();

            }
            reader.Dispose();
            cmd.Dispose();
            conn.Close();
        }

        //create a timer for auto display event if new event is added
        private void timer1_Tick(object sender, EventArgs e)
        {
            //call displayEvent method
            displayEvent();

        }


    }
}
