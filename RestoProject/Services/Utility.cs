using System.Text;
using System.Security.Cryptography;

namespace RestoProject.Services
{
  public static class Utility
  {
    public static string sha256(string pass)
    {
      var crypt = SHA256.Create();
      var hash = new StringBuilder();
      byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(pass));
      foreach (byte theByte in crypto)
      {
        hash.Append(theByte.ToString("x2"));
      }

      return hash.ToString();
    }
  }
}
