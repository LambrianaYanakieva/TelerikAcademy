using System;
using System.Collections.Generic;

namespace Academy.Models.Contracts
{
    public interface ICourse
    {
        string Name { get; set; }

        int LecturesPerWeek { get; set; }

        DateTime? StartingDate { get; set; }

        DateTime? EndingDate { get; set; }
        /// <summary>
        /// ///
        /// </summary>
        IList<IStudent> OnsiteStudents { get; }
        /// <summary>
        /// 
        /// </summary>
        IList<IStudent> OnlineStudents { get; }

        IList<ILecture> Lectures { get; }

        string ToString();

    }
}
