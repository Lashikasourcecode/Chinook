
using Chinook.Services;

namespace Chinook.Shared.Components
{
    public class ArtistViewComponent
    {
        private readonly ArtistService _artistService;
        public ArtistViewComponent( ArtistService artistService)
        {
            _artistService = artistService;

        }


    }
}
