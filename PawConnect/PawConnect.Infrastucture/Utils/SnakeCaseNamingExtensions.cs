using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace PawConnect.Infrastucture.Utils;

public static class SnakeCaseNamingExtensions
{
    public static void ConvertToSnakeCase(ModelBuilder modelBuilder)
    {
        foreach (var entity in modelBuilder.Model.GetEntityTypes())
        {
            // Table name
            entity.SetTableName(ToSnakeCase(entity.GetTableName()));

            // Regular columns
            foreach (var property in entity.GetProperties())
            {
                property.SetColumnName(ToSnakeCase(property.GetColumnBaseName()));
            }

            foreach (var complex in entity.GetComplexProperties())
            {
                ApplyComplexSnakeCase(complex, parentPrefix: null);
            }
        }
    }

    // Recursively walk complex types and set full column names to snake_case.
    private static void ApplyComplexSnakeCase(IMutableComplexProperty complex, string? parentPrefix)
    {
        // Build the prefix path like "Address" or "ShippingAddress_Street"
        var prefix = string.IsNullOrEmpty(parentPrefix)
            ? complex.Name
            : $"{parentPrefix}_{complex.Name}";

        // Leaf scalar properties of this complex type
        foreach (var prop in complex.ComplexType.GetProperties())
        {
            var leaf = prop.GetColumnName(); // usually the simple property name (e.g. "Street")
            var full = string.IsNullOrEmpty(prefix) ? leaf : $"{prefix}_{leaf}";
            var name = full.Replace("__", "_");
            if (!string.IsNullOrEmpty(name))
                prop.SetColumnName(ToSnakeCase(name));
        }

        // Nested complex types
        foreach (var nested in complex.ComplexType.GetComplexProperties())
        {
            ApplyComplexSnakeCase(nested, prefix);
        }
    }

    private static string ToSnakeCase(string name)
    {
        if (string.IsNullOrEmpty(name))
            return name;

        var sb = new StringBuilder();
        for (var i = 0; i < name.Length; i++)
        {
            var c = name[i];
            if (char.IsUpper(c))
            {
                if (i > 0) sb.Append('_');
                sb.Append(char.ToLowerInvariant(c));
            }
            else
            {
                sb.Append(c);
            }
        }
        return sb.Replace("__", "_").ToString();
    }
}