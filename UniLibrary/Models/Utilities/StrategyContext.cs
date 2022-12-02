using UniLibrary.Interfaces;

namespace UniLibrary.Models.Utilities
{

    public class StrategyContext
    {

        private IStrategy _strategy;

        public StrategyContext(IStrategy strategy)
        {
            _strategy = strategy;
        }

        public int executeStrategy(int bookStatus)
        {
            return _strategy.setBookStatus(bookStatus);
        }

    }

}