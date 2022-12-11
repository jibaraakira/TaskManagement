using ProjectDiary.Program.DTO;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection.Metadata;
using System.Windows;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.TaskList
{
    /// <summary>
    /// 選んだタスクを消去します。
    /// </summary>
    internal class DeleteTaskComnnand : TaskCmd, ICommand
    {
        Action deleteAction;
        Func<bool> checkSelectedIndexFunc;


        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return true;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="parameter"></param>
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

        internal void SetAction(Action deleteView, Func<bool> checkFunc)
        {

            deleteAction = deleteView;
            checkSelectedIndexFunc = checkFunc;
        }
    }
}
