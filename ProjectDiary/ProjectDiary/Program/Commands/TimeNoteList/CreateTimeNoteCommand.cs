using ProjectDiary.Program.Domains;
using ProjectDiary.Program.DTO;
using System;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.NoteList
{
    /// <summary>
    /// 時間列メモを追加するコマンドです。
    /// </summary>
    internal class CreateTimeNoteCommand : TimeNoteCmd, ICommand
    {
        /// <summary>
        /// 時間列メモの「消去」ボタンにバインドする、時間列メモを消去するコマンドです。
        /// </summary>
        private readonly DeleteTimeNoteCommand deleteCmd;

        /// <summary>
        /// イベントハンドラーです。
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// コマンドが実行可能な状況か否かを決定します。
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
            TimeNote newNote = new TimeNote() { 
                NoteIndex = memoList.Count, 
                NoteCreateTime = CustomDateTime.GetNowDateTime()
            };
            newNote.SetDeleteNoteComand(deleteCmd);
            memoList.Add(newNote);
        }

        /// <summary>
        /// コンストラクターです。
        /// </summary>
        /// <param name="cmd">時間列メモを消去するコマンド。</param>
        public CreateTimeNoteCommand(DeleteTimeNoteCommand cmd)
        {
            deleteCmd = cmd;
        }
    }
}
