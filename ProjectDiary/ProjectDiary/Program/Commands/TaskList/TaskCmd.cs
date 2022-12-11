using ProjectDiary.Program.DTO;
using System.Collections.ObjectModel;
using System.Windows.Controls;

namespace ProjectDiary.Program.Commands.TaskList
{

    /// <summary>
    /// タスクのコマンドの親クラスです。
    /// </summary>
    internal class TaskCmd
    {
        /// <summary>
        /// タスクに一覧的に表示するデーターグリッド。
        /// </summary>
        internal ObservableCollection<WorkTask> TaskList { get; private set; }

        internal int selectedIndex;

        /// <summary>
        /// タスクに一覧的に表示するデーターグリッドを格納します。
        /// </summary>
        /// <param name="taskList">タスクのリスト。</param>
        internal  void SetTaskViewListValues(ObservableCollection<WorkTask> taskList, int index)
        {
            TaskList = taskList;
            selectedIndex = index;
        }
    }
}
