namespace AspNetCoreMiniProfiler.Models
{
    public class ClientProduct
    {
        public int ProductId { get; set; }
        public int ClientId { get; set; }

        public virtual Client Client { get; set; }
        public virtual Product Product { get; set; }
    }
}
