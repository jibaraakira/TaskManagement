using ProjectDiary.Program.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectDiary.Program.DAO
{
    internal class WorkTaskDAO
    {

        internal static WorkTask[] GetWorkTaksArray()
        {
            return new WorkTask[] {
                new WorkTask()
                {
                    TaskName ="１つ目のタスク",
                    StartDate = "2022-11-10",
                    StartTime = "11:11:12",
                    Status = Status.Pending,
                },
                new WorkTask()
                {
                    TaskName ="２つ目のタスク",
                    StartDate = "2022-11-10",
                    StartTime = "11:11:12",
                    Status = Status.Waiting,
                },
                 new WorkTask()
                {
                    TaskName ="３つ目のタスク",
                    StartDate = "2022-11-10",
                    StartTime = "11:11:12",
                    EndtDate = "2022-11-18",
                    EndTime = "12:12:12",
                    Status = Status.Done,
                },

            };
        }
    }
}
