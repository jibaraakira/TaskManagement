using ProjectDiary.Program.DAO;
using ProjectDiary.Program.DTO;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;

namespace ProjectDiary.Program.Commands.FixedNoteList
{
    public class DeleteParagraphCommand : CreateFixedCmd, ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            MessageBoxResult result =
                MessageBox.Show(
                    "このセクションを消しますか？",
                    "確認",
                    MessageBoxButton.OKCancel,
                    MessageBoxImage.Warning
                    );

            if (result == MessageBoxResult.OK)
            {
                var set = fixedNoteList.First(item => item.ParagraphIndex == (int)parameter);
                fixedNoteList.Remove(set);
            }
        }
    }
}