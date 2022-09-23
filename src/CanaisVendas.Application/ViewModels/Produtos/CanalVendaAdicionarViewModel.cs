using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace LinearSistemas.CanaisVendas.Application.ViewModels.Produtos
{
    public class CanalVendaAdicionarViewModel
    {
        [Required(ErrorMessage = "Id é requerido")]
        public Guid Id { get; set; }
    }
}
