using ProjectDiary.Program.DTO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace ProjectDiary.Program
{
    /// <summary>
    /// 画面要素用の拡張メソッドを収めた拡張クラスです。
    /// </summary>
    internal static class ElementExtends
    {
        /// <summary>
        /// リストボックスが最後の項目が見えるようにスクロールします。
        /// </summary>
        /// <param name="listBox">リストボックス。</param>
        public static void ScrollEnd(this ListBox listBox)
        {
            listBox.SelectedIndex = listBox.Items.Count - 1;
            listBox.ScrollIntoView(listBox.SelectedItem);

        }
    }

    /// <summary>
    /// コレクションのの拡張メソッドを収めた拡張クラスです。
    /// </summary>
    internal static class CollectionExtension
    {
        /// <summary>
        /// 木構造のリストを作成します。
        /// </summary>
        /// <param name="parentList">親となるリスト</param>
        /// <param name="downList">子になるリスト</param>
        /// <param name="floor">階層。</param>
        public static void CreateTree(this ObservableCollection<CheckRowTreeSource> parentList , IEnumerable<CheckRowTreeSource> downList, int floor = 0) 
        {
            if (!downList.Any())
            {
                return;
            }

            var setItemsInThisFoor =
                    downList
                        .Where(item => item.HierarchyPathArray.Length == floor + 1)
                        .ToList();

             setItemsInThisFoor.Sort((a, b) => {

                 int aNum = a.HierarchyPath[floor];
                 int bNum = b.HierarchyPath[floor];

                 return aNum - bNum ;
                });

            foreach (var (item, index) in setItemsInThisFoor.Select((i, v)=>(i, v)))
            {
                var downDownList = downList.Where(item => item.HierarchyPathArray.Length >= floor + 2 && item.HierarchyPathArray[floor] == index);

                item.AddChildButtonVisible =
                        downDownList.Count() == 0 ?
                        Visibility.Visible :
                        Visibility.Hidden;

                parentList.Add(item);
                item.GetChild().CreateTree(downDownList, floor + 1);
            }

        }

        /// <summary>
        /// リストが変化した時の動的なデータコレクションとしてコレクションを返します。
        /// </summary>
        /// <typeparam name="T">コレクションの要素の型。</typeparam>
        /// <param name="collection">元になるコレクション。</param>
        /// <returns></returns>
        public static ObservableCollection<T> ToObservableCollection<T>(this IEnumerable<T> collection)
        {
            return new ObservableCollection<T>(collection);
        }

        /// <summary>
        /// コレクションのディープコピーを返します。
        /// </summary>
        /// <typeparam name="T">コレクションの要素の型</typeparam>
        /// <param name="src">コピー元のコレクション。</param>
        /// <returns></returns>
        public static T DeepClone<T>(this T src)
        {
            using var memoryStream = new System.IO.MemoryStream();
            var binaryFormatter
              = new System.Runtime.Serialization
                    .Formatters.Binary.BinaryFormatter();
            binaryFormatter.Serialize(memoryStream, src); // シリアライズ
            memoryStream.Seek(0, System.IO.SeekOrigin.Begin);
            return (T)binaryFormatter.Deserialize(memoryStream); // デシリアライズ
        }
    }
}
