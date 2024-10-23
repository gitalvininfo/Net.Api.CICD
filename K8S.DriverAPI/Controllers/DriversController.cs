using K8S.DriverAPI.Data.Repositories.Interfaces;
using K8S.DriverAPI.DTOs.Requests;
using K8S.DriverAPI.DTOs.Responses;
using K8S.DriverAPI.Models;
using Mapster;
using Microsoft.AspNetCore.Mvc;

namespace K8S.DriverAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        protected readonly IUnitOfWork _unitOfWork;
        private readonly IConfiguration _configuration;

        public DriversController(IUnitOfWork unitOfWork, IConfiguration configuration)
        {
            _unitOfWork = unitOfWork;
            _configuration = configuration;
        }

        [HttpGet]
        [Route("{driverId:Guid}")]
        public async Task<IActionResult> GetDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver == null)
                return NotFound();

            var result = driver.Adapt<GetDriverResponse>();

            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _unitOfWork.Drivers.All();

            var result = drivers.Adapt<IEnumerable<GetDriverResponse>>();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDriver([FromBody] CreateDriverRequest driver)
        {
            if(!ModelState.IsValid)
                return BadRequest();

            var result = driver.Adapt<Driver>();

            await _unitOfWork.Drivers.Add(result);

            await _unitOfWork.CompleteAsync();

            return CreatedAtAction(nameof(GetDriver), new { driverId = result.Id }, result);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDriver([FromBody] UpdateDriverRequest driver)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = driver.Adapt<Driver>();

            await _unitOfWork.Drivers.Update(result);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpDelete("{driverId:Guid}")]
        public async Task<IActionResult> DeleteDriver(Guid driverId)
        {
            var driver = await _unitOfWork.Drivers.GetById(driverId);

            if (driver == null)
                return NotFound();

            await _unitOfWork.Drivers.Delete(driverId);

            await _unitOfWork.CompleteAsync();

            return NoContent();
        }

        [HttpGet("Test")]
        public IActionResult Test()
        {
            return Ok("Test connection works!");
        }

        [HttpGet("TestCICD")]
        public IActionResult TestCICD()
        {
            return Ok("CICD works!");
        }

        [HttpGet("TestSQL")]
        public IActionResult TestSQL()
        {
            return Ok("SQL works! CICD works!");
        }

    } 
}
