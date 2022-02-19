Game Zahlenratespiel = new Game();
System.Console.WriteLine("Hallo und willkommen beim Zahlenratenspiel!");

Start:
Zahlenratespiel.start();
System.Console.WriteLine("Möchtest du nochmal spielen?[j/N]");

while (System.Console.ReadKey().Key == System.ConsoleKey.J) goto Start;
System.Console.WriteLine("Okay, danke fürs spielen und bis zum nächsten Mal!");
Thread.Sleep(1000);
Environment.Exit(0);

class Game
{
    int target_tries;
    int actual_tries;
    int scale;

    Random rnd = new Random();
    int random_num;
    int guessed_num;

    void initVal()
    {
        target_tries = 0;
        actual_tries = 0;
        scale = 0;
        random_num = 0;
        guessed_num = 0;
    }

    public void start()
    {
        do
        {
            initVal();
            System.Console.WriteLine("Zuerst wähle bitte deine Schwierigkeitsstufe");
            System.Console.WriteLine("Einfach[1]: 10 Versuche(1-100)\nMittel[2]: 6 Versuche(1-50)\nSchwer[3]: 3 Versuche(1-20)");
            System.Console.WriteLine("Drücke die enstsprechende [Taste], um deine Schwierigkeitsstufe zu wählen!");
            var choice = System.Console.ReadKey().Key;

            if (choice == System.ConsoleKey.D1)
            {
                System.Console.WriteLine("\nSchwierigkeitsstufe 'Einfach' gewählt");
                target_tries = 10;
                scale = 100;
            }

            else if (choice == System.ConsoleKey.D2)
            {
                System.Console.WriteLine("\nSchwierigkeitsstufe 'Mittel' gewählt");
                target_tries = 6;
                scale = 50;
            }

            else if (choice == System.ConsoleKey.D3)
            {
                System.Console.WriteLine("\nSchwierigkeitsstufe 'Schwer' gewählt");
                target_tries = 3;
                scale = 20;
            }

            else
            {
                System.Console.WriteLine("\nUngültige Eingabe!\nVersuche es erneut.");
                continue;
            }

            random_num = rnd.Next(1, scale);

        } while (target_tries == 0);

        System.Console.WriteLine("Okay lass uns anfangen!\nErrate eine Zahl zwischen 1 - {0}!", scale);

        do
        {
            System.Console.Write("Deine Eingabe[{0}]: ", actual_tries + 1);

            if (!int.TryParse(System.Console.ReadLine(), out guessed_num))
            {
                System.Console.WriteLine("\nUngültige Eingabe!\nVersuche es erneut.");
            }

            else
            {
                if (guessed_num < random_num)
                {
                    System.Console.WriteLine("\n{0} ist zu klein", guessed_num);
                    actual_tries++;
                }

                else if (guessed_num > random_num)
                {
                    System.Console.WriteLine("\n{0} ist zu groß", guessed_num);
                    actual_tries++;
                }

                else
                {
                    break;
                }
            }
        } while (actual_tries != target_tries);

        if (guessed_num == random_num) System.Console.WriteLine("Glückwunsch, du hast gewonnen!\nErratene Zahl: {0}", guessed_num);
        else System.Console.WriteLine("Schade, leider verloren.");
        Thread.Sleep(1000);
    }
}
