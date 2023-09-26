using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QueryLab
{
    class Program
    {
        static void Main(string[] args)
        {
            QueryBuilder qb = new QueryBuilder(@"..\..\..\Data\data.db");

            var savedPokemon = qb.ReadAll<Pokemon>();
            var savedBannedGames = qb.ReadAll<BannedGame>();
            Boolean cont = true;
            while(cont == true)
            {
                Console.WriteLine("\nWhat do you want to do?");
                Console.WriteLine("1: Add new row to table");
                Console.WriteLine("2: Delete all rows in table");
                Console.WriteLine("3: Restore to starting tables");
                Console.WriteLine("0: Exit");
                string responseStr = Console.ReadLine();
                int response = Convert.ToInt32(responseStr);

                switch (response) 
                {
                    case 1: create(qb);
                        break;
                    case 2:
                        Console.WriteLine("What table do you want to delete?");
                        string tab = Console.ReadLine();
                        deleteEm(qb,tab);
                        break;
                    case 3:
                        deleteEm(qb, "pokemon");
                        deleteEm(qb, "bannedgame");
                        foreach (var item in savedBannedGames) 
                        {
                            qb.Create(item);
                            
                        }
                        foreach (var item in savedPokemon)
                        {
                            qb.Create(item);
                        }
                        Console.WriteLine("All tables restored to the state they were in at the beginning of the program");
                        
                        break;
                        
                    case 0:
                        cont = false;
                        break;

                }
            }


            Console.ReadLine();

        }
          

        public static void create(QueryBuilder qb) 
        {
            Console.WriteLine("Please enter the data for the new object with csv format");
            string data = Console.ReadLine();
            var list = data.Split(',');
            if (list.Length == 4)
            {
                var getCount = qb.ReadAll<BannedGame>();
                int count = getCount.Count();
                int id = count+1;
                BannedGame game = new BannedGame(id, list[0], list[1], list[2], list[3]);
                qb.Create(game);
                Console.WriteLine("New Banned Game Added\n");
               Console.WriteLine(qb.Read<BannedGame>(id));
            }
            else if(list.Length == 13)
            {
                var getCount = qb.ReadAll<BannedGame>();
                int count = getCount.Count();
                int id = count + 1;
               // int id = int.Parse(list[0]);
                int dex = int.Parse(list[0]);
                int total = int.Parse(list[5]);
                int hp = int.Parse(list[6]);
                int attack = int.Parse(list[7]);
                int defence = int.Parse(list[8]);
                int specialA = int.Parse(list[9]);
                int specialD  = int.Parse(list[10]);
                int speed   = int.Parse(list[11]);
                int gen = int.Parse(list[12]);  
                Pokemon poke = new Pokemon(id, dex, list[1], list[2], list[3], list[4], total,hp,attack,defence, specialA,specialD,speed,gen);
                qb.Create(poke);
                Console.WriteLine("New Pokemon added\n");
                Console.WriteLine(qb.Read<Pokemon>(id));
            }
            else
            {
                Console.WriteLine("Invalid data");
            }
        }

        public static void deleteEm(QueryBuilder qb, string table)
        {
            if(table.ToLower() == "pokemon")
            { 
                qb.DeleteAll<Pokemon>();
                Console.WriteLine("All rows of the Pokemon table were deleted.");

            }
            else if (table.ToLower() == "bannedgame")
            {
                qb.DeleteAll<BannedGame>();
                Console.WriteLine("All rows of the BannedGame table were deleted.");
            }
        }
    }
}
