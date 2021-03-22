using Business.Interfaces.Services;
using Business.IO;
using Business.IO.Produto;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]

    public class ProdutoController : ControllerBase
    {
        private IProdutoService _service;

        public ProdutoController(IProdutoService service)
        {
            _service = service;
        }


        [HttpPost]
        [DisableRequestSizeLimit]
        public async Task<IActionResult> Post([FromForm] ProdutoInput _produto)
        {
            try
            {
                 var rest = JsonConvert.DeserializeObject<ProdutoInput>(Request.Form["produto"]);
                var produto = await _service.Save(rest);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }

        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] ProdutoInput _produto)
        {
            try
            {
                var produto = await _service.Update(_produto);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }

        }
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var produto = await _service.Delete(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }

        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetId(int id)
        {
            try
            {
                var produto = await _service.GetId(id);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                 return Ok(new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetFilter([FromQuery] ProdutoInput _filtro)
        {
            try
            {
                var produto = await _service.GetFilter(_filtro);
                return Ok(produto);
            }
            catch (Exception ex)
            {
                return Ok(new ReturnView() { Object = null, Message = ex.Message, Status = false });
            }
        }
    }
}
