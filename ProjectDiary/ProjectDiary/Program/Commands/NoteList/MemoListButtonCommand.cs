using ProjectDiary.Program.DTO;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectDiary.Program.Commands.NoteList
{
    /// <summary>
    /// メモ一覧に関わるボタンのコマンドです。
    /// </summary>
    internal class MemoListButtonCommand
    {
        /// <summary>
        /// メモ一覧のリストです。
        /// </summary>
        internal ObservableCollection<Note> memoList;

        /// <summary>
        /// メモ一覧を格納します。
        /// </summary>
        /// <param name="list"></param>
        internal void SetMemoList(ObservableCollection<Note> list)
        {
            memoList = list;
        }
    }
}
