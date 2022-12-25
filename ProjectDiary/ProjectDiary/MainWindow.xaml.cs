using ProjectDiary.Program;
using ProjectDiary.Program.DAO;
using ProjectDiary.Program.Domains;
using ProjectDiary.Program.DTO;
using ProjectDiary.Program.ViewManipurator;
using ProjectDiary.Program.ViewModelPart;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ProjectDiary
{
    /// <summary>
    /// 日誌アプリのメイン画面です。
    /// </summary>
    public partial class MainWindow : Window
    {
        #region 検索のコンボボックス

        /// <summary>
        /// 状態を検索するためのコンボボックスです。
        /// </summary>
        public Dictionary<SelectedViewStatus, string> StatusSearchCmbList = new Dictionary<SelectedViewStatus, string>()
        {
            {SelectedViewStatus.Defalut, "　"},
            {SelectedViewStatus.DoneAndStop, "完了と中止"},
            {SelectedViewStatus.Waiting, "未着手"},
            {SelectedViewStatus.Pending, "保留"},
            {SelectedViewStatus.Working, "進行中"},
            {SelectedViewStatus.Done, "完了"},
            {SelectedViewStatus.Stop, "中止"},

        };
        #endregion

        #region タスク一覧の状態列
        /// <summary>
        /// 状態列のコンボボックスのためのディクショナリーです。
        /// </summary>
        public static readonly Dictionary<Status, string> StatusNameDic =
            new Dictionary<Status, string>
                {
                    { Status.Waiting, "未着手" },
                    { Status.Pending, "保留" },
                    { Status.Working, "進行中" },
                    { Status.Done, "完了" },
                    { Status.Stop, "中止" },
                };

        /// <summary>
        /// 状態列のコンボボックスのコレクションです。
        /// </summary>
        public List<StatusComboItem> StatusColumnCmbList 
            = new List<StatusComboItem>()
            {
                new StatusComboItem() { NowStatus = Status.Done},
                new StatusComboItem() { NowStatus = Status.Waiting},
                new StatusComboItem() { NowStatus = Status.Pending},
                new StatusComboItem() { NowStatus = Status.Working},
                new StatusComboItem() { NowStatus = Status.Stop},
            };


        /// <summary>
        /// ステータスのコンボボックスのアイテムにバインドするためのクラスです。
        /// </summary>
        public class StatusComboItem
        {
            /// <summary>
            /// コンボボックスに表示する文字列です。
            /// </summary>
            public string StatusName => StatusNameDic[NowStatus];

            /// <summary>
            /// コンボボックスが返す値です。
            /// </summary>
            public Status NowStatus { get; internal set; }
        }

        internal TaskSearch taskSearch;
        #endregion

        /// <summary>
        /// コンストラクターです。
        /// </summary>
        public MainWindow()
        {

            InitializeComponent();

            StatusSearchCmb.ItemsSource = StatusSearchCmbList;

            taskSearch = new TaskSearch(this);
            taskSearch.SetDefalut();

            DataContext = new MainWindowViewModel();

            MemoViewList.ScrollEnd();

        }

    }

    /// <summary>
    /// 日誌アプリのメイン画面に対するビューモデルです。
    /// </summary>
    internal class MainWindowViewModel : INotifyPropertyChanged
    {
        public WorkTaskViewModelPart WorkTaskVMP { get; set; } = new WorkTaskViewModelPart();
        public CheckListViewModelPart CheckListVMP { get; set; } = new CheckListViewModelPart();
        public TimeNoteListViewModelPart MemoListVMP { get; set; } = new TimeNoteListViewModelPart();
        public FixedNoteViewModelPart FixedMeMoVMP { get; set; } = new FixedNoteViewModelPart();

        /// <summary>
        /// コンストラクター
        /// </summary>
        public MainWindowViewModel()
        {
            WorkTaskVMP.TaskList = new ObservableCollection<WorkTask>(WorkTaskDAO.GetWorkTaksArray());
            CheckListVMP.SetDefalt(CheckTodoDao.GetTodoArray());
            MemoListVMP.SetDefalt(SequenceNoteDao.GetTimeNoteArray());
            FixedMeMoVMP.SetDefalut(FixedSequenceNoteDao.GetFixedNoteArray());
        }

        /// <summary>
        /// プロパティが変更されたときに発生するイベントをハンドルします。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

    }

}
