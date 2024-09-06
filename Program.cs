Meny
using Meny;

namespace Meny
{
internal class Meny
{
static void Main(string[] args)
{
bool isRunning = true;
while (isRunning)
{
Console.WriteLine("----------------------------------------");
Console.WriteLine("[G]issa talet");
Console.WriteLine("[Te]mperatur i olika städer");
Console.WriteLine("[D]atorn gissar talet");
Console.WriteLine("[Tä]rningskast");
Console.WriteLine("[O]mvänd triangel");
Console.WriteLine("[K]rona eller klave");
Console.WriteLine("[A]vsluta");
Console.Write("Val: ");
string choice = Console.ReadLine();
switch (choice.ToLower())
{
    case "g":
        Games.guessNumber();
        break;
    case "te":
        Data.cityTemperature();
        break;
    case "d":
        Games.computerGuess();
        break;
    case "tä":
        Data.dice();
        break;
    case "o":
        Data.triangle();
        break;
    case "k":
        Data.headOrTale();
        break;
    case "a":
        Console.WriteLine("Avslutar...");
        isRunning = false;
        break;
    default:
        Console.WriteLine("Vad menar du nu? Testa igen.");
        break;
}
}
}   }   }


Games
using System;

namespace Meny
{
internal class Games
{   
public static void guessNumber()
{   //Gissa rätt tal mellan 1-100.
Console.WriteLine("----------------------------------------");
Console.WriteLine("Jag tänker på ett tal. Gissa vilket mellan 1-100!");
int guess = int.Parse(Console.ReadLine());
Random randomNumber = new Random();
int number = randomNumber.Next(1, 101);                 //Ett random tal mellan 1-100
int attempts = 1;                                       //1 för att det ska bli rätt antal gissningar
do
{
    attempts++;
    Console.WriteLine("Gissa igen.");                   //"Gissa igen" kommer varje loop
    if (guess < number)
        Console.WriteLine("Mitt tal är högre!");
    else if (guess > number)
        Console.WriteLine("Mitt tal är lägre!");
    guess = int.Parse(Console.ReadLine());              //Ropar på "Gissa igen"
}
while (guess != number);
Console.WriteLine("Grattis du gissade rätt! Antal försök: " + attempts);
Console.Write("Tryck enter för meny");
Console.ReadKey();
}
public static void computerGuess()
{   //Ett spel där datorn gissar rätt siffra mellan 1-100.
Console.WriteLine("----------------------------------------");
Console.WriteLine("DU ska tänka på ett tal mellan 1-100. Tryck enter för att börja!");
Console.ReadKey();
int guess;
int attempts = 0;
int min = 1;
int max = 100;
string answer;
do
{
    int computerGuess = (min + max) / 2;    //min+max/2=gör en binär sökning=mindre försök
    attempts++;
    Console.WriteLine($"Jag gissar på " + computerGuess + "! Är det [h]ögre, [l]ägre eller [r]ätt?");
    answer = Console.ReadLine().ToLower();  //ToLower tar både liten och stor bokstav.
    if (answer == "h")
        min = computerGuess + 1;        //+1 för att det rätta talet är minst 1 högre än det datorn gissar.
    else if (answer == "l")
        max = computerGuess - 1;        //-1 för att det rätta talet är minst 1 mindre än det datorn gissar.
}
while (answer != "r");
Console.WriteLine("JAAA jag gissade rätt! Antal försök: " + attempts);
Console.Write("Tryck enter för meny");
Console.ReadKey();
}
}
}


Data
using System;

namespace Meny
{
internal class Data
{
public static void cityTemperature()
{   //Ett program som berättar var det är kallast.
Console.WriteLine("----------------------------------------");
Console.Write("Vad är temperaturen i Motala? ");
double temp1 = Convert.ToDouble(Console.ReadLine());    //Går även att använda float som lagrar
Console.Write("Vad är temperaturen i Halmstad? ");      //upp till 7 decimaler.
double temp2 = Convert.ToDouble(Console.ReadLine());
Console.Write("Vad är temperaturen i Kiruna? ");
double temp3 = Convert.ToDouble(Console.ReadLine());
if (temp1 < temp2 && temp1 < temp3)                     //Använder jämförande och logiska operatorer.
    Console.WriteLine("Det är kallast i Motala!");
else if (temp2 < temp1 && temp2 < temp3)
    Console.WriteLine("Det är kallast i Halmstad!");
else if (temp3 < temp1 && temp3 < temp2)
    Console.WriteLine("Det är kallast i Kiruna!");
else
    Console.WriteLine("Det är samma grader i alla 3 städer!");
Console.Write("Tryck enter för meny");
Console.ReadKey();
}
public static void dice()
{   //Ett program som slumpar fram tärningsslag 5 gånger.
Random rndNr = new Random();
int dice = 0;
while (dice < 5)
{
    int number = rndNr.Next(1, 7);     //Genererar ett nummer mellan 1-6
    Console.WriteLine(number);
    dice++;
}
Console.Write("Tryck enter för meny");
Console.ReadKey();
}
public static void triangle()
{   //Ett program som gör en triangel med basen nedåt.
Console.WriteLine("----------------------------------------");
Console.Write("Ange antal: ");
int number = int.Parse(Console.ReadLine());
int i = 0;
while (i <= number)  //loopa nr antal gånger(tack vare i++). Denna är vertikal.
{
    int j = 0;
    while (j <= i)  //loopa nr antal gånger(tack vare j++). Denna är horisontell.
    {
        Console.Write(number);
        j++;
    }
    Console.WriteLine();
    i++;
}
Console.Write("Tryck enter för meny");
Console.ReadKey();
}
public static void headOrTale()
{   //Ett program som gör en triangel med basen nedåt.
Console.WriteLine("----------------------------------------");
Console.Write("Hur många gånger vill du singla slant?: ");
int nrThrows = int.Parse(Console.ReadLine());   //VIKTIGT att namnge variabeln RÄTT!
Random rnd = new Random();
for (int i = 0; i<nrThrows; i++)              //for istället för while. while delar upp
{                                               //innehållet på 3 rader.
    int tal = rnd.Next(0, 2);                   //Generar 0 och 1.
    if (tal == 0)
        Console.WriteLine("Klave");
    else if (tal == 1)
        Console.WriteLine("Krona");
}
Console.Write("Tryck enter för meny");
Console.ReadKey();
}
}
}