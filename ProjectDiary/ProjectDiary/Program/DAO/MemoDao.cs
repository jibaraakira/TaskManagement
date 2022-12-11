using ProjectDiary.Program.DTO;
using System.Collections.Generic;

namespace ProjectDiary.Program.DAO
{
    internal class MemoDao
    {
        internal static List<Note> GetTodoArray()
        {
            return new List<Note>()
            {
                // 色データをObservableCollectionに設定
                new Note {NoteIndex = 0, NoteCreateTime = "2022-12-02　13:07:53", NoteText = "asdfaaaaaaaaaaaadsadfasdfsadfasdf" },
                new Note {NoteIndex = 1},
                new Note {NoteIndex = 2},
            };
        }
    }
}