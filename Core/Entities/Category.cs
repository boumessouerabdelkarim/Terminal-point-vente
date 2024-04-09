using System;
using System.Collections.Generic;

namespace Core.Entities;

public partial class Category
{
    public int Id { get; set; }

    public string Nom { get; set; }

    public string ImageUrl { get; set; }

    public virtual ICollection<Article> Articles { get; set; } = new List<Article>();
}
