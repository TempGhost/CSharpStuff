namespace MyPractice.Code
{

    public class Info
    {
        public string Word { get; set; }
        public int Count { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            return string.Format("{0} times: {1}", Count, Word);
        }
    }
}