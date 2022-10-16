using Appeal.Entities.Dtos.FileDtos;
using Appeal.Services.Abstract;
using Appeal.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Appeal.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IFileService _fileService;
        public FileController(IFileService fileService)
        {
            _fileService = fileService;

        }

        [HttpGet]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var file = await _fileService.Get(id);
                var downloadedFile = File(file.FileContent, file.ContentType, file.FileName);

                return downloadedFile;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
          

        }
    }
}
