using Helpers.StateMachine;

namespace Source.StateMachine
{
public readonly struct SplashScreenInfo : ISplashScreenInfo
{
    public bool SkipAnimation { get; }
    public string MapName { get; }
    public string ModeName { get; }

    SplashScreenInfo(Builder builder)
    {
        SkipAnimation = builder.SkipAnimation;
        MapName = builder.MapName;
        ModeName = builder.ModeName;
    }

    public sealed class Builder
    {
        public bool SkipAnimation { get; private set; }
        public string MapName { get; private set; } = string.Empty;
        public string ModeName { get; private set; } = string.Empty;

        public Builder SetSkipAnimation(bool enable)
        {
            SkipAnimation = enable;
            return this;
        }

        public Builder SetMapName(string mapName)
        {
            MapName = mapName;
            return this;
        }

        public Builder SetModeName(string modeName)
        {
            ModeName = modeName;
            return this;
        }

        public SplashScreenInfo Build() => new(this);
    }
}
}