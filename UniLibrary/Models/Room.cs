// using System.ComponentModel.DataAnnotations;

// namespace MvcRoom.Models;

// abstract class Room
//     {
//         public int ID { get; set; }
//     }
//     class StudyRoom : Room
//     {
//     }
//     class MeetingRoom : Room
//     {
//     }
//     class ConferenceRoom : Room
//     {
//     }
//     class ComputerRoom : Room
//     {
//     }
//     abstract class Document
//     {
//         private List<Room> _Rooms = new List<Room>();
//         // Constructor calls abstract Factory method
//         public Document()
//         {
//             this.CreateRooms();
//         }
//         public List<Room> Rooms
//         {
//             get { return _Rooms; }
//         }
//         // Factory Method
//         public abstract void CreateRooms();
//     }
//     /// <summary>
//     /// A 'ConcreteCreator' class
//     /// </summary>
//     class Resume : Document
//     {
//         // Factory Method implementation
//         public override void CreateRooms()
//         {
//             Rooms.Add(new SkillsRoom());
//             Rooms.Add(new EducationRoom());
//             Rooms.Add(new ExperienceRoom());
//         }
//     }
//     /// <summary>
//     /// A 'ConcreteCreator' class
//     /// </summary>
//     class Report : Document
//     {
//         // Factory Method implementation
//         public override void CreateRooms()
//         {
//             Rooms.Add(new IntroductionRoom());
//             Rooms.Add(new ResultsRoom());
//             Rooms.Add(new ConclusionRoom());
//             Rooms.Add(new SummaryRoom());
//             Rooms.Add(new BibliographyRoom());
//         }
//     }
// }