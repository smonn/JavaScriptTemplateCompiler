using System;
using System.IO;
using System.Reflection;
using System.Text;
using JSTC.Config;
using JSTC.Extensions;

namespace JSTC.Compilation
{
    public sealed class Compiler
    {
        private readonly IJSTCConfiguration _config;

        public delegate void CompilerEventHandler(object sender, CompilerEventArgs e);
        public event CompilerEventHandler UpdatedFile;

        public Compiler(IJSTCConfiguration config)
        {
            _config = config;

            if (_config.Listen)
                EnableFileSystemWatcher();
        }

        private void EnableFileSystemWatcher()
        {
            var watcher = new FileSystemWatcher();

            watcher.Path = _config.Path;
            watcher.Filter = String.Format("*{0}", _config.Extension);
            watcher.NotifyFilter = NotifyFilters.Size | NotifyFilters.LastWrite | NotifyFilters.FileName;
            watcher.IncludeSubdirectories = true;

            watcher.Changed += Watcher_OnChange;
            watcher.Created += Watcher_OnChange;
            watcher.Deleted += Watcher_OnChange;
            watcher.Renamed += Watcher_OnChange;

            watcher.EnableRaisingEvents = true;
        }

        private void Watcher_OnChange(object sender, FileSystemEventArgs e)
        {
            Compile();
        }

        private void OnUpdatedFile(String target)
        {
            if (UpdatedFile != null)
            {
                var args = new CompilerEventArgs(target, (new FileInfo(target)).Length);
                UpdatedFile(this, args);
            }
        }

        public void Compile()
        {
            var assembly = Assembly.GetExecutingAssembly();
            var filePaths = Directory.EnumerateFiles(_config.Path, String.Format("*{0}", _config.Extension), SearchOption.AllDirectories);
            var sb = new StringBuilder();

            if (_config.InitializeJsObject)
                sb.AppendLine(String.Format("var {0} = {{}};", _config.JsObject));

            foreach (var path in filePaths)
                AppendTemplate(sb, path);

            var target = String.IsNullOrWhiteSpace(_config.Output) ? String.Format("{0}\\{1}.js", _config.Path, _config.JsObject) : _config.Output;
            var directory = Path.GetDirectoryName(target);

            if (!Directory.Exists(directory))
                Directory.CreateDirectory(directory);

            File.WriteAllText(target, sb.ToString());

            OnUpdatedFile(target);
        }

        private void AppendTemplate(StringBuilder sb, String path)
        {
            var fileName = Path.GetFileName(path).Replace(_config.Extension, String.Empty);
            var content = new StringBuilder(File.ReadAllText(path));

            content.CompactWhiteSpaces();
            content.Replace("\"", "\\\"");

            var template = String.Format("{0}[\"{1}\"] = \"{2}\";", _config.JsObject, fileName, content.ToString());

            sb.AppendLine(template);
        }
    }
}
