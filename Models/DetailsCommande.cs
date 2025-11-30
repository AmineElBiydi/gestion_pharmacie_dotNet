namespace GestionPharmacie.Models
{
    public class DetailsCommande
    {
        public int ID { get; set; }
        public int CommandeID { get; set; }
        public int MedicamentID { get; set; }
        public int Quantite { get; set; }
        public decimal PrixUnitaire { get; set; }
        
        // Navigation properties
        public string? MedicamentNom { get; set; }
        public string? MedicamentReference { get; set; }
        
        public decimal SousTotal => Quantite * PrixUnitaire;
    }
}
