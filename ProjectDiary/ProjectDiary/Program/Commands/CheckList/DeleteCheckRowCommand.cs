using System;
using System.Windows;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.CheckList
{
    /// <summary>
    ///　
    /// </summary>
    public class DeleteCheckRowCommand : RowCmdBase, ICommand
    {

        /// <summary>
        /// イベントハンドラーです。
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
            MessageBoxResult result =
            MessageBox.Show(
                "選択したチェック項目を消しますか？",
                "確認",
                MessageBoxButton.OKCancel,
                MessageBoxImage.Warning
                );

            if (result == MessageBoxResult.OK)
            {
                SetSeparatedPath((string)parameter);

                SetTargetRowIndexAndCollection(CheckList);

                DelteItem();

                ResetHierarchyPath(CheckList);

                hieracheFloor = 0;

            }
        }

        private void DelteItem()
        {
            var selectedRowIndex = int.Parse(pathNumArray[hieracheFloor]);
            SelectedRowList.RemoveAt(selectedRowIndex);
        }
    }
}

