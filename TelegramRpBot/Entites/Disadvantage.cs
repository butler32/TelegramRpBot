using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Disadvantage
    {
        public Disadvantage()
        {
            HotTemperName = "Вспыльчивый";
            GreedName = "Жадный";
            DelusionName = "Заблуждения";
            EnvyName = "Зависить";
            LawAbidingName = "Законопослушный";
            ImpulsiveName = "Импульсивный";
            OathName = "Клятва";
            CodeOfHonorName = "Кодекс чести";
            BloodLustName = "Кровожадность";
            CuriosityName = "Любопытство";
            ObsessionName = "Навязчивая идея";
            BadLuckName = "Невезение";
            IntoleranceName = "Нетерпимость";
            PacifismName = "Пацифизм";
            TruthfullnessName = "Правдивость";
            GluttonyName = "Обжорство";
            DepravityName = "Развратность";
            SelfConfidenceName = "Самоуверенность";
            BadVisionName = "Плохое зрение";
            BadHearingName = "Тугоухость";
            PhobiasName = "Фобии";
            SleepyName = "Сонливый";
            SenseOfDutyName = "Чувство долга";
        }

        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int HotTemper { get; set; }
        public string HotTemperName { get; }
        public int Greed { get; set; }
        public string GreedName { get; }
        public int Delusion { get; set; }
        public string DelusionName { get; }
        public int Envy { get; set; }
        public string EnvyName { get; }
        public int LawAbiding { get; set; }
        public string LawAbidingName { get; }
        public int Impulsive { get; set; }
        public string ImpulsiveName { get; }
        public int Oath { get; set; }
        public string OathName { get; }
        public int CodeOfHonor { get; set; }
        public string CodeOfHonorName { get; }
        public int BloodLust { get; set; }
        public string BloodLustName { get; }
        public int Curiosity { get; set; }
        public string CuriosityName { get; }
        public int Obsession { get; set; }
        public string ObsessionName { get; }
        public int BadLuck { get; set; }
        public string BadLuckName { get; }
        public int Intolerance { get; set; }
        public string IntoleranceName { get; }
        public int Pacifism { get; set; }
        public string PacifismName { get; }
        public int Truthfullness { get; set; }
        public string TruthfullnessName { get; }
        public int Gluttony { get; set; }
        public string GluttonyName { get; }
        public int Depravity { get; set; }
        public string DepravityName { get; }
        public int SelfConfidence { get; set; }
        public string SelfConfidenceName { get; }
        public int BadVision { get; set; }
        public string BadVisionName { get; }
        public int BadHearing { get; set; }
        public string BadHearingName { get; }
        public int Phobias { get; set; }
        public string PhobiasName { get; }
        public int SenseOfDuty { get; set; }
        public string SenseOfDutyName { get; }
        public int Sleepy { get; set; }
        public string SleepyName { get; }

    }
}
