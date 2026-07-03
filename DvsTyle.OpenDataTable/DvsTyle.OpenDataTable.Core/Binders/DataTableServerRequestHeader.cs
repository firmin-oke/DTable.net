using System;
using System.Collections.Generic;
using System.Text;
using DvStyle.OpenDataTable.TableDef;

namespace DvStyle.OpenDataTable.Binders
{
    /// <summary>
    /// Modèle de données pour les paramètres le traitement de données côté serveur. Il contient les informations sur l'ordre, les colonnes, 
    /// la recherche et d'autres paramètres nécessaires pour traiter les requêtes du côté serveur.
    /// </summary>
    public class DataTableServerRequestHeader
    {
        /// <summary>
        /// Ordre de tri pour les colonnes. Chaque élément du tableau représente une colonne et contient des informations sur l'index de la colonne et la direction du tri (ascendant ou descendant).
        /// </summary>
        public DataTableOrder[] Order { get; set; }
        /// <summary>
        /// Les colonnes de la table. Chaque élément du tableau représente une colonne et contient des informations sur le nom de la colonne, le nom de la propriété associée,
        /// </summary>
        public DataTableColumn[] Columns { get; set; }
        /// <summary>
        /// Paramètres de recherche pour la table. Il contient la valeur de recherche et un indicateur indiquant si la recherche est une expression régulière.
        /// </summary>
        public DataTableSearch Search { get; set; }
        public KeyValuePair<string, object>[] Globalqueryfilters { get; set; }
        /// <summary>
        /// Date de début pour la recherche. Si spécifiée, les résultats seront filtrés pour inclure uniquement les enregistrements dont la date est postérieure ou égale à cette date.
        /// </summary>
        public DateTime? SearchStartDate { get; set; }
        /// <summary>
        /// Date de fin pour la recherche. Si spécifiée, les résultats seront filtrés pour inclure uniquement les enregistrements dont la date est antérieure ou égale à cette date.
        /// </summary>
        public DateTime? SearchEndDate { get; set; }

        /// <summary>
        /// Nombre de lignes à retourner pour la pagination. Il indique combien de lignes doivent être renvoyées dans la réponse du serveur.
        /// </summary>
        public int Length { get; set; }
        /// <summary>
        /// Numéro de séquence pour la requête. Il est utilisé pour suivre les requêtes et les réponses, en particulier lorsque plusieurs requêtes sont envoyées simultanément.
        /// </summary>
        public int Draw { get; set; }
        /// <summary>
        /// Accès à partir de quel index de ligne pour la pagination. Il indique à partir de quelle ligne les résultats doivent être renvoyés dans la réponse du serveur.
        /// </summary>
        public int Start { get; set; }

        public DataTableServerRequestHeader(DataTableOrder[] order, DataTableColumn[] columns, DataTableSearch search)
        {
            Order = order;
            Columns = columns;
            Search = search;
            Globalqueryfilters = new KeyValuePair<string, object>[] { };
        }

        public DataTableServerRequestHeader()
        {
            Order = new DataTableOrder[] { };
            Columns = new DataTableColumn[] { };
            Search = new DataTableSearch();
            Globalqueryfilters = new KeyValuePair<string, object>[] { };
        }
    }
}
