using Library.Basket.API.Models;
using Library.Infra.Redis.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Library.Basket.API.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BasketController : ControllerBase
{
    const string CACHE_NAME = "Student_Basket";
    private readonly ICacheRepository _cacheRepository;
    public BasketController(ICacheRepository cacheRepository)
    {
        _cacheRepository = cacheRepository;
    }

    [HttpGet]
    [ProducesResponseType(typeof(StudentBasket), (int)HttpStatusCode.OK)]
    [Route("/api/v1/basket/student/{studentId}")]
    public async Task<ActionResult<StudentBasket>> GetBasketByStudentIdAsync(Guid studentId)
    {
        var studentBasket = await _cacheRepository
            .GetItemWithCustomKeyAsync<StudentBasket>(CACHE_NAME + "_" + studentId.ToString());

        return Ok(studentBasket);
    }

    [HttpPost]
    [ProducesResponseType(typeof(StudentBasket), (int)HttpStatusCode.OK)]
    [Route("/api/v1/basket")]
    public async Task<ActionResult<StudentBasket>> AddBasketAsync(StudentBasket studentBasket)
    {
        await _cacheRepository.SetItemAsync(
             studentBasket.StudentId.ToString(), CACHE_NAME, studentBasket);

        return Ok();
    }

    [HttpDelete]
    [ProducesResponseType(typeof(void), (int)HttpStatusCode.OK)]
    [Route("/api/basket/{id}")]
    public async Task<ActionResult> DeleteByStudentIdAsync(Guid id)
    {
        await _cacheRepository.RemoveAsync(id.ToString(), CACHE_NAME);
        return Ok();
    }
}