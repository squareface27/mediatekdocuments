﻿using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Serilog;

namespace MediaTekDocuments.dal
{

    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "https://restmediatekdocuments.minty-dev-create.fr/";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour delete
        /// </summary>
        private const string DELETE = "DELETE";
        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                authenticationString = "admin:adminpwd";

                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Verbose()
                .WriteTo.File("logs/log.txt",
                rollingInterval: RollingInterval.Day)
                .CreateLogger();
                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if(instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre");
            Log.Information("Récupération des genres");
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon");
            Log.Information("Récupération des rayons");
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public");
            Log.Information("Récupération des publics");
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre");
            Log.Information("Récupération des livres");
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd");
            Log.Information("Récupération des DVD");
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue");
            Log.Information("Récupération des revues");
            return lesRevues;
        }

        /// <summary>
        /// Retourne touts les utilisateurs à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Utilisateur</returns>
        public Utilisateur GetUtilisateur(string username, string password)
        {
            var login = new { username = username, password = password };
            String jsonIdDocument = JsonConvert.SerializeObject(login);
            List<Utilisateur> lesUtilisateurs = TraitementRecup<Utilisateur>(GET, "utilisateur/" + jsonIdDocument);

            if (lesUtilisateurs != null && lesUtilisateurs.Count > 0)
            {
                Log.Information(username + " " + "s\'est connecté");
                return lesUtilisateurs[0];
            }
            Log.Error("Échec de la connection");
            return null;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Suivi> GetAllSuivi()
        {
            List<Suivi> suivis = TraitementRecup<Suivi>(GET, "suivi");
            Log.Information("Récupération des suivis");
            return suivis;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id de la revue concernée</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            String jsonIdDocument = convertToJson("id", idDocument);
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + jsonIdDocument);
            Log.Information("Récupération des exemplaires");
            return lesExemplaires;
        }

        /// <summary>
        /// Retourne les exemplaires d'un livre
        /// </summary>
        /// <param name="idLivre">id du livre concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<CommandeDocument> GetCommandesLivres(string idLivre)
        {
            String jsonIdDocument = convertToJson("id", idLivre);
            List<CommandeDocument> lesCommandesLivres = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + jsonIdDocument);
            Log.Information("Récupération des commandes de livres");
            return lesCommandesLivres;
        }

        /// <summary>
        /// Retourne les exemplaires d'un dvd
        /// </summary>
        /// <param name="idDvd">id du dvd concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<CommandeDocument> GetCommandesDvd(string idDvd)
        {
            String jsonIdDocument = convertToJson("id", idDvd);
            List<CommandeDocument> lesCommandesDvd = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + jsonIdDocument);
            Log.Information("Récupération des commandes de DVD");
            return lesCommandesDvd;
        }

        /// <summary>
        /// Obtention de l'ID max
        /// </summary>
        public string GetMaxCommandeId()
        {
            JObject retour = api.RecupDistant(GET, "maxcommande");
            var resultat = (string)retour["result"][0]["MAX(CAST(id AS UNSIGNED))"];
            return resultat;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire/" + jsonExemplaire);
                Log.Information("Exemplaire ajouté");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false; 
        }

        /// <summary>
        /// ecriture d'une commande de livre en base de données
        /// </summary>
        /// <param name="commandeLivre">commande livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerCommandeLivre(CommandeDocument commandeLivre)
        {
            String jsonCommandeLivre = JsonConvert.SerializeObject(commandeLivre, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commandedocument/" + jsonCommandeLivre);
                Log.Information("Commande de livre ajoutée");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// ecriture d'une commande de dvd en base de données
        /// </summary>
        /// <param name="commandeDvd">commande livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerCommandeDvd(CommandeDocument commandeDvd)
        {
            String jsonCommandeDvd = JsonConvert.SerializeObject(commandeDvd, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commandedocument/" + jsonCommandeDvd);
                Log.Information("Commande de dvd ajoutée");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// suppression d'une commande de livre en base de données
        /// </summary>
        /// <param name="commandeLivre">commande livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool SupprimerCommandeLivre(CommandeDocument commandeLivre)
        {
            String jsonCommandeLivre = JsonConvert.SerializeObject(commandeLivre, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "commandedocument/" + jsonCommandeLivre);
                Log.Information("Commande de livre supprimée");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// suppression d'une commande de livre en base de données
        /// </summary>
        /// <param name="commandeDvd">commande livre à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool SupprimerCommandeDvd(CommandeDocument commandeDvd)
        {
            String jsonCommandeDvd = JsonConvert.SerializeObject(commandeDvd, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "commandedocument/" + jsonCommandeDvd);
                Log.Information("Commande de DVD supprimée");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// modification d'une commande de livre en base de données
        /// </summary>
        /// <param name="commandeLivre">commande livre à modifier</param>
        /// <returns>true si la modification a pu se faire (retour != null)</returns>
        public bool UpdateCommandeLivre(CommandeDocument commandeLivre)
        {
            String jsonCommandeLivre = JsonConvert.SerializeObject(commandeLivre, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, "commandedocument/" + jsonCommandeLivre);
                Log.Information("Commande de livre modifiée");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// modification d'une commande de dvd en base de données
        /// </summary>
        /// <param name="commandeDvd">commande livre à modifier</param>
        /// <returns>true si la modification a pu se faire (retour != null)</returns>
        public bool UpdateCommandeDvd(CommandeDocument commandeDvd)
        {
            String jsonCommandeDvd = JsonConvert.SerializeObject(commandeDvd, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, "commandedocument/" + jsonCommandeDvd);
                Log.Information("Commande de DVD modifiée");
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error(ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T> (String methode, String message)
        {
            List<T> liste = new List<T>();
            Console.WriteLine("TraitementRecup : " + methode + " " + message);
            try
            {
                JObject retour = api.RecupDistant(methode, message);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Console.WriteLine("code erreur = " + code + " message = " + (String)retour["message"]);
                    Log.Error("code erreur = " + code + " message = " + (String)retour["message"]);
                }
            }catch(Exception e)
            {
                Console.WriteLine("Erreur lors de l'accès à l'API : "+e.Message);
                Log.Error("Erreur lors de l'accès à l'API : " + e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Convertit en json un couple nom/valeur
        /// </summary>
        /// <param name="nom"></param>
        /// <param name="valeur"></param>
        /// <returns>couple au format json</returns>
        private String convertToJson(Object nom, Object valeur)
        {
            Dictionary<Object, Object> dictionary = new Dictionary<Object, Object>();
            dictionary.Add(nom, valeur);
            return JsonConvert.SerializeObject(dictionary);
        }

        /// <summary>
        /// Modification du convertisseur Json pour gérer le format de date
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }

    }
}
