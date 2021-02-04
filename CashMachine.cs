//Übung CashMachine

using System;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            const int PINCODE = 1234;
            const int BANKBALANCE = 70;       //Kontostand
            const int OVERDRAFT_LIMIT = 20;   //Überziehungsrahmen
            const int AVAILABLE_MONEY = 100;  //Im Bankomat verfügbares Bargeld

            int enteredPin;
            int wrongTries = 0;
            int moneyToWidthdraw;
            
            do
            {
                Console.Write("Pin eingeben:");
                enteredPin = Convert.ToInt32(Console.ReadLine());
                if (enteredPin!=PINCODE)
                {
                    Console.WriteLine("Pin Code falsch!");
                    wrongTries++;
                }

            } while (enteredPin != PINCODE && wrongTries<3);

            if (wrongTries>=3)  //3 falsche Eingaben
            {
                Console.WriteLine("Karte wird eingezogen!");
            }
            else
            {
                do  //Betrag einlesen
                {
                    Console.Write("Betrag eingeben:");
                    moneyToWidthdraw = Convert.ToInt32(Console.ReadLine());
                    if (moneyToWidthdraw > AVAILABLE_MONEY) //Betrag übersteigt verfügbares Geld im Bankomat
                    {
                        Console.WriteLine($"Es sind nur {AVAILABLE_MONEY} Euro verfügbar.");
                        wrongTries++;
                    }
                    else if (moneyToWidthdraw>(BANKBALANCE+OVERDRAFT_LIMIT)) //Betrag übersteigt Kontostand und Überziehungslimit
                    {
                        Console.WriteLine($"Maximale Kontobelastung {BANKBALANCE+OVERDRAFT_LIMIT} Euro.");
                        wrongTries++;
                    }
                } while (((moneyToWidthdraw > AVAILABLE_MONEY) || (moneyToWidthdraw>(BANKBALANCE+OVERDRAFT_LIMIT)))
                        && wrongTries < 2);
                if (wrongTries<2)
                {
                    Console.WriteLine("Betrag wird ausbezahlt");
                }
                else
                {
                    Console.WriteLine("Erneut falscher Betrag eingegeben! Auf Wiedersehen!");
                }
            }
        }
    }
}
