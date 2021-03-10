using System.Linq;

namespace Sandbox.Encryption.MD5
{
    public sealed class HexMD5CEncryptionService : IEncryptionService
    {
        private readonly ICryptographyService _cryptographyService;

        public HexMD5CEncryptionService(ICryptographyService cryptographyService)
        {
            _cryptographyService = cryptographyService;
        }

        public string Encrypt(string input)
        {
            var output = _cryptographyService.ComputeHash(input)
                .Select(x => x.ToString("x2"))
                .ToList();

            return string.Join("", output);
        }
    }
}
