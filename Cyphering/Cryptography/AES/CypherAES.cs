namespace Cryptography
{
    /// <summary>
    /// AES暗号化クラス
    /// </summary>
    public class CypherAES : ICypherAES
    {
        private ICypherAES cypher;

        /// <summary>
        /// 暗号鍵
        /// </summary>
        public string Key => this.cypher.Key;

        /// <summary>
        /// 初期化ベクトル
        /// </summary>
        public string IV => this.cypher.IV;

        /// <summary>
        /// AES暗号種別
        /// </summary>
        public enum eCypyherAESKind
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
        public CypherAES(
            in string? key = null,
            in string? iv = null,
            in eCypyherAESKind kind = eCypyherAESKind.Dotnet
            )
        {
            switch (kind)
            {
                case eCypyherAESKind.Dotnet:
                default:
                    this.cypher = new CypherAESDotnet(key, iv);
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
            return this.cypher.Encrypt(plainData);
        }

        /// <summary>
        /// 入力データを複合化する。
        /// </summary>
        /// <param name="plainData">暗号化されたデータ</param>
        /// <returns>
        /// 複合化されたデータ
        /// </returns>
        public string Decript(in string cypherData)
        {
            return this.cypher.Decript(cypherData);
        }
    }
}
