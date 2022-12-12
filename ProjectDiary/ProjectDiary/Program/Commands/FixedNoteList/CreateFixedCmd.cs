using ProjectDiary.Program.DTO;
using System.Collections.ObjectModel;

namespace ProjectDiary.Program.Commands.FixedNoteList
{
    /// <summary>
    /// 固定メモ一覧に関するコマンドです。
    /// </summary>
    public class CreateFixedCmd
    {
        /// <summary>
        /// 固定メモ一覧の表示のためのコレクションです。
        /// </summary>
        public ObservableCollection<FixedNote> fixedNoteList;

        /// <summary>
        /// 固定メモ一覧の表示のためのコレクションを格納します。
        /// </summary>
        /// <param name="list">固定メモ一覧の表示のためのコレクション。</param>
        public void SetDefalut(ObservableCollection<FixedNote> list)
        {
            fixedNoteList = list;
        }

    }
}