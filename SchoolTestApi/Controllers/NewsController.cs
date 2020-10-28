using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Models;


namespace Controllers{

[Route("api/[controller]")]
[ApiController]

public class NewsController : ControllerBase{
private readonly SchoolContext _context;

public NewsController(SchoolContext context)
{
    _context = context;
}
[HttpGet]
public async Task<ActionResult<IEnumerable<NewsEntity>>> GetNews()
{
    return await _context.NewsItems
        .Select(x => newsDTO(x))
        .ToListAsync();
}
[HttpGet("{id}")]
public async Task<ActionResult<NewsEntity>> GetNews(long id)
{
    var newsItem = await _context.NewsItems.FindAsync(id);

    if (newsItem == null)
    {
        return NotFound();
    }

    return newsDTO(newsItem);
}
 [HttpPost]
    public async Task<ActionResult<NewsEntity>> CreateNews(NewNewsEntityDTO newsItem)
    {
        var news = new NewsEntity
        {
            Title = newsItem.Title,
            Subtitle = newsItem.Subtitle,
            Content = newsItem.Content,
        };

        _context.NewsItems.Add(news);
        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetNews),
            new { id = news.Id },
            newsDTO(news));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteNews(long id)
    {
        var news = await _context.NewsItems.FindAsync(id);

        if (news == null)
        {
            return NotFound();
        }

        _context.NewsItems.Remove(news);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool NewsExists(long id) =>
         _context.NewsItems.Any(e => e.Id == id);

    private static NewsEntity newsDTO(NewsEntity newsItem) =>
        new NewsEntity
        {
            Id = newsItem.Id,
            Title = newsItem.Title,
            Subtitle = newsItem.Subtitle,
            Content = newsItem.Content,
        };       
    }

}