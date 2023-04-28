using C__Blackjack;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("hoeveel spelers? :) ");
        int aantalspelers = Convert.ToInt32(Console.ReadLine());
        BlackjackGame game = new BlackjackGame(aantalspelers);
        game.start();
    }
}