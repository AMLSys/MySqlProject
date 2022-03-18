using System;
using System.Windows.Forms;
using Projet_MySQL.Errors;
using Projet_MySQL.Database;
using Projet_MySQL.Ressources;
using System.Resources;

namespace Projet_MySQL
{
    public partial class frmDatabase : Form
    {
        private dbMethods dbMethods = new dbMethods();

        public frmDatabase()
        {
            InitializeComponent();

            dbMethods.rm = new ResourceManager(typeof(isNotConn));
        }

        /// <summary>
        /// Connect the user to the mysql database
        /// <!--TODO-->
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtNomDb.Text))
            {
                dbMethods.CreateAConnection(txtNomDb.Text);
            }else
            {
                dbMethods.CreateAConnection();
            }

            if (dbMethods.isConnected == true)
            {
                dbMethods.rm = new ResourceManager(typeof(isNotConn));
                dbMethods.UpdateFormLabels(this);

                dbMethods.isConnected = false;

                dbMethods.myConnection.Close();
            }
            else if (dbMethods.isConnected == false)
            {
                try
                {
                    dbMethods.myConnection.Open();

                    dbMethods.rm = new ResourceManager(typeof(isConn));
                    dbMethods.UpdateFormLabels(this);
                    lblIsConnected.Text += " " + dbMethods.myConnection.Database;
                    dbMethods.isConnected = true;
                }
                catch (Exception)
                {
                    dbErrors.CreateErrorMessage("La db à la quelle vous essayez de vous connecter n'existe pas !!!");
                }
            }
        }

        /// <summary>
        /// Create a new database
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void btnAddDb_Click(object sender, EventArgs e)
        {
            if (dbMethods.isConnected == true)
            {
                //Try if the name of the database is not empty
                if (txtNomDb.Text != string.Empty)
                {
                    //Try if the database exist
                    try
                    {
                        dbMethods.CreateACommand($"CREATE DATABASE if not exists {txtNomDb.Text}");
                        dbMethods.CreateACommand($"ALTER DATABASE {txtNomDb.Text} CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci;");
                    }
                    catch (Exception) 
                     {
                        dbErrors.CreateErrorMessage("La base de donnée que vous essaiez de créer existe déjà !");
                    }; 
                }
                else
                {
                    dbErrors.ShowEmpty();
                }
            }
            else
            {
                dbErrors.ShowConnected();
            }
        }

        /// <summary>
        /// Delete an entire database
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void btnDeleteDb_Click(object sender, EventArgs e)
        {
            if (dbMethods.isConnected == true )
            {
                if (txtNomDb.Text != string.Empty)
                {
                        try
                        {
                            DialogResult result = MessageBox.Show($"Voulez vous vraiment supprimer la database {txtNomDb.Text} ?", "Alterte", MessageBoxButtons.YesNo);
                            if (result == DialogResult.Yes)
                            {
                                dbMethods.CreateACommand($"drop database if exists {txtNomDb.Text}");

                                MessageBox.Show($"Vous avez bien supprimé la database {txtNomTable.Text} !", "Confirmation");
                            }
                        }
                        catch (Exception) 
                        {
                            dbErrors.CreateErrorMessage("La base de donnée que vous essaiez de supprimer n'existe pas !");
                        };
                }
                else
                {
                    dbErrors.ShowEmpty();
                }
            }
            else
            {
                dbErrors.ShowConnected();
            }
        }


        /// <summary>
        /// Add a row in the data view
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">E</param>
        private void BtnAddRow_Click(object sender, EventArgs e)
        {
            try
            {
                dgvData.Rows.Add(1);
            }
            catch (Exception)
            {
                MessageBox.Show("", "");
            }
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
            if (dbMethods.isConnected == true)
            {
                dgvData.Columns.AddRange(dbMethods.CreateATable());
            }
            else
            {
                dbErrors.ShowConnected();
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
            dbMethods.myTable = "";

            //Try if the user is connected to a database
            if (dbMethods.isConnected == true)
            {
                //Convert the database charset into utf8mb4
                dbMethods.CreateACommand($"ALTER DATABASE {txtNomDb.Text} CHARACTER SET = utf8mb4 COLLATE = utf8mb4_unicode_ci;");

                //Start the creation of the table request
                dbMethods.myTable += $"USE {txtNomDb.Text};\n";
                dbMethods.myTable += $"DROP TABLE IF EXISTS `{txtNomTable.Text}`;\n";
                dbMethods.myTable += $"CREATE TABLE `{txtNomTable.Text}` (\n";

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
                                    dbMethods.myTable += $" AUTO_INCREMENT";
                                    dbMethods.myPrimaryKey = $"CONSTRAINT ID_{txtNomTable.Text}_ID PRIMARY KEY (`{dbMethods.myPrimaryKeyName}`)";
                                }
                                //IF a null checkbox is checked
                                else if (cellType.Equals(typeof(bool)) && cell.ColumnIndex == 3 && (bool)cell.Value == false)
                                {
                                    dbMethods.myTable += $" NOT NULL";
                                }
                                //The others
                                else if (cell.ColumnIndex == 0)
                                {
                                    dbMethods.myTable += $"`{cell.Value}` ";
                                    dbMethods.myPrimaryKeyName = (string)cell.Value;
                                }
                                else if (cell.ColumnIndex == 1)
                                {
                                    dbMethods.myTable += $"{cell.Value}";
                                }
                                else if (cell.ColumnIndex == 2)
                                {
                                    dbMethods.myTable += $"({cell.Value})";
                                }
                            }
                            catch (NullReferenceException) { };
                        }

                    if (row != dgvData.Rows[dgvData.RowCount - 1])
                    {
                        dbMethods.myTable += ",\n";
                    }
                        
                }

                dbMethods.myTable += $"{dbMethods.myPrimaryKey}\n";
                dbMethods.myTable += $") ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;";
                Console.WriteLine(dbMethods.myTable);
            }

            //Show the result of the request in sql "style"
            MessageBox.Show(dbMethods.myTable);

            dbMethods.CreateACommand(dbMethods.myTable);
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

        /// <summary>
        /// Delete a table in a database
        /// </summary>
        /// <param name="sender">Sender</param>
        /// <param name="e">e</param>
        private void BtnDeleteTable_Click(object sender, EventArgs e)
        {
            if (dbMethods.isConnected == true)
            {
                try
                {
                    DialogResult result = MessageBox.Show($"Voulez vous vraiment supprimer la table {txtNomTable.Text} ?", "Alterte", MessageBoxButtons.YesNo);
                    if (Convert.ToBoolean(DialogResult.Yes) == true)
                    {
                        dbMethods.CreateACommand($"USE {txtNomDb.Text}; DROP TABLE IF EXISTS {txtNomTable.Text};");

                        MessageBox.Show($"Vous avez bien supprimé la table {txtNomTable.Text} !", "Confirmation");
                    }
                    else { }

                }
                catch (Exception)
                {
                    dbErrors.CreateErrorMessage("La base de donnée que vous essayez de supprimer n'existe pas !!!");
                }
            }
        }
    }
}
