using Ananke.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ananke.Application.DTOs
{
    public class MediaProjectionDTO
    {
        public Assessments FirstExam { get; set; }
        public Assessments SecondExam { get; set; }
        public Assessments ThirdExam { get; set; }
        public Assessments QuarterExam { get; set; }
        public double MediaSemester { get; set; }
    }
}
