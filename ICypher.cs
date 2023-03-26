namespace Cryptgraphy
{

/// <summary>
/// 暗号化インターフェイス
/// </summary>
public interface ICypher
{
    /// <summary>
    /// 入力データを暗号化します。
    /// </summary>
    /// <param name="plainData">暗号化前のデータ</param>
    /// <returns>
    /// 暗号化結果
    /// 第一要素 : 成功可否(true:成功 false:失敗)
    /// 第二要素 : 暗号化されたデータ(失敗時:null)
    /// </returns>
    public (bool, byte[]) Encrypt(in byte[] plainData);

    /// <summary>
    /// 入力データを複合化します。
    /// </summary>
    /// <param name="plainData">暗号化前のデータ</param>
    /// <returns>
    /// 複合化結果
    /// 第一要素 : 成功可否(true:成功 false:失敗)
    /// 第二要素 : 複合化されたデータ(失敗時:null)
    /// </returns>
    public (bool, byte[]) Decript(in byte[] cypherData);
}

}
