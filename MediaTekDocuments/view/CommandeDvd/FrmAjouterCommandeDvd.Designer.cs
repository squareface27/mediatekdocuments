
namespace MediaTekDocuments.view.CommandeDvd
{
    partial class FrmAjouterCommandeDvd
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePickerDateCommande = new System.Windows.Forms.DateTimePicker();
            this.txtMontant = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNbExemplaire = new System.Windows.Forms.TextBox();
            this.btnValidation = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // dateTimePickerDateCommande
            // 
            this.dateTimePickerDateCommande.CustomFormat = "";
            this.dateTimePickerDateCommande.Location = new System.Drawing.Point(283, 242);
            this.dateTimePickerDateCommande.Name = "dateTimePickerDateCommande";
            this.dateTimePickerDateCommande.Size = new System.Drawing.Size(200, 20);
            this.dateTimePickerDateCommande.TabIndex = 12;
            this.dateTimePickerDateCommande.Value = new System.DateTime(2024, 3, 15, 0, 0, 0, 0);
            // 
            // txtMontant
            // 
            this.txtMontant.Location = new System.Drawing.Point(283, 188);
            this.txtMontant.Name = "txtMontant";
            this.txtMontant.Size = new System.Drawing.Size(199, 20);
            this.txtMontant.TabIndex = 11;
            this.txtMontant.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(240, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(278, 25);
            this.label1.TabIndex = 10;
            this.label1.Text = "Ajouter une commande de dvd";
            // 
            // txtNbExemplaire
            // 
            this.txtNbExemplaire.Location = new System.Drawing.Point(283, 137);
            this.txtNbExemplaire.Name = "txtNbExemplaire";
            this.txtNbExemplaire.Size = new System.Drawing.Size(199, 20);
            this.txtNbExemplaire.TabIndex = 9;
            this.txtNbExemplaire.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnValidation
            // 
            this.btnValidation.Location = new System.Drawing.Point(603, 346);
            this.btnValidation.Name = "btnValidation";
            this.btnValidation.Size = new System.Drawing.Size(87, 23);
            this.btnValidation.TabIndex = 8;
            this.btnValidation.Text = "Valider";
            this.btnValidation.UseVisualStyleBackColor = true;
            this.btnValidation.Click += new System.EventHandler(this.btnValidation_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(110, 346);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(87, 23);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "Annuler";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // FrmAjouterCommandeDvd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateTimePickerDateCommande);
            this.Controls.Add(this.txtMontant);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtNbExemplaire);
            this.Controls.Add(this.btnValidation);
            this.Controls.Add(this.btnCancel);
            this.Name = "FrmAjouterCommandeDvd";
            this.Text = "FrmAjouterCommandeDvd";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePickerDateCommande;
        private System.Windows.Forms.TextBox txtMontant;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNbExemplaire;
        private System.Windows.Forms.Button btnValidation;
        private System.Windows.Forms.Button btnCancel;
    }
}