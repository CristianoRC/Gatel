namespace Model.ValueObjects
{
    public class Result
    {
        public Box Box { get; set; }
        public string Plate { get; set; }
        public Vehicle Vehicle { get; set; }
        public double Score { get; set; }
        public double Dscore { get; set; }
    }
}