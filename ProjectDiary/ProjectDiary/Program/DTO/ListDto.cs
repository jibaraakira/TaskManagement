namespace ProjectDiary.Program.DTO
{
    /// <summary>
    /// 一覧的に表示するDTO。
    /// </summary>
    public abstract class ListDto
    {
        /// <summary>
        /// インデックスを更新します。
        /// </summary>
        /// <param name="index">新しいインデックス番号。</param>
        public abstract void UpdateIndex(int index);
    }
}
