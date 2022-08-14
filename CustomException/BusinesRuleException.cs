using System;

namespace OnlineBingoAPI.CustomException
{
    public class BusinesRuleException : Exception
    {
        public BusinesRuleException()
        {

        }

        public BusinesRuleException(string message)
        : base(message)
        {
        }

        public BusinesRuleException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
