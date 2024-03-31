using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Globalization;
using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System.Threading.Tasks;

namespace MediaTekDocuments.view.CommandeLivres
{
    public partial class AjouterCommandeLivreForm : Form
    {

        private FrmMediatek FrmMediatek;
        private readonly FrmMediatekController controller;
        private Dictionary<TextBox, string> textBoxPlaceholders = new Dictionary<TextBox, string>();

        public AjouterCommandeLivreForm(FrmMediatek frmMediatek)
        {
            InitializeComponent();
            this.controller = new FrmMediatekController();
            this.FrmMediatek = frmMediatek;
            InitializePlaceholder();
        }

        #region PlaceHolder
        private void InitializePlaceholder()
        {
            textBoxPlaceholders.Add(txtNbExemplaire, "Nombre d'exemplaires");
            textBoxPlaceholders.Add(txtMontant, "Montant");

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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmMediatek.Show();
        }

        private void btnValidation_Click(object sender, EventArgs e)
        {
            var maxId = controller.GetCommandesLivresMaxId();
            maxId = (int.Parse(maxId) + 1).ToString();

            string numeroLivre = FrmMediatek.NumeroLivre;
            if (string.IsNullOrWhiteSpace(numeroLivre))
            {
                MessageBox.Show("Le numéro du livre est requis.");
                return;
            }

            if (!int.TryParse(txtNbExemplaire.Text, out int nbExemplaire) || nbExemplaire <= 0)
            {
                MessageBox.Show("Le nombre d'exemplaires doit être un nombre entier positif.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtMontant.Text))
            {
                MessageBox.Show("Le montant est requis.");
                return;
            }

            double montant;
            if (!double.TryParse(txtMontant.Text, NumberStyles.Any, CultureInfo.InvariantCulture, out montant) || montant <= 0)
            {
                MessageBox.Show("Le montant doit être un nombre positif.");
                return;
            }

            string idSuivi = "00001";
            string libelle = "En cours";
            DateTime dateCommande = dateTimePickerDateCommande.Value;

            CommandeDocument commandeLivre = new CommandeDocument(maxId, nbExemplaire, idSuivi, libelle, numeroLivre, dateCommande, montant);
            controller.CreerCommandeLivre(commandeLivre);

            FrmMediatek.refresh_command();
            this.Close();
            FrmMediatek.Show();

        }


    }
}
