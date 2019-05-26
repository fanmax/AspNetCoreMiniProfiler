using System.Collections.Generic;

namespace AspNetCoreMiniProfiler.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<ClientProduct> ClientProducts { get; } = new List<ClientProduct>();
    }
}