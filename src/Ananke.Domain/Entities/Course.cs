namespace Ananke.Domain.Entities
{
    public class Course
    {
        private string Name { get; set; }
        private string Teacher { get; set; }
        private int Credits { get; set; }
        private SchedulesWeek[] Schedules { get; set; }
        // enum period private string period
        // requirement pre-req
        // private Assessments provas
        // total de aulas programadas
        // total de faltas
        // status (aprovado, cursando, nao iniciado, reprovado)
        // float AI
        // float tabalhos avaliativos

        // metodos
        // PegarMediaNasProvas {usart estrategia pois o calculo da media, trabalhos, mudam}

    }
}
