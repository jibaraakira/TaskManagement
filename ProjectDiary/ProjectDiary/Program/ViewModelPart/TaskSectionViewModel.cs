using ProjectDiary.Program.Commands.TaskList;
using ProjectDiary.Program.DTO;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ProjectDiary.Program.ViewModelPart
{
    /// <summary>
    /// タスク一覧の部分にバインドするビューモデルです。
    /// </summary>
    internal class WorkTaskViewModelPart : INotifyPropertyChanged
    {
        /// <summary>
        /// タスク一覧への表示のためのコレクションです。
        /// </summary>
        public ObservableCollection<WorkTask> TaskList { get; set; }

        /// <summary>
        /// 選択したチェックリストの行の一つ上に追加する処理のためのコマンドです。
        /// </summary>
        public DeleteTaskComnnand DeleteTaskCmd { get; set; } = new DeleteTaskComnnand();

        /// <summary>
        /// 行のインデックス値。
        /// </summary>
        private int _selectedIndex;

        /// <summary>
        /// 行のインデックス値のプロパティです。
        /// </summary>
        public int SelectedIndex
        {
            get { return _selectedIndex; }
            set
            {
                _selectedIndex = value;
                OnPropertyChanged("SelectedIndex");

            }
        }

        /// <summary>
        /// プロパティが変更されたときに発生するイベントをハンドルします。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// コンストラクターです。
        /// </summary>
        public WorkTaskViewModelPart()
        {

            DeleteTaskCmd.SetTaskViewListValues(TaskList, SelectedIndex);
            DeleteTaskCmd.SetAction(DeleteView, CheckSelectedIndex);
        }

        /// <summary>
        /// 選択した行を削除します。
        /// </summary>
        private void DeleteView()
        {
            TaskList.RemoveAt(SelectedIndex);
        }

        /// <summary>
        /// 行のインデックス値を調べます。
        /// </summary>
        /// <returns>適正ならtrue。不適ならfalse。</returns>
        private bool CheckSelectedIndex()
        {
            if (SelectedIndex < 0) return false;
            if (TaskList.Count == SelectedIndex) return false;

            return true;
        }

        /// <summary>
        /// プロパティが変化したことを通知します。
        /// </summary>
        /// <param name="name">プロパティ名。</param>
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}