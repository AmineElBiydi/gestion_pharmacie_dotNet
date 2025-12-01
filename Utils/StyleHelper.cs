using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace GestionPharmacie.Utils
{
    public static class StyleHelper
    {
        // Modern medical app palette - Updated with User's Teal Theme
        // Primary Button: #1B7F7A
        // Primary Hover: #16807A
        // Primary Disabled: #A7D3D1
        
        public static readonly Color PrimaryColor = ColorTranslator.FromHtml("#1B7F7A");
        public static readonly Color PrimaryHover = ColorTranslator.FromHtml("#16807A");
        public static readonly Color PrimaryDisabled = ColorTranslator.FromHtml("#A7D3D1");

        // Legacy mappings to new theme
        public static readonly Color PrimaryBlue = PrimaryColor; 
        public static readonly Color DarkBlue = PrimaryHover;
        public static readonly Color LightBlue = ColorTranslator.FromHtml("#4DB6AC"); // Lighter teal for accents
        
        public static readonly Color GradientStartBlue = PrimaryColor;
        public static readonly Color GradientEndBlue = ColorTranslator.FromHtml("#26A69A"); // Slightly lighter for gradient
        public static readonly Color VeryLightBlue = ColorTranslator.FromHtml("#E0F2F1"); // Very light teal for selection

        // Pastel accents for categories / highlights (Adjusted to harmonize with Teal)
        public static readonly Color AccentGreen = ColorTranslator.FromHtml("#81E6D9");      // mint
        public static readonly Color AccentOrange = ColorTranslator.FromHtml("#FFB74D");      // soft orange
        public static readonly Color AccentPurple = ColorTranslator.FromHtml("#BA68C8");     // soft purple
        public static readonly Color AccentRed = ColorTranslator.FromHtml("#F06292");        // soft pink/red
        public static readonly Color AccentYellow = ColorTranslator.FromHtml("#FFF176");     // pastel yellow
        
        public static readonly Color White = Color.White;
        public static readonly Color OffWhite = Color.FromArgb(250, 250, 250);
        public static readonly Color LightGray = Color.FromArgb(245, 245, 245);
        public static readonly Color MediumGray = Color.FromArgb(224, 224, 224);
        
        // Inputs / Fields
        public static readonly Color InputBorder = ColorTranslator.FromHtml("#E0E0E0");
        public static readonly Color InputFocusBorder = PrimaryColor;

        public static readonly Color TextDark = Color.FromArgb(33, 33, 33);
        public static readonly Color TextLight = Color.FromArgb(117, 117, 117);
        
        // Legacy compatibility
        public static readonly Color PrimaryDark = PrimaryHover;
        public static readonly Color SecondaryColor = LightBlue;
        public static readonly Color AccentColor = AccentGreen;
        public static readonly Color DangerColor = AccentRed;
        public static readonly Color WarningColor = AccentYellow;
        public static readonly Color BackgroundColor = LightGray;
        public static readonly Color SurfaceColor = White;
        public static readonly Color TextPrimary = TextDark;
        public static readonly Color TextSecondary = TextLight;
        public static readonly Color BorderColor = InputBorder;
        
        // Fonts
        public static readonly Font TitleFont = new Font("Segoe UI", 24F, FontStyle.Bold);
        public static readonly Font HeadingFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font SubheadingFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F);
        public static readonly Font LargeNumberFont = new Font("Segoe UI", 28F, FontStyle.Bold);
        
        /// <summary>
        /// Applies a royal blue → light blue vertical gradient as the background
        /// for the given control (typically a Form or main container).
        /// </summary>
        public static void ApplyGradientBackground(Control control)
        {
            if (control == null) return;

            control.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;

                var rect = control.ClientRectangle;
                if (rect.Width <= 0 || rect.Height <= 0) return;

                using (var brush = new LinearGradientBrush(
                           rect,
                           GradientStartBlue,
                           GradientEndBlue,
                           LinearGradientMode.Vertical))
                {
                    g.FillRectangle(brush, rect);
                }
            };

            control.Resize += (s, e) => control.Invalidate();
        }
        
        /// <summary>
        /// Applies a consistent, elegant theme to a form and its child controls.
        /// Keeps existing layouts but unifies colors, fonts and control styles.
        /// </summary>
        public static void ApplyFormTheme(Form form)
        {
            if (form == null) return;

            form.BackColor = BackgroundColor;
            form.Font = BodyFont;
            form.ForeColor = TextPrimary;

            // Slightly softer borderless window look when possible
            if (form.FormBorderStyle == FormBorderStyle.Sizable)
            {
                form.Padding = new Padding(0);
            }

            ApplyThemeToControls(form.Controls);
        }

        private static void ApplyThemeToControls(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                switch (control)
                {
                    case Button btn:
                        // Do not override buttons that are already explicitly styled with custom painting
                        if (btn.FlatStyle == FlatStyle.Standard && btn.Height <= 35)
                        {
                            StyleEnhancedButton(btn);
                        }
                        else if (btn.FlatStyle == FlatStyle.Flat && btn.BackColor == SystemColors.Control)
                        {
                            StyleEnhancedButton(btn);
                        }
                        break;

                    case Label lbl:
                        // Preserve big titles but unify fonts/colors for normal labels
                        if (lbl.Font.Size <= 13 && lbl.Font.Style != FontStyle.Bold)
                        {
                            StyleLabel(lbl);
                        }
                        else
                        {
                            lbl.ForeColor = TextPrimary;
                        }
                        break;

                    case TextBox tb:
                        StyleTextBox(tb);
                        break;

                    case DataGridView grid:
                        StyleDataGridView(grid);
                        break;

                    case Panel pnl:
                        // Keep existing padding & custom paints, only soften background
                        if (pnl.BackColor == SystemColors.Control || pnl.BackColor == Color.White)
                        {
                            pnl.BackColor = SurfaceColor;
                        }
                        break;

                    case GroupBox gb:
                        gb.Font = SubheadingFont;
                        gb.ForeColor = TextSecondary;
                        gb.BackColor = SurfaceColor;
                        break;

                    case TabControl tab:
                        tab.Font = BodyFont;
                        tab.BackColor = BackgroundColor;
                        foreach (TabPage page in tab.TabPages)
                        {
                            page.BackColor = BackgroundColor;
                            page.ForeColor = TextPrimary;
                        }
                        break;

                    case ComboBox cb:
                        cb.Font = BodyFont;
                        cb.BackColor = OffWhite;
                        cb.ForeColor = TextDark;
                        cb.FlatStyle = FlatStyle.Flat;
                        break;

                    case CheckBox chk:
                    case RadioButton rb:
                        control.Font = BodyFont;
                        control.ForeColor = TextSecondary;
                        break;
                }

                // Recurse for nested containers
                if (control.HasChildren)
                {
                    ApplyThemeToControls(control.Controls);
                }
            }
        }
        
        /// <summary>
        /// Applies simple, elegant button styling
        /// </summary>
        /// <summary>
        /// Applies simple, elegant button styling
        /// </summary>
        public static void StyleButton(Button button, Color? backgroundColor = null, Color? foreColor = null)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backgroundColor ?? PrimaryColor;
            button.ForeColor = foreColor ?? White;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            button.Cursor = Cursors.Hand;
            button.Height = 40;
            button.Padding = new Padding(20, 0, 20, 0);
            
            // Rounded corners (8-12px as requested)
            int radius = 10;
            button.Region = new Region(GetRoundedRect(new Rectangle(0, 0, button.Width, button.Height), radius));
            button.Resize += (s, e) =>
            {
                if (s is Button btn)
                {
                    btn.Region = new Region(GetRoundedRect(new Rectangle(0, 0, btn.Width, btn.Height), radius));
                }
            };

            // Hover effects
            button.MouseEnter += (s, e) => 
            {
                if (button.Enabled && button.BackColor == PrimaryColor)
                    button.BackColor = PrimaryHover;
            };
            button.MouseLeave += (s, e) => 
            {
                if (button.Enabled && button.BackColor == PrimaryHover)
                    button.BackColor = PrimaryColor;
            };
            button.EnabledChanged += (s, e) =>
            {
                if (!button.Enabled) button.BackColor = PrimaryDisabled;
                else button.BackColor = backgroundColor ?? PrimaryColor;
            };
        }
        
        /// <summary>
        /// Applies simple panel styling
        /// </summary>
        public static void StylePanel(Panel panel, Color? backgroundColor = null)
        {
            panel.BackColor = backgroundColor ?? White;
            panel.Padding = new Padding(20);
        }
        
        /// <summary>
        /// Creates a clean card with subtle shadow
        /// </summary>
        public static Panel CreateCard(int x, int y, int width, int height, Color? bgColor = null)
        {
            var card = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = bgColor ?? White,
                Padding = new Padding(15)
            };
            
            card.Paint += (sender, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                
                // Simple border
                using (var pen = new Pen(MediumGray, 1))
                {
                    var rect = new Rectangle(0, 0, card.Width - 1, card.Height - 1);
                    g.DrawRectangle(pen, rect);
                }
            };
            
            return card;
        }
        
        /// <summary>
        /// Applies modern label styling
        /// </summary>
        public static void StyleLabel(Label label, Font? font = null, Color? foreColor = null)
        {
            label.Font = font ?? BodyFont;
            label.ForeColor = foreColor ?? TextDark;
        }
        
        /// <summary>
        /// Applies modern textbox styling with focus effects
        /// </summary>
        /// <summary>
        /// Applies modern textbox styling with focus effects
        /// </summary>
        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 11F);
            textBox.Height = 40;
            textBox.BackColor = OffWhite;
            textBox.ForeColor = TextDark;
            
            // We can't easily change the border color of a standard TextBox without custom painting or a wrapper.
            // However, we can simulate focus by changing backcolor or using a panel container.
            // For now, we'll stick to standard properties but ensure clean look.
            
            // Focus events for better UX
            textBox.Enter += (s, e) =>
            {
                if (s is TextBox tb)
                {
                    tb.BackColor = White;
                    // Ideally we would change border color to InputFocusBorder here
                }
            };
            
            textBox.Leave += (s, e) =>
            {
                if (s is TextBox tb)
                {
                    tb.BackColor = OffWhite;
                }
            };
        }
        
        /// <summary>
        /// Creates a modern panel with shadow and rounded corners
        /// </summary>
        public static Panel CreateModernPanel(int x, int y, int width, int height, Color? bgColor = null, int cornerRadius = 12)
        {
            var panel = new Panel
            {
                Location = new Point(x, y),
                Size = new Size(width, height),
                BackColor = bgColor ?? White,
                Padding = new Padding(0)
            };
            
            panel.Paint += (sender, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                
                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);
                
                // Draw shadow (multiple layers for depth)
                for (int i = 0; i < 3; i++)
                {
                    var shadowRect = new Rectangle(2 + i, 2 + i, panel.Width - 1, panel.Height - 1);
                    using (var shadowPath = GetRoundedRect(shadowRect, cornerRadius))
                    using (var shadowBrush = new SolidBrush(Color.FromArgb(10 - i * 3, 0, 0, 0)))
                    {
                        g.FillPath(shadowBrush, shadowPath);
                    }
                }
                
                // Draw main panel with rounded corners
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var brush = new SolidBrush(panel.BackColor))
                {
                    g.FillPath(brush, path);
                }
                
                // Draw border
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var pen = new Pen(Color.FromArgb(240, 240, 240), 1))
                {
                    g.DrawPath(pen, path);
                }
            };
            
            return panel;
        }
        
        /// <summary>
        /// Styles an existing panel as a rounded "card" with shadow,
        /// suitable for dashboard sections and info cards.
        /// </summary>
        /// <summary>
        /// Styles an existing panel as a rounded "card" with shadow,
        /// suitable for dashboard sections and info cards.
        /// </summary>
        public static void StyleCardPanel(Panel panel, int cornerRadius = 12)
        {
            if (panel == null) return;

            panel.BackColor = SurfaceColor; // White background
            panel.Padding = new Padding(20);

            panel.Paint += (sender, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;

                var rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

                // Subtle shadow: rgba(0,0,0,0.06)
                // We simulate this with a very light gray brush
                var shadowColor = Color.FromArgb(15, 0, 0, 0); // approx 0.06 alpha
                
                // Draw shadow
                var shadowRect = new Rectangle(2, 2, panel.Width - 1, panel.Height - 1);
                using (var shadowPath = GetRoundedRect(shadowRect, cornerRadius))
                using (var shadowBrush = new SolidBrush(shadowColor))
                {
                    g.FillPath(shadowBrush, shadowPath);
                }

                // Main card
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var brush = new SolidBrush(panel.BackColor))
                {
                    g.FillPath(brush, path);
                }

                // Subtle border if needed, or just rely on shadow
                // User asked for border radius 8-12px, didn't explicitly ask for border line, but usually good for definition
                using (var path = GetRoundedRect(rect, cornerRadius))
                using (var pen = new Pen(Color.FromArgb(240, 240, 240), 1))
                {
                    g.DrawPath(pen, path);
                }
            };

            panel.Resize += (s, e) => panel.Invalidate();
        }
        
        /// <summary>
        /// Creates an enhanced button with better styling
        /// </summary>
        public static void StyleEnhancedButton(Button button, Color? backgroundColor = null, Color? foreColor = null, int cornerRadius = 8)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backgroundColor ?? PrimaryBlue;
            button.ForeColor = foreColor ?? White;
            button.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            button.Cursor = Cursors.Hand;
            button.Height = 48;
            button.Padding = new Padding(0);
            
            // Rounded corners
            button.Region = new Region(GetRoundedRect(new Rectangle(0, 0, button.Width, button.Height), cornerRadius));
            button.Resize += (s, e) =>
            {
                if (s is Button btn)
                {
                    btn.Region = new Region(GetRoundedRect(new Rectangle(0, 0, btn.Width, btn.Height), cornerRadius));
                }
            };
            
            // Enhanced hover effects
            var originalColor = button.BackColor;
            button.MouseEnter += (s, e) =>
            {
                if (s is Button btn)
                {
                    btn.BackColor = DarkBlue;
                }
            };
            button.MouseLeave += (s, e) =>
            {
                if (s is Button btn)
                {
                    btn.BackColor = originalColor;
                }
            };
        }
        
        /// <summary>
        /// Applies clean DataGridView styling
        /// </summary>
        public static void StyleDataGridView(DataGridView grid)
        {
            grid.BorderStyle = BorderStyle.None;
            grid.BackgroundColor = White;
            grid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            grid.DefaultCellStyle.BackColor = White;
            grid.AlternatingRowsDefaultCellStyle.BackColor = LightGray;
            grid.DefaultCellStyle.SelectionBackColor = VeryLightBlue;
            grid.DefaultCellStyle.SelectionForeColor = TextDark;
            grid.DefaultCellStyle.Font = BodyFont;
            grid.EnableHeadersVisualStyles = false;
            grid.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            grid.ColumnHeadersDefaultCellStyle.BackColor = PrimaryBlue;
            grid.ColumnHeadersDefaultCellStyle.ForeColor = White;
            grid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            grid.ColumnHeadersDefaultCellStyle.Padding = new Padding(5);
            grid.ColumnHeadersHeight = 42;
            grid.RowTemplate.Height = 38;
            grid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.MultiSelect = false;
            grid.AllowUserToAddRows = false;
            grid.AllowUserToDeleteRows = false;
            grid.ReadOnly = true;
        }
        
        /// <summary>
        /// Helper method to create rounded rectangles
        /// </summary>
        private static GraphicsPath GetRoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            // top left arc
            path.AddArc(arc, 180, 90);

            // top right arc
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);

            // bottom right arc
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);

            // bottom left arc
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);

            path.CloseFigure();
            return path;
        }
    }
}
