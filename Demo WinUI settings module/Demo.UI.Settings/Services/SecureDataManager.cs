using System;
using System.Security.Cryptography;
using System.Text;
using Windows.Storage;

namespace Demo.UI.Settings.Services;

/// <summary>
/// Provides methods for securely managing data, such as connection strings.
/// </summary>
internal static class SecureDataManager
{
    private const string ENTROPY = "SET_YOUR_OWN_ENTROPY";
    private const string CONNECTION_STRING_KEY = "ConnectionString";

    /// <summary>
    /// Saves the connection string securely.
    /// </summary>
    /// <param name="connectionString">The connection string to save.</param>
    internal static void SaveConnectionString(string connectionString)
    {
        byte[] encryptedData = ProtectedData.Protect(
            Encoding.UTF8.GetBytes(connectionString),
            Encoding.UTF8.GetBytes(ENTROPY),
            DataProtectionScope.CurrentUser
        );
        string encryptedConnectionString = Convert.ToBase64String(encryptedData);

        var localSettings = ApplicationData.Current.LocalSettings;
        localSettings.Values[CONNECTION_STRING_KEY] = encryptedConnectionString;
    }

    /// <summary>
    /// Retrieves the connection string securely.
    /// </summary>
    /// <returns>The decrypted connection string, or null if not found.</returns>
    internal static string? GetConnectionString()
    {
        var localSettings = ApplicationData.Current.LocalSettings;
        if (
            localSettings.Values.TryGetValue(
                CONNECTION_STRING_KEY,
                out object? encryptedConnectionString
            )
        )
        {
            byte[] encryptedData = Convert.FromBase64String((string)encryptedConnectionString);
            byte[] decryptedData = ProtectedData.Unprotect(
                encryptedData,
                Encoding.UTF8.GetBytes(ENTROPY),
                DataProtectionScope.CurrentUser
            );
            return Encoding.UTF8.GetString(decryptedData);
        }
        return null;
    }
}
