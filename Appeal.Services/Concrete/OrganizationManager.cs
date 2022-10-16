using Appeal.Data.Abstract;
using Appeal.Entities.Dtos.OrganizationDtos;
using Appeal.Services.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.Concrete
{
    public class OrganizationManager : IOrganizationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public OrganizationManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OrganizationGetAllDto>> GetOrganizationsByAppealTypeId(int appealTypeId)
        {
            try
            {
                var organizations = await _unitOfWork.OrganizationRepository.GetOrganizationsByAppealTypeId(appealTypeId);
                var organizationsDto = _mapper.Map<IEnumerable<OrganizationGetAllDto>>(organizations);

                return organizationsDto;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
        }
    }
}
