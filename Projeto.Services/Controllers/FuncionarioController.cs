using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net.Http;
using Projeto.Services.Models;
using System.Net;
using Projeto.Data.Entities;
using Projeto.Data.Repositories;

namespace Projeto.Services.Controllers
{
    [RoutePrefix("api/Funcionario")]
    public class FuncionarioController : ApiController
    {
        public object FuncionarioRepository { get; private set; }

        [HttpPost]
        public HttpResponseMessage Post(FuncionarioCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.Nome = model.Nome;
                    funcionario.Cpf = model.Cpf;
                    funcionario.DataAdmissao = model.DataAdmissao;
                    funcionario.Salario = model.Salario;

                    FuncionarioRepository repository = new FuncionarioRepository();
                    repository.Insert(funcionario);

                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionário cadastrado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro de validação dos dados");
            }
        }

        [HttpPut]
        public HttpResponseMessage Put(FuncionarioEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Funcionario funcionario = new Funcionario();
                    funcionario.IdFuncionario = model.IdFuncionario;
                    funcionario.Nome = model.Nome;
                    funcionario.Cpf = model.Cpf;
                    funcionario.DataAdmissao = model.DataAdmissao;
                    funcionario.Salario = model.Salario;

                    FuncionarioRepository repository = new FuncionarioRepository();
                    repository.Update(funcionario);

                    return Request.CreateResponse(HttpStatusCode.OK, "Funcionário atualizado com sucesso.");
                }
                catch (Exception e)
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, "Erro de validação dos dados");
            }
        }

        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                repository.Delete(id);

                return Request.CreateResponse(HttpStatusCode.OK, "Funcionário excluído com sucesso.");
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetAll()
        {
            try
            {
                List<FuncionarioConsultaModel> lista = new List<FuncionarioConsultaModel>();
                FuncionarioRepository repository = new FuncionarioRepository();
                foreach(var item in repository.SelectAll())
                {
                    FuncionarioConsultaModel model = new FuncionarioConsultaModel();
                    model.IdFuncionario = item.IdFuncionario;
                    model.Nome = item.Nome;
                    model.Cpf = item.Cpf;
                    model.Salario = item.Salario;
                    model.DataAdmissao = item.DataAdmissao;

                    lista.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, lista);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }

        [HttpGet]
        public HttpResponseMessage GetById(int id)
        {
            try
            {
                FuncionarioRepository repository = new FuncionarioRepository();
                Funcionario item = repository.SelectById(id);

                FuncionarioConsultaModel model = new FuncionarioConsultaModel();
                model.IdFuncionario = item.IdFuncionario;
                model.Nome = item.Nome;
                model.Cpf = item.Cpf;
                model.Salario = item.Salario;
                model.DataAdmissao = item.DataAdmissao;

                return Request.CreateResponse(HttpStatusCode.OK, model);

            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, e.Message);
            }
        }
    }
}