namespace GestionPharmacie.Models
{
    public class Client
    {
        public int ID { get; set; }
        public string Numero { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public string Prenom { get; set; } = string.Empty;
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }

        public string NomComplet => $"{Nom} {Prenom}";
    }
}
