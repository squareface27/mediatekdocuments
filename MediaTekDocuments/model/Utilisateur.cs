namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Utilisateur (identification d'un utilisateur)
    /// </summary>
    public class Utilisateur
    {
        /// <summary>
        /// Récupère l'identifiant de l'utilisateur
        /// </summary>
        public string Login { get; set; }

        /// <summary>
        /// Récupère le mot de passe de l'utilisateur
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Récupère le libelle du Service de l'utilisateur
        /// </summary>
        public string Service { get; set; }

        /// <summary>
        /// Initialisation d'un objet Utilisateur
        /// </summary>
        /// <param name="login">Login de l'utilisateur</param>
        /// <param name="password">Mot de passe de l'utilisateur</param>
        /// <param name="libelle">Libelle du service de l'utilisateur</param>
        public Utilisateur(string login, string password, string libelle)
        {
            this.Login = login;
            this.Password = password;
            this.Service = libelle;
        }
    }
}