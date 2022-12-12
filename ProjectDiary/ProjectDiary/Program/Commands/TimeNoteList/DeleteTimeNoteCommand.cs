using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;


namespace ProjectDiary.Program.Commands.NoteList
{
    /// <summary>
    /// 時間列メモを消去するコマンドです。
    /// </summary>
    internal class DeleteTimeNoteCommand : TimeNoteCmd, ICommand
    {
        /// <summary>
        /// イベントハンドラーです。
        /// </summary>
        public event EventHandler CanExecuteChanged;

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
            MessageBoxResult result =
                MessageBox.Show(
                    "メモを消しますか？",
                    "確認",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning
                    );

            if (result == MessageBoxResult.OK)
            {
                var set = memoList.First(item => item.NoteIndex == (int)parameter);
                memoList.Remove(set);
            }
        }
    }
}
