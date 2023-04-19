namespace Concord.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Concord.Models;

[ApiController]
[Route("api/[controller]")]
public class ChannelController : ControllerBase
{
    private readonly DatabaseContext _context;

    public ChannelController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Channel>>> GetChannelItems()
    {
        return await _context.Channels.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Channel>> GetChannelItem(int id)
    {
        var channelItem = await _context.Channels.FindAsync(id);

        if (channelItem == null)
        {
            return NotFound();
        }

        return channelItem;
    }

    [HttpPost]
    public async Task<ActionResult<Channel>> PostChannelItem(Channel channel)
    {
        _context.Channels.Add(channel);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetChannelItem), new { id = channel.Id }, channel);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutChannelItem(int id, Channel channel)
    {
        if (id != channel.Id)
        {
            return BadRequest();
        }

        _context.Entry(channel).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteChannelItem(int id)
    {
        var channelItem = await _context.Channels.FindAsync(id);
        if (channelItem == null)
        {
            return NotFound();
        }

        _context.Channels.Remove(channelItem);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}