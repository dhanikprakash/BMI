namespace BMI
{
    public  class PreObesityCategory : ICategory
    {
        public float Lowerlimit { get; private set; }
        public float UpperLimit { get; private set; }
        public string Name { get; private set; }
        public PreObesityCategory()
        {
            Lowerlimit = float.Parse("25.0");
            UpperLimit = float.Parse("29.9");
            Name = "Pre-obesity";
        }
    }
}
