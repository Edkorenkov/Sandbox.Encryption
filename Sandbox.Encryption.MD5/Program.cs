using System;
using System.Security.Cryptography;
using Microsoft.Extensions.DependencyInjection;

namespace Sandbox.Encryption.MD5
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<HashAlgorithm, MD5CryptoServiceProvider>()
                .AddSingleton<Func<HashAlgorithm>>(x => x.GetRequiredService<HashAlgorithm>)
                .AddSingleton<ICryptographyService, MD5CryptographyService>()
                .AddSingleton<IEncryptionService, HexMD5CEncryptionService>()
                .AddSingleton<IEncryptionService, UrlEncodedMD5EncryptionService>()
                .BuildServiceProvider();

            var hexMD5 = serviceProvider.GetEncryptionService<IEncryptionService>("HexMD5");
            var urlEncodedMD5 = serviceProvider.GetEncryptionService<IEncryptionService>("UrlEncodedMD5");

            var input = "Plain text to encrypt";
            
            Console.WriteLine(hexMD5.Encrypt(input));

            Console.WriteLine(urlEncodedMD5.Encrypt(input));

            Console.ReadLine();
        }
    }
}
