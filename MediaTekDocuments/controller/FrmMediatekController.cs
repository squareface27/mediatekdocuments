using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Contrôleur lié à FrmMediatek
    /// </summary>
    class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter sur la liste des genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter sur la liste des livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter sur la liste des revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter sur la liste des utilisateurs
        /// </summary>
        /// <returns>Liste d'objets Utilisateur</returns>
        public Utilisateur GetUtilisateur(string username, string password)
        {
            return access.GetUtilisateur(username, password);
        }

        /// <summary>
        /// getter sur les rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// getter sur les publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// récupère les suivis
        /// </summary>
        /// <param name="suivis">L'objet suivis concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public List<Suivi> GetSuivis()
        {
            return access.GetAllSuivi();
        }


        /// <summary>
        /// récupère les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocuement">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocuement)
        {
            return access.GetExemplairesRevue(idDocuement);
        }

        /// <summary>
        /// récupère les exemplaires d'un livre
        /// </summary>
        /// <param name="idLivre">id du livre concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<CommandeDocument> GetCommandesLivres(string idLivre)
        {
            return access.GetCommandesLivres(idLivre);
        }

        /// <summary>
        /// récupère les exemplaires d'un livre
        /// </summary>
        /// <param name="idDvd">id du livre concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<CommandeDocument> GetCommandesDvd(string idDvd)
        {
            return access.GetCommandesDvd(idDvd);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="exemplaire">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            return access.CreerExemplaire(exemplaire);
        }

        /// <summary>
        /// 
        /// </summary>
        public string GetCommandesLivresMaxId()
        {
            return access.GetMaxCommandeId();
        }

        /// <summary>
        /// Crée une commande de livre dans la bdd
        /// </summary>
        /// <param name="commandeLivre">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerCommandeLivre(CommandeDocument commandeLivre)
        {
            return access.CreerCommandeLivre(commandeLivre);
        }

        /// <summary>
        /// Crée une commande de dvd dans la bdd
        /// </summary>
        /// <param name="commandeDvd">L'objet Exemplaire concerné</param>
        /// <returns>True si la création a pu se faire</returns>
        public bool CreerCommandeDvd(CommandeDocument commandeDvd)
        {
            return access.CreerCommandeDvd(commandeDvd);
        }

        /// <summary>
        /// Modifier une commande de livre dans la bdd
        /// </summary>
        /// <param name="commandeLivre">L'objet Exemplaire concerné</param>
        /// <returns>True si la modification a pu se faire</returns>
        public bool UpdateCommandeLivre(CommandeDocument commandeLivre)
        {
            return access.UpdateCommandeLivre(commandeLivre);
        }

        /// <summary>
        /// Modifier une commande de dvd dans la bdd
        /// </summary>
        /// <param name="commandeDvd">L'objet Exemplaire concerné</param>
        /// <returns>True si la modification a pu se faire</returns>
        public bool UpdateCommandeDvd(CommandeDocument commandeDvd)
        {
            return access.UpdateCommandeDvd(commandeDvd);
        }

        /// <summary>
        /// Modifier une commande de livre dans la bdd
        /// </summary>
        /// <param name="commandeLivre">L'objet Exemplaire concerné</param>
        /// <returns>True si la modification a pu se faire</returns>
        public bool SupprimerCommandeLivre(CommandeDocument commandeLivre)
        {
            return access.SupprimerCommandeLivre(commandeLivre);
        }

        /// <summary>
        /// Modifier une commande de livre dans la bdd
        /// </summary>
        /// <param name="commandeDvd">L'objet Exemplaire concerné</param>
        /// <returns>True si la modification a pu se faire</returns>
        public bool SupprimerCommandeDvd(CommandeDocument commandeDvd)
        {
            return access.SupprimerCommandeDvd(commandeDvd);
        }

    }
}
