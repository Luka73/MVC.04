using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Projeto.Services.Models
{
    public class FuncionarioEdicaoModel
    {
        [Required]
        public int IdFuncionario { get; set; }
        [Required]
        public string Nome { get; set; }
        [Required]
        public string Cpf { get; set; }
        [Required]
        public decimal Salario { get; set; }
        [Required]
        public DateTime DataAdmissao { get; set; }
    }
}