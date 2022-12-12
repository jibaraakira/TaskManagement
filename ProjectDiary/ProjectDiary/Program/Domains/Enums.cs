namespace ProjectDiary.Program
{

    /// <summary>
    /// タスクの状態の列挙型です。
    /// </summary>
    public enum Status
    {
        /// <summary>
        /// 未着手
        /// </summary>
        Waiting = 0,

        /// <summary>
        /// 保留
        /// </summary>
        Pending = 1,

        /// <summary>
        /// 進行中
        /// </summary>
        Working = 2,

        /// <summary>
        /// 完了
        /// </summary>
        Done = 3,

        /// <summary>
        /// 中止
        /// </summary>
        Stop = 4,

    }
    
    /// <summary>
    /// タスクの状態を検索する項目の列挙型です。
    /// </summary>
    public enum SelectedViewStatus
    {
        /// <summary>
        /// 未着手と、保留と進行中
        /// </summary>
        Defalut,

        /// <summary>
        /// 完了と中止
        /// </summary>
        DoneAndStop,

        /// <summary>
        /// 未着手
        /// </summary>
        Waiting,

        /// <summary>
        /// 保留
        /// </summary>
        Pending,

        /// <summary>
        /// 進行中
        /// </summary>
        Working,

        /// <summary>
        /// 完了
        /// </summary>
        Done,

        /// <summary>
        /// 中止
        /// </summary>
        Stop ,
    }

}
