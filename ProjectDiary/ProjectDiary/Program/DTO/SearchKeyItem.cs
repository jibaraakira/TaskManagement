namespace ProjectDiary.Program.DTO
{
    /// <summary>
    /// タスクの検索キーのクラスです。
    /// </summary>
    internal class SearchKeyItem
    {
        /// <summary>
        /// 選択した日付です。
        /// </summary>
        public string SelectedDate { get; set; }

        /// <summary>
        /// タスクの状態を検索する項目の列挙型です。
        /// </summary>
        public SelectedViewStatus ViewStatus { get; set; } = SelectedViewStatus.Defalut;
    }
}
