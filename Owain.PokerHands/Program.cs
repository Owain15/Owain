﻿
using Poker;



//var royalFlushRuleProcessor = new RoyalFlushHandRule();
//var straightFlushRuleProcessor = new StraightFlushHandRule();
//var fourOfAKindProcessor = new FourOfAKindHandRule();
//var fullHouseProcessor = new FullHouseHandRule();
//var flushProcessor = new FlushHandRule();
//var StraightProcessor = new StraightHandRule();
//var threeOfAKindProcessor = new ThreeOfAKindHandRule();
//var twoPairsProcessor = new TwoPairsHandRule();
//var onePairProcessor = new OnePairHandRule();
////var highCardProcessor = new HighCardHandRule();

var roundNumber = 1;
var p1Score = 0;
var p2Score = 0;

//  load the file

var lines = File.ReadAllText("./poker.txt")
    .Split("\r\n")
    .Where(line => line.Length > 0);

foreach (var line in lines)
{
    var hands = line
    .Split(' ')
    .Select(it => new Card(it))
    .Select((it, index) => new { index, Card = it })
    .Select(it => new { it.index, it.Card })
    .GroupBy(it => it.index < 5)
    .ToList();

    

    Hand playerOne = new Hand(hands[0].Select(it => it.Card).ToList());
    Hand playerTwo = new Hand(hands[1].Select(it => it.Card).ToList());

    // rewright using hand class

    //var leftHandScore = GetScore(leftHand.Select(it => it.Card).ToList());
    //var rightHandScore = GetScore(rightHand.Select(it => it.Card).ToList());

    var roundResult = "Result Not Found.";

    if (playerOne.Score > playerTwo.Score)
    {
        p1Score++;
        roundResult="Player One Wins.";
    }

    if (playerOne.Score < playerTwo.Score)
    {
        p2Score++;
        roundResult = "Player Two wins.";
    }

    if (playerOne.Score == playerTwo.Score)
    {
        roundResult = "Draw.";
    }

    Console.WriteLine();
    Console.WriteLine($" Round:{roundNumber}   ||   {roundResult}");
    Console.WriteLine();

    if (roundResult == "Draw.")
    {
        TieBreak tieBreak = new TieBreak(playerOne,playerTwo);
        string winner = tieBreak.Resolution;

        if (winner == "playerOne")
        {
            p1Score++;
            roundResult = "Player One Wins.";
        }
        else if (winner == "playedTwo")
        {
            p2Score++;
            roundResult = "Player Two wins.";
        }
        else { roundResult = " No Winner Found!"; }

        Console.WriteLine();
        Console.WriteLine($" Tie Break   ||   {roundResult}");
        Console.WriteLine();

    }

    roundNumber++;

}

DisplayResult();

void DisplayResult()
{
    Console.WriteLine();
    Console.WriteLine("   .......... .......... .......... .......... ..........   ");
    Console.WriteLine();
    Console.WriteLine($"       Player One Score: {p1Score}  ||   Player Two Score: {p2Score}  ");
    Console.WriteLine();
    Console.WriteLine("   .......... .......... .......... .......... ..........   ");
    Console.WriteLine();
}







