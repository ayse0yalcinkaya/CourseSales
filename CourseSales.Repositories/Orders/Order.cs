namespace CourseSales.Repositories.Orders
{
    public class Order: BaseEntity<int>, IAuditEntity
    {
        public int UserId { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }
    }
}
