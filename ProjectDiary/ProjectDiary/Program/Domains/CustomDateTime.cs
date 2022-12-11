using System;

namespace ProjectDiary.Program.Domains
{
    /// <summary>
    /// カスタムした
    /// </summary>
    internal class CustomDateTime
    {
        /// <summary>
        /// 日付のフォーマットです。
        /// </summary>
        private static readonly string dateFormat = "yyyy-MM-dd";

        /// <summary>
        /// 時間のフォーマットです。
        /// </summary>
        private static readonly string timeFormat = "HH:mm:ss";

        /// <summary>
        /// 現在の日付と時間を取得します。
        /// </summary>
        /// <returns>現在の日付と時間を一緒にした文字列。</returns>
        internal static string GetNowDateTime()
        {
            return DateTime.Now.ToString($"{dateFormat} {timeFormat}");
        }

        /// <summary>
        /// 現在の日付を取得します。
        /// </summary>
        /// <returns>現在の日付を取得します。</returns>
        internal static string GetNowDate() => DateTime.Now.ToString($"{dateFormat}");
    }
}
