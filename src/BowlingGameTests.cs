namespace fun_with_bowling;

public class BowlingGameTests
{
    [Theory]
    [InlineData(0, 0, 0)]
    [InlineData(1, 1, 0)]
    [InlineData(2, 0, 2)]
    [InlineData(3, 1, 2)]
    [InlineData(7, 0, 7)]
    [InlineData(9, 5, 4)]
    public void Should_calculate_totalScore_on_open_frames(int totalScore, int firstScore, int secondScore)
    {
        // Arrange
        var bowlingGame = new BowlingTestGameWith(openframes: 9);

        // Act
        bowlingGame.OpenFrame(firstScore, secondScore);

        // Assert
        Assert.Equal(totalScore, bowlingGame.TotalScore());
    }

    [Fact]
    public void Should_calculate_totalScore_on_game_with_only_open_frames()
    {
        // Arrange
        var bowlingGame = new BowlingGame();

        // Act
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);
        bowlingGame.OpenFrame(5, 0);

        // Assert
        Assert.Equal(50, bowlingGame.TotalScore());
    }

    [Theory]
    [InlineData(3, 7)]
    [InlineData(4, 6)]
    [InlineData(5, 5)]
    public void Should_calculate_totalScore_on_spare(int firstScore, int secondScore)
    {
        // Arrange
        var bowlingGame = new BowlingTestGameWith(openframes: 9);

        // Act
        bowlingGame.Spare(firstScore, secondScore);
        bowlingGame.Bonus(0);

        // Assert
        Assert.Equal(10, bowlingGame.TotalScore())
;
    }

    [Fact]
    public void Should_calculate_totalScore_on_spare_and_bonus()
    {
        // Arrange
        var bowlingGame = new BowlingTestGameWith(openframes: 9);

        // Act
        bowlingGame.Spare(6, 4);
        bowlingGame.Bonus(8);

        // Assert
        Assert.Equal(18, bowlingGame.TotalScore());
    }


    [Fact]
    public void Should_calculate_totalScore_on_strike_and_bonus()
    {
        // Arrange
        var bowlingGame = new BowlingTestGameWith(openframes: 9);

        // Act
        bowlingGame.Strike();
        bowlingGame.Bonus(10);
        bowlingGame.Bonus(8);

        // Assert
        Assert.Equal(28, bowlingGame.TotalScore());
    }

    [Fact]
    public void Should_calculate_totalScore_on_two_strikes()
    {
        // Arrange
        var bowlingGame = new BowlingTestGameWith(openframes: 8);

        // Act
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Bonus(4);
        bowlingGame.Bonus(5);

        Assert.Equal(43, bowlingGame.TotalScore());
    }


    [Fact]
    public void Should_calculate_totalScore_on_game_with_10_spares()
    {
        // Arrange
        var bowlingGame = new BowlingGame();

        // Act
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Spare(5, 5);
        bowlingGame.Bonus(5);

        // Assert
        Assert.Equal(150, bowlingGame.TotalScore());
    }


    [Fact]
    public void Should_calculate_totalScore_on_game_with_spare_and_bonus()
    {
        // Arrange
        var bowlingGame = new BowlingTestGameWith(openframes: 9);

        // Act
        bowlingGame.Spare(5, 5);
        bowlingGame.Bonus(5);

        // Assert
        Assert.Equal(15, bowlingGame.TotalScore());
    }


    [Fact]
    public void Should_calculate_totalScore_on_perfect_game()
    {
        // Arrange
        var bowlingGame = new BowlingGame();

        // Act
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Strike();
        bowlingGame.Bonus(10);
        bowlingGame.Bonus(10);

        // Assert
        Assert.Equal(300, bowlingGame.TotalScore());
    }


    [Fact]
    public void Should_calculate_totalScore_on_random_game1()
    {
        // Arrange
        var bowlingGame = new BowlingGame();

        // Act
        bowlingGame.OpenFrame(3, 6);
        bowlingGame.OpenFrame(8, 1);
        bowlingGame.Spare(6, 4);
        bowlingGame.OpenFrame(7, 1);
        bowlingGame.OpenFrame(8, 1);
        bowlingGame.OpenFrame(7, 2);
        bowlingGame.OpenFrame(2, 6);
        bowlingGame.OpenFrame(4, 4); 
        bowlingGame.OpenFrame(6, 1); 
        bowlingGame.Spare(8, 2); 
        bowlingGame.Bonus(10);

        // Assert
        Assert.Equal(104, bowlingGame.TotalScore());
    }

     [Fact]
    public void Should_calculate_totalScore_on_random_game2()
    {
        // Arrange
        var bowlingGame = new BowlingGame();

        // Act
        bowlingGame.Strike();
        bowlingGame.OpenFrame(1,1);
        bowlingGame.OpenFrame(2,2);
        bowlingGame.OpenFrame(3,3);
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
}

file class BowlingTestGameWith : BowlingGame
{
    public BowlingTestGameWith(int openframes)
    {
        for (int i = 0; i < openframes; i++)
        {
            OpenFrame(0, 0);
        }
    }
}