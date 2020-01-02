namespace DataRepository
{
    public interface ICategoryRepository
    {
        dynamic Insert(dynamic data);
        dynamic Update(dynamic data);
        dynamic Delete(dynamic data);
        dynamic GetData(dynamic data);
    }
}
