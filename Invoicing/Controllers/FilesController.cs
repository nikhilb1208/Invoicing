﻿using System.Collections.Generic;
using Invoicing.BusinessLogic.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoicing.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class FilesController : Controller
    {
        private readonly IFileService _fileService;
        private readonly string[] ValidExtensions = { "pdf", "doc", "docx", "xls", "xlsx", "png", "jpg", "jpeg" };
        public FilesController(IFileService fileService)
        {
            _fileService = fileService;
        }

        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        [HttpPost("upload"), DisableRequestSizeLimit]
        public IActionResult Upload()
        {
            try
            {
                var file = Request.Form.Files[0];

                if(!ValidExtensions.Contains(_fileService.GetFileExtension(file.FileName)))
                {
                    return BadRequest("Nieprawidłowe rozszerzenie pliku. Dopuszczalne rozszerzenia to: pdf, doc, docx, xls, xlsx, png, jpg, jpeg");
                }
                var path = _fileService.ExportFile(file);
                return Json(path);
            }
            catch (System.Exception ex)
            {
                return Json("Upload Failed: " + ex.Message);
            }
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
