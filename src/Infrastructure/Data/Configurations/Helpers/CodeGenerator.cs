using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;

namespace Kore.Infrastructure.Data.Configurations.Helpers;
public class CodeGenerator : ValueGenerator<string>
{
    public override string Next(EntityEntry entry)
    {
        string prefix = "1";
        return $"{prefix}{Guid.NewGuid()}";
    }
    public override bool GeneratesTemporaryValues => false;
}
