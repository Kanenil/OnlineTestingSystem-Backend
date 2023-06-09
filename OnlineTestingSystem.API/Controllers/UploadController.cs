﻿using Amazon.S3;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineTestingSystem.Application.Contracts.Infrastructure;
using OnlineTestingSystem.Application.Models.Upload;

namespace OnlineTestingSystem.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class UploadController : ControllerBase
{
    private readonly IUploadService _uploadService;

    public UploadController(IUploadService uploadService)
    {
        _uploadService = uploadService;
    }

    [HttpPost("upload")]
    public async Task<ActionResult<UploadFileResult>> Upload(IFormFile file)
    {
        return Ok(await _uploadService.UploadFileAsync(file));
    }

}
