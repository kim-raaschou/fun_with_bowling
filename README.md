# fun_with_bowling

Velkommen til "Fun With Bowling" - en spændende kode kata, hvor jeg udforsker min begrænset viden om bowling. 
Kataen er skrevet i C# 12 på den nye .Net 8.

Opgaven
Med udgangspunkt i kodekataen [Bowling Kata](https://codingdojo.org/kata/Bowling/) har jeg skrevet en efter egen mening udemærket implementering - selvom jeg var udfordret på min manglende forståelse for reglerne!!

Implementeringen er valideret op imod [Bowlinggenius](https://www.bowlinggenius.com/).

Tag en dyb indånding, og dyk ned i koden.

God fornøjelse.

Kode Eksempeler
```csharp
    [Fact]
    public void Should_calculate_totalScore_on_random_game2()
    {
        // Arrange
        var bowlingGame = new BowlingGame();

        // Act
        bowlingGame.Strike();
        bowlingGame.OpenFrame(1, 1);
        bowlingGame.OpenFrame(2, 2);
        bowlingGame.OpenFrame(3, 3);
        bowlingGame.Strike();
        bowlingGame.OpenFrame(4, 4);
        bowlingGame.Spare(5, 5);
        bowlingGame.OpenFrame(3, 3);
        bowlingGame.OpenFrame(2, 2);
        bowlingGame.Spare(1, 9);
        bowlingGame.Bonus(10);

        // Assert
        Assert.Equal(93, bowlingGame.TotalScore());
    }
