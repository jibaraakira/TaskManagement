using ProjectDiary.Program.Commands.FixedNoteList;
using ProjectDiary.Program.DTO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectDiary.Program.ViewModelPart
{
    /// <summary>
    /// 固定メモの部分にバインドするビューモデルです。
    /// </summary>
    internal class FixedMemoViewModelPart
    {
        /// <summary>
        /// メモ一覧への表示のためのコレクションです。
        /// </summary>
        public ObservableCollection<FixedNote> FixedNoteList { get; set; }

        /// <summary>
        /// 一覧にメモを追加するためのコマンドです。
        /// </summary>
        public CreateFixedNoteCommand CreateFixedNoteCmd { get; set; } = new CreateFixedNoteCommand();

        /// <summary>
        /// 一覧のメモを消去する処理ためのコマンドです。
        /// </summary>
        public DeleteParagraphCommand DeleteParagraphCmd { get; set; } = new DeleteParagraphCommand();

        /// <summary>
        /// 初期設定です。
        /// </summary>
        /// <param name="fixNotes">固定メモのリスト。</param>
        internal void SetDefalut(List<FixedNote> fixNotes)
        {
            
            FixedNoteList = 
                new ObservableCollection<FixedNote>(
                   fixNotes.Select(item => {
                       item.DeleteParagraphCommand = DeleteParagraphCmd;
                       return item;
                   })
                );

            CreateFixedNoteCmd.SetDefalut(FixedNoteList);
            DeleteParagraphCmd.SetDefalut(FixedNoteList);
        }
    }
}
