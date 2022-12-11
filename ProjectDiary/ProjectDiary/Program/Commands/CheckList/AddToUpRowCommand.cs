using ProjectDiary.Program.Domains;
using System;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.CheckList
{
    /// <summary>
    ///  選択した行の１つ上に行を追加するためのボタンのコマンドです。
    /// </summary>
    public class AddToUpRowCommand : RowCmdBase, ICommand
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

            AddToTopOfSelectedItem(int.Parse(pathNumArray[hieracheFloor]));

            ResetHierarchyPath(CheckList);

            hieracheFloor = 0;
        }

        /// <summary>
        /// 選択した行の上に行を追加します。
        /// </summary>
        private void AddToTopOfSelectedItem(int selectedRowIndex)
        {

            var newRow = GetNewCheckListRow();

            if (SelectedRowList.Count == 0)
            {
                SelectedRowList.Add(
                   newRow
                   );
            }
            else
            {
                SelectedRowList.Insert(
                   selectedRowIndex,
                   newRow
                   );
            }
        }
    }
}
