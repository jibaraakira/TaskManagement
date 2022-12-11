using ProjectDiary.Program.DTO;
using System.Collections.Generic;

namespace ProjectDiary.Program.DAO
{
    public class FixedMemoDao
    {
        internal static List<FixedNote> GetTodoArray()
        {
            return new List<FixedNote>()
            {
                new FixedNote()
                {
                    Headline="abcd",
                    ParagraphIndex=0,
                    ParagraphText="kkdkdkdkkdk"
                },
                new FixedNote()
                {
                    Headline="efgh",
                    ParagraphIndex = 1,
                    ParagraphText = "ijkl"
                }
            };
        }
    }
}