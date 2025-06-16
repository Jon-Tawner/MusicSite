using Microsoft.EntityFrameworkCore;
using MusicSite.Data;
using MusicSite.Models;

namespace MusicSite.Services
{
    public class SongService
    {
        private readonly AppDbContext _dbContext;
        private readonly string _songsDirectory;

        public SongService(AppDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _songsDirectory =
                Environment.GetEnvironmentVariable("SONGS_DIRECTORY") ??
                configuration.GetValue<string>("SongsDirectory") ?? string.Empty;
        }

        public async Task SyncAsync()
        {
            if (string.IsNullOrWhiteSpace(_songsDirectory) || !Directory.Exists(_songsDirectory))
            {
                return;
            }

            var files = Directory.EnumerateFiles(_songsDirectory, "*.mp3");
            foreach (var file in files)
            {
                var fileName = Path.GetFileNameWithoutExtension(file);
                var existing = await _dbContext.Songs.FirstOrDefaultAsync(s => s.FilePath == file);
                if (existing == null)
                {
                    _dbContext.Songs.Add(new Song
                    {
                        Title = fileName,
                        Artist = "Unknown",
                        FilePath = file
                    });
                }
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Song>> GetSongsAsync() => await _dbContext.Songs.ToListAsync();
    }
}
