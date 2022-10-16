using Appeal.Data.Abstract;
using Appeal.Entities.Dtos.AppeatDtos;
using Appeal.Services.Abstract;
using Appeal.Shared.Utilities.Results.Concrete;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.Concrete
{
    public class AppealManager : IAppealService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AppealManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Add(AppealCreateDto dto, int? fileId)
        {
            try
            {
                var appeal = _mapper.Map<Appeal.Entities.Concretes.Appeal>(dto);
                int appealId = 0;
                if (dto.Id == 0)
                {
                    appeal.FileId = (int)fileId;
                    appeal.InsertedUser = 1; //User cedvelimiz olmadigi ucun statik id kimi 1 teyin etdim
                }
                else
                {
                    var currentAppeal = await Get(dto.Id);
                    appeal.FileId = (int)(dto.Doc==null?currentAppeal.FileId:fileId);
                    appeal.UpdatedUser = 1;
                } 
                appealId = await _unitOfWork.AppealRepository.AddAsync(appeal);

                return appealId;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }

        }

        public async Task Delete(int id)
        {
            try
            {
                await _unitOfWork.AppealRepository.DeleteAsync(id);
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
        }

        public async Task<AppealGetDto> Get(int id)
        {
            try
            {
                var appeal = await _unitOfWork.AppealRepository.GetByIdAsync(id);
                var appealDto = _mapper.Map<AppealGetDto>(appeal);

                return appealDto;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }

        }

        public async Task<IEnumerable<AppealGetAllDto>> GetAll(AppealRequestDto requestDto)
        {
            try
            {
                var appeals = await _unitOfWork.AppealRepository.GetAllAppealsAsync(requestDto);
                var appealsDto = _mapper.Map<IEnumerable<AppealGetAllDto>>(appeals);

                return appealsDto;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
        }

        public async Task<IEnumerable<AppealTypeGetDto>> GetAllAppealTypes()
        {
            try
            {
                var appealTypes = await _unitOfWork.AppealRepository.GetAllAppealTypesAsync();
                var appealTypesDto = _mapper.Map<IEnumerable<AppealTypeGetDto>>(appealTypes);

                return appealTypesDto;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
        }
    }
}
