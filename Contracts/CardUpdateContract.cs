using System.Collections.Generic;

namespace OnlineBingoAPI.Contracts
{
    public class CardUpdateContract
    {
        public int ReferenceId { get; set; }
        public IList<NumberReadContract> Numbers { get; set; }
    }
}
