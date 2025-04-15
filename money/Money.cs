using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace money
{
    public class Money
    {
        private int hryvnia;
        private int kopiyka;

        public Money(int hryvnia, int kopiyka)
        {
            if (hryvnia < 0 || kopiyka < 0)
                throw new ArgumentException("Сумма не может быть отрицательной.");

            
            this.hryvnia = hryvnia + kopiyka / 100;
            this.kopiyka = kopiyka % 100;
        }
        public int Hryvnia => hryvnia;
        public int Kopiyka => kopiyka;

        public static Money operator +(Money m1, Money m2)
        {
            int totalHryvnia = m1.hryvnia + m2.hryvnia;
            int totalKopiyka = m1.kopiyka + m2.kopiyka;

            totalHryvnia += totalKopiyka / 100;
            totalKopiyka %= 100;

            return new Money(totalHryvnia, totalKopiyka);
        }

        public static Money operator -(Money m1, Money m2)
        {
            int totalHryvnia = m1.hryvnia - m2.hryvnia;
            int totalKopiyka = m1.kopiyka - m2.kopiyka;

            if (totalHryvnia < 0 || (totalHryvnia == 0 && totalKopiyka < 0))
                throw new BankruptException("Банкрот: отрицательная сумма.");

            if (totalKopiyka < 0)
            {
                totalHryvnia--;
                totalKopiyka += 100;
            }

            return new Money(totalHryvnia, totalKopiyka);
        }

        public static Money operator /(Money m, int divisor)
        {
            if (divisor <= 0)
                throw new ArgumentException("Делитель должен быть положительным числом.");

            int totalKopiyka = m.hryvnia * 100 + m.kopiyka;
            totalKopiyka /= divisor;

            return new Money(totalKopiyka / 100, totalKopiyka % 100);
        }

        public static Money operator *(Money m, int multiplier)
        {
            if (multiplier < 0)
                throw new ArgumentException("Множитель не может быть отрицательным.");

            int totalKopiyka = (m.hryvnia * 100 + m.kopiyka) * multiplier;
            return new Money(totalKopiyka / 100, totalKopiyka % 100);
        }

        public static Money operator ++(Money m)
        {
            int totalKopiyka = m.hryvnia * 100 + m.kopiyka + 1;
            return new Money(totalKopiyka / 100, totalKopiyka % 100);
        }

        public static Money operator --(Money m)
        {
            int totalKopiyka = m.hryvnia * 100 + m.kopiyka - 1;

            if (totalKopiyka < 0)
                throw new BankruptException("Банкрот: отрицательная сумма.");

            return new Money(totalKopiyka / 100, totalKopiyka % 100);
        }

        public static bool operator ==(Money m1, Money m2)
        {
            return m1.hryvnia == m2.hryvnia && m1.kopiyka == m2.kopiyka;
        }
        public static bool operator !=(Money m1, Money m2)
        {
            return !(m1 == m2);
        }

        public static bool operator <(Money m1, Money m2)
        {
            if (m1.hryvnia < m2.hryvnia)
                return true;
            if (m1.hryvnia == m2.hryvnia && m1.kopiyka < m2.kopiyka)
                return true;
            return false;
        }

        public static bool operator >(Money m1, Money m2)
        {
            if (m1.hryvnia > m2.hryvnia)
                return true;
            if (m1.hryvnia == m2.hryvnia && m1.kopiyka > m2.kopiyka)
                return true;
            return false;
        }

        public override string ToString()
        {
            return $"{hryvnia} грн {kopiyka} коп";
        }

        public override bool Equals(object obj)
        {
            if (obj is Money other)
                return this == other;
            return false;
        }

        public override int GetHashCode()
        {
            return hryvnia.GetHashCode() ^ kopiyka.GetHashCode();
        }
    }
}
