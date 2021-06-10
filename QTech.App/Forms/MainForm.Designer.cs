namespace Storm.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel8 = new System.Windows.Forms.Panel();
            this.Body = new System.Windows.Forms.Panel();
            this.topPanel = new QTech.Component.GRAPanel();
            this.colorWithAlpha4 = new QTech.Component.ColorWithAlpha();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.pTopMenu = new QTech.Component.ExTabBar();
            this.pBottom = new QTech.Component.GRAPanel();
            this.colorWithAlpha7 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha9 = new QTech.Component.ColorWithAlpha();
            this.pBranch = new System.Windows.Forms.FlowLayoutPanel();
            this.lblUserProfile_ = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.Label();
            this.lblUserDropDown_ = new System.Windows.Forms.Label();
            this.lblBranchIcon_ = new System.Windows.Forms.Label();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.txtVersion = new System.Windows.Forms.LinkLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtDomain = new System.Windows.Forms.Label();
            this._lblLinkServer = new System.Windows.Forms.Label();
            this._lbSocketStatus = new QTech.Component.ExLabel();
            this._lbSocket = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.mainPanel = new QTech.Component.GRAPanel();
            this.colorWithAlpha5 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha6 = new QTech.Component.ColorWithAlpha();
            this.graPanel2 = new QTech.Component.GRAPanel();
            this.colorWithAlpha13 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha14 = new QTech.Component.ColorWithAlpha();
            this.graPanel3 = new QTech.Component.GRAPanel();
            this.colorWithAlpha10 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha11 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha12 = new QTech.Component.ColorWithAlpha();
            this.pContainForm = new QTech.Component.GRAPanel();
            this.colorWithAlpha1 = new QTech.Component.ColorWithAlpha();
            this.colorWithAlpha2 = new QTech.Component.ColorWithAlpha();
            this.pMenuHeader = new QTech.Component.ExTabItem();
            this.pBoder = new QTech.Component.GRAPanel();
            this.colorWithAlpha3 = new QTech.Component.ColorWithAlpha();
            this.pContainBottom = new QTech.Component.GRAPanel();
            this.colorWithAlpha8 = new QTech.Component.ColorWithAlpha();
            this.menuSwitchLinkServer = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.tsmMenuUITeam = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmMenuTestTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.tmsMenuDevTeam = new System.Windows.Forms.ToolStripMenuItem();
            this.cnmStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.btnChangePassword = new System.Windows.Forms.ToolStripMenuItem();
            this.btnLogOut = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.container.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).BeginInit();
            this.pBottom.SuspendLayout();
            this.pBranch.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.mainPanel.SuspendLayout();
            this.graPanel2.SuspendLayout();
            this.graPanel3.SuspendLayout();
            this.pContainBottom.SuspendLayout();
            this.menuSwitchLinkServer.SuspendLayout();
            this.cnmStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // container
            // 
            this.container.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.container.Controls.Add(this.mainPanel);
            this.container.Controls.Add(this.pContainBottom);
            this.container.Controls.Add(this.topPanel);
            this.container.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.container.Size = new System.Drawing.Size(1280, 699);
            this.container.Text = "container";
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.ControlLight;
            this.panel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel8.Location = new System.Drawing.Point(0, 23);
            this.panel8.Margin = new System.Windows.Forms.Padding(0);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(816, 472);
            this.panel8.TabIndex = 1;
            // 
            // Body
            // 
            this.Body.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Body.Location = new System.Drawing.Point(0, 29);
            this.Body.Name = "Body";
            this.Body.Size = new System.Drawing.Size(194, 177);
            this.Body.TabIndex = 7;
            this.Body.Visible = false;
            // 
            // topPanel
            // 
            this.topPanel.BackColor = System.Drawing.Color.Transparent;
            this.topPanel.Border = true;
            this.topPanel.BorderColor = System.Drawing.Color.Gray;
            this.topPanel.Colors.Add(this.colorWithAlpha4);
            this.topPanel.ContentPadding = new System.Windows.Forms.Padding(0);
            this.topPanel.Controls.Add(this.label3);
            this.topPanel.Controls.Add(this.picLogo);
            this.topPanel.Controls.Add(this.pTopMenu);
            this.topPanel.CornerRadius = 1;
            this.topPanel.Corners = ((QTech.Component.Corners)((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight)));
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.topPanel.Gradient = false;
            this.topPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.topPanel.GradientOffset = 1F;
            this.topPanel.GradientSize = new System.Drawing.Size(0, 0);
            this.topPanel.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.topPanel.Grayscale = false;
            this.topPanel.Image = null;
            this.topPanel.ImageAlpha = 75;
            this.topPanel.ImagePadding = new System.Windows.Forms.Padding(5);
            this.topPanel.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.topPanel.ImageSize = new System.Drawing.Size(48, 48);
            this.topPanel.Location = new System.Drawing.Point(1, 0);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(1);
            this.topPanel.Rounded = true;
            this.topPanel.Size = new System.Drawing.Size(1278, 35);
            this.topPanel.TabIndex = 0;
            // 
            // colorWithAlpha4
            // 
            this.colorWithAlpha4.Alpha = 255;
            this.colorWithAlpha4.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.colorWithAlpha4.Parent = this.topPanel;
            // 
            // picLogo
            // 
            this.picLogo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.picLogo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picLogo.ErrorImage = global::QTech.Properties.Resources.QTech__2_;
            this.picLogo.Image = global::QTech.Properties.Resources.Pheng_Ry;
            this.picLogo.InitialImage = global::QTech.Properties.Resources.QTech__2_;
            this.picLogo.Location = new System.Drawing.Point(6, 1);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(75, 33);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picLogo.TabIndex = 0;
            this.picLogo.TabStop = false;
            this.picLogo.WaitOnLoad = true;
            // 
            // pTopMenu
            // 
            this.pTopMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.pTopMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.pTopMenu.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.pTopMenu.Location = new System.Drawing.Point(1, 1);
            this.pTopMenu.Name = "pTopMenu";
            this.pTopMenu.Padding = new System.Windows.Forms.Padding(0, 4, 0, 0);
            this.pTopMenu.Size = new System.Drawing.Size(1276, 39);
            this.pTopMenu.TabIndex = 16;
            // 
            // pBottom
            // 
            this.pBottom.BackColor = System.Drawing.Color.LightGray;
            this.pBottom.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pBottom.Border = true;
            this.pBottom.BorderColor = System.Drawing.Color.Gray;
            this.pBottom.Colors.Add(this.colorWithAlpha7);
            this.pBottom.Colors.Add(this.colorWithAlpha9);
            this.pBottom.ContentPadding = new System.Windows.Forms.Padding(-1, 0, -1, -1);
            this.pBottom.Controls.Add(this.pBranch);
            this.pBottom.Controls.Add(this.flowLayoutPanel2);
            this.pBottom.Controls.Add(this.label2);
            this.pBottom.Controls.Add(this.txtLogin);
            this.pBottom.Controls.Add(this.label1);
            this.pBottom.CornerRadius = 1;
            this.pBottom.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.pBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBottom.Gradient = false;
            this.pBottom.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pBottom.GradientOffset = 1F;
            this.pBottom.GradientSize = new System.Drawing.Size(0, 0);
            this.pBottom.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.pBottom.Grayscale = true;
            this.pBottom.Image = null;
            this.pBottom.ImageAlpha = 75;
            this.pBottom.ImagePadding = new System.Windows.Forms.Padding(5);
            this.pBottom.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.pBottom.ImageSize = new System.Drawing.Size(48, 48);
            this.pBottom.Location = new System.Drawing.Point(1, 0);
            this.pBottom.Name = "pBottom";
            this.pBottom.Padding = new System.Windows.Forms.Padding(2);
            this.pBottom.Rounded = true;
            this.pBottom.Size = new System.Drawing.Size(1276, 25);
            this.pBottom.TabIndex = 1;
            // 
            // colorWithAlpha7
            // 
            this.colorWithAlpha7.Alpha = 255;
            this.colorWithAlpha7.Color = System.Drawing.Color.LightGray;
            this.colorWithAlpha7.Parent = this.pBottom;
            // 
            // colorWithAlpha9
            // 
            this.colorWithAlpha9.Alpha = 255;
            this.colorWithAlpha9.Color = System.Drawing.Color.LightGray;
            this.colorWithAlpha9.Parent = this.pBottom;
            // 
            // pBranch
            // 
            this.pBranch.AutoSize = true;
            this.pBranch.Controls.Add(this.lblUserProfile_);
            this.pBranch.Controls.Add(this.txtUserName);
            this.pBranch.Controls.Add(this.lblUserDropDown_);
            this.pBranch.Controls.Add(this.lblBranchIcon_);
            this.pBranch.Location = new System.Drawing.Point(205, 2);
            this.pBranch.Name = "pBranch";
            this.pBranch.Size = new System.Drawing.Size(277, 23);
            this.pBranch.TabIndex = 11;
            this.pBranch.WrapContents = false;
            // 
            // lblUserProfile_
            // 
            this.lblUserProfile_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserProfile_.Image = global::QTech.Properties.Resources.picuser;
            this.lblUserProfile_.Location = new System.Drawing.Point(3, 0);
            this.lblUserProfile_.Name = "lblUserProfile_";
            this.lblUserProfile_.Size = new System.Drawing.Size(20, 20);
            this.lblUserProfile_.TabIndex = 2;
            // 
            // txtUserName
            // 
            this.txtUserName.AutoSize = true;
            this.txtUserName.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtUserName.ForeColor = System.Drawing.Color.Black;
            this.txtUserName.Location = new System.Drawing.Point(29, 0);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(69, 19);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.Text = "អ្នកប្រើប្រាស់";
            // 
            // lblUserDropDown_
            // 
            this.lblUserDropDown_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblUserDropDown_.ForeColor = System.Drawing.Color.Black;
            this.lblUserDropDown_.Image = global::QTech.Properties.Resources.down_arrow_12;
            this.lblUserDropDown_.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblUserDropDown_.Location = new System.Drawing.Point(101, 0);
            this.lblUserDropDown_.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.lblUserDropDown_.Name = "lblUserDropDown_";
            this.lblUserDropDown_.Size = new System.Drawing.Size(19, 19);
            this.lblUserDropDown_.TabIndex = 7;
            this.lblUserDropDown_.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblBranchIcon_
            // 
            this.lblBranchIcon_.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lblBranchIcon_.Location = new System.Drawing.Point(126, 0);
            this.lblBranchIcon_.Name = "lblBranchIcon_";
            this.lblBranchIcon_.Size = new System.Drawing.Size(20, 20);
            this.lblBranchIcon_.TabIndex = 4;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.txtVersion);
            this.flowLayoutPanel2.Controls.Add(this.label5);
            this.flowLayoutPanel2.Controls.Add(this.txtDomain);
            this.flowLayoutPanel2.Controls.Add(this._lblLinkServer);
            this.flowLayoutPanel2.Controls.Add(this._lbSocketStatus);
            this.flowLayoutPanel2.Controls.Add(this._lbSocket);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Right;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(740, 2);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(534, 21);
            this.flowLayoutPanel2.TabIndex = 13;
            // 
            // txtVersion
            // 
            this.txtVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtVersion.AutoSize = true;
            this.txtVersion.Font = new System.Drawing.Font("Arial Narrow", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtVersion.LinkBehavior = System.Windows.Forms.LinkBehavior.HoverUnderline;
            this.txtVersion.Location = new System.Drawing.Point(489, 0);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Padding = new System.Windows.Forms.Padding(0, 1, 0, 0);
            this.txtVersion.Size = new System.Drawing.Size(42, 16);
            this.txtVersion.TabIndex = 6;
            this.txtVersion.TabStop = true;
            this.txtVersion.Text = "V1.0.0.0";
            this.txtVersion.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(446, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(43, 19);
            this.label5.TabIndex = 8;
            this.label5.Text = "ជំនាន់៖";
            // 
            // txtDomain
            // 
            this.txtDomain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDomain.AutoSize = true;
            this.txtDomain.Cursor = System.Windows.Forms.Cursors.Hand;
            this.txtDomain.ForeColor = System.Drawing.Color.Black;
            this.txtDomain.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.txtDomain.Location = new System.Drawing.Point(357, 0);
            this.txtDomain.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.txtDomain.Name = "txtDomain";
            this.txtDomain.Size = new System.Drawing.Size(86, 19);
            this.txtDomain.TabIndex = 9;
            this.txtDomain.Text = "Domain: 0.3.334";
            this.txtDomain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.txtDomain.Visible = false;
            // 
            // _lblLinkServer
            // 
            this._lblLinkServer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lblLinkServer.AutoSize = true;
            this._lblLinkServer.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lblLinkServer.ForeColor = System.Drawing.Color.Black;
            this._lblLinkServer.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._lblLinkServer.Location = new System.Drawing.Point(289, 0);
            this._lblLinkServer.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._lblLinkServer.Name = "_lblLinkServer";
            this._lblLinkServer.Size = new System.Drawing.Size(65, 19);
            this._lblLinkServer.TabIndex = 10;
            this._lblLinkServer.Text = "Link Server";
            this._lblLinkServer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // _lbSocketStatus
            // 
            this._lbSocketStatus.AutoSize = true;
            this._lbSocketStatus.Location = new System.Drawing.Point(268, 0);
            this._lbSocketStatus.Name = "_lbSocketStatus";
            this._lbSocketStatus.Required = false;
            this._lbSocketStatus.Size = new System.Drawing.Size(15, 19);
            this._lbSocketStatus.TabIndex = 0;
            this._lbSocketStatus.Text = " ";
            this._lbSocketStatus.Visible = false;
            // 
            // _lbSocket
            // 
            this._lbSocket.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this._lbSocket.AutoSize = true;
            this._lbSocket.Cursor = System.Windows.Forms.Cursors.Hand;
            this._lbSocket.ForeColor = System.Drawing.Color.Black;
            this._lbSocket.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this._lbSocket.Location = new System.Drawing.Point(219, 0);
            this._lbSocket.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this._lbSocket.Name = "_lbSocket";
            this._lbSocket.Size = new System.Drawing.Size(46, 19);
            this._lbSocket.TabIndex = 12;
            this._lbSocket.Text = "Socket:";
            this._lbSocket.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this._lbSocket.Visible = false;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(1197, -700);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 19);
            this.label2.TabIndex = 7;
            this.label2.Text = "ជំនាន់";
            // 
            // txtLogin
            // 
            this.txtLogin.AutoSize = true;
            this.txtLogin.ForeColor = System.Drawing.Color.Black;
            this.txtLogin.Location = new System.Drawing.Point(27, 4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(110, 19);
            this.txtLogin.TabIndex = 1;
            this.txtLogin.Text = "01-01-2019 01:01:01";
            // 
            // label1
            // 
            this.label1.Image = global::QTech.Properties.Resources.calendar;
            this.label1.Location = new System.Drawing.Point(1, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(28, 19);
            this.label1.TabIndex = 0;
            // 
            // mainPanel
            // 
            this.mainPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.mainPanel.Border = true;
            this.mainPanel.BorderColor = System.Drawing.Color.Gray;
            this.mainPanel.Colors.Add(this.colorWithAlpha5);
            this.mainPanel.Colors.Add(this.colorWithAlpha6);
            this.mainPanel.ContentPadding = new System.Windows.Forms.Padding(0, -1, 0, -1);
            this.mainPanel.Controls.Add(this.graPanel2);
            this.mainPanel.CornerRadius = 1;
            this.mainPanel.Corners = QTech.Component.Corners.TopLeft;
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Gradient = false;
            this.mainPanel.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.mainPanel.GradientOffset = 1F;
            this.mainPanel.GradientSize = new System.Drawing.Size(0, 0);
            this.mainPanel.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.mainPanel.Grayscale = false;
            this.mainPanel.Image = null;
            this.mainPanel.ImageAlpha = 75;
            this.mainPanel.ImagePadding = new System.Windows.Forms.Padding(5);
            this.mainPanel.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.mainPanel.ImageSize = new System.Drawing.Size(48, 48);
            this.mainPanel.ImeMode = System.Windows.Forms.ImeMode.On;
            this.mainPanel.Location = new System.Drawing.Point(1, 35);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Padding = new System.Windows.Forms.Padding(3, 3, 4, 2);
            this.mainPanel.Rounded = false;
            this.mainPanel.Size = new System.Drawing.Size(1278, 637);
            this.mainPanel.TabIndex = 2;
            // 
            // colorWithAlpha5
            // 
            this.colorWithAlpha5.Alpha = 255;
            this.colorWithAlpha5.Color = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.colorWithAlpha5.Parent = this.mainPanel;
            // 
            // colorWithAlpha6
            // 
            this.colorWithAlpha6.Alpha = 255;
            this.colorWithAlpha6.Color = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.colorWithAlpha6.Parent = this.mainPanel;
            // 
            // graPanel2
            // 
            this.graPanel2.BackColor = System.Drawing.Color.Transparent;
            this.graPanel2.Border = true;
            this.graPanel2.BorderColor = System.Drawing.Color.Transparent;
            this.graPanel2.Colors.Add(this.colorWithAlpha13);
            this.graPanel2.Colors.Add(this.colorWithAlpha14);
            this.graPanel2.ContentPadding = new System.Windows.Forms.Padding(0);
            this.graPanel2.Controls.Add(this.graPanel3);
            this.graPanel2.CornerRadius = 5;
            this.graPanel2.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.graPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graPanel2.Gradient = true;
            this.graPanel2.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.graPanel2.GradientOffset = 1F;
            this.graPanel2.GradientSize = new System.Drawing.Size(0, 0);
            this.graPanel2.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.graPanel2.Grayscale = false;
            this.graPanel2.Image = null;
            this.graPanel2.ImageAlpha = 75;
            this.graPanel2.ImagePadding = new System.Windows.Forms.Padding(5);
            this.graPanel2.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.graPanel2.ImageSize = new System.Drawing.Size(48, 48);
            this.graPanel2.Location = new System.Drawing.Point(3, 3);
            this.graPanel2.Name = "graPanel2";
            this.graPanel2.Padding = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.graPanel2.Rounded = true;
            this.graPanel2.Size = new System.Drawing.Size(1271, 632);
            this.graPanel2.TabIndex = 1;
            // 
            // colorWithAlpha13
            // 
            this.colorWithAlpha13.Alpha = 255;
            this.colorWithAlpha13.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.colorWithAlpha13.Parent = this.graPanel2;
            // 
            // colorWithAlpha14
            // 
            this.colorWithAlpha14.Alpha = 255;
            this.colorWithAlpha14.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.colorWithAlpha14.Parent = this.graPanel2;
            // 
            // graPanel3
            // 
            this.graPanel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.graPanel3.Border = true;
            this.graPanel3.BorderColor = System.Drawing.Color.Gray;
            this.graPanel3.Colors.Add(this.colorWithAlpha10);
            this.graPanel3.Colors.Add(this.colorWithAlpha11);
            this.graPanel3.Colors.Add(this.colorWithAlpha12);
            this.graPanel3.ContentPadding = new System.Windows.Forms.Padding(0);
            this.graPanel3.Controls.Add(this.pContainForm);
            this.graPanel3.Controls.Add(this.pMenuHeader);
            this.graPanel3.Controls.Add(this.pBoder);
            this.graPanel3.CornerRadius = 5;
            this.graPanel3.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.graPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.graPanel3.Gradient = true;
            this.graPanel3.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.graPanel3.GradientOffset = 1F;
            this.graPanel3.GradientSize = new System.Drawing.Size(0, 0);
            this.graPanel3.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.graPanel3.Grayscale = false;
            this.graPanel3.Image = null;
            this.graPanel3.ImageAlpha = 75;
            this.graPanel3.ImagePadding = new System.Windows.Forms.Padding(5);
            this.graPanel3.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.graPanel3.ImageSize = new System.Drawing.Size(48, 48);
            this.graPanel3.Location = new System.Drawing.Point(3, 0);
            this.graPanel3.Name = "graPanel3";
            this.graPanel3.Rounded = true;
            this.graPanel3.Size = new System.Drawing.Size(1268, 632);
            this.graPanel3.TabIndex = 0;
            // 
            // colorWithAlpha10
            // 
            this.colorWithAlpha10.Alpha = 255;
            this.colorWithAlpha10.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.colorWithAlpha10.Parent = this.graPanel3;
            // 
            // colorWithAlpha11
            // 
            this.colorWithAlpha11.Alpha = 255;
            this.colorWithAlpha11.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.colorWithAlpha11.Parent = this.graPanel3;
            // 
            // colorWithAlpha12
            // 
            this.colorWithAlpha12.Alpha = 255;
            this.colorWithAlpha12.Color = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.colorWithAlpha12.Parent = this.graPanel3;
            // 
            // pContainForm
            // 
            this.pContainForm.BackColor = System.Drawing.Color.Yellow;
            this.pContainForm.Border = true;
            this.pContainForm.BorderColor = System.Drawing.Color.Gray;
            this.pContainForm.Colors.Add(this.colorWithAlpha1);
            this.pContainForm.Colors.Add(this.colorWithAlpha2);
            this.pContainForm.ContentPadding = new System.Windows.Forms.Padding(0);
            this.pContainForm.CornerRadius = 5;
            this.pContainForm.Corners = ((QTech.Component.Corners)((QTech.Component.Corners.BottomLeft | QTech.Component.Corners.BottomRight)));
            this.pContainForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pContainForm.Gradient = true;
            this.pContainForm.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pContainForm.GradientOffset = 0F;
            this.pContainForm.GradientSize = new System.Drawing.Size(0, 0);
            this.pContainForm.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.pContainForm.Grayscale = false;
            this.pContainForm.Image = null;
            this.pContainForm.ImageAlpha = 75;
            this.pContainForm.ImagePadding = new System.Windows.Forms.Padding(5);
            this.pContainForm.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.pContainForm.ImageSize = new System.Drawing.Size(48, 48);
            this.pContainForm.Location = new System.Drawing.Point(0, 22);
            this.pContainForm.Name = "pContainForm";
            this.pContainForm.Padding = new System.Windows.Forms.Padding(2);
            this.pContainForm.Rounded = true;
            this.pContainForm.Size = new System.Drawing.Size(1268, 610);
            this.pContainForm.TabIndex = 1;
            // 
            // colorWithAlpha1
            // 
            this.colorWithAlpha1.Alpha = 255;
            this.colorWithAlpha1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.colorWithAlpha1.Parent = this.pContainForm;
            // 
            // colorWithAlpha2
            // 
            this.colorWithAlpha2.Alpha = 255;
            this.colorWithAlpha2.Color = System.Drawing.SystemColors.Control;
            this.colorWithAlpha2.Parent = this.pContainForm;
            // 
            // pMenuHeader
            // 
            this.pMenuHeader.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.pMenuHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(127)))), ((int)(((byte)(0)))));
            this.pMenuHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pMenuHeader.Image = null;
            this.pMenuHeader.IsTitle = true;
            this.pMenuHeader.Location = new System.Drawing.Point(0, 0);
            this.pMenuHeader.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.pMenuHeader.Name = "pMenuHeader";
            this.pMenuHeader.Selected = false;
            this.pMenuHeader.Size = new System.Drawing.Size(1268, 22);
            this.pMenuHeader.TabIndex = 0;
            this.pMenuHeader.Text = "ម៊ឺនុយ";
            this.pMenuHeader.TextAlignment = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pBoder
            // 
            this.pBoder.BackColor = System.Drawing.Color.Transparent;
            this.pBoder.Border = true;
            this.pBoder.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.pBoder.ContentPadding = new System.Windows.Forms.Padding(0);
            this.pBoder.CornerRadius = 2;
            this.pBoder.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.pBoder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBoder.Gradient = true;
            this.pBoder.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pBoder.GradientOffset = 1F;
            this.pBoder.GradientSize = new System.Drawing.Size(0, 0);
            this.pBoder.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.pBoder.Grayscale = false;
            this.pBoder.Image = null;
            this.pBoder.ImageAlpha = 75;
            this.pBoder.ImagePadding = new System.Windows.Forms.Padding(5);
            this.pBoder.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.pBoder.ImageSize = new System.Drawing.Size(48, 48);
            this.pBoder.Location = new System.Drawing.Point(0, 0);
            this.pBoder.Name = "pBoder";
            this.pBoder.Rounded = true;
            this.pBoder.Size = new System.Drawing.Size(1268, 632);
            this.pBoder.TabIndex = 2;
            // 
            // colorWithAlpha3
            // 
            this.colorWithAlpha3.Alpha = 255;
            this.colorWithAlpha3.Color = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            // 
            // pContainBottom
            // 
            this.pContainBottom.BackColor = System.Drawing.Color.Transparent;
            this.pContainBottom.Border = true;
            this.pContainBottom.BorderColor = System.Drawing.Color.Gray;
            this.pContainBottom.Colors.Add(this.colorWithAlpha8);
            this.pContainBottom.ContentPadding = new System.Windows.Forms.Padding(0, -1, 0, 0);
            this.pContainBottom.Controls.Add(this.pBottom);
            this.pContainBottom.CornerRadius = 1;
            this.pContainBottom.Corners = ((QTech.Component.Corners)((((QTech.Component.Corners.TopLeft | QTech.Component.Corners.TopRight) 
            | QTech.Component.Corners.BottomLeft) 
            | QTech.Component.Corners.BottomRight)));
            this.pContainBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pContainBottom.Gradient = false;
            this.pContainBottom.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.pContainBottom.GradientOffset = 1F;
            this.pContainBottom.GradientSize = new System.Drawing.Size(0, 0);
            this.pContainBottom.GradientWrapMode = System.Drawing.Drawing2D.WrapMode.Tile;
            this.pContainBottom.Grayscale = false;
            this.pContainBottom.Image = null;
            this.pContainBottom.ImageAlpha = 75;
            this.pContainBottom.ImagePadding = new System.Windows.Forms.Padding(5);
            this.pContainBottom.ImagePosition = QTech.Component.ImagePositions.BottomRight;
            this.pContainBottom.ImageSize = new System.Drawing.Size(48, 48);
            this.pContainBottom.Location = new System.Drawing.Point(1, 672);
            this.pContainBottom.Name = "pContainBottom";
            this.pContainBottom.Padding = new System.Windows.Forms.Padding(1, 0, 1, 1);
            this.pContainBottom.Rounded = true;
            this.pContainBottom.Size = new System.Drawing.Size(1278, 26);
            this.pContainBottom.TabIndex = 2;
            // 
            // colorWithAlpha8
            // 
            this.colorWithAlpha8.Alpha = 255;
            this.colorWithAlpha8.Color = System.Drawing.Color.FromArgb(((int)(((byte)(245)))), ((int)(((byte)(245)))), ((int)(((byte)(237)))));
            this.colorWithAlpha8.Parent = this.pContainBottom;
            // 
            // menuSwitchLinkServer
            // 
            this.menuSwitchLinkServer.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuSwitchLinkServer.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmMenuUITeam,
            this.tsmMenuTestTeam,
            this.tmsMenuDevTeam});
            this.menuSwitchLinkServer.Name = "menuSwitchLinkServer";
            this.menuSwitchLinkServer.Size = new System.Drawing.Size(174, 70);
            // 
            // tsmMenuUITeam
            // 
            this.tsmMenuUITeam.Name = "tsmMenuUITeam";
            this.tsmMenuUITeam.Size = new System.Drawing.Size(173, 22);
            this.tsmMenuUITeam.Text = "UI Team";
            // 
            // tsmMenuTestTeam
            // 
            this.tsmMenuTestTeam.Name = "tsmMenuTestTeam";
            this.tsmMenuTestTeam.Size = new System.Drawing.Size(173, 22);
            this.tsmMenuTestTeam.Text = "Test Team";
            // 
            // tmsMenuDevTeam
            // 
            this.tmsMenuDevTeam.Name = "tmsMenuDevTeam";
            this.tmsMenuDevTeam.Size = new System.Drawing.Size(173, 22);
            this.tmsMenuDevTeam.Text = "tmsMenuDevTeam";
            // 
            // cnmStrip
            // 
            this.cnmStrip.Font = new System.Drawing.Font("Khmer OS System", 8.25F);
            this.cnmStrip.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cnmStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnChangePassword,
            this.btnLogOut});
            this.cnmStrip.Name = "cnmStrip";
            this.cnmStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.cnmStrip.Size = new System.Drawing.Size(147, 52);
            // 
            // btnChangePassword
            // 
            this.btnChangePassword.Name = "btnChangePassword";
            this.btnChangePassword.Size = new System.Drawing.Size(146, 24);
            this.btnChangePassword.Text = "ប្តូរលេខសំងាត់";
            // 
            // btnLogOut
            // 
            this.btnLogOut.Name = "btnLogOut";
            this.btnLogOut.Size = new System.Drawing.Size(146, 24);
            this.btnLogOut.Text = "ចាកចេញ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.Font = new System.Drawing.Font("Khmer Muol", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(87, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(170, 24);
            this.label3.TabIndex = 8;
            this.label3.Text = "សម្រាប់ប្រើបណ្ដោះអាសន្ន";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.Name = "MainForm";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Controls.SetChildIndex(this.container, 0);
            this.container.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picLogo)).EndInit();
            this.pBottom.ResumeLayout(false);
            this.pBottom.PerformLayout();
            this.pBranch.ResumeLayout(false);
            this.pBranch.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.mainPanel.ResumeLayout(false);
            this.graPanel2.ResumeLayout(false);
            this.graPanel3.ResumeLayout(false);
            this.pContainBottom.ResumeLayout(false);
            this.menuSwitchLinkServer.ResumeLayout(false);
            this.cnmStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        //private Dynamic.Component.RoundPanel roundPanel1;
        //private SoftTech.Component.ExTabItem exTabItem2;
        private System.Windows.Forms.Panel panel8;
        private QTech.Component.GRAPanel mainPanel;
        private QTech.Component.GRAPanel pBottom;
        private QTech.Component.GRAPanel topPanel;
        private QTech.Component.GRAPanel graPanel2;
        private QTech.Component.GRAPanel graPanel3;
        private QTech.Component.ExTabItem pMenuHeader;
        private QTech.Component.GRAPanel pContainForm;
        private System.Windows.Forms.Panel Body;
        private QTech.Component.GRAPanel pBoder;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txtLogin;
        private System.Windows.Forms.LinkLabel txtVersion;
        private System.Windows.Forms.Label label2;
        private QTech.Component.ColorWithAlpha colorWithAlpha1;
        private QTech.Component.ColorWithAlpha colorWithAlpha2;
        private QTech.Component.ColorWithAlpha colorWithAlpha3;
        private QTech.Component.ExTabBar pTopMenu;
        private QTech.Component.ColorWithAlpha colorWithAlpha4;
        private QTech.Component.ColorWithAlpha colorWithAlpha5;
        private QTech.Component.ColorWithAlpha colorWithAlpha6;
        private QTech.Component.ColorWithAlpha colorWithAlpha7;
        private QTech.Component.GRAPanel pContainBottom;
        private QTech.Component.ColorWithAlpha colorWithAlpha8;
        private QTech.Component.ColorWithAlpha colorWithAlpha9;
        private System.Windows.Forms.PictureBox picLogo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label txtDomain;
        private System.Windows.Forms.ContextMenuStrip menuSwitchLinkServer;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuUITeam;
        private System.Windows.Forms.ToolStripMenuItem tsmMenuTestTeam;
        private System.Windows.Forms.Label _lblLinkServer;
        private System.Windows.Forms.ContextMenuStrip cnmStrip;
        private System.Windows.Forms.ToolStripMenuItem btnChangePassword;
        private System.Windows.Forms.ToolStripMenuItem btnLogOut;
        private System.Windows.Forms.ToolStripMenuItem tmsMenuDevTeam;
        private System.Windows.Forms.Label _lbSocket;
        private QTech.Component.ExLabel _lbSocketStatus;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel pBranch;
        private System.Windows.Forms.Label lblUserProfile_;
        private System.Windows.Forms.Label txtUserName;
        private System.Windows.Forms.Label lblUserDropDown_;
        private System.Windows.Forms.Label lblBranchIcon_;
        private QTech.Component.ColorWithAlpha colorWithAlpha13;
        private QTech.Component.ColorWithAlpha colorWithAlpha14;
        private QTech.Component.ColorWithAlpha colorWithAlpha10;
        private QTech.Component.ColorWithAlpha colorWithAlpha11;
        private QTech.Component.ColorWithAlpha colorWithAlpha12;
        private System.Windows.Forms.Label label3;
    }
}