using System.Data.SqlClient;
using GestionPharmacie.Models;

namespace GestionPharmacie.Data
{
    public class CommandeRepository
    {
        private readonly MedicamentRepository _medicamentRepo = new();

        public List<Commande> GetAll()
        {
            var commandes = new List<Commande>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT c.*, cl.Nom + ' ' + cl.Prenom AS ClientNom,
                      ISNULL(c.EstPaye, 0) AS EstPaye,
                      c.TypePaiement
                      FROM Commandes c
                      INNER JOIN Clients cl ON c.ClientID = cl.ID
                      ORDER BY c.DateCommande DESC", conn);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commandes.Add(MapFromReader(reader));
                    }
                }
            }
            
            return commandes;
        }

        public List<Commande> SearchByDate(DateTime startDate, DateTime endDate)
        {
            var commandes = new List<Commande>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT c.*, cl.Nom + ' ' + cl.Prenom AS ClientNom,
                      ISNULL(c.EstPaye, 0) AS EstPaye,
                      c.TypePaiement
                      FROM Commandes c
                      INNER JOIN Clients cl ON c.ClientID = cl.ID
                      WHERE c.DateCommande >= @start AND c.DateCommande <= @end
                      ORDER BY c.DateCommande DESC", conn);
                
                cmd.Parameters.AddWithValue("@start", startDate);
                cmd.Parameters.AddWithValue("@end", endDate);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commandes.Add(MapFromReader(reader));
                    }
                }
            }
            
            return commandes;
        }

        public List<Commande> SearchByClient(int clientID)
        {
            var commandes = new List<Commande>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT c.*, cl.Nom + ' ' + cl.Prenom AS ClientNom,
                      ISNULL(c.EstPaye, 0) AS EstPaye,
                      c.TypePaiement
                      FROM Commandes c
                      INNER JOIN Clients cl ON c.ClientID = cl.ID
                      WHERE c.ClientID = @clientID
                      ORDER BY c.DateCommande DESC", conn);
                
                cmd.Parameters.AddWithValue("@clientID", clientID);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        commandes.Add(MapFromReader(reader));
                    }
                }
            }
            
            return commandes;
        }

        public Commande? GetById(int id)
        {
            Commande? commande = null;
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT c.*, cl.Nom + ' ' + cl.Prenom AS ClientNom,
                      ISNULL(c.EstPaye, 0) AS EstPaye,
                      c.TypePaiement
                      FROM Commandes c
                      INNER JOIN Clients cl ON c.ClientID = cl.ID
                      WHERE c.ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        commande = MapFromReader(reader);
                    }
                }
            }
            
            if (commande != null)
            {
                commande.Details = GetCommandeDetails(id);
            }
            
            return commande;
        }

        public List<DetailsCommande> GetCommandeDetails(int commandeID)
        {
            var details = new List<DetailsCommande>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT dc.*, m.Nom AS MedicamentNom, m.Reference AS MedicamentReference
                      FROM DetailsCommande dc
                      INNER JOIN Medicaments m ON dc.MedicamentID = m.ID
                      WHERE dc.CommandeID = @id", conn);
                cmd.Parameters.AddWithValue("@id", commandeID);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        details.Add(new DetailsCommande
                        {
                            ID = (int)reader["ID"],
                            CommandeID = (int)reader["CommandeID"],
                            MedicamentID = (int)reader["MedicamentID"],
                            Quantite = (int)reader["Quantite"],
                            PrixUnitaire = (decimal)reader["PrixUnitaire"],
                            MedicamentNom = reader["MedicamentNom"].ToString(),
                            MedicamentReference = reader["MedicamentReference"].ToString()
                        });
                    }
                }
            }
            
            return details;
        }

        public int Insert(Commande commande)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Insert commande
                        var cmd = new SqlCommand(
                            @"INSERT INTO Commandes (DateCommande, ClientID, MontantTotal, Statut, EstPaye, TypePaiement)
                              VALUES (@date, @clientID, @montant, @statut, @estPaye, @typePaiement);
                              SELECT CAST(SCOPE_IDENTITY() AS INT);", conn, transaction);
                        
                        cmd.Parameters.AddWithValue("@date", commande.DateCommande);
                        cmd.Parameters.AddWithValue("@clientID", commande.ClientID);
                        cmd.Parameters.AddWithValue("@montant", commande.MontantTotal);
                        cmd.Parameters.AddWithValue("@statut", commande.Statut);
                        cmd.Parameters.AddWithValue("@estPaye", commande.EstPaye);
                        cmd.Parameters.AddWithValue("@typePaiement", (object?)commande.TypePaiement ?? DBNull.Value);
                        
                        int commandeID = (int)cmd.ExecuteScalar();
                        
                        // Insert details and update stock
                        foreach (var detail in commande.Details)
                        {
                            var detailCmd = new SqlCommand(
                                @"INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire)
                                  VALUES (@cmdID, @medID, @qte, @prix)", conn, transaction);
                            
                            detailCmd.Parameters.AddWithValue("@cmdID", commandeID);
                            detailCmd.Parameters.AddWithValue("@medID", detail.MedicamentID);
                            detailCmd.Parameters.AddWithValue("@qte", detail.Quantite);
                            detailCmd.Parameters.AddWithValue("@prix", detail.PrixUnitaire);
                            detailCmd.ExecuteNonQuery();
                            
                            // Update stock
                            var stockCmd = new SqlCommand(
                                @"UPDATE Medicaments SET QuantiteStock = QuantiteStock - @qte WHERE ID = @id",
                                conn, transaction);
                            stockCmd.Parameters.AddWithValue("@qte", detail.Quantite);
                            stockCmd.Parameters.AddWithValue("@id", detail.MedicamentID);
                            stockCmd.ExecuteNonQuery();
                        }
                        
                        transaction.Commit();
                        return commandeID;
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(Commande commande)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                using (var transaction = conn.BeginTransaction())
                {
                    try
                    {
                        // Update commande header
                        var cmd = new SqlCommand(
                            @"UPDATE Commandes 
                              SET DateCommande = @date, ClientID = @clientID, 
                                  MontantTotal = @montant, Statut = @statut,
                                  EstPaye = @estPaye, TypePaiement = @typePaiement
                              WHERE ID = @id", conn, transaction);
                        
                        cmd.Parameters.AddWithValue("@id", commande.ID);
                        cmd.Parameters.AddWithValue("@date", commande.DateCommande);
                        cmd.Parameters.AddWithValue("@clientID", commande.ClientID);
                        cmd.Parameters.AddWithValue("@montant", commande.MontantTotal);
                        cmd.Parameters.AddWithValue("@statut", commande.Statut);
                        cmd.Parameters.AddWithValue("@estPaye", commande.EstPaye);
                        cmd.Parameters.AddWithValue("@typePaiement", (object?)commande.TypePaiement ?? DBNull.Value);
                        
                        cmd.ExecuteNonQuery();

                        // Delete old details
                        var deleteCmd = new SqlCommand("DELETE FROM DetailsCommande WHERE CommandeID = @id", conn, transaction);
                        deleteCmd.Parameters.AddWithValue("@id", commande.ID);
                        deleteCmd.ExecuteNonQuery();

                        // Insert new details
                        foreach (var detail in commande.Details)
                        {
                            var detailCmd = new SqlCommand(
                                @"INSERT INTO DetailsCommande (CommandeID, MedicamentID, Quantite, PrixUnitaire)
                                  VALUES (@cmdID, @medID, @qte, @prix)", conn, transaction);
                            
                            detailCmd.Parameters.AddWithValue("@cmdID", commande.ID);
                            detailCmd.Parameters.AddWithValue("@medID", detail.MedicamentID);
                            detailCmd.Parameters.AddWithValue("@qte", detail.Quantite);
                            detailCmd.Parameters.AddWithValue("@prix", detail.PrixUnitaire);
                            detailCmd.ExecuteNonQuery();
                        }

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                // Details will be deleted automatically due to CASCADE
                var cmd = new SqlCommand("DELETE FROM Commandes WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private Commande MapFromReader(SqlDataReader reader)
        {
            return new Commande
            {
                ID = (int)reader["ID"],
                DateCommande = (DateTime)reader["DateCommande"],
                ClientID = (int)reader["ClientID"],
                MontantTotal = (decimal)reader["MontantTotal"],
                Statut = reader["Statut"].ToString() ?? "En cours",
                EstPaye = reader["EstPaye"] != DBNull.Value && (bool)reader["EstPaye"],
                TypePaiement = reader["TypePaiement"] == DBNull.Value ? null : reader["TypePaiement"].ToString(),
                ClientNom = reader["ClientNom"].ToString()
            };
        }
    }
}
