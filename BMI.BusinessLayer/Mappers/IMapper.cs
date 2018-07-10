namespace BMI.BusinessLayer.Mappers
{
    public interface IMapper <out T, in U>
    {
        T Map(U source);
    }
}
