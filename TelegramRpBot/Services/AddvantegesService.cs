using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using TelegramRpBot.Entites;
using TelegramRpBot.Enums;
using TelegramRpBot.Specifications;

namespace TelegramRpBot.Services
{
    public class AddvantegesService
    {
        static Repository<Player> playerRepository = new Repository<Player>();
        static Repository<Advantage> advantageRepository = new Repository<Advantage>();
        static Repository<Disadvantage> disadvantageRepository = new Repository<Disadvantage>();


        public static async Task GetAdvantage(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));

            Advantage advantage = advantageRepository.Get(new AdvantageByNameSpecification(message.Text, message.From.Id));

            if (advantage == null)
            {
                await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Нормально пиши");
            }
            else if (advantage.Name == "Гибкость")
            {
                if (advantage.Level == 0)
                {
                    if (player.Points >= 5)
                    {
                        advantage.Level += 1;
                        player.Points -= 5;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else if (advantage.Level == 1)
                {
                    if (player.Points >= 10)
                    {
                        advantage.Level += 1;
                        player.Points -= 10;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} максимального уровня");
                }
            }
            else if (advantage.Name == "Сопротивлене болезням")
            {
                if (advantage.Level == 0)
                {
                    if (player.Points >= 3)
                    {
                        advantage.Level += 1;
                        player.Points -= 3;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else if (advantage.Level == 1)
                {
                    if (player.Points >= 2)
                    {
                        advantage.Level += 1;
                        player.Points -= 2;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} максимального уровня");
                }
            }
            else if (advantage.Name == "Удача")
            {
                if (advantage.Level == 0)
                {
                    if (player.Points >= 15)
                    {
                        advantage.Level += 1;
                        player.Points -= 15;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else if (advantage.Level == 1)
                {
                    if (player.Points >= 15)
                    {
                        advantage.Level += 1;
                        player.Points -= 15;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else if (advantage.Level == 2)
                {
                    if (player.Points >= 30)
                    {
                        advantage.Level += 1;
                        player.Points -= 30;
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
                    }
                    else
                    {
                        await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков");
                    }
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} максимального уровня");
                }
            }
            else if (player.Points >= advantage.Price && advantage.Level < advantage.MaxLevel)
            {
                advantage.Level += 1;
                player.Points -= advantage.Price;
                await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{advantage.Name} получена");
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Не хватает очков или достигнут максимальный уровень");
            }

            if (advantage != null)
            {
                advantageRepository.Update(advantage);
                playerRepository.Update(player);
            }
        }

        public static async Task GetGisadvantage(ITelegramBotClient botClient, Message message)
        {
            Player player = playerRepository.Get(new PlayerByIdSpecification(message.From.Id));

            Disadvantage disadvantage = disadvantageRepository.Get(new DIsadvantageByNameSpecification(message.Text, message.From.Id));

            if (disadvantage == null)
            {
                await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Нормально пиши");
            }
            else if (disadvantage.Name == "Чувство долга")
            {
                if (disadvantage.Level == 0)
                {
                    disadvantage.Level += 1;
                    player.Points += 2;
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{disadvantage.Name} получена");
                }
                else if (disadvantage.Level == 1)
                {
                    disadvantage.Level += 1;
                    player.Points += 3;
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{disadvantage.Name} получена");
                }
                else if (disadvantage.Level < 5)
                {
                    disadvantage.Level += 1;
                    player.Points += 5;
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{disadvantage.Name} получена");
                }
                else
                {
                    await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{disadvantage.Name} максимального уровня");
                }
            }
            else if (disadvantage.Level < disadvantage.MaxLevel)
            {
                disadvantage.Level += 1;
                player.Points += disadvantage.Price;
                await botClient.SendTextMessageAsync(chatId: message.From.Id, text: $"{disadvantage.Name} получена");
            }
            else
            {
                await botClient.SendTextMessageAsync(chatId: message.From.Id, text: "Достигнут максимальный уровень");
            }

            if (disadvantage != null)
            {
                disadvantageRepository.Update(disadvantage);
                playerRepository.Update(player);
            }
        }



        public static async Task SendAllAdvantages(ITelegramBotClient botClient, long messageId)
        {
            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Преимущества:\n\n\n\nБесстрашие (2 очка за уровень)\nВас очень тяжело запугать! " +
                "Добавляйте ваш уровень бесстрашия к вашей Воле каждый"
                + " раз когда вы делаете бросок страха или должны сопротивляться запугиванию и сверхъестестенным силам, вызывающим страх."
                + " Вы также вычитаете ваш уровень Бесстрашия из всех бросков запугивания направленных против вас\n\n"
                + "Боевые рефлексы (15 очков)\nУ вас экстаординарная реакция и вы быстро приходите в себя при неожиданном нападении. "
                + "Вы получаете бонус +1 на любую активную защиту и +2 на все броски страха. Вы никогда не замираете в неожиданной ситуации"
                + "и получаете +6 на все броски ИН, чтобы очнуться или прийти в себя после оглушения\n\n"
                + "Высокий болевой порог (10 очков)\nВы никогда не испытываете шока, если вас ударили во время боя. Так же вы получаете " +
                "+3 на все броски живучести когда вас сбивают с ног или оглушают, либо когда вас пытают у вас +3 на бросок живучести, чтобы выдержать боль\n\n" +
                "Гибкость (5 или 15 очков)\nВы получаете +3 к на броски лазанья или побега, когда освобождаетесь от наручников. " +
                "Так же вы игнорируете штраф до -3 за работу в узком пространстве. За 15 очков тоже самое, но вместо 3 везде 5\n\n" +
                "Мягкое падение (10 очков)\nВы вычитаете из высоты падения 2 метра (автоматический успех умения Акробатика), так же " +
                "успешный бросок на ловкость уменьшит вдвое урон от падения (ваши конечести не должны быть связаны)\n\n" +
                "Ночное виденье (1 очко за уровень (максимум 9))\nПозволяет во время сражения или при проверке зрения игнорировать" +
                " штраф -1 (за каждый уровень) в темноте\n\n" +
                "Обострённые чувства (2 очка за уровень)\nЭто 4 разных преимущества: слух, вкус и обаяние, осязание, зрение. " +
                "Даёт +1 за каждый уровень на все броски чувств\n\n" +
                "Обоюдорукость (5 очков)\nИгнорирует штраф -4 при использовании не основной руки\n\n" +
                "Полная устойчиовсть (15 очков)\nУ вас нету проблем с сохранением баланса. Вы не делаете бросок на ловкость при ходьбе по " +
                "сухим узким поверхностям. Если поверхность мокрая или скользкая, то вы получаете +6 на бросок ловкости, чтобы сохранить баланс. " +
                "В бою вы получаете +4 во всех попытках сохранить устойчивость. Так же добавляет +1 к умениям акробатика и лазанье\n\n" +
                "Понимание животных (5 очков)\nМастер игры делает проверку на интеллект каждый раз, когда вы встречаете животное, и " +
                "говорит вам эмоциональное состояние животного, так же вы можете применять влияние на животных так же как и на людей\n\n" +
                "Прыгун (100 очков)\nВы можете прыгать во времени или в параллельные миры (за остальной информацией к илле, мне впадлу расписывать)\n\n" +
                "Сорвиголова (15 очков)\nКаждый раз когда вы необоснованно рискуете (по мнению мастера) вы получаете +1 ко всем умениям. " +
                "Так же вы можете перебросить кубики 1 раз при критическом провале, который произошёл во время вашей рискованной выходке\n\n" +
                "Талант к языкам (10 очков)\nВы бесплатно изучаете уровень владением языка, но если вы уже знаете этот язык хоть на каком-то уровне" +
                ", если вы его не знаете то надо платить");
            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Трудно убить (2 очка за уровень)\nВы получаете +1 за уровень при проверке на живучесть, когда провал означает смерть. " +
                "Если этот бонус делает из провального броска успешный, то вы теряете сознание\n\n" +
                "Увеличенное блокирование (5 очков)\nВы получаете +1 к значению блока при использовании умения щит\n\n" +
                "Увеличенное уклонение (15 очков)\nВы получаете +1 к значению уклонения\n\n" +
                "Увеличенное парирование (10 очков)\nВы получаете +1 к значению парирования\n\n" +
                "Удача (15 очков)\nКаждый 3 ролл вы можете перебросить 1 кубик и выбрать результат\n\n" +
                "Крутая удача (30 очков)\nКаждый 2 ролл вы можете перебросить 1 кубик и выбрать результат\n\n" +
                "Ахуеть какая крутая удача (60 очков)\nКаждый ролл вы можете перебросить 1 кубик и выбрать результат\n\n" +
                "Сопротивление яду (5 очков)\nВы получаете бонус +3 к сопротивлению яду\n\n" +
                "Сопротивление болезням (3 очка или 5 очков)\nВы получаете бонус +3 (за 3 очка) или бонус +8 (за 5 очков) при сопротивлении болезням\n\n" +
                "Чувство опасноти (15 очков)\nМастер тайно от вас кидает кубики на ваше восприятие, при успешном броске мастер говорит " +
                "вам о надвигающейся опасноти\n\n" +
                "Эмпатия (15 очков)\nКогда вы впервые встречаете НПС, вы можете попросить мастера сделать бросок на ваш интеллект и сказать, " +
                "что вы чувствуете на счёт этого человека. Если бросок провалился, то мастер скажет неправду\n\n" +
                "Сопротивление поврежденям (5 очков за уровень)\nУвеличивает сп 1 за уровень (максимум 3)\n\n" +
                "Острые когти (5 очков)\nУ вас острые когти. Урон как у кулака, но тип урона режущий\n\n" +
                "Острые зубы (1 очко)\nМожете кусаться\n\n" +
                "Острые клыки (2 очка)\nИми тоже можно кусаться, но больнее");
        }

        public static async Task SendAllDisadvantages(ITelegramBotClient botClient, long messageId)
        {
            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Недостатки:\n\n\n\nВспыльчивость (-10 очков)\nБросайте на самоконтроль в любой стрессовой ситуации. При провале вы оскорбляете, " +
                "нападаете, или иным способом начинаете дейстсовать против источника стресса\n\n" +
                "Жадность (-15 очков)\nКаждый раз когда вам предлагают награду, когда видите приманку или просто видите деньги, " +
                "сделайте проверку самоконтроля. В случае провала вы сделаете всё возможно, чтобы получить эти деньги\n\n" +
                "Заблуждение (-5, -10, -15 очков)\nВы сильно верите во что-то ненастоящее (и должны это отыгрывать). Незначительное: " +
                "ваше поведение вызывает вопросы у окружающих (-1 к отношению окружающих к вам). Значительное: ваше поведение " +
                "вызывает серьёзные вопросы у окружающих (-2 к отношению окружающих к вам). Серьёзное: окружающие боятся и жалеют вас " +
                "(-3 к отношению окружающих к вам)\n\n" +
                "Зависть (-10 очков)\nВы завидуете тем кто сильнее, умнее или богаче вас. Вы выступаете против любого плана представленного " +
                "тем, кому вы завидуете\n\n" +
                "Законопослушный (-10 очков)\nВы всегда следуете закону, если вам надо нарушить закон то киньте ролл самоконтроля, " +
                "если провал, то вы не будете нарушать, какие бы ни были последствия. Если вы всё таки нарушили, то киньте кубик ещё раз, " +
                "если провал, то идите сдавайтесь властям\n\n" +
                "Импульсвность (-10 очков)\nВы не любите разговоров, вы всегда сначала действуете, а потом думаете. Когда лучше будет " +
                "подождать, вы бросаете на самоконтроль и в случае провала действуете, какие бы ни были последствия\n\n" +
                "Клятва (-5, -10, -15 очков)\nКакая-то клятва, которую вы дали и не можете нарушить. Обсудите с мастером ценность клятвы\n\n" +
                "Кодекс чести (-5, -10, 15 очков)\nНеформальный кодекс стоит -5, формальный -10, за -15 вы обязаны совершить " +
                "самоубийство в случае нарушения кодекса\n\n" +
                "Кровожадность (-10 очков)\nВы желаете видеть своих врагов мёртвыми. Вы всегда убиваете своих врагов и делаете " +
                "контрольный удар или выстрел, чтобы убедиться, что враг умер. Если вам надо оставить кого-то в живых или просто пройти мимо" +
                ", то делайте бросок на самоконтроль\n\n" +
                "Любопытство (-5 очков)\n Вы очень любопытны и всегда лезете куда не надо (например, а что будет если нажать эту кнопку?). " +
                "Чтобы не делать чего-то любопытного, кидайте на самоконтроль\n\n" +
                "Навязчивая идея (-5, -10 очков)\nВы обязаны сделать какой-то поступок. Когда будет лучше отступиться от этой идеи, " +
                "киньте на самоконтроль. Стоимость обсуждайте с мастером\n\n" +
                "Невезение (-10 очков)\nВы ужасно невезучий. Если с кем-то должно случиться что-то плохое, то это будет с вами. " +
                "Один раз за игру мастер может вмешаться и сделать вам подлянку, например сделать успешный бросок провальным\n\n" +
                "Нетерпимость (-1, -5, -10 очков)\nВы нетерпимы к чему-то: классу, этносу, религии, полу, Стасу. Вы плохо относитесь " +
                "к ненавистному объекту и он относится к вам так же. Стоимость обсуждайте с мастером");

            await botClient.SendTextMessageAsync(chatId: messageId,
                text: "Пацифизм (-5, -10 очков)\nЗа -5 очков: вы получаете -4 к точности против людей, когда ваш удар может убить врага\n" +
                "За -10 очков: вы не можете вступать в бой, пока враг не нанесёт вам серьёзный вред\n\n" +
                "Правдивость (-5 очков)\nВы не любите врать. Делайте бросок самоконтроля, когда нужно смолчать, со штрафом -5 когда " +
                "нужно соврать. Так же у вас -5 к умениям заговаривание зубов и артистизм (когда нужно соврать)\n\n" +
                "Прожорливость (-5 очков)\nВы очень любите хорошую еду и напитки. Сделайте бросок самоконтроля, если нужно устоять " +
                "от вкусной еды или выпивки, в случае провала вы всегда пойдёте и попробуете это, независимо от ситуации\n\n" +
                "Развратность (-15 очков)\nПри каждом более менее продолжительном контакте с существом подходящего пола сделайте " +
                "бросок самоконтроля (со штрафом -5 если объект красивый, или -10 если очень красивый). В случае провала вы " +
                "должны 'наводить мосты', пуская в ход всю свою хитрость и умение\n\n" +
                "Самоуверенность (-5 очков)\nВы слишком уверенны в себе и это надо отыгрывать. Когда мастер считает, что вы действуете слишком " +
                "осторожно, сделайте бросок на самоконтроль. В случае провала вы должны действовать так, словно вы полностью " +
                "контролируете ситуацию. Так же вы получаете +2 реацкии у молодых и наивных людей\n\n" +
                "Слабое зрение (-25 очков)\nВы получаете штраф -6 к броскам умения зрение и -2 к точности\n\n" +
                "Тугоухость (-10 очков)\nУ вас проблемы со слухом. Вы получаете штраф -4 к любому броску слуха\n\n" +
                "Фобии (цену и последствия обсуждайте с иллёй и вовой)\n\n" +
                "Чувство долга (-2, -5, -10, -15, -20 очков\nВы чувствуете серьёзные обязательства по отношению к кому-то. " +
                "Цену обсуждайте с мастером\n\n" +
                "Сонливость (-8 очков)\nВы любите поспать");
        }
    }
}
