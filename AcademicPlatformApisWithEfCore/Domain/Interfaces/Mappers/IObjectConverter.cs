namespace AcademicPlatformApisWithEfCore.Domain.Interfaces.Mappers
{
    public interface IObjectConverter
    {
        T Map<T>(object obj);
    }
}
