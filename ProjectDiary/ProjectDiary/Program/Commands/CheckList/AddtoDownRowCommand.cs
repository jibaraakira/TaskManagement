using System;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.CheckList
{
    /// <summary>
    ///  選択した行の１つ下に行を追加するためのボタンのコマンドです。
    /// </summary>
    public class AddToDownRowCommand : RowCmdBase, ICommand
    {
        /// <summary>
        /// イベントハンドラーです。
        /// </summary>
        public event EventHandler CanExecuteChanged;

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

            SetSeparatedPath((string)parameter);

            SetTargetRowIndexAndCollection(CheckList);

            AddToTDownOfSelectedItem(int.Parse(pathNumArray[hieracheFloor]));

            ResetHierarchyPath(CheckList);

            hieracheFloor = 0;
        }

        /// <summary>
        /// 選択した行の上に行を追加します。
        /// </summary>
        private void AddToTDownOfSelectedItem(int selectedRowIndex)
        {

            var newRow = GetNewCheckListRow();

            if (selectedRowIndex ==  SelectedRowList.Count -1 )
            {
                SelectedRowList.Add(
                   newRow
                   );
            }
            else
            {
                SelectedRowList.Insert(
                   selectedRowIndex + 1,
                   newRow
                   );
            }
        }
    }
}
