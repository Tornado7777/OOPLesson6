using System;


namespace OOPLesson6
{
    internal class ChekInBank
    {
        /* 
         * Для класса банковский счет переопределить операторы == и != 
         * для сравнения информации в двух счетах. Переопределить метод
         * Equals аналогично оператору ==, не забыть переопределить метод 
         * GetHashCode(). Переопределить метод ToString() для печати 
         * информации о счете. Протестировать функционирование 
         * переопределенных методов и операторов на простом примере.
         */
        private int _numberChek;
        private int _balanc;
        private TypeChek _typeChek;
        private static int startChekNumber;

        public int numberChek
        {
            get
            {
                return _numberChek;
            }

            set
            {
                if (_numberChek != 0) Console.WriteLine("Номер счета будет изменен с " + _numberChek + " на " + value);
                _numberChek = value;
            }
        }

        public int balanc
        {
            set
            {
                _balanc = value;
            }
            get
            {
                return _balanc;
            }
        }

        public TypeChek typeChek
        {
            set
            {
                _typeChek = value;
            }

            get
            {
                return _typeChek;
            }
        }
        /// <summary>
        /// снятие со счета суммы
        /// </summary>
        /// <param name="sum"></param>
        /// <returns></returns>
        public bool WithdrawFromChek(int sum)
        {
            bool withdrawSucces = false;
            if (_balanc - sum >= 0)
            {
                _balanc = _balanc - sum;
                Console.WriteLine("Со счета " + _numberChek + " снята сумма: " + sum);
                withdrawSucces = true;
            }
            else Console.WriteLine("На счете " + _numberChek + " недостаточно средств для снятия: " + sum);
            return withdrawSucces;
        }
        /// <summary>
        /// Положить деньги на счет
        /// </summary>
        /// <param name="sum"></param>
        public bool ToDeposit(int sum)
        {
            bool result = false;
            _balanc += sum;
            Console.WriteLine("На счет " + _numberChek + " положена сумма: " + sum);
            result = true;
            return result;
        }


        /// <summary>
        /// Перевод на счет
        /// </summary>
        public void Transfer(ChekInBank fromTransfer, int sum)
        {
            if (fromTransfer != null)
            {
                if (fromTransfer.WithdrawFromChek(sum))
                {
                    if (this.ToDeposit(sum)) Console.WriteLine("Перевод средств " + sum + " со счета " +
                        fromTransfer.numberChek + " на счет " + this._numberChek + " успешно завершено!");
                };
            }
            else Console.WriteLine("Счета для перевода средств не существует");
        }
   
        public ChekInBank() : this(balanc: 0, typeChek: TypeChek.empty)
        {

        }
        public ChekInBank(TypeChek typeChek) : this(balanc: 0)
        {

        }
        public ChekInBank(int balanc) : this(balanc, typeChek: TypeChek.empty)
        {

        }
        public ChekInBank(int balanc, TypeChek typeChek)
        {
            _balanc = balanc;
            _typeChek = typeChek;
            _numberChek = RandomChekNumber();
        }

        public void ConsoleShowChek()
        {
            Console.WriteLine("\nДанные номера счета:" + _numberChek);
            Console.WriteLine("Тип счета: " + _typeChek);
            Console.WriteLine("Баланс счета: " + _balanc);
        }

        private int RandomChekNumber()
        {
            Random rnd = new Random();
            int randomChekNumber = rnd.Next(startChekNumber, startChekNumber + 10);
            startChekNumber = startChekNumber + 11;

            return randomChekNumber;
        }

        public override bool Equals(object obj)
        {
            return obj is ChekInBank bank &&
                   _numberChek == bank._numberChek &&
                   _balanc == bank._balanc &&
                   _typeChek == bank._typeChek;
        }

        public override int GetHashCode()
        {
            return 1205484828 + _numberChek.GetHashCode() + _balanc.GetHashCode() + _typeChek.GetHashCode();
        }

        public override string ToString()
        {
            string result = "\nДанные номера счета:" + _numberChek + "\n";
            result += "Тип счета: " + _typeChek + "\n";
            result += "Баланс счета: " + _balanc + "\n";
            return result;
        }

        public static bool operator ==(ChekInBank a, ChekInBank b)
        {
            bool result = false;
            if (a.balanc == b.balanc && a.numberChek == b.numberChek && a.typeChek == b.typeChek) result = true;
            return result;
        }
        public static bool operator !=(ChekInBank a, ChekInBank b)
        {
            bool result = true;
            if (a.balanc == b.balanc && a.numberChek == b.numberChek && a.typeChek == b.typeChek) result = false;
            return result;
        }
        public enum TypeChek
        {
            type1,
            type2,
            type3,
            empty
        }
    }


}
