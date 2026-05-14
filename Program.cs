// New instance of Random
using System.Security.Cryptography.X509Certificates;

Random rand = new Random();

// Initial variables to help with early decisions
bool begin = false;
bool beginDefence = false;
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

// Sets health for both parties
int playerHealth = 10;
int opponentHealth = 10;

// Combat begins
do
{
    // Checks if it is the player's turn to defend
    if (beginDefence == true)
    {
        // If so, the player is prompted to decide how to defend themselves. For now, only two options: block or dodge, which have the same underlying logic.
        Console.WriteLine("Your opponent launches a strike against you. How do you respond?");
        Console.WriteLine("1:\tBlock\n2:\tDodge");
        readResult = Console.ReadLine();

        switch (readResult)
        {
            // Player block (same logic as dodging for now). The chance of success is 50/50 until I can add more complex logic.
            case "1":
                int blockSuccess = rand.Next(0, 2);

                // If the block failed, then the player takes a random amount of damage between 1 and 3.
                if (blockSuccess < 1)
                {
                    int damageTaken = rand.Next(1, 4);
                    Console.WriteLine($"You failed to block your opponent's attack. You take {damageTaken} damage.");
                    playerHealth -= damageTaken;
                    Console.WriteLine($"You now have {playerHealth} health.");
                }

                // If the block succeeded, then the player takes no damage.
                else
                {
                    Console.WriteLine("You successfully block your opponent's attack. You take no damage.");
                    Console.WriteLine($"You still have {playerHealth} health.");
                }
                break;
            // Player dodges (same logic as blocking for now). Chances of success are 50/50 chance for now, until I can add more complex logic.
            case "2":
                int dodgeSuccess = rand.Next(0, 2);

                // If the dodge failed, then the player takes a random amount of damage between 1 and 3.
                if (dodgeSuccess < 1)
                {
                    int damageTaken = rand.Next(1, 4);
                    Console.WriteLine($"You failed to dodge your opponent's attack. You take {damageTaken} damage");
                    playerHealth -= damageTaken;
                    Console.WriteLine($"You now have {playerHealth} health.");
                }

                // If the dodge succeeded, then the player takes no damage.
                else
                {
                    Console.WriteLine("You successfully dodge your opponent's attack. You take no damage.");
                    Console.WriteLine($"You still have {playerHealth} health");
                }
                break;
        }
    }



    // If it is the player's turn to attack, this logic follows.
    else
    {
        // Player is prompted to launch an attack. Only one attack type for now.
        Console.WriteLine("You prepare to launch your attack.");
        Console.WriteLine("1: Attack");
        readResult = Console.ReadLine();
        switch (readResult)
        {
            // On the attack, the code decides on the opponent's defensive action, either block or dodge. Both have the same underlying logic for now.
            case "1":
                int opponentAction = rand.Next(0, 2);

                switch (opponentAction)
                {
                    // Opponent blocks
                    case 0:
                        Console.WriteLine("Your opponent moves to block your attack.");
                        int blockSuccess = rand.Next(0, 2);

                        // If the block failed, then the opponent takes a random amount of damage between 1 and 3.
                        if (blockSuccess < 1)
                        {
                            int damageTaken = rand.Next(1, 4);
                            Console.WriteLine($"Your opponent fails to block your attack. He takes {damageTaken} damage.");
                            opponentHealth -= damageTaken;
                            Console.WriteLine($"Your opponent now has {opponentHealth} health.");
                        }

                        // If the block succeeded, then the opponent takes no damage.
                        else
                        {
                            Console.WriteLine("Your opponent successfully blocked your attack. He takes no damage.");
                            Console.WriteLine($"He still has {opponentHealth} health");
                        }
                        break;

                    // Opponent dodges
                    case 1:
                        Console.WriteLine("Your opponent attempts to dodge your attack.");
                        int dodgeSuccess = rand.Next(0, 2);

                        // If the dodge failed, then the opponent takes a random amount of damage between 1 and 3.
                        if (dodgeSuccess < 1)
                        {
                            int damageTaken = rand.Next(1, 4);
                            Console.WriteLine($"Your opponent failed to dodge  your attack. He takes {damageTaken} damage");
                            opponentHealth -= damageTaken;
                            Console.WriteLine($"He now has {opponentHealth} health.");
                        }

                        // If the dodge succeeded, then the opponent takes no damage.
                        else
                        {
                            Console.WriteLine("Your opponent successfully dodged your attack. He takes no damage.");
                            Console.WriteLine($"He still has {opponentHealth} health");
                        }
                        break;
                }
                break;
            
        }
    }
    // If the player runs out of health, then it is game over. 
    if (playerHealth <= 0)
    {
        Console.WriteLine("It is a sad day. The hero has perished.");
    }

    // If the opponent runs out of health, then the player wins.
    else if (opponentHealth <= 0)
    {
        Console.WriteLine("Rejoice! You have bested your opponent!");
    }

    // If neither are dead, then the value of the defence variable is inverted. Defenders become attackers, and attackers become defenders.
    else
    {
        beginDefence = !beginDefence;
    }
    
    // do while loop continues while either the player or the opponent have health.
} while (playerHealth > 0 && opponentHealth > 0);