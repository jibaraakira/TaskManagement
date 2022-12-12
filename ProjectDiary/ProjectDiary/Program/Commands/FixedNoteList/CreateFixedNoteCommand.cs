using System;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.FixedNoteList
{
    /// <summary>
    /// 固定メモの段落を追加するためのコマンドです。
    /// </summary>
    public class CreateParagraphCommand: CreateFixedCmd, ICommand
    {

        private readonly DeleteParagraphCommand deleteParagraphCmd;

        /// <summary>
        /// イベントハンドラーです。
        /// </summary>
        public event EventHandler CanExecuteChanged;


        public CreateParagraphCommand(DeleteParagraphCommand command)
        {
            deleteParagraphCmd = command;
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
            fixedNoteList.Add(
                new DTO.FixedNote()
                {
                    DeleteParagraphCommand = deleteParagraphCmd,
                    ParagraphIndex = fixedNoteList.Count,
                }
                );
        }
    }
}