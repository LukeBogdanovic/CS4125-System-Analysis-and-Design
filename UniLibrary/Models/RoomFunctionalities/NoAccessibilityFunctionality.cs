using UniLibrary.Factories;
namespace UniLibrary.Models.RoomFunctionalities
{
    public class NoAccessibilityFunctionality : Functionality
    {

        public override string Name => "Not Accessible";

        public override string Description => "This room is not accessible for wheelchair users.";

    }
}