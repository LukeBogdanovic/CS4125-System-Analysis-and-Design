using UniLibrary.Models.Utilities;

namespace UniLibrary.Models
{

    class ConferenceRoom : Room
    {
        public Boolean ProjectorCapabilities {get; set;}
        public Boolean ZoomCapabilities {get; set;}
    }
}