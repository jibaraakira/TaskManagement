namespace ProjectDiary.Program.DTO
{
    /// <summary>
    /// タスクです。
    /// </summary>
    public class WorkTask
    {
        /// <summary>
        /// タスク名
        /// </summary>
        public string TaskName { get; set; } = "";

        /// <summary>
        /// 開始日付。
        /// </summary>
        public string StartDate { get; set; } = "";

        /// <summary>
        /// 開始時間。
        /// </summary>
        public string StartTime { get; set; } = "";

        /// <summary>
        /// 終了日付。
        /// </summary>
        public string EndtDate { get; set; } = "";

        /// <summary>
        /// 終了時間。
        /// </summary>
        public string EndTime { get; set; } = "";

        /// <summary>
        /// ステータス
        /// </summary>
        public Status Status { get; set; } = Status.Waiting;
    }
}
