using ProjectDiary.Program.Commands.FixedNoteList;
using System.ComponentModel;

namespace ProjectDiary.Program.DTO
{

    /// <summary>
    /// 固定メモのパラグラフです。
    /// </summary>
    public class FixedNote : ListDto, INotifyPropertyChanged
    {
        /// <summary>
        /// メモ作成時間です。
        /// </summary>
        public string _Headline = "";

        /// <summary>
        /// メモのインデックスです。
        /// </summary>
        public string Headline
        {
            get { return _Headline; }
            set
            {
                _Headline = value;
                OnPropertyChanged("Headline");
            }
        }

        /// <summary>
        /// メモ作成時間です。
        /// </summary>
        public int _ParagraphIndex = 0;

        /// <summary>
        /// メモのインデックスです。
        /// </summary>
        public int ParagraphIndex
        {
            get { return _ParagraphIndex; }
            set
            {
                _ParagraphIndex = value;
                OnPropertyChanged("ParagraphIndex");
            }
        }

        /// <summary>
        /// メモ作成時間です。
        /// </summary>
        public string _ParagraphText = "";

        /// <summary>
        /// メモのインデックスです。
        /// </summary>
        public string ParagraphText
        {
            get { return _ParagraphText; }
            set
            {
                _ParagraphText = value;
                OnPropertyChanged("ParagraphText");
            }
        }

        /// <summary>
        /// 自身のパラグラフを消去するためのコマンド
        /// </summary>
        public DeleteParagraphCommand DeleteParagraphCommand { get; set; }

        /// <summary>
        /// プロパティが変更されたときに発生するイベントをハンドルします。
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// プロパティが変化したことを通知します。
        /// </summary>
        /// <param name="name">プロパティ名。</param>
        private void OnPropertyChanged(string name)
        {
            if (PropertyChanged == null) return;
            PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        public override void UpdateIndex(int index)
        {
            ParagraphIndex = index;
        }
    }
}