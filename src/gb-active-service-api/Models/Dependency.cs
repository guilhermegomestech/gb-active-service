using System.ComponentModel.DataAnnotations;

namespace gb_active_service_api.Models
{
    public class Dependency : Entity
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "O campo {0} é obrigatório.")]
        [StringLength(200, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres.", MinimumLength = 2)]
        public string Address { get; set; } = null!;

        public IEnumerable<Active>? Actives { get; set; }
    }
}
