using System;
using System.Text;
using System.Security.Cryptography;

namespace Sandbox.Encryption.MD5
{
    public sealed class MD5CryptographyService : ICryptographyService
    {
        private readonly Func<HashAlgorithm> _hashAlgorithmFactory;

        public MD5CryptographyService(Func<HashAlgorithm> hashAlgorithmFactory)
        {
            _hashAlgorithmFactory = hashAlgorithmFactory;
        }

        public byte[] ComputeHash(string input)
        {
            var bytes = Encoding.UTF8.GetBytes(input);

            using (var algorithm = _hashAlgorithmFactory())
            {
                return algorithm.ComputeHash(bytes);
            }
        }
    }
}
