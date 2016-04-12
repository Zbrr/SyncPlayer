
namespace SyncPlayer.Common.Contracts
{
    public interface IFileValidationService<T>
    {
        T[] FilterFiles(T[] filesMetadatas, ValidationData validationData);

        bool IsValidFile(T file, ValidationData validationData);
    }
}
