using System.Drawing;
using System.Drawing.Drawing2D;

namespace GestionPharmacie.Utils
{
    public static class StyleHelper
    {
        // Simple & Elegant Light Blue and White Color Palette
        public static readonly Color PrimaryBlue = Color.FromArgb(66, 133, 244);       // Soft Blue
        public static readonly Color LightBlue = Color.FromArgb(100, 181, 246);        // Light Blue
        public static readonly Color VeryLightBlue = Color.FromArgb(227, 242, 253);    // Very Light Blue
        public static readonly Color DarkBlue = Color.FromArgb(25, 118, 210);          // Dark Blue
        
        public static readonly Color AccentGreen = Color.FromArgb(102, 187, 106);      // Soft Green
        public static readonly Color AccentOrange = Color.FromArgb(255, 152, 0);       // Soft Orange
        public static readonly Color AccentPurple = Color.FromArgb(149, 117, 205);     // Soft Purple
        public static readonly Color AccentRed = Color.FromArgb(239, 83, 80);          // Soft Red
        public static readonly Color AccentYellow = Color.FromArgb(255, 193, 7);       // Soft Yellow
        
        public static readonly Color White = Color.White;
        public static readonly Color OffWhite = Color.FromArgb(250, 250, 250);
        public static readonly Color LightGray = Color.FromArgb(245, 245, 245);
        public static readonly Color MediumGray = Color.FromArgb(224, 224, 224);
        public static readonly Color TextDark = Color.FromArgb(33, 33, 33);
        public static readonly Color TextLight = Color.FromArgb(117, 117, 117);
        
        // Legacy compatibility
        public static readonly Color PrimaryColor = PrimaryBlue;
        public static readonly Color PrimaryDark = DarkBlue;
        public static readonly Color SecondaryColor = LightBlue;
        public static readonly Color AccentColor = AccentGreen;
        public static readonly Color DangerColor = AccentRed;
        public static readonly Color WarningColor = AccentYellow;
        public static readonly Color BackgroundColor = LightGray;
        public static readonly Color SurfaceColor = White;
        public static readonly Color TextPrimary = TextDark;
        public static readonly Color TextSecondary = TextLight;
        public static readonly Color BorderColor = MediumGray;
        
        // Fonts
        public static readonly Font TitleFont = new Font("Segoe UI", 24F, FontStyle.Bold);
        public static readonly Font HeadingFont = new Font("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font SubheadingFont = new Font("Segoe UI", 12F, FontStyle.Bold);
        public static readonly Font BodyFont = new Font("Segoe UI", 10F);
        public static readonly Font SmallFont = new Font("Segoe UI", 9F);
        public static readonly Font LargeNumberFont = new Font("Segoe UI", 28F, FontStyle.Bold);
        
        /// <summary>
        /// Applies simple, elegant button styling
        /// </summary>
        public static void StyleButton(Button button, Color? backgroundColor = null, Color? foreColor = null)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = backgroundColor ?? PrimaryBlue;
            button.ForeColor = foreColor ?? White;
            button.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            button.Cursor = Cursors.Hand;
            button.Height = 40;
            button.Padding = new Padding(20, 0, 20, 0);
            
            // Rounded corners
            button.Region = new Region(GetRoundedRect(new Rectangle(0, 0, button.Width, button.Height), 6));
            button.Resize += (s, e) =>
            {
                if (s is Button btn)
                {
                    btn.Region = new Region(GetRoundedRect(new Rectangle(0, 0, btn.Width, btn.Height), 6));
                }
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
        public static void StyleTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("Segoe UI", 11F);
            textBox.Height = 40;
            textBox.BackColor = OffWhite;
            textBox.ForeColor = TextDark;
            
            // Focus events for better UX
            textBox.Enter += (s, e) =>
            {
                if (s is TextBox tb)
                {
                    tb.BackColor = White;
                    tb.BorderStyle = BorderStyle.FixedSingle;
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
