using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Zork
{
    //GameStates:
    /*
        0: Exit
        1: Main Menu
        2: Credits Screen
        3: Game Screen
    */

    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                GameStates gameState = GameStates.MenuScreen;
                Display mainMenu = new Menu();
                Display credits = new Credits();
                Display mainGame = new GameScreen();


                Display currentDisplay = mainMenu; //starting on main menu

                while (!Globals.exitRequested)
                {

                    gameState = currentDisplay.Run(); //player does stuff

                    switch (gameState) //update the game state based on player feedback
                    {
                        case GameStates.MenuScreen:
                            currentDisplay = mainMenu;
                            break;
                        case GameStates.CreditsScreen:
                            currentDisplay = credits;
                            break;
                        case GameStates.Exit:
                            Globals.exitRequested = true;
                            break;
                        default:
                            currentDisplay = mainMenu;
                            break;
                    }
                }

                Console.WriteLine("Now Exiting..."); //Game Over
            } catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
            
    }
}
            
//Implement game screen base class
//Implement start game screen
//Move game screen 
//Implement about screen

/*
//string parser for input
string goLeft[] = ["left", "l", "w", "west"];
foreach (string s in goLeft)
{
    if (input = s)
    {
        MoveLeft(); //parser

    }
}
*/

    /*
public class Vehicle
{
    public string colour = "";
    public string brand = "";
    public string fuelType = "";
    public int seats = 0;
    public float distanceTravelled = 0;
    public float speed;

    public Vehicle(string colour)
    {
        this.colour = colour;
    }

    public void Drive();

}

public class Car : Vehicle
{
    public override void Drive()
    {
        distanceTravelled += speed;
    }
}

public class Plane : Vehicle
{
    public override void Drive()
    {
        distanceTravelled += speed;
    }
}

public static class GameController
{
    public void UpdateGame()
    {
        Vehicle bike = new Vehicle("blue");
        Vehicle truck = new Car();
        Vehicle jet = new Plane();

        Vehicle devices = new List<Vehicle>();

        devices.add(bike);
        devices.add(truck);
        devices.add(jet);


        foreach (vehicle v in devices)
        {
            v.Drive();
        }

    }
}
*/