
using Chinook.Models;
using Chinook.Services;
using Microsoft.EntityFrameworkCore;

namespace Chinook.Services
{
    public class ArtistService:IArtistService
    {

        private readonly ChinookContext _chinookContext;
        private Playlist playList;
        private List<Playlist> validatePlayList;        
        private readonly ILogger _logger;
        private Artist searchArtistByName;
        private Artist getArtistById;

        public ArtistService(ChinookContext chinookContext,ILogger logger) 
        {
            _chinookContext = chinookContext;
            _logger = logger;

        }
        public async Task<Artist> GetArtistById(long artistId) 
        {
           
            getArtistById = await _chinookContext.Artists.Where(a => a.ArtistId == artistId).FirstAsync();
            return getArtistById;
        }

        public async Task<Artist> SearchArtistByName(string artistName)
        {
            searchArtistByName = await _chinookContext.Artists.Where(a => a.Name == artistName).FirstAsync();
            return searchArtistByName;
                                            
        }

        public async Task<int> DisplayNumberOfAlbum()
        {
            int numberOfAlbum = await _chinookContext.Albums.CountAsync();
            return numberOfAlbum;
        }

        
        public async Task<List<Playlist>> GetPlayList()
        {
            return await _chinookContext.Playlists.ToListAsync();
        }

        
        public async Task<Playlist> CreatePlayList(Playlist playList)
        {
            validatePlayList = await _chinookContext.Playlists.ToListAsync();
            int numberofPlayListAvailable = _chinookContext.Playlists.Where(p => p.Name == playList.Name).
                                            ToList().Count();
            if (numberofPlayListAvailable == 0)
            {
                _logger.LogInformation("This player already available");
            }
            else

                 _chinookContext.Playlists.Add(playList);
                 await _chinookContext.SaveChangesAsync();
                 return playList; 

        }


    }
}
