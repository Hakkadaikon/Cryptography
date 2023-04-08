namespace Cryptography
{
    /// <summary>
    /// 暗号化インターフェイス
    /// </summary>
    public interface ICipher
    {
        /// <summary>
        /// 入力データを暗号化する。
        /// </summary>
        /// <param name="plainData">暗号化前のデータ</param>
        /// <returns>
        /// 暗号化されたデータ
        /// </returns>
        /// <exception cref="CipherException">
        /// </exception>
        public string Encrypt(in string plainData);

        /// <summary>
        /// 入力データを複合化する。
        /// </summary>
        /// <param name="cipherData">暗号化されたデータ</param>
        /// <returns>
        /// 複合化されたデータ
        /// </returns>
        /// <exception cref="CipherException">
        /// </exception>
        public string Decript(in string cipherData);
    }
}
