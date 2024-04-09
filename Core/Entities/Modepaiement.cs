﻿using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Modepaiement
{
    public int Id { get; set; }

    public string Libelle { get; set; }

    public virtual ICollection<Paiement> Paiements { get; set; } = new List<Paiement>();
}
