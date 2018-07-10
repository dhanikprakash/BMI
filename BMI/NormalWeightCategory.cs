namespace BMI
{
    public class NormalWeightCategory : ICategory
    {
        public float Lowerlimit { get; private set; }
        public float UpperLimit { get; private set; }
        public string Name { get; private set; }
        public NormalWeightCategory()
        {
            Lowerlimit = float.Parse("18.5");
            UpperLimit = float.Parse("24.9");
            Name = "Normal weight";
        }

    }
}
