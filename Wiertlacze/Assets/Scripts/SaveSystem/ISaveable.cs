public interface ISaveable<T>
{
    T OnSave();

    void OnLoad(T data);
}