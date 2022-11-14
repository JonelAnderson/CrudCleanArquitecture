namespace ARQUICAPAS.Domain.Entities
{
    public partial class Encargado : BaseEntity
    {
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
       
    }
}
