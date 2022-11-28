using UniLibrary.Factories;
using UniLibrary.Models.RoomFunctionalities;

namespace UniLibrary.Models
{

    public class ConferenceRoom : Room
    {
        protected override void InitializeFunctionality(){
            AddFunctionalities(new DisplayFunctionality(),
                                    new ComputerFunctionality(),
                                    new ZoomFunctionality(),
                                    // new ConferenceFunctionality(),
                                    new NoAccessibilityFunctionality());
        }
    }
}