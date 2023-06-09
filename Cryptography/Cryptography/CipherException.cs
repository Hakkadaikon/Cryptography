﻿namespace Cryptography
{
    /// <summary>
    /// 暗号化クラス例外
    /// </summary>
    public class CipherException : Exception
    {
        public CipherException(string message) : base(message)
        {
        }

        public CipherException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}