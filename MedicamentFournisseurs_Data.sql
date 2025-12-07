-- Add sample medicament-fournisseur relationships
-- This maps which suppliers provide which medications
INSERT INTO MedicamentFournisseurs (MedicamentID, FournisseurID, PrixAchat, DelaiLivraison) VALUES
-- Paracétamol (MED001) from multiple suppliers
(1, 1, 3.50, 2),  -- Pharmacie Centrale
(1, 2, 3.75, 3),  -- MediSupply Maroc

-- Ibuprofène (MED002)
(2, 1, 5.00, 2),
(2, 3, 4.85, 5),

-- Amoxicilline (MED003)
(3, 2, 8.00, 3),
(3, 4, 7.90, 4),

-- Vitamine C (MED004)
(4, 1, 3.50, 2),
(4, 2, 3.60, 3),
(4, 3, 3.55, 4),

-- Aspirine (MED005)
(5, 1, 2.50, 2),

-- Doliprane 1000mg (MED006)
(6, 2, 5.00, 3),
(6, 3, 4.95, 4),

-- Spasfon (MED007)
(7, 3, 6.50, 4),

-- Smecta (MED008)
(8, 4, 5.50, 5),

-- Low stock items - critical to have supplier info
-- Nurofen (MED009) - Low stock
(9, 1, 6.00, 2),
(9, 2, 5.90, 3),

-- Efferalgan (MED010) - Low stock
(10, 1, 4.00, 2),
(10, 3, 3.95, 4),

-- Dafalgan (MED011) - Low stock
(11, 2, 4.50, 3),

-- Strepsils (MED012) - Very low stock
(12, 3, 3.50, 4),
(12, 4, 3.45, 5),

-- Out of stock items - IMPORTANT for reordering
-- Advil (MED013) - Out of stock
(13, 1, 5.50, 2),
(13, 2, 5.40, 3),
(13, 4, 5.45, 4),

-- Actifed (MED014) - Out of stock
(14, 2, 4.50, 3),
(14, 3, 4.40, 5),

-- Humex (MED015) - Out of stock
(15, 1, 4.00, 2),
(15, 4, 3.95, 4);
GO

PRINT 'Medicaments-Fournisseurs relationships created successfully!';
GO
    