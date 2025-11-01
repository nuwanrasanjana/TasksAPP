using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Tasks.Application.DTOs;
using Tasks.Application.Interfaces.Services;
using Tasks.Domain.Entities;

namespace Tasks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IValidator<RegisterRequest> _registerValidator;
        private readonly IValidator<LoginRequest> _loginValidator;
        

        public AuthController(IUserService userService, IValidator<RegisterRequest> registerValidator, IValidator<LoginRequest> loginValidator)
        {
            _userService = userService;
            _registerValidator = registerValidator;
            _loginValidator = loginValidator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest req)
        {
            var validationResult = await _registerValidator.ValidateAsync(req);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            var user = await _userService.CreateAsync(req);
            return Ok(new {Id = user.Id, Email = user.Email});
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var validationResult = await _loginValidator.ValidateAsync(req);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(e => e.ErrorMessage));
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.GetByEmailAsync(req.Username);
            if (user == null) return NotFound("Email not found.");

            var verifyResult = _userService.VerifyPasswordAsync(user, req.Password);
            if (verifyResult == PasswordVerificationResult.Failed)
            {
                return Unauthorized("Invalid credentials.");
            }
            return Ok(new { user.Id, user.Email });
        }
    }
}
