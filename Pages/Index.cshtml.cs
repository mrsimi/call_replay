using call_replay.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace call_replay.Pages;

public class IndexModel : PageModel
{
    private readonly ILogger<IndexModel> _logger;
    private readonly AppDbContext _context;
    private IHostingEnvironment _environment;


    [BindProperty]
    public List<AudioFile> AudioFiles {get; set;}

    [BindProperty]
    public UserViewModel UserViewModel {get; set;}

    public IndexModel(ILogger<IndexModel> logger, AppDbContext context, 
        IHostingEnvironment environment)
    {
        _logger = logger;
        _context = context;
        _environment = environment;
    }

    public async Task<IActionResult> OnGet()
    {
        var results = await _context.WishLogs
            .Select(m => new AudioFile{Id = m.Id, FileUrl = m.AudioFileUrl, WishingPerson = m.PersonWishing}).ToListAsync();

        AudioFiles = results.Count > 0 ?  results: new List<AudioFile>();

        return Page();
    }

    public IActionResult OnPost()
    {
        string extensionType = UserViewModel.Audio.FileName.Split(".")[1];
        string fileName = Guid.NewGuid().ToString("N")+$".{extensionType}";

        var audioFilePath = Path.Combine(_environment.WebRootPath, 
            "uploads", fileName);
        using(var fileStream = new FileStream(audioFilePath, FileMode.Create))
        {
            UserViewModel.Audio.CopyTo(fileStream);
        }

         var wishData = new WishLog
        {
            PersonWishing = UserViewModel.WishingPerson, 
            AudioFileUrl = "uploads/"+fileName
        };
        
        _context.WishLogs.Add(wishData);
        _context.SaveChanges();

        return RedirectToPage("Index");
    } 
}
