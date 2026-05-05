namespace winFormTestSauron.Core
{
    internal class Theme : IThemeManager
    {
        private readonly Form _form;

        public string FontName { get; set; } = "Segoe UI"; 
        public Color SurfaceColor { get; set; }
        public Color BackgroundColor { get; set; }
        public Color TextColor { get; set; }
        public Color AccentColor { get; set; }

        public Theme(Form formReceived)
        {
            _form = formReceived;
        }

        public void ApplyTheme()
        {
            _form.BackColor = BackgroundColor;
            Font mainFont = new Font(FontName, 9F, FontStyle.Regular);
            _form.Font = mainFont;
            UpdateUIElement(_form, mainFont);
        }

        private void UpdateUIElement(Control parent, Font font)
        {
            foreach (Control c in parent.Controls)
            {
                c.Font = font;
                c.ForeColor = TextColor;

                if (c is Button btn)
                {
                    btn.BackColor = AccentColor;
                    btn.FlatStyle = FlatStyle.Flat;
                }
                else
                {
                    c.BackColor = SurfaceColor;
                }

                if (c.HasChildren)
                {
                    UpdateUIElement(c, font);
                }
            }
        }
    }
}