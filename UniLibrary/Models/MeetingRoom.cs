using UniLibrary.Factories;
using UniLibrary.Models.RoomFunctionalities;

namespace UniLibrary.Models
{
public class MeetingRoom : Room
    {
        protected override void InitializeFunctionality(){
            AddFunctionalities(new DisplayFunctionality(),new WhiteBoardFunctionality(),new ComputerFunctionality(),new ZoomFunctionality(),new NoAccessibilityFunctionality());
        }
    }
}