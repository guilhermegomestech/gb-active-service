using System.ComponentModel.DataAnnotations;

namespace gb_active_service_api.Models
{
    public class Active : Entity
    {
        public Guid ResponsibleId { get; set; }
        public Guid DependencyId { get; set; }

        [Required(ErrorMessage="O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage="O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Brand { get; set; } = null!;

        public Responsible Responsible { get; set; } = null!;
        public Dependency Dependency { get; set; } = null!;
    }
}
