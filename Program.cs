// New instance of Random
Random rand = new Random();

// Initial variables to help with early decisions
bool begin = false;
bool beginDefence;
int delayCounter = 0;
string? readResult;

// Test to see whether player is ready to engage. It continues as long as the player does not answer yes
do
{
    // Promps the player to decide on the fight
    Console.WriteLine("A new challenger approaches. Do you engage, yes or no?");
    readResult = Console.ReadLine();
    // If they delay for too long, the player is forced to defend themselves. They are put at a disadvantage, as they must defend first
    if (delayCounter >= 3)
    {
        Console.WriteLine("You have hesitated too long. Defend yourself.");
        begin = true;
        beginDefence = true;
    }

    // The player may back out of the fight. For now, this simply closes the application
    else if(readResult.ToLower() == "no")
    {
        Environment.Exit(0);
    }

    // If the player chooses to engage, they are given an advantage, since they may now attack first
    else if(readResult.ToLower() == "yes")
    {
        Console.WriteLine("You ready yourself and begin your attack.");
        beginDefence = false;
        begin = true;
    }

    // If a result is given that does not match yes or no, it is treated as indecision, and the delay counter increases
    else
    {
        Console.WriteLine("Do not delay, for your enemy draws closer. Make your decision quickly.");
        Console.WriteLine("");
        delayCounter++;
    }
}
while (!begin);
