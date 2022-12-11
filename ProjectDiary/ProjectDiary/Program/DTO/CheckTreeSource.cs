﻿using ProjectDiary.Program.Commands.CheckList;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;

namespace ProjectDiary.Program.DTO
{
    /// <summary>
    /// チェックリストの行です。
    /// </summary>
    [Serializable]
    public class CheckRowTreeSource : INotifyPropertyChanged
    {
        /// <summary>
        /// 対象の行の子の行の行を表示するか否かを決めるブール値。
        /// </summary>
        private bool _IsExpanded = true;

        /// <summary>
        /// 対象の行にチェックをつけたか否かをきめるブール値。
        /// </summary>
        private bool? _IsChecked = false;

        /// <summary>
        /// チェック内容の文章。
        /// </summary>
        private string _Text = "";

        /// <summary>
        /// 開始日。
        /// </summary>
        private string _StartDate = "";

        /// <summary>
        /// 終了日。
        /// </summary>
        private string _EndDate = "";

        /// <summary>
        /// 対象の行の親の行。
        /// </summary>
        private CheckRowTreeSource _Parent = null;

        /// <summary>
        /// 対象の行が持つ子の行を複数格納するコレクション。
        /// </summary>
        private ObservableCollection<CheckRowTreeSource> _Children = new ObservableCollection<CheckRowTreeSource>();

        /// <summary>
        /// 対象の行が、階層構造の位置を示すパスの文字列。
        /// </summary>
        private string _HierarchyPath = "";

        /// <summary>
        /// 対象の行が、階層構造の位置を示す数値を格納する配列。
        /// </summary>
        private int[] _HierarchyPathArray = null;

        /// <summary>
        /// 子の行を追加するボタンの表示の制御を示す列挙型。
        /// </summary>
        private Visibility _AddChildButtonVisible = Visibility.Visible;

        /// <summary>
        /// 選択した行の１つ上に行を追加するためのボタンのコマンドのプロパティです。
        /// </summary>
        public AddToUpRowCommand AddToUpRowCmd { get; set; }

        /// <summary>
        /// 選択した行の１つ下に行を追加するためのボタンのコマンドのプロパティです。
        /// </summary>
        public AddToDownRowCommand AddToDownRowCmd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DeleteCheckRowCommand DeleteCheckRowCmd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public AddChildrenCommand AddChildrenCommand { get; set; }


        /// <summary>
        /// 象の行の子の行の行を表示するか否かを決めるブール値のプロパティ。
        /// </summary>
        public bool IsExpanded
        {
            get { return _IsExpanded; }
            set
            {
                _IsExpanded = value;
                OnPropertyChanged("IsExpanded");
            }
        }

        /// <summary>
        /// 対象の行にチェックをつけたか否かをきめるブール値のプロパティ。
        /// </summary>
        public bool? IsChecked
        {
            get { return _IsChecked; }
            set
            {
                _IsChecked = value;
                OnPropertyChanged("IsChecked");
            }
        }

        /// <summary>
        /// チェック行に表示されるテキストです。
        /// </summary>
        public string Text
        {
            get { return _Text; }
            set
            {
                _Text = value;
                OnPropertyChanged("Text");
            }
        }

        /// <summary>
        /// 対象の行の親の行のプロパティ。
        /// </summary>
        public CheckRowTreeSource Parent
        {
            get { return _Parent; }
            set
            {
                _Parent = value;
                OnPropertyChanged("Parent");
            }
        }

        /// <summary>
        /// 対象の行が、階層構造の位置を示すパスの文字列のプロパティ。
        /// </summary>
        public string HierarchyPath
        {
            get { return _HierarchyPath; }
            set
            {
                _HierarchyPath = value;

                if (AddToUpRowCmd != null)
                {
                    AddToUpRowCmd.SetSeparatedPath(value);
                }

                OnPropertyChanged("HierarchyPath");
            }
        }

        /// <summary>
        /// 対象の行が、階層構造の位置を示す数値を格納する配列のプロパティ。
        /// </summary>
        public int[] HierarchyPathArray
        {
            get { return _HierarchyPathArray; }
            set
            {
                _HierarchyPathArray = value;
                OnPropertyChanged("HierarchyPathArray");
            }
        }

        /// <summary>
        /// 開始日のプロパティ。
        /// </summary>
        public string StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                OnPropertyChanged("StartDate");
            }
        }

        /// <summary>
        /// 終了日のプロパティ。
        /// </summary>
        public string EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                OnPropertyChanged("EndDate");
            }
        }

        /// <summary>
        /// 子の行を追加するボタンの表示の制御を示す列挙型のプロパティ。
        /// </summary>
        public Visibility AddChildButtonVisible {
            get { return _AddChildButtonVisible; }
            set
            {
                _AddChildButtonVisible = value;
                OnPropertyChanged("AddChildButtonVisible");
            }
        }


        /// <summary>
        /// 対象の行が持つ子の行を複数格納するコレクション。
        /// </summary>
        public ObservableCollection<CheckRowTreeSource> Children
        {
            get { return _Children; }
            set
            {
                _Children = value;
                OnPropertyChanged("Childen");
            }
        }

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

        /// <summary>
        /// 対象の行に子の行を１つ追加します。
        /// </summary>
        /// <param name="child">子の行。</param>
        public void Add(CheckRowTreeSource child)
        {
            child.Parent = this;
            Children.Add(child);
        }

        // TODO:2022-12-09_23:23:33 どう動くのかを調べる。
        /// <summary>
        /// 子の行を更新します。
        /// </summary>

        public void UpdateChildStatus()
        {
            if (null != IsChecked)
            {
                if (null != Children)
                {
                    foreach (var item in Children)
                    {
                        item.IsChecked = IsChecked;
                        item.UpdateChildStatus();
                    }
                }
            }
        }

        /// <summary>
        /// 対象の行の子の行のコレクションを返します。
        /// </summary>
        /// <returns></returns>
        internal ObservableCollection<CheckRowTreeSource> GetChild()
        {
            return Children ;
        }

        /// <summary>
        /// コマンドを追加します。
        /// </summary>
        /// <param name="u"></param>
        /// <param name="d"></param>
        /// <param name="del"></param>
        /// <param name="c"></param>
        internal void SetCommand(
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

        /// <summary>
        /// 子の行を追加します。
        /// </summary>
        internal void SetChild(CheckRowTreeSource CheckRowTreeSource)
        {
            Children.Add(CheckRowTreeSource);
        }
    }
}
