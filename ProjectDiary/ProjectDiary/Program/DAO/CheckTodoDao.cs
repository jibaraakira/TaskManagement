using ProjectDiary.Program.DTO;
using System.Collections.Generic;

namespace ProjectDiary.Program.DAO
{
    public class CheckTodoDao
    {
        internal static List<CheckRowTreeSource> GetTodoArray()
        {
            return new List<CheckRowTreeSource>()
            {
                new CheckRowTreeSource() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item1-1", IsExpanded = true, IsChecked = false, HierarchyPath = "0-0", HierarchyPathArray = new[] { 0, 0 } },
                new CheckRowTreeSource() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item1", IsExpanded = true, IsChecked = false, HierarchyPath = "0", HierarchyPathArray = new[] { 0 } },
                new CheckRowTreeSource() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item1-2", IsExpanded = true, IsChecked = false, HierarchyPath = "0-1", HierarchyPathArray = new[] { 0, 1 } },
                new CheckRowTreeSource() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item2", IsExpanded = false, IsChecked = false, HierarchyPath = "1", HierarchyPathArray = new[] { 1 } },
                new CheckRowTreeSource() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item2-2", IsExpanded = true, IsChecked = false, HierarchyPath = "1-1", HierarchyPathArray = new[] { 1, 1 } },
                new CheckRowTreeSource() { StartDate = "2020-11-11", EndDate = "2020-11-12", Text = "Item2-1", IsExpanded = true, IsChecked = false, HierarchyPath = "1-0", HierarchyPathArray = new[] { 1, 0 } },
            };
        }
    }
}
