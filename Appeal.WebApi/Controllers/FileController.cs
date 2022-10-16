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
        public async Task<Response<FileGetDto>> Get(int id)
        {
            Response<FileGetDto> response = new Response<FileGetDto>();
            try
            {
                var file = await _fileService.Get(id);
                response = new Response<FileGetDto>()
                {
                    Code = (int)HttpStatusCode.OK,
                    Data = file,
                    Success = true,
                    Message = file != null ? "Məlumat uğurla gətirildi!" : "Məlumat tapılmadı!"
                };
            }
            catch (Exception)
            {
                response = new Response<FileGetDto>()
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Success = false,
                    Message = "Xəta yarandı!"
                };
            }
            return response;
        }
    }
}
