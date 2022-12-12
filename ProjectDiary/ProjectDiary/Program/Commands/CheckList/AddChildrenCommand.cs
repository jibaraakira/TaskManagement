using System.Windows;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.CheckList
{
    /// <summary>
    /// 選択した行に子の行を追加するボタンのコマンドのクラスです。
    /// </summary>
    public class AddChildrenCommand : RowCmdBase, ICommand
    {
        public bool CanExecute(object parameter)
        {
            return true;
        }
        public void Execute(object parameter)
        {
            SetSeparatedPath((string)parameter);

            AddChidlrenItem();

            ResetHierarchyPath(CheckList);

            hieracheFloor = 0;
        }

        private void AddChidlrenItem()
        {
            var setChildren = GetRow(CheckList);

            setChildren.SetChild(GetNewCheckListRow());

            setChildren.AddChildButtonVisible = Visibility.Hidden;
        }
    }
}