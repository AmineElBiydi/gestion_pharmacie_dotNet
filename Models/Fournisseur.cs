namespace GestionPharmacie.Models
{
    public class Fournisseur
    {
        public int ID { get; set; }
        public string Nom { get; set; } = string.Empty;
        public string? Telephone { get; set; }
        public string? Email { get; set; }
        public string? Adresse { get; set; }
        public string? Ville { get; set; }
        public string? CodePostal { get; set; }
        public bool Actif { get; set; } = true;
        public DateTime DateCreation { get; set; } = DateTime.Now;

        // Display properties for UI
        public string NomComplet => $"{Nom} - {Ville ?? "N/A"}";
        public string ContactInfo => $"{Telephone ?? "N/A"} | {Email ?? "N/A"}";
    }

    // Model for medication-supplier relationship
    public class MedicamentFournisseur
    {
        public int MedicamentID { get; set; }
        public int FournisseurID { get; set; }
        public string FournisseurNom { get; set; } = string.Empty;
        public string? FournisseurTelephone { get; set; }
        public string? FournisseurEmail { get; set; }
        public decimal? PrixAchat { get; set; }
        public int? DelaiLivraison { get; set; }
        public DateTime DateDebut { get; set; }
        
        // Display property
        public string InfoFournisseur => $"{FournisseurNom} ({FournisseurTelephone})";
        public string PrixInfo => PrixAchat.HasValue ? $"{PrixAchat.Value:N2} DH" : "N/A";
    }
}
