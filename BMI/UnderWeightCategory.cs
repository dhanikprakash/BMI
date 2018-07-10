namespace BMI
{
    public class UnderWeightCategory : ICategory
    {
        public float Lowerlimit { get; private set; }
        public float UpperLimit { get; private set; }
        public string Name { get; private set; }
        public UnderWeightCategory()
        {
            Lowerlimit = float.Parse("00.0");
            UpperLimit = float.Parse("18.5");
            Name = "Underweight";
        }
    }
}
