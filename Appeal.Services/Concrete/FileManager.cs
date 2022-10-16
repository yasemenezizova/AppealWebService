using Appeal.Data.Abstract;
using Appeal.Entities.Dtos.FileDtos;
using Appeal.Services.Abstract;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Appeal.Services.Concrete
{
    public class FileManager : IFileService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileManager(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> Add(Entities.Concretes.File entity)
        {
            try
            {
                entity.InsertedUser = 1;                    
                var addedFile = await _unitOfWork.FileRepository.AddAsync(entity);
                return addedFile;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
        }

        public async Task<FileGetDto> Get(int id)
        {
            try
            {
                var file = await _unitOfWork.FileRepository.GetByIdAsync(id);
                var fileDto = _mapper.Map<FileGetDto>(file);
                fileDto.Content = Convert.ToBase64String(file.FileContent);
                return fileDto;
            }
            catch (Exception)
            {
                throw new Exception("Xəta yarandı!");
            }
        }
    }
}
