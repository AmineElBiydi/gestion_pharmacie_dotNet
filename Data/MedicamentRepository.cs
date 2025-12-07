using System.Data;
using System.Data.SqlClient;
using GestionPharmacie.Models;

namespace GestionPharmacie.Data
{
    public class MedicamentRepository
    {
        public List<Medicament> GetAll()
        {
            var medicaments = new List<Medicament>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    "SELECT * FROM Medicaments ORDER BY Nom", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicaments.Add(MapFromReader(reader));
                    }
                }
            }

            return medicaments;
        }

        public List<Medicament> GetMedicamentsEnAlerte()
        {
            var medicaments = new List<Medicament>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"SELECT * FROM Medicaments 
                      WHERE QuantiteStock <= Seuil
                      ORDER BY QuantiteStock ASC, DatePeremption ASC", conn);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicaments.Add(MapFromReader(reader));
                    }
                }
            }

            return medicaments;
        }

        public List<Medicament> Search(string searchTerm)
        {
            return SearchByCriteria(searchTerm, "Tous");
        }

        public List<Medicament> SearchByCriteria(string searchTerm, string criteria)
        {
            var medicaments = new List<Medicament>();

            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd;

                switch (criteria)
                {
                    case "Référence":
                        cmd = new SqlCommand(
                            @"SELECT * FROM Medicaments 
                              WHERE Reference LIKE @search
                              ORDER BY Nom", conn);
                        break;

                    case "Nom":
                        cmd = new SqlCommand(
                            @"SELECT * FROM Medicaments 
                              WHERE Nom LIKE @search
                              ORDER BY Nom", conn);
                        break;

                    default:
                        cmd = new SqlCommand(
                            @"SELECT * FROM Medicaments 
                              WHERE Reference LIKE @search OR Nom LIKE @search
                              ORDER BY Nom", conn);
                        break;
                }

                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        medicaments.Add(MapFromReader(reader));
                    }
                }
            }

            return medicaments;
        }

        public Medicament? GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Medicaments WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);

                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return MapFromReader(reader);
                    }
                }
            }

            return null;
        }

        public int Insert(Medicament medicament)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"INSERT INTO Medicaments 
                      (Reference, Nom, DatePeremption, PrixUnitaire, QuantiteStock, Seuil, EstBloque)
                      VALUES (@ref, @nom, @date, @prix, @qte, @seuil, @estBloque);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);

                cmd.Parameters.AddWithValue("@ref", medicament.Reference);
                cmd.Parameters.AddWithValue("@nom", medicament.Nom);
                cmd.Parameters.AddWithValue("@date", medicament.DatePeremption);
                cmd.Parameters.AddWithValue("@prix", medicament.PrixUnitaire);
                cmd.Parameters.AddWithValue("@qte", medicament.QuantiteStock);
                cmd.Parameters.AddWithValue("@seuil", medicament.Seuil);
                cmd.Parameters.AddWithValue("@estBloque", medicament.EstBloque ? 1 : 0);

                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Medicament medicament)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"UPDATE Medicaments 
                      SET Reference = @ref, Nom = @nom, DatePeremption = @date,
                          PrixUnitaire = @prix, QuantiteStock = @qte, Seuil = @seuil,
                          EstBloque = @estBloque
                      WHERE ID = @id", conn);

                cmd.Parameters.AddWithValue("@id", medicament.ID);
                cmd.Parameters.AddWithValue("@ref", medicament.Reference);
                cmd.Parameters.AddWithValue("@nom", medicament.Nom);
                cmd.Parameters.AddWithValue("@date", medicament.DatePeremption);
                cmd.Parameters.AddWithValue("@prix", medicament.PrixUnitaire);
                cmd.Parameters.AddWithValue("@qte", medicament.QuantiteStock);
                cmd.Parameters.AddWithValue("@seuil", medicament.Seuil);
                cmd.Parameters.AddWithValue("@estBloque", medicament.EstBloque ? 1 : 0);

                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("update Medicaments set estBloque=1 WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        public void UpdateStock(int medicamentID, int quantite)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"UPDATE Medicaments 
                      SET QuantiteStock = QuantiteStock + @qte 
                      WHERE ID = @id", conn);

                cmd.Parameters.AddWithValue("@id", medicamentID);
                cmd.Parameters.AddWithValue("@qte", quantite);
                cmd.ExecuteNonQuery();
            }
        }

        private Medicament MapFromReader(SqlDataReader reader)
        {
            return new Medicament
            {
                ID = (int)reader["ID"],
                Reference = reader["Reference"].ToString() ?? "",
                Nom = reader["Nom"].ToString() ?? "",
                DatePeremption = (DateTime)reader["DatePeremption"],
                PrixUnitaire = (decimal)reader["PrixUnitaire"],
                QuantiteStock = (int)reader["QuantiteStock"],
                Seuil = (int)reader["Seuil"],
                EstBloque = (bool)reader["EstBloque"]     // <-- LECTURE AJOUTÉE
            };
        }
    }
}
