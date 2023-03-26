using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace Cryptography
{
    /// <summary>
    /// AES暗号化(.NET標準ライブラリ使用)クラス
    /// </summary>
    public class CypherAESDotnet : ICypherAES
    {
        private byte[] _key = new byte[16];
        private byte[] _iv = new byte[16];

        [Required]
        public string Key
        {
            get => Convert.ToBase64String(this._key);
            private set
            {
                this._key = Convert.FromBase64String(value);
            }
        }

        [Required]
        public string IV
        {
            get => Convert.ToBase64String(this._iv);
            private set
            {
                this._iv = Convert.FromBase64String(value);
            }
        }

        public CypherAESDotnet(in string? key = null, in string? iv = null)
        {
            try
            {
                using var rng = RandomNumberGenerator.Create();
                if (key == null)
                {
                    rng.GetBytes(this._key);
                }
                else
                {
                    this.Key = key;
                }

                if (iv == null)
                {
                    this._iv = new byte[this._key.Length];
                    rng.GetBytes(this._iv);
                }
                else
                {
                    this.IV = iv;
                }
            }
            catch (Exception ex)
            {
                throw new CypherException("Failed to AES initialize.", ex);
            }
        }

        /// <summary>
        /// AES情報を格納する。
        /// </summary>
        /// <param name="aes">格納先</param>
        private void SetAESInfo(in Aes aes)
        {
            aes.Key = this._key;
            aes.IV = this._iv;
            aes.Mode = CipherMode.CBC;
            aes.Padding = PaddingMode.PKCS7;
        }

        public string Encrypt(in string plainData)
        {
            try
            {
                using Aes aes = Aes.Create();
                SetAESInfo(aes);
                using MemoryStream ms = new MemoryStream();
                using CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(), CryptoStreamMode.Write);
                cs.Write(System.Text.Encoding.ASCII.GetBytes(plainData), 0, plainData.Length);
                cs.FlushFinalBlock();

                return Convert.ToBase64String(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw new CypherException("Failed to encript.", ex);
            }
        }

        public string Decript(in string cypherData)
        {
            try
            {
                using Aes aes = Aes.Create();
                SetAESInfo(aes);

                var cypherArray = Convert.FromBase64String(cypherData);

                using MemoryStream ms = new MemoryStream();
                using CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(), CryptoStreamMode.Write);
                cs.Write(cypherArray, 0, cypherArray.Length);
                cs.FlushFinalBlock();

                return System.Text.Encoding.ASCII.GetString(ms.ToArray());
            }
            catch (Exception ex)
            {
                throw new CypherException("Failed to decript.", ex);
            }
        }
    }
}