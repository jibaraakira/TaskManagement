using ProjectDiary.Program.Commands.CheckList;

namespace ProjectDiary.Program.Domains
{
    /// <summary>
    /// チェックToDo一覧のコマンドを集めたクラスです。
    /// </summary>
    internal class CheckListCommandSet
    {
        /// <summary>
        /// 選択した行の１つ上に行を追加するためのボタンのコマンドのプロパティです。
        /// </summary>
        public  AddToUpRowCommand AddToUpRowCmd { get; private set; }

        /// <summary>
        /// 選択した行の１つ下に行を追加するためのボタンのコマンドのプロパティです。
        /// </summary>
        public AddToDownRowCommand AddToDownRowCmd { get; private set; }

        /// <summary>
        /// 選択した行を消去するためのボタンのコマンドのプロパティです。
        /// </summary>
        public DeleteCheckRowCommand DeleteCheckRowCmd { get; private set; }

        /// <summary>
        /// 選択した行に子の行を追加するボタンのコマンドのプロパティです。
        /// </summary>
        public AddChildrenCommand AddChildrenCommand{ get; private set; }


        /// <summary>
        /// コマンドを格納します。
        /// </summary>
        /// <param name="u">選択した行の１つ上に行を追加するためのボタンのコマンド。</param>
        /// <param name="d">選択した行の１つ下に行を追加するためのボタンのコマンド。</param>
        /// <param name="del">選択した行を消去するためのボタンのコマンド。</param>
        /// <param name="c">選択した行に子の行を追加するボタンのコマンド。</param>
        internal CheckListCommandSet (
            AddToUpRowCommand u, 
            AddToDownRowCommand d, 
            DeleteCheckRowCommand del, 
            AddChildrenCommand c)
        {
            AddToUpRowCmd = u;
            AddToDownRowCmd = d;
            DeleteCheckRowCmd = del;
            AddChildrenCommand = c;
        }
    }
}
