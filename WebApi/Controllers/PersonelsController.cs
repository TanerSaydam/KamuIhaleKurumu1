using EntityFrameworkCorePagination.Nuget.Pagination;
using FluentValidation;
using GenericFileService.Files;
using KIKWebApi.Authorization;
using KIKWebApi.DTOs;
using KIKWebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KIKWebApi.Controllers;

[Route("api/[controller]/[action]")]
//[Authorize(AuthenticationSchemes ="Bearer")]
[ApiController]
public class PersonelsController : ControllerBase
{
    private readonly IValidator<CreatePersonelDto> _validator;
    private readonly IValidator<UpdatePersonelDto> _updateValidator;

    public PersonelsController(IValidator<CreatePersonelDto> validator, IValidator<UpdatePersonelDto> updateValidator)
    {
        _validator = validator;
        _updateValidator = updateValidator;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(Constants.Personels);
    }

    [HttpGet]
    public IActionResult GetAllWithPagination(PaginationRequest request)
    {
        var response = Constants.Personels
            .AsQueryable()
            .Where(p =>
            p.Name.ToLower().Contains(request.Search.ToLower()) ||
            p.LastName.ToLower().Contains(request.Search.ToLower()) ||
            p.Profession.ToLower().Contains(request.Search.ToLower())
            )
            .ToPagedListAsync(request.PageNumber, request.PageSize);

        return Ok(response);
    }

    [HttpPost]
    public IActionResult Create(CreatePersonelDto request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return StatusCode(403, validationResult.Errors);
        }

        Personel personel =
            Constants.Personels
            .Where(p =>
            p.Name.ToLower() == request.Name.ToLower() &&
            p.LastName.ToLower() == request.LastName ||
            p.Profession.ToLower() == request.Profession)
            .FirstOrDefault();

        if (personel != null) throw new Exception("Bu personel daha önce kaydedilmiş");

        personel = new()
        {
            Name = request.Name.ToLower(),
            LastName = request.LastName.ToLower(),
            Profession = request.Profession.ToLower(),
            Salary = request.Salary,
            LeavingDate = request.LeavingDate,
            StartingDate = request.StartingDate,
            LeavingStatus = request.LeavingStatus
        };

        Constants.Personels.Add(personel);

        return NoContent();
    }

    [HttpPost]
    public IActionResult CreateWithImage([FromForm] CreatePersonelWithFileDto request)
    {
        var validationResult = _validator.Validate(request);

        if (!validationResult.IsValid)
        {
            return StatusCode(403, validationResult.Errors);
        }

        Personel personel =
            Constants.Personels
            .Where(p =>
            p.Name.ToLower() == request.Name.ToLower() &&
            p.LastName.ToLower() == request.LastName ||
            p.Profession.ToLower() == request.Profession)
            .FirstOrDefault();

        if (personel != null) throw new Exception("Bu personel daha önce kaydedilmiş");

        string fileName = FileService.FileSaveToServer(request.Image, "./wwwroot/images/");

        personel = new()
        {
            Name = request.Name.ToLower(),
            LastName = request.LastName.ToLower(),
            Profession = request.Profession.ToLower(),
            Salary = request.Salary,
            LeavingDate = request.LeavingDate,
            StartingDate = request.StartingDate,
            ImageUrl = fileName,
            LeavingStatus = request.LeavingStatus
        };

        Constants.Personels.Add(personel);

        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult RemoveById(string id)
    {
        Personel personel = Constants.Personels.FirstOrDefault(p => p.Id == id);
        if (personel == null) throw new Exception("Personel bulunamadı!");

        Constants.Personels.Remove(personel);
        return NoContent();
    }

    [HttpPost]
    public IActionResult Update(UpdatePersonelDto request)
    {
        var validationResult = _updateValidator.Validate(request);

        if (!validationResult.IsValid)
        {
            return StatusCode(403, validationResult.Errors);
        }

        Personel personel =
            Constants.Personels
            .Where(p =>
            p.Id == request.Id)
            .FirstOrDefault();

        if (personel == null) throw new Exception("Personel kaydı bulunamadı!");

        Personel updatePersonel = new()
        {
            Id = request.Id,
            Name = request.Name.ToLower(),
            LastName = request.LastName.ToLower(),
            Profession = request.Profession.ToLower(),
            Salary = request.Salary,
            ImageUrl = personel.ImageUrl,
            LeavingDate = request.LeavingDate,
            StartingDate = request.StartingDate,
            LeavingStatus = request.LeavingStatus
        };

        Constants.Personels.Remove(personel);
        Constants.Personels.Add(updatePersonel);

        return NoContent();
    }
}