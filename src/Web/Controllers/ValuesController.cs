using Microsoft.AspNetCore.Mvc;

namespace Web.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        return Ok(new string[] { "value1", "value2", "value3" });
    }

    [HttpGet("{id}")]
    public ActionResult<string> Get(int id)
    {
        if (id < 1 || id > 10)
        {
            return NotFound($"Value with ID {id} not found.");
        }

        return Ok($"value{id}");
    }

    [HttpPost]
    public ActionResult<string> Post([FromBody] string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return BadRequest("Value cannot be empty.");
        }

        return CreatedAtAction(nameof(Get), new { id = 1 }, value);
    }

    [HttpPut("{id}")]
    public ActionResult Put(int id, [FromBody] string value)
    {
        if (string.IsNullOrEmpty(value))
        {
            return BadRequest("Value cannot be empty.");
        }

        if (id < 1 || id > 10)
        {
            return NotFound($"Value with ID {id} not found.");
        }

        return Ok($"Updated value{id} to: {value}");
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(int id)
    {
        if (id < 1 || id > 10)
        {
            return NotFound($"Value with ID {id} not found.");
        }

        return Ok($"Deleted value{id}");
    }
}