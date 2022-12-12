using ProjectDiary.Program.Commands.NoteList;
using System.ComponentModel;

namespace ProjectDiary.Program.DTO
{
    /// <summary>
    /// メモです。
    /// </summary>
    internal class TimeNote : ListDto, INotifyPropertyChanged
    {
        /// <summary>
        /// メモのインデックスです。
        /// </summary>
        public int _NoteIndex = 0;

        /// <summary>
        /// メモ作成時間です。
        /// </summary>
        public string _NoteCreateTime = "";


        /// <summary>
        /// メモのテキストです。
        /// </summary>
        public string _NoteText = $"";

        /// <summary>
        /// メモのインデックスのプロパティです。
        /// </summary>
        public int NoteIndex
        {
            get { return _NoteIndex; }
            set
            {
                _NoteIndex = value;
                OnPropertyChanged("NoteIndex");
            }
        }

        /// <summary>
        /// メモ作成時間のプロパティです。 
        /// </summary>
        public string NoteCreateTime
        {
            get { return _NoteCreateTime; }
            set
            {
                _NoteCreateTime = value;
                OnPropertyChanged("NoteCreateTime");
            }
        }

        /// <summary>
        /// メモのテキストのプロパティ。
        /// </summary>
        public string NoteText
        {
            get { return _NoteText; }
            set
            {
                _NoteText = value;
                OnPropertyChanged("NoteText");
            }
        }

        /// <summary>
        /// 自身のメモを消去するコマンドです。
        /// </summary>
        public DeleteTimeNoteCommand DeleteNoteCommand { get; private set; }
        
        /// <summary>
        /// プロパティが変更されたときに発生するイベントをハンドルします。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// 自身のメモを消去するコマンドを格納します。
        /// </summary>
        /// <param name="cmd">自身のメモを消去するコマンド。</param>
        public void SetDeleteNoteComand(DeleteTimeNoteCommand cmd)
        {
            DeleteNoteCommand = cmd;
        }

        public override void UpdateIndex(int index) => NoteIndex = index;


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
