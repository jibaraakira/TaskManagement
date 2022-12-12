using ProjectDiary.Program.Domains;
using ProjectDiary.Program.DTO;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectDiary.Program.Commands.CheckList
{
    public class RowCmdBase
    {
        #region フィールド
        /// <summary>
        /// チェックリストの内容を持つコレクション。
        /// </summary>
        internal ObservableCollection<CheckToDoTreeRow> CheckList;

        /// <summary>
        /// 
        /// </summary>
        internal ObservableCollection<CheckToDoTreeRow> SelectedRowList;

        /// <summary>
        /// 
        /// </summary>
        public event EventHandler CanExecuteChanged;

        /// <summary>
        /// 階層の深さを示す数値。
        /// </summary>
        internal int hieracheFloor = 0;

        /// <summary>
        /// 階層のパスをデリミタごとに分けた文字型の配列です。
        /// </summary>
        internal string[] pathNumArray;

        internal CheckListCommandSet cmdSet;

        #endregion

        #region フィールドにセットをする
        /// <summary>
        /// チェックリストの内容を持つコレクションをセットします。
        /// </summary>
        /// <param name="noteList">チェックリストの内容を持つコレクション。</param>
        internal void SetCheckList(ObservableCollection<CheckToDoTreeRow> list)
        {
            CheckList = list;
        }

        /// <summary>
        /// チェックリストの行の持つ階層のパスを文字型の配列として格納します。
        /// </summary>
        /// <param name="path">チェックリストの行の持つ階層のパス</param>
        internal void SetSeparatedPath(string path)
        {
            pathNumArray = path.Split("-");
        }

        internal void SetAllCommand(CheckListCommandSet cmds)
        {
            cmdSet = cmds;
        }

        #endregion

        #region リストを再帰的に操作する処理

        /// <summary>
        /// 再帰的な処理で、チェック行の情報を取得します。
        /// </summary>
        /// <param name="list">リスト</param>
        /// <returns>チェック行の情報</returns>
        internal CheckToDoTreeRow GetRow(ObservableCollection<CheckToDoTreeRow> list)
        {
            // もし、現在より深い階層のチェック行の情報が取得できる場合、再帰的に取得する。
            if (hieracheFloor < pathNumArray.Length - 1)
            {
                int index = int.Parse(pathNumArray[hieracheFloor]);
                hieracheFloor++;
                return GetRow(list[index].GetChild());
            }
            else
            {
                // ターゲットのチェック行の情報を返します。
                if (list != null)
                {
                    return list[int.Parse(pathNumArray[hieracheFloor])];
                }
                else
                {
                    return new CheckToDoTreeRow();
                }
            }
        }

        /// <summary>
        /// 選択したチェックリストの行が格納されているコレクションを取得します。
        /// </summary>
        /// <param name="list"></param>
        internal void SetTargetRowIndexAndCollection(ObservableCollection<CheckToDoTreeRow> list)
        {
            // もし、現在より深い階層のチェック行のコレクションが取得できる場合、再帰的に取得する。
            if (hieracheFloor < pathNumArray.Length - 1)
            {
                int index = int.Parse(pathNumArray[hieracheFloor]);
                hieracheFloor++;
                SetTargetRowIndexAndCollection(list[index].GetChild());
            }
            else
            {
                // 選択した行が格納されているコレクションを取得する。
                SelectedRowList = list ?? new ObservableCollection<CheckToDoTreeRow>();
                return;
            }
        }

        /// <summary>
        /// 追加されたチェックリストの行ごとの階層のパスを修正します。
        /// </summary>
        /// <param name="list"></param>
        /// <param name="hieracheFloor"></param>
        internal void ResetHierarchyPath(ObservableCollection<CheckToDoTreeRow> list, int hieracheFloor = 0, string parentPath = "")
        {

            foreach (var (item, index) in list.Select((v, i) => (v, i)))
            {
                // もし子要素のコレクションがあれば、そこを優先する。。
                if (item.Children.Any())
                {
                    int childrenFloor = hieracheFloor + 1;
                    string newParent = parentPath == "" ? index.ToString() : $"{parentPath}-{index}";

                    ResetHierarchyPath(item.GetChild(), childrenFloor, newParent);
                }

                // 新しい階層パスに書き換えます。
                item.HierarchyPath = hieracheFloor == 0 ? index.ToString() : $"{parentPath}-{index}";
            }
        }

        #endregion


        public CheckToDoTreeRow GetNewCheckListRow()
        {
            return new CheckToDoTreeRow() {
                Text = "",
                StartDate = CustomDateTime.GetNowDate(),
                AddToUpRowCmd = cmdSet.AddToUpRowCmd,
                AddToDownRowCmd = cmdSet.AddToDownRowCmd,
                AddChildrenCommand = cmdSet.AddChildrenCommand, 
                DeleteCheckRowCmd = cmdSet.DeleteCheckRowCmd,
            };
        }
    }
}
