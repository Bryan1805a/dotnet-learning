namespace BTC4;

using System.Drawing;
using System.Windows.Forms;

partial class ExplorerForm
{
    private System.ComponentModel.IContainer components = null;

    private MenuStrip menu_strip;
    private ToolStripMenuItem menu_action;
    private ToolStripMenuItem menu_new_folder;
    private ToolStripMenuItem menu_new_file;
    private ToolStripSeparator menu_sep_1;
    private ToolStripMenuItem menu_rename;
    private ToolStripMenuItem menu_copy;
    private ToolStripMenuItem menu_cut;
    private ToolStripMenuItem menu_paste;
    private ToolStripSeparator menu_sep_2;
    private ToolStripMenuItem menu_delete;
    private ToolStripMenuItem menu_refresh;

    private Panel pnl_top;
    private Label lbl_path;
    private TextBox txt_current_path;

    private SplitContainer split_container;
    private TreeView tr_directories;
    private ListView lsv_files;
    private ColumnHeader col_name;
    private ColumnHeader col_type;
    private ColumnHeader col_size;
    private ColumnHeader col_date;

    private ContextMenuStrip context_menu;
    private ToolStripMenuItem ctx_open;
    private ToolStripSeparator ctx_sep_1;
    private ToolStripMenuItem ctx_new_folder;
    private ToolStripMenuItem ctx_new_file;
    private ToolStripSeparator ctx_sep_2;
    private ToolStripMenuItem ctx_rename;
    private ToolStripMenuItem ctx_copy;
    private ToolStripMenuItem ctx_cut;
    private ToolStripMenuItem ctx_paste;
    private ToolStripSeparator ctx_sep_3;
    private ToolStripMenuItem ctx_delete;
    private ToolStripMenuItem ctx_refresh;

    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    private void InitializeComponent()
    {
        this.components = new System.ComponentModel.Container();

        this.menu_strip = new MenuStrip();
        this.menu_action = new ToolStripMenuItem();
        this.menu_new_folder = new ToolStripMenuItem();
        this.menu_new_file = new ToolStripMenuItem();
        this.menu_sep_1 = new ToolStripSeparator();
        this.menu_rename = new ToolStripMenuItem();
        this.menu_copy = new ToolStripMenuItem();
        this.menu_cut = new ToolStripMenuItem();
        this.menu_paste = new ToolStripMenuItem();
        this.menu_sep_2 = new ToolStripSeparator();
        this.menu_delete = new ToolStripMenuItem();
        this.menu_refresh = new ToolStripMenuItem();

        this.pnl_top = new Panel();
        this.lbl_path = new Label();
        this.txt_current_path = new TextBox();

        this.split_container = new SplitContainer();
        this.tr_directories = new TreeView();
        this.lsv_files = new ListView();
        this.col_name = new ColumnHeader();
        this.col_type = new ColumnHeader();
        this.col_size = new ColumnHeader();
        this.col_date = new ColumnHeader();

        this.context_menu = new ContextMenuStrip(this.components);
        this.ctx_open = new ToolStripMenuItem();
        this.ctx_sep_1 = new ToolStripSeparator();
        this.ctx_new_folder = new ToolStripMenuItem();
        this.ctx_new_file = new ToolStripMenuItem();
        this.ctx_sep_2 = new ToolStripSeparator();
        this.ctx_rename = new ToolStripMenuItem();
        this.ctx_copy = new ToolStripMenuItem();
        this.ctx_cut = new ToolStripMenuItem();
        this.ctx_paste = new ToolStripMenuItem();
        this.ctx_sep_3 = new ToolStripSeparator();
        this.ctx_delete = new ToolStripMenuItem();
        this.ctx_refresh = new ToolStripMenuItem();

        this.menu_strip.SuspendLayout();
        this.pnl_top.SuspendLayout();
        ((System.ComponentModel.ISupportInitialize)(this.split_container)).BeginInit();
        this.split_container.Panel1.SuspendLayout();
        this.split_container.Panel2.SuspendLayout();
        this.split_container.SuspendLayout();
        this.context_menu.SuspendLayout();
        this.SuspendLayout();

        this.menu_strip.Items.AddRange(new ToolStripItem[] {
            this.menu_action
        });
        this.menu_strip.Location = new Point(0, 0);
        this.menu_strip.Name = "menu_strip";
        this.menu_strip.Size = new Size(880, 24);
        this.menu_strip.TabIndex = 0;
        this.menu_strip.Text = "menu_strip";

        this.menu_action.DropDownItems.AddRange(new ToolStripItem[] {
            this.menu_new_folder,
            this.menu_new_file,
            this.menu_sep_1,
            this.menu_rename,
            this.menu_copy,
            this.menu_cut,
            this.menu_paste,
            this.menu_sep_2,
            this.menu_delete,
            this.menu_refresh
        });
        this.menu_action.Name = "menu_action";
        this.menu_action.Text = "&Thao tác";

        this.menu_new_folder.Name = "menu_new_folder";
        this.menu_new_folder.ShortcutKeys = Keys.Control | Keys.Shift | Keys.N;
        this.menu_new_folder.Text = "Tạo thư mục";
        this.menu_new_folder.Click += new System.EventHandler(this.action_new_folder_click);

        this.menu_new_file.Name = "menu_new_file";
        this.menu_new_file.ShortcutKeys = Keys.Control | Keys.N;
        this.menu_new_file.Text = "Tạo tập tin";
        this.menu_new_file.Click += new System.EventHandler(this.action_new_file_click);

        this.menu_sep_1.Name = "menu_sep_1";
        this.menu_sep_1.Size = new Size(207, 6);

        this.menu_rename.Name = "menu_rename";
        this.menu_rename.ShortcutKeys = Keys.F2;
        this.menu_rename.Text = "Đổi tên";
        this.menu_rename.Click += new System.EventHandler(this.action_rename_click);

        this.menu_copy.Name = "menu_copy";
        this.menu_copy.ShortcutKeys = Keys.Control | Keys.C;
        this.menu_copy.Text = "Sao chép";
        this.menu_copy.Click += new System.EventHandler(this.action_copy_click);

        this.menu_cut.Name = "menu_cut";
        this.menu_cut.ShortcutKeys = Keys.Control | Keys.X;
        this.menu_cut.Text = "Cắt / Di chuyển";
        this.menu_cut.Click += new System.EventHandler(this.action_cut_click);

        this.menu_paste.Name = "menu_paste";
        this.menu_paste.ShortcutKeys = Keys.Control | Keys.V;
        this.menu_paste.Text = "Dán";
        this.menu_paste.Click += new System.EventHandler(this.action_paste_click);

        this.menu_sep_2.Name = "menu_sep_2";
        this.menu_sep_2.Size = new Size(207, 6);

        this.menu_delete.Name = "menu_delete";
        this.menu_delete.ShortcutKeys = Keys.Delete;
        this.menu_delete.Text = "Xóa";
        this.menu_delete.Click += new System.EventHandler(this.action_delete_click);

        this.menu_refresh.Name = "menu_refresh";
        this.menu_refresh.ShortcutKeys = Keys.F5;
        this.menu_refresh.Text = "Làm mới";
        this.menu_refresh.Click += new System.EventHandler(this.action_refresh_click);

        this.pnl_top.Controls.Add(this.lbl_path);
        this.pnl_top.Controls.Add(this.txt_current_path);
        this.pnl_top.Dock = DockStyle.Top;
        this.pnl_top.Height = 35;
        this.pnl_top.Padding = new Padding(5);

        this.lbl_path.AutoSize = true;
        this.lbl_path.Location = new Point(8, 8);
        this.lbl_path.Name = "lbl_path";
        this.lbl_path.Size = new Size(68, 15);
        this.lbl_path.Text = "Đường dẫn:";

        this.txt_current_path.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
        this.txt_current_path.Location = new Point(80, 5);
        this.txt_current_path.Name = "txt_current_path";
        this.txt_current_path.ReadOnly = true;
        this.txt_current_path.Size = new Size(790, 23);

        this.split_container.Dock = DockStyle.Fill;
        this.split_container.Location = new Point(0, 59);
        this.split_container.Name = "split_container";
        this.split_container.SplitterDistance = 260;
        this.split_container.Size = new Size(880, 480);
        this.split_container.TabIndex = 1;

        this.tr_directories.Dock = DockStyle.Fill;
        this.tr_directories.Location = new Point(0, 0);
        this.tr_directories.Name = "tr_directories";
        this.tr_directories.Size = new Size(260, 480);
        this.tr_directories.TabIndex = 0;
        this.tr_directories.BeforeExpand += new TreeViewCancelEventHandler(this.tr_directories_before_expand);
        this.tr_directories.AfterSelect += new TreeViewEventHandler(this.tr_directories_after_select);

        this.lsv_files.Columns.AddRange(new ColumnHeader[] {
            this.col_name,
            this.col_type,
            this.col_size,
            this.col_date
        });
        this.lsv_files.ContextMenuStrip = this.context_menu;
        this.lsv_files.Dock = DockStyle.Fill;
        this.lsv_files.FullRowSelect = true;
        this.lsv_files.Location = new Point(0, 0);
        this.lsv_files.MultiSelect = false;
        this.lsv_files.Name = "lsv_files";
        this.lsv_files.Size = new Size(616, 480);
        this.lsv_files.TabIndex = 0;
        this.lsv_files.UseCompatibleStateImageBehavior = false;
        this.lsv_files.View = View.Details;
        this.lsv_files.DoubleClick += new System.EventHandler(this.lsv_files_double_click);

        this.col_name.Text = "Tên";
        this.col_name.Width = 230;

        this.col_type.Text = "Loại";
        this.col_type.Width = 100;

        this.col_size.Text = "Kích thước";
        this.col_size.Width = 100;

        this.col_date.Text = "Ngày sửa đổi";
        this.col_date.Width = 150;

        this.context_menu.Items.AddRange(new ToolStripItem[] {
            this.ctx_open,
            this.ctx_sep_1,
            this.ctx_new_folder,
            this.ctx_new_file,
            this.ctx_sep_2,
            this.ctx_rename,
            this.ctx_copy,
            this.ctx_cut,
            this.ctx_paste,
            this.ctx_sep_3,
            this.ctx_delete,
            this.ctx_refresh
        });
        this.context_menu.Name = "context_menu";
        this.context_menu.Size = new Size(181, 242);

        this.ctx_open.Name = "ctx_open";
        this.ctx_open.Text = "Mở";
        this.ctx_open.Click += new System.EventHandler(this.lsv_files_double_click);

        this.ctx_sep_1.Name = "ctx_sep_1";
        this.ctx_sep_1.Size = new Size(177, 6);

        this.ctx_new_folder.Name = "ctx_new_folder";
        this.ctx_new_folder.Text = "Tạo thư mục";
        this.ctx_new_folder.Click += new System.EventHandler(this.action_new_folder_click);

        this.ctx_new_file.Name = "ctx_new_file";
        this.ctx_new_file.Text = "Tạo tập tin";
        this.ctx_new_file.Click += new System.EventHandler(this.action_new_file_click);

        this.ctx_sep_2.Name = "ctx_sep_2";
        this.ctx_sep_2.Size = new Size(177, 6);

        this.ctx_rename.Name = "ctx_rename";
        this.ctx_rename.Text = "Đổi tên";
        this.ctx_rename.Click += new System.EventHandler(this.action_rename_click);

        this.ctx_copy.Name = "ctx_copy";
        this.ctx_copy.Text = "Sao chép";
        this.ctx_copy.Click += new System.EventHandler(this.action_copy_click);

        this.ctx_cut.Name = "ctx_cut";
        this.ctx_cut.Text = "Cắt / Di chuyển";
        this.ctx_cut.Click += new System.EventHandler(this.action_cut_click);

        this.ctx_paste.Name = "ctx_paste";
        this.ctx_paste.Text = "Dán";
        this.ctx_paste.Click += new System.EventHandler(this.action_paste_click);

        this.ctx_sep_3.Name = "ctx_sep_3";
        this.ctx_sep_3.Size = new Size(177, 6);

        this.ctx_delete.Name = "ctx_delete";
        this.ctx_delete.Text = "Xóa";
        this.ctx_delete.Click += new System.EventHandler(this.action_delete_click);

        this.ctx_refresh.Name = "ctx_refresh";
        this.ctx_refresh.Text = "Làm mới";
        this.ctx_refresh.Click += new System.EventHandler(this.action_refresh_click);

        this.split_container.Panel1.ResumeLayout(false);
        this.split_container.Panel2.ResumeLayout(false);
        ((System.ComponentModel.ISupportInitialize)(this.split_container)).EndInit();
        this.split_container.ResumeLayout(false);

        this.AutoScaleDimensions = new SizeF(7F, 15F);
        this.AutoScaleMode = AutoScaleMode.Font;
        this.ClientSize = new Size(880, 540);
        this.Controls.Add(this.split_container);
        this.Controls.Add(this.pnl_top);
        this.Controls.Add(this.menu_strip);
        this.MainMenuStrip = this.menu_strip;
        this.Name = "ExplorerForm";
        this.StartPosition = FormStartPosition.CenterScreen;
        this.Text = "Windows Explorer Demo";
        this.Load += new System.EventHandler(this.explorer_form_load);

        this.menu_strip.ResumeLayout(false);
        this.menu_strip.PerformLayout();
        this.pnl_top.ResumeLayout(false);
        this.pnl_top.PerformLayout();
        this.context_menu.ResumeLayout(false);
        this.ResumeLayout(false);
        this.PerformLayout();
    }

    #endregion
}
