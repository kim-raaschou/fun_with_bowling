namespace fun_with_bowling;

public record Frame(FrameType Type, int FirstDelevery, int SecondDelevery = 0);

public enum FrameType { OpenFrame, Spare, Strike, Bonus }

public class BowlingGame
{
    private readonly List<Frame> _frames = [];

    public void OpenFrame(int firstScore, int secondScore) =>
        _frames.Add(new Frame(FrameType.OpenFrame, firstScore, secondScore));

    public void Spare(int firstScore, int secondScore) =>
        _frames.Add(new Frame(FrameType.Spare, firstScore, secondScore));

    public void Strike() =>
        _frames.Add(new Frame(FrameType.Strike, 10));

    public void Bonus(int bonus)
    {
        var bonusFrame = _frames.FirstOrDefault(frame => frame.Type == FrameType.Bonus);

        if (bonusFrame is null)
        {
            _frames.Add(new Frame(FrameType.Bonus, bonus));
        }
        else
        {
            _frames.Remove(bonusFrame);
            _frames.Add(bonusFrame with { SecondDelevery = bonus });
        }
    }

    public int TotalScore()
    {
        var scoreCalculator = new FrameScoreCalculator(_frames);
        
        return _frames
            .Select((_, frameIndex) => scoreCalculator.GetScore(frameIndex))
            .Sum();
    }
}