using Cryptography;

namespace CryptographyTest
{
    /// <summary>
    /// 暗号化ライブラリのテスト
    /// </summary>
    [TestClass]
    public class CryptographyTest
    {
        /// <summary>
        /// パスワードの復元確認
        /// </summary>
        /// <remarks>
        /// 暗号化した文字列を復号し、暗号化前の文字列と同じか確認
        /// ※暗号化に使うインスタンスと復号に使うインスタンスが同じ
        /// </remarks>
        [TestMethod]
        public void Encription_Then_Decription_SameInstance()
        {
            // パスワード(平文)
            string plainText = "p@ssw0rd";

            // 暗号化
            ICipherAes cipher1 = new CipherAes();
            var encryptData = cipher1.Encrypt(plainText);

            // 復号
            var decryptData = cipher1.Decript(encryptData);

            Assert.AreEqual(decryptData, plainText);
        }

        /// <summary>
        /// パスワードの復元確認
        /// </summary>
        /// <remarks>
        /// 暗号化した文字列を復号し、暗号化前の文字列と同じか確認
        /// ※暗号化に使うインスタンスと復号に使うインスタンスが違う
        /// </remarks>
        [TestMethod]
        public void Encription_Then_Decription_DifferentInstance()
        {
            // パスワード(平文)
            string plainText = "p@ssw0rd";

            // 暗号化
            ICipherAes cipher1 = new CipherAes();
            var encryptData = cipher1.Encrypt(plainText);

            // 復号
            ICipherAes cypher2 = new CipherAes(cipher1.Key, cipher1.IV);
            var decryptData = cipher1.Decript(encryptData);

            Assert.AreEqual(decryptData, plainText);
        }

        /// <summary>
        /// AES暗号化の確認
        /// </summary>
        /// <remarks>
        /// 暗号化した文字列と、前もって用意した暗号化後文字列が同じか確認
        /// </remarks>
        [TestMethod]
        public void Encription()
        {
            // パスワード(平文)
            string plainText = "p@ssw0rd";

            // AES鍵
            string key = "/vPEPTPrrf34Eut1Vi5Sxg==";

            // 初期化ベクトル
            string iv = "ebCclVyI/cTT2df+V1OrQQ==";

            // パスワード(上記の平文/AES鍵/初期化ベクトルを使って暗号化後)
            string encryptPass = "BmajCFWSPGpl+yG8Eea9Cw==";

            // 暗号化
            ICipherAes cipher = new CipherAes(key, iv);
            var encryptData = cipher.Encrypt(plainText);

            Assert.AreEqual(encryptData, encryptPass);
        }

        /// <summary>
        /// AES復号の確認
        /// </summary>
        /// <remarks>
        /// 復号した文字列と、前もって用意した平文が同じか確認
        /// </remarks>
        [TestMethod]
        public void Decription()
        {
            // パスワード(平文)
            string plainText = "p@ssw0rd";

            // AES鍵
            string key = "/vPEPTPrrf34Eut1Vi5Sxg==";

            // 初期化ベクトル
            string iv = "ebCclVyI/cTT2df+V1OrQQ==";

            // パスワード(上記の平文/AES鍵/初期化ベクトルを使って暗号化後)
            string encryptPass = "BmajCFWSPGpl+yG8Eea9Cw==";

            // 復号
            ICipherAes cipher = new CipherAes(key, iv);
            var decriptData = cipher.Decript(encryptPass);

            Assert.AreEqual(decriptData, plainText);
        }

        /// <summary>
        /// AES鍵長の確認
        /// </summary>
        /// <remarks>
        /// 自動生成したAESの鍵長が192bit(24byte)か確認
        /// </remarks>
        [TestMethod]
        public void KeyLength()
        {
            // 復号
            ICipherAes cipher = new CipherAes();
            Assert.AreEqual(cipher.Key.Length, 24);
        }

        /// <summary>
        /// 初期化ベクトル長の確認
        /// </summary>
        /// <remarks>
        /// 自動生成したAESの初期化ベクトルが192bit(24byte)か確認
        /// </remarks>
        [TestMethod]
        public void IVLength()
        {
            // 復号
            ICipherAes cipher = new CipherAes();
            Assert.AreEqual(cipher.IV.Length, 24);
        }

        /// <summary>
        /// AES鍵の設定確認
        /// </summary>
        /// <remarks>
        /// 暗号化ライブラリのコンストラクタで設定したAES鍵と
        /// プロパティから取得できるAES鍵が同じか確認
        /// </remarks>
        [TestMethod]
        public void KeyProperty()
        {
            // AES鍵
            string key = "/vPEPTPrrf34Eut1Vi5Sxg==";

            // 初期化ベクトル
            string iv = "ebCclVyI/cTT2df+V1OrQQ==";

            ICipherAes cipher = new CipherAes(key, iv);
            Assert.AreEqual(cipher.Key, key);
        }

        /// <summary>
        /// 初期化ベクトルの設定確認
        /// </summary>
        /// <remarks>
        /// 暗号化ライブラリのコンストラクタで設定した初期化ベクトルと
        /// プロパティから取得できる初期化ベクトルが同じか確認
        /// </remarks>
        [TestMethod]
        public void IVProperty()
        {
            // AES鍵
            string key = "/vPEPTPrrf34Eut1Vi5Sxg==";

            // 初期化ベクトル
            string iv = "ebCclVyI/cTT2df+V1OrQQ==";

            ICipherAes cipher = new CipherAes(key, iv);
            Assert.AreEqual(cipher.IV, iv);
        }
    }
}