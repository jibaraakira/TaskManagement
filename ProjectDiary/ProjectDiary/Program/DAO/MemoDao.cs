using ProjectDiary.Program.DTO;
using System.Collections.Generic;

namespace ProjectDiary.Program.DAO
{
    /// <summary>
    /// データベースから時間列メモのデータを参照、追加、更新、削除をするDAOです。
    /// </summary>
    internal class SequenceNoteDao
    {
        /// <summary>
        /// 時間列メモのデータのリストを取得します。
        /// </summary>
        /// <returns>時間列メモのデータのリスト。</returns>
        internal static List<TimeNote> GetTimeNoteArray()
        {
            return new List<TimeNote>()
            {
                // 色データをObservableCollectionに設定
                new TimeNote {NoteIndex = 0, NoteCreateTime = "2022-12-02　13:07:53", NoteText = "asdfaaaaaaaaaaaadsadfasdfsadfasdf" },
                new TimeNote {NoteIndex = 1},
                new TimeNote {NoteIndex = 2},
            };
        }
    }
}