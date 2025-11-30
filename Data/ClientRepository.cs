using System.Data.SqlClient;
using GestionPharmacie.Models;

namespace GestionPharmacie.Data
{
    public class ClientRepository
    {
        public List<Client> GetAll()
        {
            var clients = new List<Client>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Clients ORDER BY Nom, Prenom", conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(MapFromReader(reader));
                    }
                }
            }
            
            return clients;
        }

        public List<Client> Search(string searchTerm)
        {
            return SearchByCriteria(searchTerm, "Tous");
        }

        public List<Client> SearchByCriteria(string searchTerm, string criteria)
        {
            var clients = new List<Client>();
            
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                SqlCommand cmd;
                
                switch (criteria)
                {
                    case "Numéro":
                        cmd = new SqlCommand(
                            @"SELECT * FROM Clients 
                              WHERE Numero LIKE @search
                              ORDER BY Nom, Prenom", conn);
                        break;
                    case "Nom":
                        cmd = new SqlCommand(
                            @"SELECT * FROM Clients 
                              WHERE Nom LIKE @search
                              ORDER BY Nom, Prenom", conn);
                        break;
                    case "Prénom":
                        cmd = new SqlCommand(
                            @"SELECT * FROM Clients 
                              WHERE Prenom LIKE @search
                              ORDER BY Nom, Prenom", conn);
                        break;
                    case "Téléphone":
                        cmd = new SqlCommand(
                            @"SELECT * FROM Clients 
                              WHERE Telephone LIKE @search
                              ORDER BY Nom, Prenom", conn);
                        break;
                    default: // "Tous"
                        cmd = new SqlCommand(
                            @"SELECT * FROM Clients 
                              WHERE Numero LIKE @search OR Nom LIKE @search OR Prenom LIKE @search OR Telephone LIKE @search
                              ORDER BY Nom, Prenom", conn);
                        break;
                }
                
                cmd.Parameters.AddWithValue("@search", "%" + searchTerm + "%");
                
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        clients.Add(MapFromReader(reader));
                    }
                }
            }
            
            return clients;
        }

        public Client? GetById(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("SELECT * FROM Clients WHERE ID = @id", conn);
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

        public int Insert(Client client)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"INSERT INTO Clients (Numero, Nom, Prenom, Adresse, Telephone)
                      VALUES (@num, @nom, @prenom, @adresse, @tel);
                      SELECT CAST(SCOPE_IDENTITY() AS INT);", conn);
                
                cmd.Parameters.AddWithValue("@num", client.Numero);
                cmd.Parameters.AddWithValue("@nom", client.Nom);
                cmd.Parameters.AddWithValue("@prenom", client.Prenom);
                cmd.Parameters.AddWithValue("@adresse", (object?)client.Adresse ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tel", (object?)client.Telephone ?? DBNull.Value);
                
                return (int)cmd.ExecuteScalar();
            }
        }

        public void Update(Client client)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand(
                    @"UPDATE Clients 
                      SET Numero = @num, Nom = @nom, Prenom = @prenom,
                          Adresse = @adresse, Telephone = @tel
                      WHERE ID = @id", conn);
                
                cmd.Parameters.AddWithValue("@id", client.ID);
                cmd.Parameters.AddWithValue("@num", client.Numero);
                cmd.Parameters.AddWithValue("@nom", client.Nom);
                cmd.Parameters.AddWithValue("@prenom", client.Prenom);
                cmd.Parameters.AddWithValue("@adresse", (object?)client.Adresse ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@tel", (object?)client.Telephone ?? DBNull.Value);
                
                cmd.ExecuteNonQuery();
            }
        }

        public void Delete(int id)
        {
            using (var conn = DatabaseConnection.GetConnection())
            {
                conn.Open();
                var cmd = new SqlCommand("DELETE FROM Clients WHERE ID = @id", conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }
        }

        private Client MapFromReader(SqlDataReader reader)
        {
            return new Client
            {
                ID = (int)reader["ID"],
                Numero = reader["Numero"].ToString() ?? "",
                Nom = reader["Nom"].ToString() ?? "",
                Prenom = reader["Prenom"].ToString() ?? "",
                Adresse = reader["Adresse"] == DBNull.Value ? null : reader["Adresse"].ToString(),
                Telephone = reader["Telephone"] == DBNull.Value ? null : reader["Telephone"].ToString()
            };
        }
    }
}
