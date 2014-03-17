using System;

namespace JSTC.Compilation
{
    public sealed class CompilerEventArgs : EventArgs
    {
        public String FileName { get; private set; }
        public Int64 FileSize { get; private set; }

        public CompilerEventArgs(String fileName, Int64 fileSize)
        {
            FileName = fileName;
            FileSize = fileSize;
        }
    }
}
