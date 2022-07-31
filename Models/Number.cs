namespace OnlineBingoAPI.Models
{
    public class Number
    {
        public int Num { get; set; }
        public bool Checked { get; set; }

        public Number(int num)
        {
            Num = num;
            Checked = false;
        }
    }
}
