using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Data.OleDb;
using System.Configuration;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //Global Variables:
        private OleDbConnection con = new OleDbConnection();
        private DateTime date = DateTime.Now;
        
        public MainWindow()
        {
            InitializeComponent();
            con.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            loadCombobox();
        }

        /*
         * THIS METHOD WILL LOAD ALL THE NAMES ON THE COMBOBOX.
         */
        private void loadCombobox()
        {
            //con.ConnectionString = ConfigurationManager.ConnectionStrings["Connection"].ToString();
            try
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "SELECT * FROM Elist";// This will create a query for our first name 
                command.CommandText = query; // .CommandText is like getter and setters. It will receive and the values from query and set it to command.
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FName.Items.Add(reader["FName"].ToString());
                    LName.Items.Add(reader["LName"].ToString());
                }// while
                // We wont be using .ExecuteNonQuery(), be thats only used the update, selection or delete.
                con.Close();
            } //Try
            catch (Exception exception)
            {
                MessageBox.Show("Error" + exception);
            }//Catches the exception
        }// END OF LOADCOMBOBOX
        private void FName_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           /* try 
            {
                con.Open();
                OleDbCommand command = new OleDbCommand();
                command.Connection = con;
                string query = "select FName from Elist";// This will create a query for our first name 
                command.CommandText = query; // .CommandText is like getter and setters. It will receive and the values from query and set it to command.
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    FName.Items.Add(reader[0].ToString());
                }// while
                // We wont be using .ExecuteNonQuery(), be thats only used the update, selection or delete.
                con.Close();
            } //Try
            catch (Exception exception) 
            {
                MessageBox.Show("Error"+exception);
            }//Catches the exception*/
        }
    }
}
