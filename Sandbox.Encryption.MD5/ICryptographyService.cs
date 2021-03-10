namespace Sandbox.Encryption.MD5
{
    public interface ICryptographyService
    {
        byte[] ComputeHash(string input);
    }
}
