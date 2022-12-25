using ProjectDiary.Program.DTO;
using System.Collections.Generic;

namespace ProjectDiary.Program.DAO
{
    /// <summary>
    /// データベースからチェックToDo一覧のデータを参照、追加、更新、削除をするDAOです。
    /// </summary>
    public class CheckTodoDao
    {
        /// <summary>
        /// チェックToDoのデータのリストを取得します。
        /// </summary>
        /// <returns>チェックToDoのデータのリスト。</returns>
        internal static List<CheckToDoTreeRow> GetTodoArray()
        {
            return new List<CheckToDoTreeRow>()
            {
                new CheckToDoTreeRow() { StartDate = "2020-11-11", StartTime="20:20:20", EndDate = "2020-11-12", EndTime="20:20:20", Text = "Item1-1", IsExpanded = true, IsChecked = false, HierarchyPath = "0-0", HierarchyPathArray = new[] { 0, 0 } },
                new CheckToDoTreeRow() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item1", IsExpanded = true, IsChecked = false, HierarchyPath = "0", HierarchyPathArray = new[] { 0 } },
                new CheckToDoTreeRow() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item1-2", IsExpanded = true, IsChecked = false, HierarchyPath = "0-1", HierarchyPathArray = new[] { 0, 1 } },
                new CheckToDoTreeRow() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item2", IsExpanded = false, IsChecked = false, HierarchyPath = "1", HierarchyPathArray = new[] { 1 } },
                new CheckToDoTreeRow() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item2-2", IsExpanded = true, IsChecked = false, HierarchyPath = "1-1", HierarchyPathArray = new[] { 1, 1 } },
                new CheckToDoTreeRow() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item2-1", IsExpanded = true, IsChecked = false, HierarchyPath = "1-0", HierarchyPathArray = new[] { 1, 0 } },
            };
        }
    }
}
