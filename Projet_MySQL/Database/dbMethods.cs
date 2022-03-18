using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Resources;
using System.Windows.Forms;

namespace Projet_MySQL.Database
{
    /// <summary>
    /// All methods class
    /// </summary>
    public class dbMethods
    {
        //Variables used in all the program
        public bool isConnected = false, canCreate = false;
        public MySqlConnection myConnection = new MySqlConnection();
        public string myTable, myPrimaryKey, myPrimaryKeyName, myConnectionString;
        public int myNbLine = 0;
        public ResourceManager rm;


        /// <summary>
        /// Create a new table in the database
        /// With a name, a type a value size, is the value null, a primary key and a comment
        /// </summary>
        /// <returns>Return the data grid view, then show it on the main form</returns>
        public DataGridViewColumn[] CreateATable()
        {
            //Create all columns
            DataGridViewColumn dc_Nom = new DataGridViewTextBoxColumn();
            DataGridViewColumn dc_Type = new DataGridViewComboBoxColumn();
            DataGridViewColumn dc_TailleVal = new DataGridViewComboBoxColumn();
            DataGridViewColumn dc_IsNull = new DataGridViewCheckBoxColumn();
            DataGridViewColumn dc_IsPrimaryKey = new DataGridViewCheckBoxColumn();

            //Change the header text
            dc_Nom.HeaderText = "Nom";
            dc_Type.HeaderText = "Type";
            dc_TailleVal.HeaderText = "Taille/Valeurs";
            dc_IsNull.HeaderText = "Null ?";
            dc_IsPrimaryKey.HeaderText = "PrimaryKey ?";

            //Fill the type cell with sql types
            DataGridViewComboBoxCell myComboCell = new DataGridViewComboBoxCell();
            myComboCell.Items.AddRange("INT", "CHAR", "VARCHAR", "DECIMAL", "DATE", "BOOLEAN", "FLOAT", "DATETIME");
            dc_Type.CellTemplate = myComboCell;

            //Convert the size value into an int
            dc_TailleVal.ValueType = typeof(int);

            //Fill the value combo cell with number between 0 and 255
            DataGridViewComboBoxCell myValComboCell = new DataGridViewComboBoxCell();
            for (int i = 0; i <= 255; i++)
            {
                myValComboCell.Items.Add(i);
            }
            dc_TailleVal.CellTemplate = myValComboCell;

            //Add all the values into an array
            DataGridViewColumn[] myCreatedTable = { dc_Nom, dc_Type, dc_TailleVal, dc_IsNull, dc_IsPrimaryKey};

            //Return the data grid view column array
            return myCreatedTable;
        }

        /// <summary>
        /// Create a command
        /// Catch the errors and show an errors message
        /// </summary>
        /// <param name="command">The sql command to execute</param>
        public void CreateACommand(string command)
        {
            MySqlCommand myCmd = myConnection.CreateCommand();
            myCmd.CommandText = command;
            MySqlDataAdapter myAdaptater = new MySqlDataAdapter(myCmd);
            DataSet myDataSet = new DataSet();

            try
            {
                myAdaptater.Fill(myDataSet);
            }catch (Exception)
            {
            }
        }

        /// <summary>
        /// Disable all buttons except the "btnConnect" button
        /// </summary>
        /// <param name="myForm">The form the all the buttons are</param>
        public void Disconnect(Form myForm)
        {
            //Find all the controls in the form
            foreach (Control aControl in myForm.Controls)
            {
                //Descactivate all the buttons
                if (aControl.Name.StartsWith("btn") && aControl.Name != "btnConnect")
                    aControl.Enabled = false;
            }
        }

        /// <summary>
        /// Update the labels in a form
        /// </summary>
        /// <param name="myForm"></param>
        public void UpdateFormLabels(Form myForm)
        {
            foreach (Control aControl in myForm.Controls)
            {
                if (aControl.Name == "btnConnect" || aControl.Name == "lblIsConnected")
                    aControl.Text = rm.GetString(aControl.Name);
            }
        }

        /// <summary>
        /// Create a connection to the mysql database
        /// </summary>
        public void CreateAConnection()
        {
            myConnectionString = "Server=localhost;Uid=root;Pwd=root;Database=mysql;Charset=latin1";
            myConnection = new MySqlConnection(myConnectionString);
        }

        /// <summary>
        /// Create a connection to a 'custom' database
        /// </summary>
        /// <param name="connectionString">The name of the database</param>
        public void CreateAConnection(string connectionString)
        {
            myConnectionString = $"Server=localhost;Uid=root;Pwd=root;Database={connectionString};Charset=latin1";
            myConnection = new MySqlConnection(myConnectionString);
        }
    }
}
