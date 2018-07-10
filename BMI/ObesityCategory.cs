namespace BMI
{
    public class ObesityCategory : ICategory
    {
        public float Lowerlimit { get; private set; }
        public float UpperLimit { get; private set; }
        public string Name { get; private set; }
        public ObesityCategory()
        {
            Lowerlimit = float.Parse("30.0");
            UpperLimit = float.Parse("34.9");
            Name = "Obesity class I";
        }
    }
}
