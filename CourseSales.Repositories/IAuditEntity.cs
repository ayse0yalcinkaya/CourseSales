namespace CourseSales.Repositories
{
    public interface IAuditEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Updated { get; set; }
        public string CreatedBy { get; set; }
        public string? UpdatedBy { get; set; }

    }
}
