using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Domain.Enums
{
    public enum ExamsSemester
    {
        [Description("Primeira prova")]
        FirstExam = 0,
        [Description("Segunda prova")]
        SecondExam = 1,
        [Description("Terceira prova")]
        ThirdExam = 2,
        [Description("Quarta prova")]
        QuarterExam = 3
    }
}
