﻿using ProjectDiary.Program.Commands.NoteList;
using ProjectDiary.Program.DTO;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ProjectDiary.Program.ViewModelPart
{
    /// <summary>
    /// メモ一覧の部分にバインドするビューモデルです。
    /// </summary>
    internal class MemoListViewModelPart
    {
        /// <summary>
        /// メモ一覧への表示のためのコレクションです。
        /// </summary>
        public ObservableCollection<Note> NoteList { get;  set; } 

        /// <summary>
        /// メモ一覧を作成するためのコマンドです。
        /// </summary>
        public CreateMemoCommand CreateMemoCmd { get;  set; }

        /// <summary>
        /// メモ一覧のメモを消去する処理ためのコマンドです。
        /// </summary>
        public DeleteNoteCommand DeleteMemoCmd { get;  set; } = new DeleteNoteCommand();


        /// <summary>
        /// メモ一覧の初期設定をします。
        /// </summary>
        /// <param name="notes">メモのリスト。</param>
        public void SetDefalt(List<Note> notes)
        {
            CreateMemoCmd = new CreateMemoCommand(DeleteMemoCmd);
            NoteList = 
                new ObservableCollection<Note>(
                    notes.Select(item => {
                        item.SetDeleteNoteComand(DeleteMemoCmd); 
                        return item; 
                    })
                );

            CreateMemoCmd.SetMemoList(NoteList);
            DeleteMemoCmd.SetMemoList(NoteList);
        }
    }
}