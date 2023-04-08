namespace Cryptography
{
    /// <summary>
    /// AES暗号化クラス
    /// </summary>
    public class CipherAes : ICipherAes
    {
        private ICipherAes cipher;

        /// <summary>
        /// 暗号鍵
        /// </summary>
        public string Key => this.cipher.Key;

        /// <summary>
        /// 初期化ベクトル
        /// </summary>
        public string IV => this.cipher.IV;

        /// <summary>
        /// AES暗号種別
        /// </summary>
        public enum CipherAesKind
        {
            /// <summary>
            /// .NET標準ライブラリ使用
            /// </summary>
            Dotnet
        }
        
        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="key">
        /// 暗号鍵
        /// 指定しない場合はランダム値を使用する。
        /// </param>
        /// <param name="iv">
        /// 初期化ベクトル
        /// 指定しない場合はランダム値を使用する。
        /// </param>
        /// <param name="kind">
        /// AES暗号化種別
        /// 指定しない場合は.NET標準ライブラリのAESクラスを使用
        /// </param>
        public CipherAes(
            in string? key = null,
            in string? iv = null,
            in CipherAesKind kind = CipherAesKind.Dotnet
            )
        {
            switch (kind)
            {
                case CipherAesKind.Dotnet:
                default:
                    this.cipher = new CipherAesDotnet(key, iv);
                    break;
            }
        }

        /// <summary>
        /// 入力データを暗号化する。
        /// </summary>
        /// <param name="plainData">暗号化前のデータ</param>
        /// <returns>
        /// 暗号化されたデータ
        /// </returns>
        public string Encrypt(in string plainData)
        {
            return this.cipher.Encrypt(plainData);
        }

        /// <summary>
        /// 入力データを複合化する。
        /// </summary>
        /// <param name="plainData">暗号化されたデータ</param>
        /// <returns>
        /// 複合化されたデータ
        /// </returns>
        public string Decript(in string cipherData)
        {
            return this.cipher.Decript(cipherData);
        }
    }
}
