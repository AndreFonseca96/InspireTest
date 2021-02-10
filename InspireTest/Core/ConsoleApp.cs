using InspireTest.Models;
using System;
using System.Linq;

namespace InspireTest.Core
{
    public class ConsoleApp
    {

        #region Constructor
        public ConsoleApp()
        {
        }

        #endregion

        #region Methods

        public void Init()
        {
            Loader loader = new Loader();
            Bomb bomb = loader.LoadBomb();
            WelcomeMessage();
            ShowRules(bomb);
            string userInput = GetUserInput(bomb);
            Simulation simulation = new Simulation(bomb, userInput);
            ShowResult(simulation);
        }

        public void WelcomeMessage()
        {
            Console.WriteLine("-------------------------------------------- \n");
            Console.WriteLine("Bem-vindo ao exercicio de desarmar uma bomba \n");
            Console.WriteLine("-------------------------------------------- \n");            
        }

        public void ShowRules(Bomb bomb)
        {
            Console.WriteLine("Regras: \n");
            Console.WriteLine(bomb.ToString());
        }

        public string GetUserInput(Bomb bomb)
        {
            Console.WriteLine("\n Introduza a ordem dos fios que quer cortar separados por virgula: \n");
            string input;
            do
            {
                input = Console.ReadLine();
            } while (!ValidateInput(bomb, input));

            return input;
        }

        public bool ValidateInput(Bomb bomb, string input)
        {
            input = input.Replace(" ", string.Empty);
            string[] inputSub = input.Split(",");

            foreach (string inputWire in inputSub)
            {
                // If the input does not match any existing wire
                if (!bomb.WireExists(inputWire))
                {
                    Console.WriteLine("\n O fio " + inputWire + " não é um fio válido. Volte a introduzir a ordem: \n");
                    return false;
                }
            }
            return true;
        }

        public void ShowResult(Simulation simulation)
        {
            if (simulation.Simulate()) // returns the result of the simulation
            {
                Console.WriteLine("\nBomba explodiu");
            }
            else
            {
                Console.WriteLine("\nBomba desarmada");
            }
        }

        #endregion

    }
}
