using ProjectDiary.Program.DTO;
using System.Windows;
using System.Windows.Controls;

namespace ProjectDiary
{
    /// <summary>
    /// ツリー状に表示されるチェックリストの項目のxamlです。
    /// </summary>
    public partial class CheckTreeView : TreeView
    {
        /// <summary>
        /// コンストラクターです。
        /// </summary>
        public CheckTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// チェックボックスをクリックした時のイベントです。
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var checkBox = (CheckBox)sender;
            var source = (CheckToDoTreeRow)checkBox.DataContext;

            source.UpdateChildStatus();
        }
    }

}
