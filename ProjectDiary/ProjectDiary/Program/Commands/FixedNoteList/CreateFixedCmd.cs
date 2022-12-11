using ProjectDiary.Program.DTO;
using System.Collections.ObjectModel;
using System;

namespace ProjectDiary.Program.Commands.FixedNoteList
{
    public class CreateFixedCmd
    {

        public ObservableCollection<FixedNote> fixedNoteList;

        public void SetDefalut(ObservableCollection<FixedNote> list)
        {
            fixedNoteList = list;
        }

    }
}