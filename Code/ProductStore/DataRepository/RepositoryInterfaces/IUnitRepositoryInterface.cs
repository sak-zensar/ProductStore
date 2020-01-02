namespace DataRepository
{
    public interface IUnitRepositoryInterface
    {
        dynamic Insert(dynamic data);
        dynamic Update(dynamic data);
        dynamic Delete(dynamic data);
        dynamic GetData(dynamic data);
    }
}
