using System.ComponentModel.DataAnnotations;

namespace Revisao.Api.DTO
{
    public class CriancaRequestDto
    {
        [MaxLength(255), MinLength(3)]

        public string Nome { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A rua deve ter entre 3 e 20 caracteres")]
        public string Rua { get; set; } 
        public int Numero { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O bairro deve ter entre 3 e 20 caracteres")]
        public string Bairro { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "A cidade deve ter entre 3 e 20 caracteres")]
        public string Cidade { get; set; }
        [StringLength(20, MinimumLength = 3, ErrorMessage = "O estado deve ter entre 3 e 20 caracteres")]
        public string Estado { get; set; }
        [StringLength(9, ErrorMessage = "O CEP deve ter 9 digitos")]
        public string CEP { get; set; }

        [Range(0, 15, ErrorMessage = ("A idade não pode ser maior que 15 anos"))]
        public int Idade { get; set; }
        [StringLength(500, MinimumLength = 10, ErrorMessage = "A carta deve ter entre 10 e 500 caracteres")]
        public string TextoCarta { get; set; }
    }
}
