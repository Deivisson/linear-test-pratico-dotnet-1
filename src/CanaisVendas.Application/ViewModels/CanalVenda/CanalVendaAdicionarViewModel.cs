using System.ComponentModel.DataAnnotations;

namespace LinearSistemas.CanaisVendas.Application.ViewModels.CanalVenda
{
    public class CanalVendaAdicionarViewModel
    {
        [Required(ErrorMessage = "Id é requerido")]
        public int Id { get; set; }
    }
}
