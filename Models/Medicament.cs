namespace GestionPharmacie.Models
{
    public class Medicament
    {
        public int ID { get; set; }
        public string Reference { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public DateTime DatePeremption { get; set; }
        public decimal PrixUnitaire { get; set; }
        public int QuantiteStock { get; set; }
        public int Seuil { get; set; }

        public bool EstEnAlerte()
        {
            return QuantiteStock <= Seuil || DatePeremption <= DateTime.Now.AddMonths(3);
        }
    }
}
