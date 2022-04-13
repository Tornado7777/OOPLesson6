using System;


namespace OOPLesson6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //проверка работы конструкторов
            ChekInBank chekInBank = new ChekInBank();
            ChekInBank chekInBank2 = new ChekInBank(60000,ChekInBank.TypeChek.type3);
            chekInBank.numberChek = 80000;
            chekInBank.typeChek = ChekInBank.TypeChek.type2;
            chekInBank.balanc = 999;
            Console.WriteLine(chekInBank.ToString());
            chekInBank2.ConsoleShowChek();
            //проверка опреаторов == и  !=
            Console.WriteLine($"Сравнение счетов {chekInBank.numberChek} == {chekInBank2.numberChek} ");
            Console.WriteLine(chekInBank == chekInBank2);
            Console.WriteLine($"Сравнение счетов {chekInBank.numberChek} == {chekInBank.numberChek} ");
            Console.WriteLine(chekInBank == chekInBank);
            Console.WriteLine($"Сравнение счетов {chekInBank.numberChek} != {chekInBank2.numberChek} ");
            Console.WriteLine(chekInBank != chekInBank2);
            Console.WriteLine($"Сравнение счетов {chekInBank.numberChek} != {chekInBank.numberChek} ");
            Console.WriteLine(chekInBank != chekInBank);
            Console.WriteLine($"Сравнение счетов {chekInBank.numberChek} Equals {chekInBank2.numberChek} ");
            Console.WriteLine(chekInBank.Equals(chekInBank2));
            Console.WriteLine($"Сравнение счетов {chekInBank.numberChek} Equals {chekInBank.numberChek} ");
            Console.WriteLine(chekInBank.Equals(chekInBank));

            Console.WriteLine($"GetHashCode счета номер : {chekInBank2.numberChek}");
            Console.WriteLine(chekInBank2.GetHashCode());

            Console.ReadLine();

        }
    }
}
