using Application.GeminiAPI;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContentController : ControllerBase
    {
        private readonly GeminiContentService _geminiContentService;

        public ContentController()
        {
            // Replace "your-google-api-key" with your actual Google API key
            _geminiContentService = new GeminiContentService("AIzaSyBjSRUXlZnHh9oPyf1Zz3zAuCjqclvPo30");
        }

        [HttpPost("generate")]
        public async Task<IActionResult> Generate([FromBody] string prompt)
        {
            try
            {
                var result = await _geminiContentService.GenerateContent(prompt);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
