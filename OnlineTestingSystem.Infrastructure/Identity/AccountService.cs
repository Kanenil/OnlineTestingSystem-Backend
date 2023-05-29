using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.Application.Contracts.Identity;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Application.Contracts.Persistence;
using OnlineTestingSystem.Application.DTOs.User;
using OnlineTestingSystem.Application.Exeptions;
using OnlineTestingSystem.Application.Models.Account;
using OnlineTestingSystem.Domain.Identity;
using OnlineTestingSystem.Infrastructure.Upload;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace OnlineTestingSystem.Infrastructure.Identity
{
    public class AccountService : IAccountService
    {
        private readonly UserManager<UserEntity> _userManager;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly IMapper _mapper;

        public AccountService(UserManager<UserEntity> userManager, IMapper mapper, IUnitOfWork unitOfWork, IUploadService uploadService)
        {
            _userManager = userManager;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _uploadService = uploadService;
        }

        public async Task<UserDTO> Profile(string username)
        {
            var user = await _unitOfWork.UsersRepository.GetUserByUsernameAsync(username);

            if (user == null)
                throw new NotFoundException("User", username);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task Logout(string username)
        {
            var user = await _userManager.FindByNameAsync(username);

            if (user == null)
                throw new BadRequestException($"User with '{username}' not exists.");

            var refUser = await _unitOfWork.UsersRepository.GetAsync(user.Id);
            refUser.RefreshToken = null;
            await _unitOfWork.Save();
        }

        public async Task EditProfile(string username, EditProfile model)
        {
            var user = await _unitOfWork.UsersRepository.GetUserByUsernameAsync(username);

            if (user == null)
                throw new NotFoundException("User", username);

            if(model.FirstName != user.FirstName)
                user.FirstName = model.FirstName;

            if (model.LastName != user.LastName)
                user.LastName = model.LastName;

            if (model.Image != null && user.Image != model.Image)
            {
                if(user.Image != null)
                    await _uploadService.RemoveFileAsync(user.Image);
                user.Image = model.Image;
            }

            if (model.BackgroundImage != null && user.BackgroundImage != model.BackgroundImage)
            {
                if(user.BackgroundImage != null)
                    await _uploadService.RemoveFileAsync(user.BackgroundImage);
                user.BackgroundImage = model.BackgroundImage;
            }

            await _unitOfWork.Save();
        }
    }
}
