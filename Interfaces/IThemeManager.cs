interface IThemeManager
{
    string FontName { get; set; }
    Color SurfaceColor { get; set; }
    Color BackgroundColor { get; set; }
    Color TextColor { get; set; }
    Color AccentColor { get; set; }

    void ApplyTheme();

}