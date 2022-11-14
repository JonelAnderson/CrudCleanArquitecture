namespace ARQUICAPAS.Application.Dtos.Encargado.Response
{
    public class EncargadoResponseDto
    { 
        public int EncargadoId { get; set; }
        public string? Name { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public DateTime AuditCreateDate { get; set; }

        public int State { get; set; }
        public string? StateEncargado { get; set; }
    }
}
