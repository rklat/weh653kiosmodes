using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Reflection;

namespace OEMTitleBarHandler
{
    class EmbeddedResources
    {
        Assembly _assembly;
        Stream _binaryStream;
        const string fileRemnet = "\\Windows\\Remnet.exe";
        
        public EmbeddedResources()
        {
            try
            {
                _assembly = Assembly.GetExecutingAssembly();
                _binaryStream = _assembly.GetManifestResourceStream("OEMTitleBarHandler.Remnet.exe");
            }
            catch (Exception)
            {

            }
        }
        public bool replaceRemnet()
        {
            bool bRet = false;
            try
            {
                byte[] _bytes = new byte[_binaryStream.Length];
                //ReadWholeArray(_binaryStream, _bytes);


                // Create the file.
                using (FileStream fs = File.Create(fileRemnet, 1024))
                {
                    CopyStream(_binaryStream, fs);
                }
                bRet = true;
            }
            catch (Exception)
            {
                bRet = false;
            }
            return bRet;
        }
        public bool restoreRemnet()
        {
            bool bRet = false;
            try
            {
                System.IO.File.Delete(fileRemnet);
                bRet = true;
            }
            catch (Exception)
            {
                bRet = false;
            }
            return bRet;
        }
        /// <summary>
        /// Copies the contents of input to output. Doesn't close either stream.
        /// </summary>
        private static void CopyStream(Stream input, Stream output)
        {
            byte[] buffer = new byte[8 * 1024];
            int len;
            while ((len = input.Read(buffer, 0, buffer.Length)) > 0)
            {
                output.Write(buffer, 0, len);
            }
        }

    }
}
