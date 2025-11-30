using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using GestionPharmacie.Models;

namespace GestionPharmacie.Data
{
    public class AuthenticationService
    {
        /// <summary>
        /// Validates user credentials and returns the user if valid
        /// </summary>
        public static User? ValidateUser(string username, string password)
        {
            try
            {
                string passwordHash = HashPassword(password);
                
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT UserId, Username, PasswordHash, FullName, Role, IsActive, CreatedDate 
                                   FROM Users 
                                   WHERE Username = @Username AND PasswordHash = @PasswordHash AND IsActive = 1";
                    
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    PasswordHash = reader.GetString(2),
                                    FullName = reader.GetString(3),
                                    Role = reader.GetString(4),
                                    IsActive = reader.GetBoolean(5),
                                    CreatedDate = reader.GetDateTime(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error validating user: " + ex.Message);
            }
            
            return null;
        }
        
        /// <summary>
        /// Hashes a password using SHA256
        /// </summary>
        public static string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
        
        /// <summary>
        /// Gets a user by username
        /// </summary>
        public static User? GetUserByUsername(string username)
        {
            try
            {
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"SELECT UserId, Username, PasswordHash, FullName, Role, IsActive, CreatedDate 
                                   FROM Users 
                                   WHERE Username = @Username";
                    
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        
                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                return new User
                                {
                                    UserId = reader.GetInt32(0),
                                    Username = reader.GetString(1),
                                    PasswordHash = reader.GetString(2),
                                    FullName = reader.GetString(3),
                                    Role = reader.GetString(4),
                                    IsActive = reader.GetBoolean(5),
                                    CreatedDate = reader.GetDateTime(6)
                                };
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving user: " + ex.Message);
            }
            
            return null;
        }
        
        /// <summary>
        /// Creates a new user account
        /// </summary>
        public static User CreateUser(string username, string password, string fullName, string role = "Pharmacien", bool isActive = true)
        {
            try
            {
                // Validate username
                if (string.IsNullOrWhiteSpace(username) || username.Length < 3)
                {
                    throw new Exception("Le nom d'utilisateur doit contenir au moins 3 caractères.");
                }
                
                // Validate password
                if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
                {
                    throw new Exception("Le mot de passe doit contenir au moins 6 caractères.");
                }
                
                // Validate full name
                if (string.IsNullOrWhiteSpace(fullName))
                {
                    throw new Exception("Le nom complet est requis.");
                }
                
                // Validate role
                if (role != "Pharmacien" && role != "Admin" && role != "User")
                {
                    throw new Exception("Le rôle doit être 'Pharmacien', 'Admin' ou 'User'.");
                }
                
                // Check if username already exists
                if (GetUserByUsername(username) != null)
                {
                    throw new Exception("Ce nom d'utilisateur existe déjà.");
                }
                
                // Hash password
                string passwordHash = HashPassword(password);
                
                // Insert user
                using (var conn = DatabaseConnection.GetConnection())
                {
                    conn.Open();
                    string query = @"INSERT INTO Users (Username, PasswordHash, FullName, Role, IsActive, CreatedDate)
                                   VALUES (@Username, @PasswordHash, @FullName, @Role, @IsActive, GETDATE());
                                   SELECT CAST(SCOPE_IDENTITY() AS INT);";
                    
                    using (var cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@Username", username);
                        cmd.Parameters.AddWithValue("@PasswordHash", passwordHash);
                        cmd.Parameters.AddWithValue("@FullName", fullName);
                        cmd.Parameters.AddWithValue("@Role", role);
                        cmd.Parameters.AddWithValue("@IsActive", isActive);
                        
                        int userId = (int)cmd.ExecuteScalar();
                        
                        return new User
                        {
                            UserId = userId,
                            Username = username,
                            PasswordHash = passwordHash,
                            FullName = fullName,
                            Role = role,
                            IsActive = isActive,
                            CreatedDate = DateTime.Now
                        };
                    }
                }
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2627) // Unique constraint violation
                {
                    throw new Exception("Ce nom d'utilisateur existe déjà.");
                }
                throw new Exception("Erreur lors de la création de l'utilisateur: " + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erreur lors de la création de l'utilisateur: " + ex.Message);
            }
        }
    }
}
