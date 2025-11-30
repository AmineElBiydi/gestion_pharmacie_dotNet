namespace GestionPharmacie.Models
{
    public class Livraison
    {
        public int ID { get; set; }
        public DateTime DateLivraison { get; set; }
        public int FournisseurID { get; set; }
        public int MedicamentID { get; set; }
        public int Quantite { get; set; }
        
        // Navigation properties
        public string? FournisseurNom { get; set; }
        public string? MedicamentNom { get; set; }
    }
}
