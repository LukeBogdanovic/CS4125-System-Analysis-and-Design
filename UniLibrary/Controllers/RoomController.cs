using UniLibrary.Interfaces;
using UniLibrary.Models;
using UniLibrary.Factories;
using UniLibrary.ViewModels;

namespace UniLibrary.Controllers
{

    public class RoomsController : Controller
    {

        private readonly IRoomService _roomService;

        public RoomsController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        public async Task<IActionResult> Index()
        {
            var rooms = await _roomService.GetAllRoomsAsync(filter: null, orderBy: x => x.OrderBy(x => x.Name), m => m.Name!, m => m.Floor, m => m.Capacity);
            return View(rooms);
        }

        public async Task<IActionResult> Create()
        {
            await Task.CompletedTask;
            return View();
        }

        // [HttpPost,ValidateAntiForgeryToken]
        // public async Task<IActionResult> (RoomViewModel model)
        // {
        //     Room room = getRoom(model.Room.ID)
        //         {
        //             ID = model.Room.ID,
        //             Name = model.BookDetails.Description,
        //             Capacity = model.BookDetails.ISBN,
        //             Floor = model.BookDetails.Title,
        //         };
        // }

        // [HttpDelete]
    }

}