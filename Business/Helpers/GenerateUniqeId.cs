
namespace Business.Helpers;

public class GenerateUniqeId
{
    public static string GenerateId()
    {
        return Guid.NewGuid().ToString();
    }
}
