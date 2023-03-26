namespace Cryptography
{
    /// <summary>
    /// AES暗号化インターフェイス
    /// </summary>
    public interface ICypherAES : ICypher
    {
        /// <summary>
        /// 暗号鍵
        /// </summary>
        public string Key { get; }

        /// <summary>
        /// 初期化ベクトル
        /// </summary>
        public string IV { get; }
    }
}