using System;

namespace Geldautomat
{
    class Program
    {
        static void Main()
        {
            Display_Menü display = new Display_Menü();

            while (display.Mashine == State.Running)
            {
                Greeting();
                QueryCardID();
                string cardID = Console.ReadLine();
                display.CardCheck(cardID);
                if (display.User == State_login.CardBlocked || display.User == State_login.CardRejected)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Ihre Karte ist ungültig.Bitte wenden Sie sich an einen Bankmitarbeiter.");
                    Console.ResetColor();
                    return;
                }
                else
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nIhre Karte ist gültig");
                    Console.ResetColor();
                break;
            }

            QueryMenu_1();

            char User_Input = char.Parse(Console.ReadLine());
            switch (User_Input)
            {
                case 'a':
                    QueryMenu_MoneyAmount();
                    {
                        switch (User_Input)
                        {
                            case 'a':
                            case 'b':
                            case 'c':
                            case 'd':
                            case 'e':
                                break;
                            default:
                                return;
                        }   
                    }

                    Query_MenuY_N();
                    Char Y_N = char.Parse(Console.ReadLine());

                    do
                    {
                        if (Y_N == 'J' || Y_N == 'j')
                        {
                        break;
                        } 
                        Farewell();
                        return;
                    }
                    while (Y_N == 'N' || Y_N == 'n');
                        break;

                case 'b':
                    Console.WriteLine("\nLegen Sie das Geld in das vorhandende Fach.");
                    break;

                case 'c':
                    Console.WriteLine("\nBitte warten Sie einen Moment, ihre Kontoauszüge werden gedruckt.");
                    break;

                case 'd':

                    do
                    {
                        Farewell();
                        return;
                    }
                    while (User_Input == 'd');
            }


            Console.WriteLine("\nBitte geben Sie Ihren Pin ein:");

            do
            {
                string Pin = Console.ReadLine();
                short Input_pin;
                Input_pin = short.Parse(Pin);
                display.Pin_Input(Input_pin);
            }
            while (display.User != State_login.UserLoggedIn || display.User != State_login.CardBlocked);

            if (display.User == State_login.CardBlocked)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Karte gesperrt!Bitte informieren Sie einen Bankmitarbeiter!");
                Console.ResetColor();
                Farewell();
                return;
            }

            Farewell();
        }



        private static void Greeting()
        {
            Console.WriteLine("Herzlich Willkommen!");
        }

        private static void QueryCardID()
        {   
            Console.WriteLine("\nBitte schieben Sie Ihre Bankkarte in den Automaten und geben Sie Ihre CardID ein:");
        }

        private static void QueryMenu_1()
        {
            Console.WriteLine("\nBitte wählen Sie eine Aktion aus der folgenden Liste aus:");
            Console.WriteLine("\ta - Geld abheben");
            Console.WriteLine("\tb - Geld einzahlen");
            Console.WriteLine("\tc - Kontoauszüge drucken");
            Console.WriteLine("\td - Beenden");
            Console.WriteLine("\nIhre Auswahl?");
        }

        private static void QueryMenu_MoneyAmount()
        {
            Console.WriteLine("\nWelchen Betrag möchten Sie abheben?");
            Console.WriteLine("\ta - 50 Euro");
            Console.WriteLine("\tb - 100 Euro");
            Console.WriteLine("\tc - 150 Euro");
            Console.WriteLine("\td - 200 Euro");
            Console.WriteLine("\te - 250 Euro");
            Console.WriteLine("\nIhre Auswahl?");
        }

        private static void Query_MenuY_N()
        {
            Console.WriteLine("\nBitte beachten Sie, wenn Sie kein Kunde unserer Bank sind beträgt die Zusatzgebühr 4,95 Euro.");
            Console.WriteLine("Möchten Sie trotzdem fortfahren? Bitte geben Sie J für Ja und N für Nein ein.");
        }

        private static void Farewell()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nBitte entnehmen Sie Ihre Bankkarte.");
            Console.ResetColor();
            Console.WriteLine("Vielen Dank und auf Wiedersehen.");
        }
    }
}
