using Appeal.Entities.Dtos.OrganizationDtos;
using Appeal.Services.Abstract;
using Appeal.Shared.Utilities.Results.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Appeal.WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private readonly IOrganizationService _organizationService;
        public OrganizationController(IOrganizationService organizationService)
        {
            _organizationService = organizationService;
        }
        [HttpGet]
        public async Task<Response<IEnumerable<OrganizationGetAllDto>>> GetOrganizationsByAppealTypeId(int appealTypeId)
        {
            Response<IEnumerable<OrganizationGetAllDto>> response = new Response<IEnumerable<OrganizationGetAllDto>>();
            try
            {
                var organizations = await _organizationService.GetOrganizationsByAppealTypeId(appealTypeId);
                response = new Response<IEnumerable<OrganizationGetAllDto>>()
                {
                    Code = (int)HttpStatusCode.OK,
                    Data = organizations,
                    Success = true,
                    Message = organizations.Count() != 0 ? "Məlumatlar uğurla gətirildi!" : "Məlumat tapılmadı!"
                };
            }
            catch (Exception ex)
            {
                response = new Response<IEnumerable<OrganizationGetAllDto>>()
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
