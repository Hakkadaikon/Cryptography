using Cryptography;

/// <summary>
/// エントリポイント
/// </summary>
internal class Program
{
    /// <summary>
    /// エントリポイント
    /// </summary>
    /// <param name="args">引数</param>
    public static void Main(String[] args)
    {
        // 暗号化する文字列
        string plainText1 = "test";
        string plainText2 = "testaaatest";

        CypherTest(plainText1);
        CypherTest(plainText2);
    }

    /// <summary>
    /// 暗号化テスト
    /// </summary>
    /// <param name="plainText">暗号化対象文字列</param>
    private static void CypherTest(in string plainText)
    {
        try
        {
            Console.WriteLine("Cypher test");
            Console.WriteLine("--------------------------------");
            Console.WriteLine("plain data  :{0}", plainText);

            // 暗号化
            ICypherAES cypher1 = new CypherAES();
            var encryptData = cypher1.Encrypt(plainText);

            // 複合化
            ICypherAES cypher2 = new CypherAES(cypher1.Key, cypher1.IV);
            var decryptData = cypher2.Decript(encryptData);

            Console.WriteLine("Encrypt data:{0}", encryptData);
            Console.WriteLine("         Key:{0}", cypher1.Key);
            Console.WriteLine("         IV :{0}", cypher1.IV);
            Console.WriteLine("Decrypt data:{0}", decryptData);
            Console.WriteLine("--------------------------------");
        }
        catch (CypherException ex)
        {
            Console.WriteLine("Error!");
            Console.WriteLine(ex.ToString());
            Console.WriteLine("--------------------------------");
        }
    }
}