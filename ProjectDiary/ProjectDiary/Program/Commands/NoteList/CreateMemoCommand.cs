using ProjectDiary.Program.Domains;
using ProjectDiary.Program.DTO;
using System;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.NoteList
{
    /// <summary>
    /// 「メモ追加」ボタンがクリックした時の処理を発行するコマンドです。
    /// </summary>
    internal class CreateMemoCommand : MemoListButtonCommand, ICommand
    {

        /// <summary>
        /// イベントハンドラーです。
        /// </summary>
        public event EventHandler CanExecuteChanged;


        private DeleteNoteCommand deleteCmd;


        public CreateMemoCommand(DeleteNoteCommand cmd)
        {
            deleteCmd = cmd;
        }

        /// <summary>
        /// コマンドが実行可能な状況か否かをけっています。
        /// </summary>
        /// <param name="parameter">パラメーター。</param>
        /// <returns>可能ならtrue、不可能ならfalse。</returns>

        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// コマンドが実行した時のメソッドです。
        /// </summary>
        /// <param name="parameter">パラメーター。</param>
        public void Execute(object parameter)
        {
            // メモ一覧を表示するためのリストボックスにメモを追加して、スクロールを一番下に下げます。
            var newNoteIndex = memoList.Count;
            Note newNote = new Note() { NoteIndex = newNoteIndex, NoteCreateTime = CustomDateTime.GetNowDateTime() };
            newNote.SetDeleteNoteComand(deleteCmd);
            memoList.Add(newNote);
        }
    }
}
