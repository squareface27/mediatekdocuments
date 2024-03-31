using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaTekDocuments.model
{
    public class CommandeDocument : Commande
    {
        public int NombreExemplaire { get; }
        public Suivi LeSuivi { get; }
        public string IdLivreDvd { get; }

        public CommandeDocument(string id, int nombreExemplaire, string idSuivi, string libelleSuivi, string idLivreDvd, DateTime dateCommande, double montant)
            : base ( id, dateCommande, montant)
        {
            this.NombreExemplaire = nombreExemplaire;
            this.LeSuivi = new Suivi(idSuivi, libelleSuivi);
            this.IdLivreDvd = idLivreDvd;

        }
    }
}
