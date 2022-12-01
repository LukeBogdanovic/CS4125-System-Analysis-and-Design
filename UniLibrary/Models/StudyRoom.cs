using UniLibrary.Factories;
using UniLibrary.Models.RoomFunctionalities;


namespace UniLibrary.Models
{
public class StudyRoom : Room
    {
        protected override void InitializeFunctionality(){
            AddFunctionalities(new DisplayFunctionality(),
                                    new WhiteBoardFunctionality(),
                                    new PowerFunctionality(),
                                    new NoAccessibilityFunctionality());
        }
    }
}