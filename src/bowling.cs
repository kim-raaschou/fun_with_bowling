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

    public void Bonus(int bonus) =>
        _frames.Add(new Frame(FrameType.Bonus, bonus));

    public int TotalScore() =>
        _frames.Select(GetTotalForFame).Sum();

    private int GetTotalForFame(Frame frame, int index)
    {
        var (type, firstDelevery, secondDelevery) = frame;

        return type switch
        {
            FrameType.OpenFrame => firstDelevery + secondDelevery,
            FrameType.Spare => firstDelevery + secondDelevery + GetBonus(index + 1),
            FrameType.Strike => firstDelevery + secondDelevery + GetBonus(index + 1) + GetBonus(index + 2),
            _ => 0
        };

        int GetBonus(int frame)
        {
            var (_, bonus, _) = _frames[frame];
            return bonus;
        }
    }
}