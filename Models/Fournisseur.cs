namespace GestionPharmacie.Models
{
    public class Fournisseur
    {
        public int ID { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? Adresse { get; set; }
        public string? Telephone { get; set; }
    }
}
