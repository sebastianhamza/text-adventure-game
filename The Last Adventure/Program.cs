using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Media;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace textAdventure
{
    class Program
    {
        private static int health = 100;
        private static int energy = 10;
        private static string faction = "None";

        static void Main(string[] args)
        {
            Console.Title = "The Last Adventure";
            start();
        }

        //This is the title screen
        public static void start()
        {
            string title = @"
             _____ _             _               _       ___ ______ _   _ _____ _   _ _____ _   _______ _____ 
            |_   _| |           | |             | |     / _ \|  _  \ | | |  ___| \ | |_   _| | | | ___ \  ___|
              | | | |__   ___   | |     __ _ ___| |_   / /_\ \ | | | | | | |__ |  \| | | | | | | | |_/ / |__  
              | | | '_ \ / _ \  | |    / _` / __| __|  |  _  | | | | | | |  __|| . ` | | | | | | |    /|  __| 
              | | | | | |  __/  | |___| (_| \__ \ |_   | | | | |/ /\ \_/ / |___| |\  | | | | |_| | |\ \| |___ 
              \_/ |_| |_|\___|  \_____/\__,_|___/\__|  \_| |_/___/  \___/\____/\_| \_/ \_/  \___/\_| \_\____/ 
                                                                                                  
                                                                                                  
                                                        ";
            Console.WriteLine(title);
            WriteSlowly("Welcome to The Last ADVENTURE");
            WriteSlowly("Press 'Enter' to begin");
            Console.ReadLine();
            Console.Clear();
            first();
        }


        //Here you can choose your character and it's race
        public static void first()
        {
            statBar();
            string name;
            WriteSlowly("Choose your adventurer name:");
            name = Console.ReadLine();
            WriteSlowly("Well hello there " + name + " ! ");
            WriteSlowly("I hope you are ready for adventure!");
            Console.ReadLine();
            Console.Clear();
            statBar();
            WriteSlowly("Choose your faction:");
            WriteSlowly("1. Barbarian");
            WriteSlowly("2. Druid");
            WriteSlowly("3. Paladin");
            WriteSlowly("4. Rogue");
            string choice = Console.ReadLine();
            if ((choice == "1") || (choice == "Barbarian"))
                faction = "Barbarian";
            else if ((choice == "2") || (choice == "Druid"))
                faction = "Druid";
            else if ((choice == "3") || (choice == "Paladin"))
                faction = "Paladin";
            else if ((choice == "4") || (choice == "Rogue"))
                faction = "Rogue";
            else
                faction = "Barbarian"; 

            Console.Clear();
            statBar();

            WriteSlowly("Congratulations! You are now a " + faction + " looking for fight!");
            WriteSlowly("Press 'Enter' to start your adventure!");
            Console.ReadLine();
            Console.Clear();
            second();

        }

        //Second act
        //You encounter a monster in a forest
        public static void second()
        {
            statBar();
            WriteSlowly("You are slowly walking along the path when you hear a strange soud from a bush");
            WriteSlowly("   *Grrrrrr*   ");
            WriteSlowly("You approach to see what is making that sound when...");
            WriteSlowly("Press 'Enter' to continue.");
            Console.ReadLine();
            Console.Clear();
            Console.Clear();
            randomFight(10, 2);

        }
        //third act
        //You encounter a monster under a bridge
        public static void third()
        {
            statBar();
            WriteSlowly("While you are crossing a bridge, you see something splashing in the water");
            WriteSlowly("   *Shhhhh*   ");
            WriteSlowly("What do you do?");
            WriteSlowly("1. Check the water");
            WriteSlowly("2. Move away");
            string choice = Console.ReadLine();
            if ((choice == "1") || (choice == "Check the water"))
            {
                WriteSlowly("While you go around the bridge to search for what is making the noise");
                WriteSlowly("A monster jumps out of the water");
            }

            else if ((choice == "2") || (choice == "Move away"))
            {
                WriteSlowly("While you turn around to leave, somethings grabs your leg");
                WriteSlowly("Before you know it, a monster appers in your rear");
            }
            WriteSlowly("Press 'Enter' to continue.");
            Console.ReadLine();
            Console.Clear();
            randomFight(25, 10);
            Console.Clear();
            Console.ReadLine();

        }
        //With this you can spawn random monsters
        //You use randomFight(x,y) where x represents the hitpoints of the monster and y it's attack
        public static void randomFight(int life, int attack)
        {
            string monster = @" 
                             \||/
                             |  @___oo
                   /\  /\   / (__,,,,|
                  ) /^\) ^\/ _)
                  )   /^\/   _)
                  )   _ /  / _)
              /\  )/\/ ||  | )_)
             <  >      |(,,) )__)
              ||      /    \)___)\
              | \____(      )___) )___
              \______(_______;;; __;;;


";
            statBar();
            string alienName = randomName();
            Console.WriteLine(monster);
            WriteSlowly($"You have encountered: " + alienName + ". It has " + life + " hitpoints and has " + attack + " damage");
            WriteSlowly("What do you do?");
            WriteSlowly("1. Fight");
            WriteSlowly("2. Run");
            string choice;
            choice = Console.ReadLine();
            if (choice == "1")
            {
                if (life > 0)
                    while (life > 0)
                    {
                        Console.Clear();
                        statBar();
                        WriteSlowly("Press enter to roll dice for damage");
                        Console.ReadLine();
                        int damage = rollDice(20);
                        WriteSlowly($"You hit " + alienName + " for " + damage + " damage.");
                        if (life - damage <= 0)
                        {
                            WriteSlowly("You knocked down " + alienName);
                            Console.ReadLine();
                            youWin();
                        }
                        else
                        {
                            life = life - attack;
                            WriteSlowly(alienName + " has " + life + " hitpoints");
                            WriteSlowly($"It hits back with a force of " + attack);
                            health = health - attack;
                            Console.ReadLine();
                        }
                    }
                else
                    youLose();
            }

            else
                WriteSlowly("You try to cowardly escape but something is on your tail");
            WriteSlowly("Something BIG");
            Console.Clear();
            randomFight(999, 1);

        }

        public static void youLose()
        {
            Console.Clear();
            WriteSlowly("You feel a sharp pain coming from your chest");
            WriteSlowly("Can't do anything but accept your fate");
            WriteSlowly("GAME OVER");
            Console.ReadLine();

        }
        public static void youWin()
        {
            Console.Clear();
            statBar();
            WriteSlowly("The beast is lying down on the ground");
            WriteSlowly("You search the monster for loot");
            WriteSlowly("Unlucky...");
            WriteSlowly("Press 'Enter' to continue");
            Console.ReadLine();
            Console.Clear();
            third();

        }

        //This is the status bar the will apear in almost every scene of the game
        //The parameters it displays are global so that you can change them from every scene
        public static void statBar()
        {
            string statusBar = @"
                                   HEALTH: " + health + "%" + "    FACTION: " + faction + "    ENERGY: " + energy + "\n\n" +
"                    -------------------------------------------------------------------------------\n\n";
            Console.WriteLine(statusBar);
        }

        public static string randomName()
        {
            string input = @"Aayala,Aeryn,Airen,Allana,Aurra,Ax,Ayala,Azan,Belanna,Bal Antilles,Bardan,Bellonda,Bialar,Bria,Cade,Cando,Chiana,Chiara,Correllia,Corran,Dash,Davin,Deanna,Deckard,Dejah,Deliah Blue,Dengar,Derrial,Diva,Eldredth,Elihu,Galant,Galen,Garrus,Gilina,Harishka,Holden,Inara Serra,Iriel,Jaina,Joelle,Jubal,Kagin,Kaidan,Kaylee,Keyan,Kira,Korben,Kreia,Kyp,Lapis Lazuli,Lazarus,Leelo,Leia,Liara,Luminara,Malcom,Makkan,Margrethe,Moya,Natasi,Natira,Noranti,Oola,Padme,Pallas,Rebi,Rhysling,Riddick,Rinya,River,Rune,Rygel,Sabe,Samara,Sarek,Sela,Selim,Serenity,Siona,Soval,Stark,Talis,Talock,Talon,Talyn,Tasha,Tenel,Tenenial,Thane,Tharen,Thorby,Tyber,Tyrell,Vito,Vorian,Winter,Zalga,Zhora,Zoe,Zorg";
            List<string> alienNames = input.Split(',').ToList();
            Random ran = new Random();
            int r = ran.Next(maxValue: 104);
            return (alienNames[r]);
        }

        //This function returns a random number between 1 and maxim; It also outputs that random number in the console;
        public static int rollDice(int maxim)
        {
            Random rnd = new Random();
            int dice = rnd.Next(1, maxim);
            WriteSlowly("You rolled a " + dice);
            return dice;
        }

        //This function creates the "Typewriter" effect by waiting a certain time between each character and between words;
        public static void WriteSlowly(string text)
        {
            string[] words = text.Split(' ');
            Task t = Task.Run(() =>
            {
                foreach (string word in words)
                {
                    foreach (char letter in word)
                    {
                        Console.Write(letter);
                        System.Threading.Thread.Sleep(20);
                        //Play();
                    }

                    Console.Write(" ");
                    System.Threading.Thread.Sleep(70);
                }
            });
            t.Wait();
            Console.WriteLine();
        }


        /*private static void Play()
        {
            string soundfile = Environment.CurrentDirectory + @"\typewriter.wav";
            var sound = new System.Media.SoundPlayer(soundfile);
            sound.Play();
        }
        */
    }
}
