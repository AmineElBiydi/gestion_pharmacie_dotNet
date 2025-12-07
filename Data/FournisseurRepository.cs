using System.Data;
using System.Data.SqlClient;
using GestionPharmacie.Models;

namespace GestionPharmacie.Data
{
    public class FournisseurRepository
    {
        public List<Fournisseur> GetAll()
        {
            var fournisseurs = new List<Fournisseur>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Fournisseurs WHERE Actif = 1 ORDER BY Nom", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        fournisseurs.Add(MapToFournisseur(reader));
                    }
                }
            }
            return fournisseurs;
        }

        public Fournisseur? GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Fournisseurs WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapToFournisseur(reader);
                    }
                }
            }
            return null;
        }

        public void Insert(Fournisseur fournisseur)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    INSERT INTO Fournisseurs (Nom, Telephone, Email, Adresse, Ville, CodePostal, Actif)
                    VALUES (@Nom, @Telephone, @Email, @Adresse, @Ville, @CodePostal, @Actif)", conn);
                
                cmd.Parameters.AddWithValue("@Nom", fournisseur.Nom);
                cmd.Parameters.AddWithValue("@Telephone", (object?)fournisseur.Telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object?)fournisseur.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Adresse", (object?)fournisseur.Adresse ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ville", (object?)fournisseur.Ville ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodePostal", (object?)fournisseur.CodePostal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Actif", fournisseur.Actif);
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Update(Fournisseur fournisseur)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    UPDATE Fournisseurs 
                    SET Nom = @Nom, Telephone = @Telephone, Email = @Email, 
                        Adresse = @Adresse, Ville = @Ville, CodePostal = @CodePostal, Actif = @Actif
                    WHERE ID = @ID", conn);
                
                cmd.Parameters.AddWithValue("@ID", fournisseur.ID);
                cmd.Parameters.AddWithValue("@Nom", fournisseur.Nom);
                cmd.Parameters.AddWithValue("@Telephone", (object?)fournisseur.Telephone ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Email", (object?)fournisseur.Email ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Adresse", (object?)fournisseur.Adresse ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Ville", (object?)fournisseur.Ville ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@CodePostal", (object?)fournisseur.CodePostal ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Actif", fournisseur.Actif);
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            // Soft delete
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("UPDATE Fournisseurs SET Actif = 0 WHERE ID = @ID", conn);
                cmd.Parameters.AddWithValue("@ID", id);
                cmd.ExecuteNonQuery();
            }
        }

        // Get suppliers for a specific medication
        public List<MedicamentFournisseur> GetSuppliersForMedicament(int medicamentId)
        {
            var suppliers = new List<MedicamentFournisseur>();
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(@"
                    SELECT mf.*, f.Nom as FournisseurNom, f.Telephone as FournisseurTelephone, f.Email as FournisseurEmail
                    FROM MedicamentFournisseurs mf
                    INNER JOIN Fournisseurs f ON mf.FournisseurID = f.ID
                    WHERE mf.MedicamentID = @MedicamentID AND f.Actif = 1
                    ORDER BY mf.PrixAchat", conn);
                
                cmd.Parameters.AddWithValue("@MedicamentID", medicamentId);
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        suppliers.Add(new MedicamentFournisseur
                        {
                            MedicamentID = reader.GetInt32(0),
                            FournisseurID = reader.GetInt32(1),
                            PrixAchat = reader.IsDBNull(2) ? null : reader.GetDecimal(2),
                            DelaiLivraison = reader.IsDBNull(3) ? null : reader.GetInt32(3),
                            DateDebut = reader.GetDateTime(4),
                            FournisseurNom = reader.GetString(5),
                            FournisseurTelephone = reader.IsDBNull(6) ? null : reader.GetString(6),
                            FournisseurEmail = reader.IsDBNull(7) ? null : reader.GetString(7)
                        });
                    }
                }
            }
            return suppliers;
        }

        private Fournisseur MapToFournisseur(SqlDataReader reader)
        {
            return new Fournisseur
            {
                ID = reader.GetInt32(reader.GetOrdinal("ID")),
                Nom = reader.GetString(reader.GetOrdinal("Nom")),
                Telephone = reader.IsDBNull(reader.GetOrdinal("Telephone")) ? null : reader.GetString(reader.GetOrdinal("Telephone")),
                Email = reader.IsDBNull(reader.GetOrdinal("Email")) ? null : reader.GetString(reader.GetOrdinal("Email")),
                Adresse = reader.IsDBNull(reader.GetOrdinal("Adresse")) ? null : reader.GetString(reader.GetOrdinal("Adresse")),
                Ville = reader.IsDBNull(reader.GetOrdinal("Ville")) ? null : reader.GetString(reader.GetOrdinal("Ville")),
                CodePostal = reader.IsDBNull(reader.GetOrdinal("CodePostal")) ? null : reader.GetString(reader.GetOrdinal("CodePostal")),
                Actif = reader.GetBoolean(reader.GetOrdinal("Actif")),
                DateCreation = reader.GetDateTime(reader.GetOrdinal("DateCreation"))
            };
        }
    }
}
