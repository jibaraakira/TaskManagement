using ProjectDiary.Program.Commands.CheckList;

namespace ProjectDiary.Program.Domains
{
    internal class CheckListCommandSet
    {
        public  AddToUpRowCommand AddToUpRowCmd { get; private set; }
        public  AddToDownRowCommand AddToDownRowCmd { get; private set; }
        public  DeleteCheckRowCommand DeleteCheckRowCmd { get; private set; }
        public  AddChildrenCommand AddChildrenCommand{ get; private set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="u"></param>
        /// <param name="d"></param>
        /// <param name="del"></param>
        /// <param name="c"></param>
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
