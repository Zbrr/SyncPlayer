
namespace SyncPlayer.Common.Contracts
{
    public interface IFileValidationRule<in T>
    {
        bool IsValidFile(T file, ValidationData validationData = null);
    }
}
