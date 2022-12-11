using System;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.FixedNoteList
{
    public class CreateFixedNoteCommand: CreateFixedCmd, ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            fixedNoteList.Add(
                new DTO.FixedNote()
                {
                    
                }
                );
        }
    }
}