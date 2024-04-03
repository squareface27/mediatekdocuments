using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MediaTekDocuments.view;
using MediaTekDocuments.controller;

namespace MediaTekDocuments.view
{
  
    public partial class FrmLogin : Form
    {
        private readonly FrmMediatekController controller;
        private Dictionary<TextBox, string> textBoxPlaceholders = new Dictionary<TextBox, string>();
        public FrmLogin()
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
            InitializePlaceholder();
            textBoxPassword.PasswordChar = '*';
        }

        #region PlaceHolder
        private void InitializePlaceholder()
        {
            textBoxPlaceholders.Add(textBoxUsername, "Nom d'utilisateur");
            textBoxPlaceholders.Add(textBoxPassword, "Mot de passe");

            foreach (var pair in textBoxPlaceholders)
            {
                pair.Key.Enter += (sender, e) => RemovePlaceholder((TextBox)sender);
                pair.Key.Leave += (sender, e) => SetPlaceholder((TextBox)sender);
            }

            foreach (var textBox in textBoxPlaceholders.Keys)
            {
                SetPlaceholder(textBox);
            }
        }

        private void SetPlaceholder(TextBox textBox)
        {
            if (textBox != null && string.IsNullOrEmpty(textBox.Text) && textBoxPlaceholders.ContainsKey(textBox))
            {
                textBox.Text = textBoxPlaceholders[textBox];
                textBox.ForeColor = Color.Gray;
            }
        }

        private void RemovePlaceholder(TextBox textBox)
        {
            if (textBox != null && textBoxPlaceholders.ContainsKey(textBox) && textBox.Text == textBoxPlaceholders[textBox])
            {
                textBox.Text = string.Empty;
                textBox.ForeColor = Color.Black;
            }
        }
        #endregion


        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = textBoxUsername.Text;
            string password = textBoxPassword.Text;

            var serviceLibelle = controller.GetUtilisateur(username, password);
            if (serviceLibelle == null || serviceLibelle.Service == null)
            {
                MessageBox.Show("[ERREUR] - Connexion impossible.");
            }

            else if (serviceLibelle.Service == "culture")
            {
                MessageBox.Show("[ERREUR] - Vous n'avez pas accès à cette application.");
                Application.Exit();
            } 
            else
            {
                this.Hide();
                var formMenuPrincipal = new FrmMediatek(serviceLibelle);
                formMenuPrincipal.Show();
            }
        }
    }
}
