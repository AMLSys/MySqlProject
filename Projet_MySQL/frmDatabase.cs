using System;
using System.Data;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace Projet_MySQL
{
    public partial class frmDatabase : Form
    {
        string MyConnectionString = "Server=localhost;Uid=root;Pwd=root;Database=mysql;Charset=latin1";
        public bool isConnected = false;
        MySqlConnection myConnection;
        string myTable;

        public frmDatabase()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Connect the user to the mysql database
        /// <!--TODO-->
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            myConnection = new MySqlConnection(MyConnectionString);

            if (isConnected == true)
            {
                myConnection.Close();
                btnConnect.Text = "Connexion";
                lblIsConnected.Text = "Déconnecté";
                Console.WriteLine("Déconnecté");
                isConnected = false;
            }
            else if (isConnected == false)
            {
                myConnection.Open();
                btnConnect.Text = "Déconnexion";
                lblIsConnected.Text = $"Connecté à {myConnection.Database}";
                Console.WriteLine("Connecté");
                isConnected = true;
            }
        }

        /// <summary>
        /// Create a new database
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void btnAddDb_Click(object sender, EventArgs e)
        {
            if (isConnected == true)
            {
                //Try if the name of the database is not empty
                if (txtNomDb.Text != string.Empty)
                {
                    //Try if the database exist
                    try
                    {
                            MySqlCommand myCmd = myConnection.CreateCommand();
                            myCmd.CommandText = $"CREATE DATABASE if not exists {txtNomDb.Text}";
                            MySqlDataAdapter myAdaptater = new MySqlDataAdapter(myCmd);
                            DataSet myDataSet = new DataSet();
                            myAdaptater.Fill(myDataSet);
                            //dgvData.DataSource = myDataSet.Tables[0].DefaultView;
                    }
                    catch (Exception) 
                     {
                            MessageBox.Show("La base de donnée que vous essaiez de créer existe déjà !", "My_SQL Error");
                    }; 
                }
                else
                {
                    ShowEmpty();
                }
            }
            else
            {
                ShowConnected();
            }
        }

        /// <summary>
        /// Delete an entire database
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void btnDeleteDb_Click(object sender, EventArgs e)
        {
            if (isConnected == true )
            {
                if (txtNomDb.Text != string.Empty)
                {
                        try
                        {
                            MySqlCommand myCmd = myConnection.CreateCommand();
                            myCmd.CommandText = $"drop database if exists {txtNomDb.Text}";
                            MySqlDataAdapter myAdaptater = new MySqlDataAdapter(myCmd);
                            DataSet myDataSet = new DataSet();
                            myAdaptater.Fill(myDataSet);
                        }
                        catch (Exception) 
                        {
                            MessageBox.Show("La base de donnée que vous essaiez de supprimer n'existe pas !", "My_SQL Error");
                        };
                }
                else
                {
                    ShowEmpty();
                }
            }
            else
            {
                ShowConnected();
            }
        }

        /// <summary>
        /// Show if a field is empty
        /// Temporary Method
        /// </summary>
        private void ShowEmpty()
        {
            MessageBox.Show("Veuillez remplir le champ du nom de la base de donnée !", "My_SQL Error");
        }

        /// <summary>
        /// Show if the user is not connected
        /// Temporary Method
        /// </summary>
        private void ShowConnected()
        {
            MessageBox.Show("Veuillez vous connecter au SGBD !", "My_SQL Error");
        }

        /// <summary>
        /// Add a row in the data view
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            dgvData.Rows.Add(1);
        }

        /// <summary>
        /// Delete a row in the data view
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void BtnDeleteRow_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in dgvData.SelectedRows)
            {
                dgvData.Rows.RemoveAt(item.Index);
            }
        }

        /// <summary>
        /// Create a new data view
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void BtnCreateTable_Click(object sender, EventArgs e)
        {
            //Clear
            dgvData.Columns.Clear();
            dgvData.Refresh();

            //Create all the columns with name and inputs in them
            if (isConnected == true)
            {
                DataGridViewColumn dc_Nom = new DataGridViewTextBoxColumn();
                DataGridViewColumn dc_Type = new DataGridViewComboBoxColumn();
                DataGridViewColumn dc_TailleVal = new DataGridViewTextBoxColumn();
                DataGridViewColumn dc_IsNull = new DataGridViewCheckBoxColumn();
                DataGridViewColumn dc_IsPrimaryKey = new DataGridViewCheckBoxColumn();
                DataGridViewColumn dc_Comment = new DataGridViewTextBoxColumn();

                dc_Nom.HeaderText = "Nom";
                dc_Type.HeaderText = "Type";
                dc_TailleVal.HeaderText = "Taille/Valeurs";
                dc_IsNull.HeaderText = "Null ?";
                dc_IsPrimaryKey.HeaderText = "PrimaryKey ?";
                dc_Comment.HeaderText = "Commentaire";


                DataGridViewComboBoxCell myComboCell = new DataGridViewComboBoxCell();
                myComboCell.Items.AddRange("INT", "CHAR", "STRING", "DECIMAL", "DATE", "VARCHAR", "BOOLEAN", "FLOAT", "DATETIME");
                dc_Type.CellTemplate = myComboCell;

                dgvData.Columns.AddRange(dc_Nom, dc_Type, dc_TailleVal, dc_IsNull, dc_IsPrimaryKey, dc_Comment);
            }
            else
            {
                ShowConnected();
            }
            
        }

        /// <summary>
        /// <<!--TODO-->
        /// Finalise the creation of the table
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void BtnFinaliser_Click(object sender, EventArgs e)
        {
            //Make the table string empty
            myTable = "";

            //Try if the user is connected to a database
            if (isConnected == true)
            {
                /*MySqlCommand myCmd = myConnection.CreateCommand();
                myCmd.CommandText = $"drop database if exists {txtNomDb.Text}";
                myCmd.CommandText = $"CREATE TABLE IF NOT EXISTS {txtNomDb.Text}";*/

                //Start the creation of the table request
                myTable += $"CREATE TABLE IF NOT EXISTS {txtNomDb.Text}(";

                //Reach the rows of the data view
                foreach (DataGridViewRow row in dgvData.Rows)
                {
                    //Reach the cells in the rows
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        try
                        {
                            Type cellType = cell.Value.GetType();

                            //If a "ID" checkbox is checked
                            if (cellType.Equals(typeof(bool)) && cell.ColumnIndex == 4 && (bool)cell.Value == true)
                            {
                                myTable += $"AUTO_INCREMENT";
                            }
                            //IF a null checkbox is checked
                            else if (cellType.Equals(typeof(bool)) && cell.ColumnIndex == 3 && (bool)cell.Value == true)
                            {
                                myTable += $"NOT NULL";
                            }
                            //The others
                            else
                            {
                                myTable += $"{cell.Value} ";
                            }
                        }
                        catch (Exception) { };
                                            }
                    myTable += "\n";
                }
            }

            //Show the result of the request in sql "style"
            MessageBox.Show(myTable);
        }

        /// <summary>
        /// Let the primary checkbox being checked only one time in a column
        /// Taked on StackOverflow : https://stackoverflow.com/questions/35350584/allow-only-one-checkbox-selected-in-datagridview
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void DgvData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            var columnIndex = 4;
            if (e.ColumnIndex == columnIndex)
            {
                var isChecked = (bool)dgvData.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                if (isChecked)
                {
                    foreach (DataGridViewRow row in dgvData.Rows)
                    {
                        if (row.Index != e.RowIndex)
                        {
                            row.Cells[columnIndex].Value = !isChecked;
                        }
                    }
                }
            }
        }
    }
}
