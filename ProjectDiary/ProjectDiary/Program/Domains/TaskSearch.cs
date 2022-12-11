using ProjectDiary.Program.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace ProjectDiary.Program.ViewManipurator
{
    /// <summary>
    /// タスクを検索する画面要素をコントロールするクラスです。
    /// </summary>
    internal class TaskSearch
    {
        /// <summary>
        /// 画面対象
        /// </summary>
        private readonly MainWindow window;

        /// <summary>
        /// コンストラクターです。
        /// </summary>
        /// <param name="win">画面</param>
        internal TaskSearch(MainWindow win)
        {
            window = win;   
            
        }

        /// <summary>
        /// 画面要素の初期設定を行います。
        /// </summary>
        internal void SetDefalut()
        {
            window.TodayDataPicker.SelectedDate = DateTime.Today;
            window.StatusSearchCmb.SelectedIndex = 0;
        }

        /// <summary>
        /// 複数の検索キーを取得します。
        /// </summary>
        /// <returns>数の検索キー</returns>
        internal SearchKeyItem GetSearchWordItem()
        {
            return new SearchKeyItem()
            {
                SelectedDate = window.TodayDataPicker.SelectedDate.ToString(),
                ViewStatus = (SelectedViewStatus)window.StatusSearchCmb.SelectedItem
            };

        }

        /// <summary>
        /// デフォルトでの複数の検索キーを取得します。
        /// </summary>
        /// <returns></returns>
        internal SearchKeyItem GetDefalutSearchKeyItem()
        {
            return new SearchKeyItem()
            {
                SelectedDate = window.TodayDataPicker.SelectedDate.ToString(),
            };
        }
    }
}
