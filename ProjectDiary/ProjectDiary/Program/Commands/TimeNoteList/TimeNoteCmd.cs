using ProjectDiary.Program.DTO;
using System.Collections.ObjectModel;

namespace ProjectDiary.Program.Commands.NoteList
{
    /// <summary>
    /// 時間列メモ一覧に関わるボタンのコマンドです。
    /// </summary>
    internal class TimeNoteCmd
    {
        /// <summary>
        /// 時間列メモ一覧のリストです。
        /// </summary>
        internal ObservableCollection<TimeNote> memoList;

        /// <summary>
        /// 時間列メモ一覧を格納します。
        /// </summary>
        /// <param name="list"> 時間列メモのリスト。</param>
        internal void SetMemoList(ObservableCollection<TimeNote> list)
        {
            memoList = list;
        }
    }
}
