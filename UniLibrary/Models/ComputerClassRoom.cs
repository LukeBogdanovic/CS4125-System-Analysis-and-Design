using UniLibrary.Factories;
using UniLibrary.Models.RoomFunctionalities;

namespace UniLibrary.Models
{
    public class ComputerClassRoom : Room
    {

        protected override void InitializeFunctionality()
        {
            AddFunctionalities(new ComputerClassFunctionality(),
                                    new DisplayFunctionality(),
                                    new WhiteBoardFunctionality(),
                                    new NoAccessibilityFunctionality());
        }
    }
}