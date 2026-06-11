// New instance of Random
using System.Collections.Concurrent;
using System.Security.Cryptography.X509Certificates;

Random rand = new Random();

// Initial variables to help with early decisions
bool beginDefence = false;
int delayCounter = 0;


// Promps the player to decide on the fight
beginDefence = StartFight(delayCounter);


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
        beginDefence = PlayerDefence();
    }

    // If it is the player's turn to attack, this logic follows.
    else
    {
        // The player is prompted to launch an attack. Only one attack type for now. The opponent's defensive action is decided by the code, and the logic for blocking and dodging is the same for now.
        beginDefence = PlayerAttack();
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

    // do while loop continues while either the player or the opponent have health.
} while (playerHealth > 0 && opponentHealth > 0);


// Method to prompt the player to decide whether to engage in the fight. If they answer no, then the game ends. If they answer yes, then the fight begins. If they fail to answer either yes or no, then they are prompted again, and if they fail to answer after 5 prompts, then the player is forced to defend themselves.
bool StartFight(int delayCounter)
{
    do
    {
        Console.WriteLine("A new challenger approaches. Do you engage, yes or no?");
        string? readResult = Console.ReadLine();
        if (readResult.ToLower() == "yes")
        {
            Console.WriteLine("You ready yourself and begin your attack.");
            return false;
        }
        else if (readResult.ToLower() == "no")
        {
            Environment.Exit(0);
            return false;
        }
        else
        {
            Console.WriteLine("Do not delay, for your enemy draws closer. Make your decision quickly.");
            delayCounter++;
            if (delayCounter > 5)
            {
                return true;
            }
        }
    } while (delayCounter < 5);
    return true;
}


// Method to prompt the player to decide how to defend themselves. For now, only two options: block or dodge, which have the same underlying logic.
bool PlayerDefence()
{
    Console.WriteLine("Your opponent launches a strike against you. How do you respond?");
    Console.WriteLine("1:\tBlock\n2:\tDodge");
    string? readResult = Console.ReadLine();

    switch (readResult)
    {
        case "1":
            int blockSuccess = rand.Next(0, 2);
            if (blockSuccess < 1)
            {
                int damageTaken = rand.Next(1, 4);
                Console.WriteLine($"You failed to block your opponent's attack. You take {damageTaken} damage.");
                playerHealth -= damageTaken;
                Console.WriteLine($"You now have {playerHealth} health.");
            }

            else
            {
                Console.WriteLine("You successfully block your opponent's attack. You take no damage.");
                Console.WriteLine($"You still have {playerHealth} health.");
            }
            break;

        case "2":
            int dodgeSuccess = rand.Next(0, 2);

            if (dodgeSuccess < 1)
            {
                int damageTaken = rand.Next(1, 4);
                Console.WriteLine($"You failed to dodge your opponent's attack. You take {damageTaken} damage");
                playerHealth -= damageTaken;
                Console.WriteLine($"You now have {playerHealth} health.");
            }

            else
            {
                Console.WriteLine("You successfully dodge your opponent's attack. You take no damage.");
                Console.WriteLine($"You still have {playerHealth} health");
            }
            break;
    }
    return false;
}

// Method to prompt the player to launch an attack. Only one attack type for now. The opponent's defensive action is decided by the code, and the logic for blocking and dodging is the same for now.
bool PlayerAttack()
{
    Console.WriteLine("You prepare to launch your attack.");
    Console.WriteLine("1: Attack");
    string? readResult = Console.ReadLine();
    switch (readResult)
    {
        case "1":
            int opponentAction = rand.Next(0, 2);

            switch (opponentAction)
            {
                case 0:
                    Console.WriteLine("Your opponent moves to block your attack.");
                    int blockSuccess = rand.Next(0, 2);

                    if (blockSuccess < 1)
                    {
                        int damageTaken = rand.Next(1, 4);
                        Console.WriteLine($"Your opponent fails to block your attack. He takes {damageTaken} damage.");
                        opponentHealth -= damageTaken;
                        Console.WriteLine($"Your opponent now has {opponentHealth} health.");
                    }

                    else
                    {
                        Console.WriteLine("Your opponent successfully blocked your attack. He takes no damage.");
                        Console.WriteLine($"He still has {opponentHealth} health");
                    }
                    break;

                case 1:
                    Console.WriteLine("Your opponent attempts to dodge your attack.");
                    int dodgeSuccess = rand.Next(0, 2);

                    if (dodgeSuccess < 1)
                    {
                        int damageTaken = rand.Next(1, 4);
                        Console.WriteLine($"Your opponent failed to dodge  your attack. He takes {damageTaken} damage");
                        opponentHealth -= damageTaken;
                        Console.WriteLine($"He now has {opponentHealth} health.");
                    }

                    else
                    {
                        Console.WriteLine("Your opponent successfully dodged your attack. He takes no damage.");
                        Console.WriteLine($"He still has {opponentHealth} health");
                    }
                    break;
            }
            break;

    }
    return true;
}


