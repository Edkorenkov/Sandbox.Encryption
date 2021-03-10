using System;
using System.Web;

namespace Sandbox.Encryption.MD5
{
    public sealed class UrlEncodedMD5EncryptionService : IEncryptionService
    {
        private readonly ICryptographyService _cryptographyService;

        public UrlEncodedMD5EncryptionService(ICryptographyService cryptographyService)
        {
            _cryptographyService = cryptographyService;
        }

        public string Encrypt(string input)
        {
            var output = Convert.ToBase64String(
                _cryptographyService.ComputeHash(input));

            return HttpUtility.UrlEncode(output);
        }
    }
}
