using System;

namespace Cryptgraphy
{ 

/// <summary>
/// AES暗号化クラス
/// </summary>
public class CypherAES : ICypher
{
	private byte[] key { get; set; }	
	private byte[] iv { get; set; }

	/// <summary>
	/// コンストラクタ
	/// </summary>
	/// <param name="key">キー</param>
	/// <param name="iv">初期化ベクタ</param>
	public CypherAES(in byte[] key, in byte iv)
	{
		this.key = key;
		this.iv = iv;
	}
}

}
