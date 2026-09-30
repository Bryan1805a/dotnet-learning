namespace BTC4;

using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

public partial class ExplorerForm : Form
{
    private string current_path = "";
    private string clipboard_path = "";
    private bool is_cut = false;

    public ExplorerForm()
    {
        InitializeComponent();
        load_drives();
    }

    private void explorer_form_load(object? sender, EventArgs e)
    {
        if (tr_directories.Nodes.Count == 0)
        {
            load_drives();
        }
    }

    private void load_drives()
    {
        tr_directories.Nodes.Clear();
        DriveInfo[] all_drives = DriveInfo.GetDrives();

        foreach (DriveInfo drive in all_drives)
        {
            try
            {
                TreeNode drive_node = new TreeNode(drive.Name);
                drive_node.Tag = drive.Name;
                tr_directories.Nodes.Add(drive_node);
            }
            catch
            {
            }
        }

        if (tr_directories.Nodes.Count > 0)
        {
            tr_directories.SelectedNode = tr_directories.Nodes[0];
        }
    }

    private void tr_directories_before_expand(object? sender, TreeViewCancelEventArgs e)
    {
        if (e.Node != null)
        {
            load_tree_subdirs(e.Node);
        }
    }

    private void tr_directories_after_select(object? sender, TreeViewEventArgs e)
    {
        if (e.Node == null)
        {
            return;
        }

        current_path = e.Node.Tag?.ToString() ?? e.Node.Text;
        txt_current_path.Text = current_path;

        load_tree_subdirs(e.Node);
        load_list_view(current_path);
    }

    private void load_tree_subdirs(TreeNode parent_node)
    {
        string folder_path = parent_node.Tag?.ToString() ?? parent_node.Text;
        if (string.IsNullOrEmpty(folder_path) || !Directory.Exists(folder_path))
        {
            return;
        }

        try
        {
            parent_node.Nodes.Clear();
            string[] sub_dirs = Directory.GetDirectories(folder_path);

            foreach (string sub_dir in sub_dirs)
            {
                try
                {
                    DirectoryInfo dir_info = new DirectoryInfo(sub_dir);
                    TreeNode sub_node = new TreeNode(dir_info.Name);
                    sub_node.Tag = sub_dir;
                    parent_node.Nodes.Add(sub_node);
                }
                catch
                {
                }
            }
        }
        catch
        {
        }
    }

    private void load_list_view(string folder_path)
    {
        lsv_files.Items.Clear();

        if (string.IsNullOrEmpty(folder_path) || !Directory.Exists(folder_path))
        {
            return;
        }

        try
        {
            string[] directories = Directory.GetDirectories(folder_path);
            foreach (string dir in directories)
            {
                try
                {
                    DirectoryInfo dir_info = new DirectoryInfo(dir);
                    ListViewItem item = new ListViewItem(dir_info.Name);
                    item.SubItems.Add("Folder");
                    item.SubItems.Add("");
                    item.SubItems.Add(dir_info.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                    item.Tag = dir;
                    lsv_files.Items.Add(item);
                }
                catch
                {
                }
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show("Khong the truy cap thu muc: " + ex.Message, "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        try
        {
            string[] files = Directory.GetFiles(folder_path);
            foreach (string file in files)
            {
                try
                {
                    FileInfo file_info = new FileInfo(file);
                    ListViewItem item = new ListViewItem(file_info.Name);
                    item.SubItems.Add(file_info.Extension.ToUpper() + " File");
                    item.SubItems.Add(format_file_size(file_info.Length));
                    item.SubItems.Add(file_info.LastWriteTime.ToString("yyyy-MM-dd HH:mm"));
                    item.Tag = file;
                    lsv_files.Items.Add(item);
                }
                catch
                {
                }
            }
        }
        catch
        {
        }
    }

    private string format_file_size(long byte_count)
    {
        if (byte_count >= 1048576)
        {
            return (byte_count / 1048576.0).ToString("0.##") + " MB";
        }
        if (byte_count >= 1024)
        {
            return (byte_count / 1024.0).ToString("0.##") + " KB";
        }
        return byte_count + " B";
    }

    private void lsv_files_double_click(object? sender, EventArgs e)
    {
        if (lsv_files.SelectedItems.Count == 0)
        {
            return;
        }

        string selected_item_path = lsv_files.SelectedItems[0].Tag?.ToString() ?? "";
        if (Directory.Exists(selected_item_path))
        {
            current_path = selected_item_path;
            txt_current_path.Text = current_path;

            TreeNode? current_node = tr_directories.SelectedNode;
            if (current_node != null)
            {
                foreach (TreeNode child in current_node.Nodes)
                {
                    if (child.Tag?.ToString() == selected_item_path)
                    {
                        tr_directories.SelectedNode = child;
                        return;
                    }
                }
            }

            load_list_view(current_path);
        }
        else if (File.Exists(selected_item_path))
        {
            try
            {
                Process.Start(new ProcessStartInfo(selected_item_path) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Khong the mo tap tin: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void action_new_folder_click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(current_path) || !Directory.Exists(current_path))
        {
            MessageBox.Show("Vui long chon mot thu muc hop le!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string folder_name = InputDialog.Show("Nhap ten thu muc moi:", "Tao thu muc", "New Folder");
        if (string.IsNullOrEmpty(folder_name))
        {
            return;
        }

        try
        {
            string new_folder_path = Path.Combine(current_path, folder_name);
            Directory.CreateDirectory(new_folder_path);
            load_list_view(current_path);
            refresh_selected_tree_node();
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi tao thu muc: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void action_new_file_click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(current_path) || !Directory.Exists(current_path))
        {
            MessageBox.Show("Vui long chon mot thu muc hop le!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string file_name = InputDialog.Show("Nhap ten tap tin moi:", "Tao tap tin", "NewFile.txt");
        if (string.IsNullOrEmpty(file_name))
        {
            return;
        }

        try
        {
            string new_file_path = Path.Combine(current_path, file_name);
            File.WriteAllText(new_file_path, "");
            load_list_view(current_path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi tao tap tin: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void action_rename_click(object? sender, EventArgs e)
    {
        if (lsv_files.SelectedItems.Count == 0)
        {
            MessageBox.Show("Vui long chon mot muc de doi ten!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string target_path = lsv_files.SelectedItems[0].Tag?.ToString() ?? "";
        string current_name = Path.GetFileName(target_path);
        string new_name = InputDialog.Show("Nhap ten moi:", "Doi ten", current_name);

        if (string.IsNullOrEmpty(new_name) || new_name == current_name)
        {
            return;
        }

        try
        {
            string parent_dir = Path.GetDirectoryName(target_path) ?? "";
            string destination_path = Path.Combine(parent_dir, new_name);

            if (File.Exists(target_path))
            {
                File.Move(target_path, destination_path);
            }
            else if (Directory.Exists(target_path))
            {
                Directory.Move(target_path, destination_path);
                refresh_selected_tree_node();
            }

            load_list_view(current_path);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi doi ten: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void action_copy_click(object? sender, EventArgs e)
    {
        if (lsv_files.SelectedItems.Count == 0)
        {
            MessageBox.Show("Vui long chon mot muc de sao chep!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        clipboard_path = lsv_files.SelectedItems[0].Tag?.ToString() ?? "";
        is_cut = false;
        MessageBox.Show("Da sao chep: " + Path.GetFileName(clipboard_path), "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void action_cut_click(object? sender, EventArgs e)
    {
        if (lsv_files.SelectedItems.Count == 0)
        {
            MessageBox.Show("Vui long chon mot muc de cat!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        clipboard_path = lsv_files.SelectedItems[0].Tag?.ToString() ?? "";
        is_cut = true;
        MessageBox.Show("Da cat: " + Path.GetFileName(clipboard_path), "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
    }

    private void action_paste_click(object? sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(clipboard_path))
        {
            MessageBox.Show("Khong co du lieu trong bo nho tam!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        if (string.IsNullOrEmpty(current_path) || !Directory.Exists(current_path))
        {
            MessageBox.Show("Thu muc dich khong ton tai!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string source_name = Path.GetFileName(clipboard_path);
        string destination_path = Path.Combine(current_path, source_name);

        try
        {
            if (File.Exists(clipboard_path))
            {
                if (is_cut)
                {
                    File.Move(clipboard_path, destination_path, true);
                    clipboard_path = "";
                }
                else
                {
                    File.Copy(clipboard_path, destination_path, true);
                }
            }
            else if (Directory.Exists(clipboard_path))
            {
                if (is_cut)
                {
                    Directory.Move(clipboard_path, destination_path);
                    clipboard_path = "";
                }
                else
                {
                    copy_directory_recursive(clipboard_path, destination_path);
                }
                refresh_selected_tree_node();
            }

            load_list_view(current_path);
            MessageBox.Show("Dan thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi khi dan: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void copy_directory_recursive(string source_dir, string target_dir)
    {
        Directory.CreateDirectory(target_dir);

        foreach (string file in Directory.GetFiles(source_dir))
        {
            string dest_file = Path.Combine(target_dir, Path.GetFileName(file));
            File.Copy(file, dest_file, true);
        }

        foreach (string sub_dir in Directory.GetDirectories(source_dir))
        {
            string dest_sub_dir = Path.Combine(target_dir, Path.GetFileName(sub_dir));
            copy_directory_recursive(sub_dir, dest_sub_dir);
        }
    }

    private void action_delete_click(object? sender, EventArgs e)
    {
        if (lsv_files.SelectedItems.Count == 0)
        {
            MessageBox.Show("Vui long chon mot muc de xoa!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        string target_path = lsv_files.SelectedItems[0].Tag?.ToString() ?? "";
        string item_name = Path.GetFileName(target_path);

        DialogResult confirm_result = MessageBox.Show(
            "Ban co chac chan muon xoa '" + item_name + "' khong?",
            "Xac nhan xoa",
            MessageBoxButtons.YesNo,
            MessageBoxIcon.Question
        );

        if (confirm_result != DialogResult.Yes)
        {
            return;
        }

        try
        {
            if (File.Exists(target_path))
            {
                File.Delete(target_path);
            }
            else if (Directory.Exists(target_path))
            {
                Directory.Delete(target_path, true);
                refresh_selected_tree_node();
            }

            load_list_view(current_path);
            MessageBox.Show("Xoa thanh cong!", "Thong bao", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        catch (Exception ex)
        {
            MessageBox.Show("Loi xoa: " + ex.Message, "Loi", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void action_refresh_click(object? sender, EventArgs e)
    {
        if (!string.IsNullOrEmpty(current_path))
        {
            load_list_view(current_path);
            refresh_selected_tree_node();
        }
    }

    private void refresh_selected_tree_node()
    {
        TreeNode? selected_node = tr_directories.SelectedNode;
        if (selected_node != null)
        {
            load_tree_subdirs(selected_node);
        }
    }
}
