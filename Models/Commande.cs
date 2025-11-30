namespace GestionPharmacie.Models
{
    public class Commande
    {
        public int ID { get; set; }
        public DateTime DateCommande { get; set; }
        public int ClientID { get; set; }
        public decimal MontantTotal { get; set; }
        public string Statut { get; set; } = "En cours";
        public bool EstPaye { get; set; } = false;
        public string? TypePaiement { get; set; }
        
        // Navigation properties
        public string? ClientNom { get; set; }
        public List<DetailsCommande> Details { get; set; } = new List<DetailsCommande>();
    }
}
