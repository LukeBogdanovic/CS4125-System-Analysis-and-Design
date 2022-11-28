using UniLibrary.Factories;
using UniLibrary.Models.RoomFunctionalities;

namespace UniLibrary.Models
{
public class ComputerClassRoom : Room
    {

        public ComputerClassRoom()
        {
            Capacity = 18;
        }
        protected override void InitializeFunctionality(){
            AddFunctionalities(new ComputerClassFunctionality(),
                                    new DisplayFunctionality(),
                                    new WhiteBoardFunctionality(),
                                    new NoAccessibilityFunctionality());
        }
    }
}