﻿using ApiTarefas2.Dtos;
using ApiTarefas2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas2.Controllers
{
    [Route("tarefas")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            List<Tarefa> listaTarefas = new TarefaDAO().List();

            return Ok(listaTarefas);
        }

        //[HttpGet("{id}")]
        //public IActionResult GetById(int id) {

        //    var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

        //    if (tarefa == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok();
        //}

        [HttpPost]
        public IActionResult Post([FromBody] TarefaDTO item)
        {

            var tarefa = new Tarefa();

            tarefa.Descricao = item.Descricao;
            tarefa.Feito = item.Feito;
            tarefa.Data = DateTime.Now;

            try
            {
                var dao = new TarefaDAO();
                tarefa.Id = dao.Insert(tarefa);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


            return Created("", tarefa);
        }

        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] TarefaDTO item)
        //{
        //    var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

        //    if (tarefa == null)
        //    {
        //        return NotFound();
        //    }

        //    tarefa.Descricao = item.Descricao;
        //    tarefa.Feito = item.Feito;

        //    return Ok(listaTarefas);
        //}

        //[HttpDelete("{id}")]
        //public IActionResult Delete(int id)
        //{

        //    var tarefa = listaTarefas.Where(item => item.Id == id).FirstOrDefault();

        //    if (tarefa == null)
        //    {
        //        return NotFound();
        //    }

        //    listaTarefas.Remove(tarefa);

        //    return Ok(tarefa);
        //}

    }
}
