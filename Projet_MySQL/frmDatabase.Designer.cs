namespace Projet_MySQL
{
    partial class frmDatabase
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblIsConnected = new System.Windows.Forms.Label();
            this.btnAddDb = new System.Windows.Forms.Button();
            this.txtNomTable = new System.Windows.Forms.TextBox();
            this.dgvData = new System.Windows.Forms.DataGridView();
            this.btnDeleteDb = new System.Windows.Forms.Button();
            this.lblTable = new System.Windows.Forms.Label();
            this.btnAddRow = new System.Windows.Forms.Button();
            this.btnDeleteRow = new System.Windows.Forms.Button();
            this.btnCreateTable = new System.Windows.Forms.Button();
            this.btnDeleteTable = new System.Windows.Forms.Button();
            this.btnFinaliser = new System.Windows.Forms.Button();
            this.txtNomDb = new System.Windows.Forms.TextBox();
            this.lblDB = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConnect.Location = new System.Drawing.Point(12, 12);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(167, 40);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connexion";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblIsConnected
            // 
            this.lblIsConnected.AutoSize = true;
            this.lblIsConnected.Location = new System.Drawing.Point(185, 14);
            this.lblIsConnected.Name = "lblIsConnected";
            this.lblIsConnected.Size = new System.Drawing.Size(66, 13);
            this.lblIsConnected.TabIndex = 1;
            this.lblIsConnected.Text = "Déconnecté";
            // 
            // btnAddDb
            // 
            this.btnAddDb.Location = new System.Drawing.Point(13, 58);
            this.btnAddDb.Name = "btnAddDb";
            this.btnAddDb.Size = new System.Drawing.Size(166, 40);
            this.btnAddDb.TabIndex = 2;
            this.btnAddDb.Text = "Ajouter une base de donnée";
            this.btnAddDb.UseVisualStyleBackColor = true;
            this.btnAddDb.Click += new System.EventHandler(this.btnAddDb_Click);
            // 
            // txtNomTable
            // 
            this.txtNomTable.Location = new System.Drawing.Point(813, 32);
            this.txtNomTable.Name = "txtNomTable";
            this.txtNomTable.Size = new System.Drawing.Size(283, 20);
            this.txtNomTable.TabIndex = 3;
            this.txtNomTable.TextChanged += new System.EventHandler(this.TxtNomTable_TextChanged);
            // 
            // dgvData
            // 
            this.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvData.Location = new System.Drawing.Point(813, 58);
            this.dgvData.Name = "dgvData";
            this.dgvData.Size = new System.Drawing.Size(543, 371);
            this.dgvData.TabIndex = 4;
            this.dgvData.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvData_CellValueChanged);
            // 
            // btnDeleteDb
            // 
            this.btnDeleteDb.Location = new System.Drawing.Point(13, 102);
            this.btnDeleteDb.Name = "btnDeleteDb";
            this.btnDeleteDb.Size = new System.Drawing.Size(166, 40);
            this.btnDeleteDb.TabIndex = 5;
            this.btnDeleteDb.Text = "Supprimer une base de donnée";
            this.btnDeleteDb.UseVisualStyleBackColor = true;
            this.btnDeleteDb.Click += new System.EventHandler(this.btnDeleteDb_Click);
            // 
            // lblTable
            // 
            this.lblTable.AutoSize = true;
            this.lblTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTable.Location = new System.Drawing.Point(810, 12);
            this.lblTable.Name = "lblTable";
            this.lblTable.Size = new System.Drawing.Size(107, 17);
            this.lblTable.TabIndex = 6;
            this.lblTable.Text = "Nom de la table";
            // 
            // btnAddRow
            // 
            this.btnAddRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddRow.Location = new System.Drawing.Point(813, 435);
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.Size = new System.Drawing.Size(40, 40);
            this.btnAddRow.TabIndex = 7;
            this.btnAddRow.Text = "+";
            this.btnAddRow.UseVisualStyleBackColor = true;
            this.btnAddRow.Click += new System.EventHandler(this.BtnAddRow_Click);
            // 
            // btnDeleteRow
            // 
            this.btnDeleteRow.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeleteRow.Location = new System.Drawing.Point(859, 435);
            this.btnDeleteRow.Name = "btnDeleteRow";
            this.btnDeleteRow.Size = new System.Drawing.Size(40, 40);
            this.btnDeleteRow.TabIndex = 8;
            this.btnDeleteRow.Text = "-";
            this.btnDeleteRow.UseVisualStyleBackColor = true;
            this.btnDeleteRow.Click += new System.EventHandler(this.BtnDeleteRow_Click);
            // 
            // btnCreateTable
            // 
            this.btnCreateTable.Location = new System.Drawing.Point(12, 183);
            this.btnCreateTable.Name = "btnCreateTable";
            this.btnCreateTable.Size = new System.Drawing.Size(166, 40);
            this.btnCreateTable.TabIndex = 9;
            this.btnCreateTable.Text = "Créer une table";
            this.btnCreateTable.UseVisualStyleBackColor = true;
            this.btnCreateTable.Click += new System.EventHandler(this.BtnCreateTable_Click);
            // 
            // btnDeleteTable
            // 
            this.btnDeleteTable.Location = new System.Drawing.Point(12, 227);
            this.btnDeleteTable.Name = "btnDeleteTable";
            this.btnDeleteTable.Size = new System.Drawing.Size(166, 40);
            this.btnDeleteTable.TabIndex = 10;
            this.btnDeleteTable.Text = "Supprimer une table";
            this.btnDeleteTable.UseVisualStyleBackColor = true;
            this.btnDeleteTable.Click += new System.EventHandler(this.BtnDeleteTable_Click);
            // 
            // btnFinaliser
            // 
            this.btnFinaliser.Location = new System.Drawing.Point(905, 435);
            this.btnFinaliser.Name = "btnFinaliser";
            this.btnFinaliser.Size = new System.Drawing.Size(166, 40);
            this.btnFinaliser.TabIndex = 11;
            this.btnFinaliser.Text = "Finaliser la table";
            this.btnFinaliser.UseVisualStyleBackColor = true;
            this.btnFinaliser.Click += new System.EventHandler(this.BtnFinaliser_Click);
            // 
            // txtNomDb
            // 
            this.txtNomDb.Location = new System.Drawing.Point(443, 32);
            this.txtNomDb.Name = "txtNomDb";
            this.txtNomDb.Size = new System.Drawing.Size(283, 20);
            this.txtNomDb.TabIndex = 12;
            this.txtNomDb.TextChanged += new System.EventHandler(this.TxtNomDb_TextChanged);
            // 
            // lblDB
            // 
            this.lblDB.AutoSize = true;
            this.lblDB.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDB.Location = new System.Drawing.Point(440, 12);
            this.lblDB.Name = "lblDB";
            this.lblDB.Size = new System.Drawing.Size(95, 17);
            this.lblDB.TabIndex = 13;
            this.lblDB.Text = "Nom de la DB";
            // 
            // frmDatabase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1468, 649);
            this.Controls.Add(this.lblDB);
            this.Controls.Add(this.txtNomDb);
            this.Controls.Add(this.btnFinaliser);
            this.Controls.Add(this.btnDeleteTable);
            this.Controls.Add(this.btnCreateTable);
            this.Controls.Add(this.btnDeleteRow);
            this.Controls.Add(this.btnAddRow);
            this.Controls.Add(this.lblTable);
            this.Controls.Add(this.btnDeleteDb);
            this.Controls.Add(this.dgvData);
            this.Controls.Add(this.txtNomTable);
            this.Controls.Add(this.btnAddDb);
            this.Controls.Add(this.lblIsConnected);
            this.Controls.Add(this.btnConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmDatabase";
            this.Text = "Gérer la base de donnée";
            ((System.ComponentModel.ISupportInitialize)(this.dgvData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label lblIsConnected;
        private System.Windows.Forms.Button btnAddDb;
        private System.Windows.Forms.TextBox txtNomTable;
        private System.Windows.Forms.DataGridView dgvData;
        private System.Windows.Forms.Button btnDeleteDb;
        private System.Windows.Forms.Label lblTable;
        private System.Windows.Forms.Button btnAddRow;
        private System.Windows.Forms.Button btnDeleteRow;
        private System.Windows.Forms.Button btnCreateTable;
        private System.Windows.Forms.Button btnDeleteTable;
        private System.Windows.Forms.Button btnFinaliser;
        private System.Windows.Forms.TextBox txtNomDb;
        private System.Windows.Forms.Label lblDB;
    }
}

