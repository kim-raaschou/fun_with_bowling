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

    public int TotalScore() =>
        _frames.Select(GetTotalScoreForFrame).Sum();

    private int GetTotalScoreForFrame(Frame frame, int frameIndex)
    {
        var (type, firstDelevery, secondDelevery) = frame;
        int score = firstDelevery + secondDelevery;

        var totalScore = type switch
        {
            FrameType.OpenFrame => score,
            FrameType.Spare => score + GetSpareBonus(frameIndex),
            FrameType.Strike => score + GetStrikeBonus(frameIndex),
            _ => 0
        };

        return totalScore;

        int GetSpareBonus(int frameIndex)
        {
            var (_, bonus, _) = _frames[frameIndex + 1];
            return bonus;
        }

        int GetStrikeBonus(int frame)
        {
            var (type, firstBonusDelevery, _) = _frames[frame + 1];
            if (type == FrameType.Strike)
            {
                var (_, secondBonusDelevery, _) = _frames[frame + 2];
                return firstBonusDelevery + secondBonusDelevery;
            }
            else
            {
                var (_, _, secondBonusDelevery) = _frames[frame + 1];
                return firstBonusDelevery + secondBonusDelevery;
            }
        }

    }
}