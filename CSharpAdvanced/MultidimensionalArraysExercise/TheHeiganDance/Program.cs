using System;

namespace TheHeiganDance
{
    class Program
    {
        private const int ChamberSize = 15;
        private const double CloudDamage = 3500;
        private const double EruptionDamage = 6000;
        private const double PlayerHealth = 18500;
        private const double HeiganHealth = 3000000;

        static void Main(string[] args)
        {
            int[] playerPosistion = new int[] { ChamberSize / 2, ChamberSize / 2 };
            double damageToHeigan = double.Parse(Console.ReadLine());

            double heiganPoints = HeiganHealth;
            double playerPoints = PlayerHealth;
            bool isHeiganDead = false;
            bool isPlayerDead = false;
            bool hasCloud = false;
            string deathCause = String.Empty;

            while (true)
            {
                string[] spellTokens = Console.ReadLine().Split();
                string spell = spellTokens[0];
                int spellRow = int.Parse(spellTokens[1]);
                int spellCol = int.Parse(spellTokens[2]);

                heiganPoints -= damageToHeigan;
                isHeiganDead = heiganPoints <= 0;

                if (hasCloud)
                {
                    playerPoints -= CloudDamage;
                    hasCloud = false;
                    isPlayerDead = playerPoints <= 0;
                }

                if (isHeiganDead || isPlayerDead)
                {
                    break;
                }

                if (IsPlayerDamagedZone(playerPosistion, spellRow, spellCol))
                {
                    if (!PlayerTryEscape(playerPosistion, spellRow, spellCol))
                    {
                        switch (spell)
                        {
                            case "Cloud":
                                playerPoints -= CloudDamage;
                                hasCloud = true;
                                deathCause = "Plague Cloud";
                                break;
                            case "Eruption":
                                playerPoints -= EruptionDamage;
                                deathCause = spell;
                                break;
                        }
                    }
                }

                isPlayerDead = playerPoints <= 0;
                if (isPlayerDead)
                {
                    break;
                }
            }

            PrintResult(playerPosistion, heiganPoints, playerPoints, deathCause);
        }

        private static void PrintResult(int[] playerPosistion, double heiganPoints, double playerPoints, string deathCause)
        {
            if (heiganPoints <= 0)
            {
                Console.WriteLine("Heigan: Defeated!");
            }
            else
            {
                Console.WriteLine($"Heigan: {heiganPoints:f2}");
            }

            if (playerPoints <= 0)
            {
                Console.WriteLine($"Player: Killed by {deathCause}");
            }
            else
            {
                Console.WriteLine($"Player: {playerPoints}");
            }

            Console.WriteLine($"Final position: {playerPosistion[0]}, {playerPosistion[1]}");
        }

        private static bool PlayerTryEscape(int[] playerPosistion, int spellRow, int spellCol)
        {
            if (playerPosistion[0] - 1 >= 0 && playerPosistion[0] - 1 < spellRow - 1)
            {
                playerPosistion[0]--;
                return true;
            }
            else if (playerPosistion[1] + 1 < ChamberSize && playerPosistion[1] + 1 > spellCol + 1)
            {
                playerPosistion[1]++;
                return true;
            }
            else if (playerPosistion[0] + 1 < ChamberSize && playerPosistion[0] + 1 > spellRow + 1)
            {
                playerPosistion[0]++;
                return true;
            }
            else if (playerPosistion[1] - 1 >= 0 && playerPosistion[1] - 1 < spellCol - 1)
            {
                playerPosistion[1]--;
                return true;
            }

            return false;
        }

        private static bool IsPlayerDamagedZone(int[] playerPosistion, int spellRow, int spellCol)
        {
            bool isHitRow = playerPosistion[0] >= spellRow - 1 && playerPosistion[0] <= spellRow + 1;
            bool isHitCol = playerPosistion[1] >= spellCol - 1 && playerPosistion[1] <= spellCol + 1;

            return isHitRow && isHitCol;
        }
    }
}
