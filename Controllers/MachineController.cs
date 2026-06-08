using MachineMaster.Models;
using MachineMaster.Services;
using MachineMaster.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace MachineMaster.Controllers
{

	[ApiController]
	[Route("api/[controller]")]
	public class MachineController : Controller
	{
		private readonly IMachineService _machineService;

		public MachineController(IMachineService machineService)
		{
			_machineService = machineService;
		}

		[HttpGet]
		public async Task<IActionResult> GetAllAsync()
		{
			var data = await _machineService.GetAllAsync();

			return Ok(data);
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetById(int id)
		{
			var data = await _machineService.GetByIdAsync(id);

			if (data == null)
				return NotFound();

			return Ok(data);
		}

		[HttpPost]
		public async Task<IActionResult> Create(Machine machine)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			try
			{
				var result = await _machineService.CreateAsync(machine);

				return Ok(result);
			}
			catch (Exception ex)
			{
				return BadRequest(new
				{
					message = ex.Message
				});
			}
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> Delete(int id)
		{
			var result = await _machineService.DeleteAsync(id);

			if (!result)
				return NotFound();

			return Ok();
		}

		[HttpGet("search")]
		public async Task<IActionResult> Search([FromQuery] string? keyword)
		{
			var result = await _machineService.SearchAsync(keyword);

			return Ok(result);
		}
	}
}
