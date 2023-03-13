// // ДОПОДНИТЕЛЬНЫЕ МАТЕРИАЛЫ: 
internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine($"Задача 1. Ответ: {GetDiscount(GetDiscount(100, -20), 20)} рублей.");
        Console.WriteLine($"Задача 2. Ответ: {GetReporterDistance(50, 100, 300, 150, 0.01):f0} км при остановке в 0.01 м.");
        Console.WriteLine($"Задача 3. Ответ: {GetCostOfSecondItem(100.10, 100):f2} рублей.");
        Console.WriteLine($"Задача 4. Ответ: Если озеро удваивает результат каждый день, то половина зарастет за (всего дней - 1 =>) 47 дней.");
        Console.WriteLine($"Задача 5. Ответ: 100 машин произведут 100 штуковин за 5 минут.");
    }

    // Вопросы на логику

    // 1.	Цена на подшипник 100 рублей. Отдел ценообразования сделал скидку 20%. Через неделю цену подняли на 20%. Какая цена на подшипник сейчас?
    static double GetDiscount(double inPrice, double inPercents)
    {
        return inPrice * (1 + inPercents / 100);
    }

    // 2.	Из пункта А в пункт B выехал поезд со скоростью 50 км/ч. На встречу в то же самое время из пункта B в пункт A выехал другой поезд со скоростью 100 км/ч. Расстояния между А и B 300 км. Одновременно с поездами из пункта А на реактивном ранце вылетел репортер», ожидая запечатлеть сенсационное столкновение поездов. Его скорость стабильна и постоянна и составляет 150 км/ч. В нетерпении он начинает летать от одного поезда к другому. Какое расстояние пролетит репортер до момента столкновения поездов?

    static double GetReporterDistance(double inTrain1Speed, double inTrain2Speed, double inDistance, double inReporterSpeed, double stopDistance)
    // stopDistance -> meters between trains    // pass inDistance A<->B in km
    {
        double v1 = inTrain1Speed, v2 = inTrain2Speed, s = inDistance * 1000, vR = inReporterSpeed;
        double sC = s; // collision or crash distance
        double sR = 0; // distance reporter moved
        double t = 0; // time for current move
        int movingToFriendFlag = 2; // default move from A to B

        while (sC >= stopDistance)
        {
            if (v1! < 0 || v2! < 0) return -1;
            if (movingToFriendFlag == 1)
            {
                t = sC / (v2 + vR);
                movingToFriendFlag = 2;
            }
            else
            {
                t = sC / (v1 + vR);
                movingToFriendFlag = 1;
            }
            sR += vR * t;
            sC -= (v1 + v2) * t;
        }
        return sR/1000;
    }

    // 3.	Пачка риса и коробка спичек вместе стоят 100 рублей 10 копеек. Пачка риса дороже коробки спичек на 100 рублей. Сколько стоит коробка спичек?

    static double GetCostOfSecondItem(double inTotalCost, double inPriceDifference)
    {
        return (inTotalCost - inPriceDifference) / 2;
    }

    // 4.	Пруд зарастает кувшинками. Каждый день их площадь удваивается. Целиком озеро зарастет за 48 дней. За сколько дней цветы поглотят половину его поверхности?

    // 5.	5 машин за 5 минут производят 5 штуковин. Сколько времени понадобится 100 машинам, чтобы произвести 100 штуковин?
}