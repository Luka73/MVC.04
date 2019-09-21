using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Contracts
{
    public interface IFuncionarioRepository
        : IBaseRepository<Funcionario>
    {
        Funcionario SelectByCpf(string cpf);
    }
}
