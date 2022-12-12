using ProjectDiary.Program.DTO;
using System.Collections.Generic;

namespace ProjectDiary.Program.DAO
{
    /// <summary>
    /// データベースから固定メモのデータを参照、追加、更新、削除をするDAOです。
    /// </summary>
    public class FixedSequenceNoteDao
    {
        /// <summary>
        /// 固定メモのデータのリストを取得します。
        /// </summary>
        /// <returns>固定メモのデータのリスト。</returns>
        internal static List<FixedNote> GetFixedNoteArray()
        {
            return new List<FixedNote>()
            {
                new FixedNote()
                {
                    Headline="abcd",
                    ParagraphIndex = 0,
                    ParagraphText="kkdkdkdkkdk"
                },
                new FixedNote()
                {
                    Headline="efgh",
                    ParagraphIndex = 1,
                    ParagraphText = "ijkl"
                }
            };
        }
    }
}