using Appeal.Entities.Dtos.AppeatDtos;
using Appeal.Entities.Dtos.FileDtos;
using Appeal.Services.Abstract;
using Appeal.Shared.Data.Concrete;
using Appeal.Shared.Extensions;
using Appeal.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.RegularExpressions;

namespace Appeal.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AppealController : ControllerBase
    {
        private readonly IAppealService _appealService;
        private readonly IFileService _fileService;
        public AppealController(IAppealService appealService, IFileService fileService)
        {
            _appealService = appealService;
            _fileService = fileService;
        }

        [HttpPost] //save and update
        public async Task<Response<int>> Save([FromForm] AppealCreateDto dto)
        {
            Response<int> response = new Response<int>();
            if (ModelState.IsValid)
            {
                try
                {
                    int data = 0;

                    //Format: +994111111111
                    if (!Regex.IsMatch(dto.Phone, @"^\+[1-9]{1}[0-9]{3,14}$"))  
                        return response = new Response<int>()
                        {
                            Code = (int)HttpStatusCode.BadRequest,
                            Data = 0,
                            Success = false,
                            Message = "Nömrənin formatı düzgün deyil!"
                        };
                    
                    if(!(dto.Email.Contains('@') && dto.Email.Contains('.')))
                        return response = new Response<int>()
                        {
                            Code = (int)HttpStatusCode.BadRequest,
                            Data = 0,
                            Success = false,
                            Message = "Elektron poçt formatı düzgün deyil!"
                        };

                    if (dto.Doc != null)
                    {
                        if (dto.Doc.Length > 4000000)
                            return response = new Response<int>()
                            {
                                Code = (int)HttpStatusCode.BadRequest,
                                Data = 0,
                                Success = false,
                                Message = "Yüklənən fayl 4 MB-dan çox ola bilməz!"
                            };

                        if (System.IO.Path.GetExtension(dto.Doc.FileName) is not (".pdf" or ".docx"))
                            return response = new Response<int>()
                            {
                                Code = (int)HttpStatusCode.BadRequest,
                                Data = 0,
                                Success = false,
                                Message = "Yalnız pdf və docx formatları dəstəklənir!"
                            };

                        Appeal.Entities.Concretes.File file = new Appeal.Entities.Concretes.File();
                        file.FileContent = dto.Doc.GetBuffer();
                        file.ContentType = dto.Doc.ContentType;
                        file.FileName = dto.Doc.FileName;
                        file.FileSize = (int?)dto.Doc.Length;

                        var fileId = await _fileService.Add(file);
                        data = await _appealService.Add(dto, fileId);
                    }
                    else
                        data = await _appealService.Add(dto, null);

                    response = new Response<int>()
                    {
                        Code = (int)HttpStatusCode.Created,
                        Data = data,
                        Success = true,
                        Message = "Məlumat yadda saxlanıldı!"
                    };
                }
                catch (Exception ex)
                {
                    response = new Response<int>()
                    {
                        Code = (int)HttpStatusCode.BadRequest,
                        Success = false,
                        Message = "Xəta yarandı!"
                    };
                }
            }
            return response;
        }

        [HttpPost]
        public async Task<Response<IEnumerable<AppealGetAllDto>>> GetAllAppeal(AppealRequestDto requestDto)
        {
            Response<IEnumerable<AppealGetAllDto>> response = new Response<IEnumerable<AppealGetAllDto>>();
            try
            {
                var appeal = await _appealService.GetAll(requestDto);

                response = new Response<IEnumerable<AppealGetAllDto>>()
                {
                    Code = (int)HttpStatusCode.OK,
                    Data = appeal,
                    Success = true,
                    Message = appeal.Count() != 0 ? "Məlumatlar uğurla gətirildi!" : "Məlumat tapılmadı!"
                };
            }
            catch (Exception ex)
            {
                response = new Response<IEnumerable<AppealGetAllDto>>()
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Success = false,
                    Message = "Xəta yarandı!"
                };
            }
            return response;
        }

        [HttpGet]
        public async Task<Response<AppealGetDto>> GetAppealById(int id)
        {
            Response<AppealGetDto> response = new Response<AppealGetDto>();
            try
            {
                var appeal = await _appealService.Get(id);
                response = new Response<AppealGetDto>()
                {
                    Code = (int)HttpStatusCode.OK,
                    Data = appeal,
                    Success = true,
                    Message = appeal != null ? "Məlumat uğurla gətirildi!" : "Məlumat tapılmadı!"
                };
            }
            catch (Exception)
            {
                response = new Response<AppealGetDto>()
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Success = false,
                    Message = "Xəta yarandı!"
                };
            }

            return response;
        }

        [HttpGet]
        public async Task<Response<IEnumerable<AppealTypeGetDto>>> GetAppealTypes()
        {
            Response<IEnumerable<AppealTypeGetDto>> response = new Response<IEnumerable<AppealTypeGetDto>>();
            try
            {
                var appealTypes = await _appealService.GetAllAppealTypes();

                response = new Response<IEnumerable<AppealTypeGetDto>>()
                {
                    Code = (int)HttpStatusCode.OK,
                    Data = appealTypes,
                    Success = true,
                    Message = appealTypes.Count() != 0 ? "Məlumatlar uğurla gətirildi!" : "Məlumat tapılmadı!"
                };
            }
            catch (Exception ex)
            {
                response = new Response<IEnumerable<AppealTypeGetDto>>()
                {
                    Code = (int)HttpStatusCode.BadRequest,
                    Success = false,
                    Message = "Xəta yarandı!"
                };
            }
            return response;
        }

        [HttpDelete]
        public async Task<Response<int>> Delete(int id)
        {
            Response<int> response = new Response<int>();
            try
            {
                await _appealService.Delete(id);

                response = new Response<int>()
                {
                    Code = (int)HttpStatusCode.OK,
                    Data = 0,
                    Success = true,
                    Message = "Məlumat silindi!"
                };
            }
            catch (Exception ex)
            {
                response = new Response<int>()
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
