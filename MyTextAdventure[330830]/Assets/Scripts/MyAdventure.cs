using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyAdventure : MonoBehaviour
{
    // Declare all states
    private enum States
    {
        start,
        intro1,
        intro2,
        delen,
        deelnee,
        deelja,
        leukgesprek,
        deeltadres,
        nacht,
        checksloten,
        einde_dood,
        deur_dicht,
        geluid,
        rennen,
        kalmeren
    }

    private States currentState = States.start;

    // Start is called before the first frame update
    void Start()
    {
        ShowMainMenu();
    }

    // Handle user input
    void OnUserInput(string input)
    {
        switch (currentState)
        {
            case States.start:
                if (input == "start")
                {
                    currentState = States.intro1;
                    StartIntro1();
                }
                else if (input == "1337")
                {
                    Terminal.WriteLine("Jij bent leet!");
                }
                else
                {
                    Terminal.WriteLine("Verkeerde invoer");
                }
                break;
            case States.intro1:
                if (input == "verder")
                {
                    currentState = States.intro2;
                    StartIntro2();
                }
                break;
            case States.intro2:
                if (input == "verder")
                {
                    currentState = States.delen;
                    StartDelen();
                }
                break;
            case States.delen:
                if (input == "ja")
                {
                    currentState = States.deelja;
                    StartDelenJa();
                }
                else if (input == "nee")
                {
                    currentState = States.deelnee;
                    StartDelenNee();
                }
                break;
            case States.deelja:
                if (input == "verder")
                {
                    currentState = States.leukgesprek;
                    StartLeukgesprek();
                }
                break;
            case States.deelnee:
                if (input == "verder")
                {
                    currentState = States.leukgesprek;
                    StartLeukgesprek();
                }
                break;
            case States.leukgesprek:
                if (input == "verder")
                {
                    currentState = States.deeltadres;
                    StartDeeltadres();
                }
                break;
            case States.deeltadres:
                if (input == "verder")
                {
                    currentState = States.nacht;
                    StartNacht();
                }
                break;
            case States.nacht:
                if (input == "verder")
                {
                    currentState = States.checksloten;
                    Startchecksloten();
                }
                break;
            case States.checksloten:
                if (input == "ja")
                {
                    currentState = States.deur_dicht;
                    Startdeur_dicht();
                }
                else if (input == "nee")
                {
                    currentState = States.einde_dood;
                    Starteinde_dood();
                }
                break;
            case States.einde_dood:
                if (input == "restart")
                {
                    currentState = States.intro1;
                    StartIntro1();
                }
                break;
            case States.deur_dicht:
                if (input == "verder")
                {
                    currentState = States.geluid;
                    Startgeluid();
                }
                break;
            case States.geluid:
                if (input == "rennen")
                {
                    currentState = States.rennen;
                    Startrennen();
                }
                else if (input == "kalmeren")
                {
                    currentState = States.kalmeren;
                    Startkalmeren();
                }
                break;
            case States.kalmeren:
                if (input == "restart")
                {
                    currentState = States.intro1;
                    StartIntro1();
                }
                break;
            case States.rennen:
                if (input == "verder")
                {
                    Starteinde();
                }
                break;
        }
    } 

    void ShowMainMenu()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Welkom bij HorrorNite!\n");
        Terminal.WriteLine("Dit is gebasseerd op een waargebeurd verhaal");
        Terminal.WriteLine("Type \"start\" om te beginnen");
    }

    void StartIntro1()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Het was een koude donkere nacht. Een goede nacht om Fortnite te doen\n");
        Terminal.WriteLine("Een goede nacht om Fortnite te doen\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");

    }

    void StartIntro2()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Tijdens het gamen ontmoet je online een persoon");
        Terminal.WriteLine("Jullie gamen samen gezellig een aantal uren verder\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");

    }

    void StartDelen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("De persoon waar je gezellig mee aan het gamen bent vraagt of jij je gegevens wilt delen met hem");
        Terminal.WriteLine("Gegevens delen?\n");
        Terminal.WriteLine("Type \"ja\" als je jou gegevens te delen");
        Terminal.WriteLine("Type \"nee\" als je jou gegevens niet wilt delen");
    }

    void StartDelenJa()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je deelt je gegevens");
        Terminal.WriteLine("Even later komt er een request binnen\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void StartDelenNee()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je deelt je gegevens niet");
        Terminal.WriteLine("Even later komt er toch een request binnen\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void StartLeukgesprek()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Jullie zijn inmiddels gestopt met gamen");
        Terminal.WriteLine("Jullie praten nog gezellig tot laat in de nacht\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void StartDeeltadres()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Even later wordt er gevraagt of je je adres wilt delen");
        Terminal.WriteLine("Omdat het erg gezellig is besluit je dit te doen.\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void StartNacht()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Inmiddels is het al laat in nacht");
        Terminal.WriteLine("Je besluit naar bed te gaan.\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void Startchecksloten()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je ligt al lekker in je bed");
        Terminal.WriteLine("Maar opeens twijfel je of je de deur wel op slot hebt gedaan");
        Terminal.WriteLine("Ga je uit bed om de sloten te checken?\n");
        Terminal.WriteLine("Type \"ja\" om de sloten te checken");
        Terminal.WriteLine("Type \"nee\" om de sloten niet te checken");
    }

    void Starteinde_dood()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("De vriend die je tijdens het gamen hebt ontmoet");
        Terminal.WriteLine("Staat ineens voor je met een mes en steekt je in je buik");
        Terminal.WriteLine("Je bent dood\n");
        Terminal.WriteLine("Type \"restart\" om opnieuw te beginnen");
    }

    void Startdeur_dicht()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Geluk! je ziet dat de deur nog open was");
        Terminal.WriteLine("Je draait de deur op slot");
        Terminal.WriteLine("Je gaat terug naar bed en valt in slaap\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void Startgeluid()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je hoort een hard geluid en wordt wakker");
        Terminal.WriteLine("Je loopt naar beneden om te kijken wat het was");
        Terminal.WriteLine("Voor je staat de vriend die je eerder hebt ontmoet met gamen met een mes in zijn hand\n");
        Terminal.WriteLine("Type \"rennen\" om weg te rennen");
        Terminal.WriteLine("Type \"kalmeren\" om hem te kalmeren");
    }

    void Startrennen()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je rent snel weg");
        Terminal.WriteLine("gelukkig heb je je telefoon bij je");
        Terminal.WriteLine("en bel je de politie\n");
        Terminal.WriteLine("Type \"verder\" om door te gaan met het verhaal");
    }

    void Startkalmeren()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("Je probeert tegen hem te kalmeren door tegen hem te praten");
        Terminal.WriteLine("Het lukt niet");
        Terminal.WriteLine("Hij steekt je in je buik");
        Terminal.WriteLine("je bent dood\n");
        Terminal.WriteLine("Type \"restart\" om door te gaan met het verhaal");
    }

    void Starteinde()
    {
        Terminal.ClearScreen();
        Terminal.WriteLine("De politie is ter plaatsen");
        Terminal.WriteLine("De crimineel wordt op gepakt");
        Terminal.WriteLine("Je hebt gewonnen!!!\n");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
