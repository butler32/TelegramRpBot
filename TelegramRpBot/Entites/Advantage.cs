using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelegramRpBot.Entites
{
    public class Advantage
    {
        public Advantage()
        {
            FearlessName = "Бесстрашный";
            BattleReflexName = "Боевые рефлексы";
            PainThresholdName = "Высокий болевой порог";
            FlexibilityName = "Гибкость";
            SoftFallName = "Мягкое падение";
            NightVisionName = "Ночное зрение";
            AcuteHearingName = "Обострённый слух";
            AcuteTasteName = "Обострённый вкус и обаяние";
            AcuteSenseOfTouchName = "Обострённое осязание";
            AcuteVisionName = "Обострённое зрение";
            DoubleHandName = "Обоюдорукость";
            FullStabilityName = "Полная устойчивость";
            UnderstandingAnimalsName = "Понимание животных";
            JumperName = "Прыгун";
            DaredevilName = "Сорвиголова";
            LanguageTalantName = "Талант к языкам";
            HardToKillName = "Трудно убить";
            MoreDeffenceName = "Увеличенное блокирование";
            MoreDodgeName = "Увеличенное уклонение";
            MoreParryName = "Увеличенное парирование";
            LuckName = "Удача";
            PosionResistName = "Сопротивление яду";
            IllResistName = "Сопротивление болезням";
            DangerSenceName = "Чувство опасности";
            EmpathyName = "Эмпатия";
            MoreSpName = "Увеличенная защита";
            ClawsName = "Остарые когти";
            SharpTeethName = "Острые зубы";
            FangsName = "Острые клыки";
        }

        public int Id { get; set; }
        public int PlayerId { get; set; }
        public int Fearless { get; set; }
        public string FearlessName { get; }
        public int BattleReflex { get; set; }
        public string BattleReflexName { get; }
        public int PainThreshold { get; set; }
        public string PainThresholdName { get; }
        public int Flexibility { get; set; }
        public string FlexibilityName { get; }
        public int SoftFall { get; set; }
        public string SoftFallName { get; }
        public int NightVision { get; set; }
        public string NightVisionName { get; }
        public int AcuteHearing { get; set; }
        public string AcuteHearingName { get; }
        public int AcuteTaste { get; set; }
        public string AcuteTasteName { get; }
        public int AcuteSenseOfTouch { get; set; }
        public string AcuteSenseOfTouchName { get; }
        public int AcuteVision { get; set; }
        public string AcuteVisionName { get; }
        public int DoubleHand { get; set; }
        public string DoubleHandName { get; }
        public int FullStability { get; set; }
        public string FullStabilityName { get; }
        public int UnderstandingAnimals { get; set; }
        public string UnderstandingAnimalsName { get; }
        public int Jumper { get; set; }
        public string JumperName { get; }
        public int Daredevil { get; set; }
        public string DaredevilName { get; }
        public int LanguageTalant { get; set; }
        public string LanguageTalantName { get; }
        public int HardToKill { get; set; }
        public string HardToKillName { get; }
        public int MoreDeffence { get; set; }
        public string MoreDeffenceName { get; }
        public int MoreDodge { get; set; }
        public string MoreDodgeName { get; }
        public int MoreParry { get; set; }
        public string MoreParryName { get; }
        public int Luck { get; set; }
        public string LuckName { get; }
        public int PosionResist { get; set; }
        public string PosionResistName { get; }
        public int IllResist { get; set; }
        public string IllResistName { get; }
        public int DangerSence { get; set; }
        public string DangerSenceName { get; }
        public int Empathy { get; set; }
        public string EmpathyName { get; }
        public int MoreSp { get; set; }
        public string MoreSpName { get; }
        public int Claws { get; set; }
        public string ClawsName { get; }
        public int SharpTeeth { get; set; }
        public string SharpTeethName { get; }
        public int Fangs { get; set; }
        public string FangsName { get; }
    }
}
