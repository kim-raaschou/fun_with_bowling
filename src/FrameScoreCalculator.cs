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

    private int GetBonusForStrike(int frameIndex)
    {
        var nextFrameType = frames[frameIndex + 1].Type;

        return nextFrameType is FrameType.Strike
            ? GetBonusFromNextTwoDeleveries(frameIndex)
            : GetBonusFromNextDelevery(frameIndex);

        int GetBonusFromNextTwoDeleveries(int frameIndex)
        {
            var (_, firstBonusDelevery, _) = frames[frameIndex + 1];
            var (_, secondBonusDelevery, _) = frames[frameIndex + 2];
            return firstBonusDelevery + secondBonusDelevery;
        }

        int GetBonusFromNextDelevery(int frameIndex)
        {
            var (_, firstBonusDelevery, secondBonusDelevery) = frames[frameIndex + 1];
            return firstBonusDelevery + secondBonusDelevery;
        }
    }
}