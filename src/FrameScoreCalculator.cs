namespace fun_with_bowling;

public class FrameScoreCalculator(IList<Frame> Frames)
{
    private readonly IList<Frame> frames = Frames;

    public int GetScore(int frameIndex)
    {
        var (type, firstDelevery, secondDelevery) = frames[frameIndex];
        int score = firstDelevery + secondDelevery;

        return type switch
        {
            FrameType.OpenFrame => score,
            FrameType.Spare => score + GetBonusForSpare(frameIndex),
            FrameType.Strike => score + GetBonusForStrike(frameIndex),
            _ => 0
        };
    }

    private int GetBonusForSpare(int frameIndex)
    {
        var (_, bonusDelevery, _) = frames[frameIndex + 1];
        return bonusDelevery;
    }

    private int GetBonusForStrike(int frame)
    {
        var (type, firstBonusDelevery, _) = frames[frame + 1];
        if (type == FrameType.Strike)
        {
            var (_, secondBonusDelevery, _) = frames[frame + 2];
            return firstBonusDelevery + secondBonusDelevery;
        }
        else
        {
            var (_, _, secondBonusDelevery) = frames[frame + 1];
            return firstBonusDelevery + secondBonusDelevery;
        }
    }
}