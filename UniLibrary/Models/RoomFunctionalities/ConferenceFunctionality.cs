using UniLibrary.Factories;
namespace UniLibrary.Models.RoomFunctionalities
{
    public class ConferenceFunctionality : Functionality
    {

        public override string Name => "Conference";

        public override string Description => "This room can host conferences and board meetings. This is only available for library staff and university staff";

    }
}