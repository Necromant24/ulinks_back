using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace UsefulLinksBackend;

public static class Storage
{

    public static string Salt { get; set; } = "some_salt";
    public static string Login { get; set; }
    public static string Password { get; set; }
    public static string Token { get; set; }
    
    public static List<string> AllTags { get; set; }


    public static void ComputeAndSetToken(string login, string password)
    {
        byte[] loginBytes = Encoding.UTF8.GetBytes(login);
        byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
        byte[] saltBytes = Encoding.UTF8.GetBytes(Salt);
        
        byte[] concat = new byte[loginBytes.Length + saltBytes.Length + passwordBytes.Length];
        System.Buffer.BlockCopy(loginBytes, 0, concat, 0, loginBytes.Length);
        System.Buffer.BlockCopy(saltBytes , 0, concat, loginBytes.Length, saltBytes .Length);
        System.Buffer.BlockCopy(passwordBytes , 0, concat, loginBytes.Length+saltBytes.Length, passwordBytes.Length);
        
        
        SHA256Managed hash = new SHA256Managed();
        
        byte[] tHashBytes = hash.ComputeHash(concat);

        
        Token = System.Text.Encoding.ASCII.GetString(tHashBytes);;
    }
    
    
    // private string GenerateToken()
    // {
    //     
    //
    // }
    
}