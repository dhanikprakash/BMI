namespace BMI.BusinessLayer
{
    public interface IBMICalulator
    {
        BMIResponse Calculate(string jsonRequest);
    }
}
