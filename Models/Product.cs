using System.Collections.Generic;

namespace AspNetCoreMiniProfiler.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }

        public virtual ICollection<ClientProduct> ClientProducts { get; } = new List<ClientProduct>();
    }
}
