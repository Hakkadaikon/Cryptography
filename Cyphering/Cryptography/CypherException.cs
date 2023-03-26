namespace Cryptography
{
    /// <summary>
    /// 暗号化クラス例外
    /// </summary>
    public class CypherException : Exception
    {
        public CypherException(string message) : base(message)
        {
        }

        public CypherException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}