using ProjectDiary.Program.Commands.CheckList;
using ProjectDiary.Program.Domains;
using ProjectDiary.Program.DTO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectDiary.Program.ViewModelPart
{
    /// <summary>
    /// チェックToDo一覧の部分にバインドするビューモデルです。
    /// </summary>
    internal class CheckListViewModelPart
    {
        /// <summary>
        /// チェックToDo一覧への表示のためのコレクションです。
        /// </summary>
        public ObservableCollection<CheckToDoTreeRow> CheckTodoList { get; private set; } = new ObservableCollection<CheckToDoTreeRow>();

        /// <summary>
        /// 選択したチェックリストの行の一つ上に追加する処理のためのコマンドです。
        /// </summary>
        public AddToUpRowCommand AddToUpRowCmd { get; private set; } = new AddToUpRowCommand();

        /// <summary>
        /// 選択したチェックリストの行の一つ下に追加する処理のためのコマンドです。
        /// </summary>
        public AddToDownRowCommand AddToBottomRowCmd { get; private set; } = new AddToDownRowCommand();

        /// <summary>
        /// 選択したチェックリストの行を削除するコマンドです。
        /// </summary>
        public DeleteCheckRowCommand DeleteCheckRowCmd { get; private set; } = new DeleteCheckRowCommand();

        /// <summary>
        /// 選択したチェックリストの行に子要素となる行を１つ追加するコマンドです。
        /// </summary>
        public AddChildrenCommand AddChidlrenCmd { get; private set; } = new AddChildrenCommand();

        /// <summary>
        /// 初期設定をします。
        /// </summary>
        /// <param name="list">チェックリストの情報リスト。</param>
        internal void SetDefalt(List<CheckToDoTreeRow> list)
        {
            var cmds = new CheckListCommandSet(
                AddToUpRowCmd,
                AddToBottomRowCmd,
                DeleteCheckRowCmd,
                AddChidlrenCmd
                );

            // コマンドの設定。
            AddToUpRowCmd.SetAllCommand(cmds);
            AddToBottomRowCmd.SetAllCommand(cmds);
            AddChidlrenCmd.SetAllCommand(cmds);

            // コレクションに値を入れて、一覧へ表示する。
            CheckTodoList.CreateTree(list.Select(item => {
                item.SetCommand(
                    AddToUpRowCmd,
                    AddToBottomRowCmd,
                    DeleteCheckRowCmd,
                    AddChidlrenCmd);
                return item;
                })
            );

            // コマンドにコレクションを参照させて、操作可能にする。
            AddToUpRowCmd.SetCheckList(CheckTodoList);
            AddToBottomRowCmd.SetCheckList(CheckTodoList);
            AddChidlrenCmd.SetCheckList(CheckTodoList);
            DeleteCheckRowCmd.SetCheckList(CheckTodoList);
        }
    }
}
