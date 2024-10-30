using System.ComponentModel.DataAnnotations;

namespace Pim1.Models
{
    public class ProdutoModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome para identificação do produto")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a data de cultivo")]
        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido")]
        public string Data { get; set; }

        [Required(ErrorMessage = "Digite a quantidade")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Digite o valor unitário")]
        public float? Valor { get; set; }

    }
}
