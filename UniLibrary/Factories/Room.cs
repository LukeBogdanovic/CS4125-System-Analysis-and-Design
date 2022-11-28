using UniLibrary.Interfaces;
using UniLibrary.Models.Enums;
using UniLibrary.Models.RoomFunctionalities;

namespace UniLibrary.Factories
{

    public abstract class Room
    {
        public int ID { get; set; }
        public string? Name {get; set;}
        public int Capacity { get; set; } = 4;
        public int Floor {get; set;}

		public string Description{get; set;}
	
		private List<Functionality> _RoomFunctionalities ;

		protected Room()
		{
			_RoomFunctionalities = new List<Functionality>();
			InitializeFunctionality();
		}
    	protected abstract void InitializeFunctionality();
		public IEnumerable<Functionality> Functionalities => _RoomFunctionalities;

        protected void AddFunctionality(Functionality functionality)
		{
			if (!_RoomFunctionalities.Contains(functionality)) _RoomFunctionalities.Add(functionality);
		}
        protected void AddFunctionalities(params Functionality[] functionalities)
		{
			if (functionalities == null) throw new Exception("The functionalities cannot be null.");
			foreach(Functionality functionality in functionalities)
			{
				AddFunctionality(functionality);
			}
		}
    }

}
