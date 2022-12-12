using System;
using System.Windows;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.TaskList
{
    /// <summary>
    /// タスク一覧で選んだ行のタスクデータを消去します。
    /// </summary>
    internal class DeleteTaskComnnand : TaskCmd, ICommand
    {
        /// <summary>
        /// ビューを消去するメソッドです。
        /// </summary>
        private Action deleteAction;

        /// <summary>
        /// 選択した行のインデックス値を変更するためのメソッドです。
        /// </summary>
        private Func<bool> checkSelectedIndexFunc;

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
            if (!checkSelectedIndexFunc()) return;

            MessageBoxResult result =
            MessageBox.Show(
                "選択したタスクを消しますか？",
                "確認",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Warning
                );

            if (result == MessageBoxResult.OK)
            {
                deleteAction();
            }     
        }

        /// <summary>
        /// メソッドを追加します。
        /// </summary>
        /// <param name="deleteView">ビューを消去するメソッド。</param>
        /// <param name="checkFunc">選択した行のインデックス値を変更するためのメソッド。</param>
        internal void SetMethods(Action deleteView, Func<bool> checkFunc)
        {

            deleteAction = deleteView;
            checkSelectedIndexFunc = checkFunc;
        }
    }
}
