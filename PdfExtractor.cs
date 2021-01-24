using System;
using System.Collections;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;


using Windows.Data.Pdf;
using Windows.Foundation;
using Windows.Storage.Streams;

// Add References (set local copy = False)
// C:\Program Files (x86)\Windows Kits\10\UnionMetadata\10.0.18362.0\Windows.winmd
// C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETCore\v4.5\System.Runtime.WindowsRuntime.dll
// https://blogs.windows.com/windowsdeveloper/2017/01/25/calling-windows-10-apis-desktop-application/#IRYBeuheFjlvW4Qx.97





namespace Pdf2Jpg
{

    /// <summary>Component to extract pictures from a pdf document</summary>
    public class PdfExtractor
    {

        public string       PdfFileName;
        public string       ExtractPath;
        public bool         DoExtract;

        public ArrayList    Bitmaps;

        protected Thread    _thread;


        /// <summary>Creates a new extractor with standard settings</summary>
        public PdfExtractor ()
        {
            Bitmaps     = new ArrayList();

            PdfFileName = null;
            DoExtract   = true;
            ExtractPath = String.Format( @"{0}\Pdf2Jpg\", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures) );
        }


        /// <summary>Starts the extracting asynchrone in an own thread</summary>
        public void Start   ()
        {
            Stop();

            if ( _thread == null )
            {
                ThreadPool.QueueUserWorkItem( new WaitCallback( Thread_Event ) );   // --> Thread_Event

                // wait until it is started
                while(_thread == null)
                {
                    Thread.Sleep(5);
                }
            }


        }

        /// <summary>Stops the running extracting</summary>
        public void Stop    ()
        {
            if ( _thread != null )
            {
                if ( _thread.IsAlive == true )
                {
                    _thread.Abort();
                }


                // wait for ending
                while( _thread != null )
                {
                    Thread.Sleep(5);
                }
            }

        }

        /// <summary>Runs the extracting</summary>
        public bool IsRunning()
        {
            return ( _thread != null );
        }


        /// <summary>The thread calls this</summary>
        protected void Thread_Event(object o)
        {
            _thread = Thread.CurrentThread;

            if ( DoExtract == true )
            {
                SetNewExtractingPath();
            }


            FileStream                      fs          = null;
            RandomAccessStream              inputStream = null;
            IAsyncOperation<PdfDocument>    opLoad      = null;

            try
            {
                Bitmaps.Clear();

                fs          = new FileStream         (PdfFileName, FileMode.Open, FileAccess.Read);
                inputStream = new RandomAccessStream (fs);



                // await
                opLoad = PdfDocument.LoadFromStreamAsync( inputStream );

                while (opLoad.Status != AsyncStatus.Completed)
                {
                    Thread.Sleep(10);
                }

                PdfDocument doc = opLoad.GetResults();
                opLoad.Close();
                opLoad = null;


                // Seiten durchsuchen
                for(uint i = 0; i < doc.PageCount; i++)
                {
                    PdfPage page = doc.GetPage(i);

                    InMemoryRandomAccessStream  stream1 = new InMemoryRandomAccessStream();
                    IAsyncAction                action  = page.RenderToStreamAsync(stream1);

                    while (action.Status != AsyncStatus.Completed)
                    {
                        System.Threading.Thread.Sleep(2);
                    }

                    Stream stream2  = stream1.AsStreamForRead();
                    Bitmap bmp      = new Bitmap(stream2);

                    if ( DoExtract == true )
                    {
                        string filename = String.Format( "{0}{1:0000}.jpg", ExtractPath, i);
                        bmp.Save(filename, System.Drawing.Imaging.ImageFormat.Jpeg);
                    }

                    Bitmaps.Add(bmp);

                    stream2.Dispose();
                    stream1.Dispose();
                }

                fs.Close();
                fs = null;
            }

            catch(Exception)
            {
                // Thread abort
                // Debug.Print(ex.Message);
                Bitmaps.Clear();
            }

            finally
            {
                // Use finally, else Thread.Abort don't calls it
                if (opLoad != null)
                {
                    opLoad.Cancel();
                    opLoad.Close();
                    opLoad = null;
                }


                if ( inputStream != null )
                {
                    inputStream = null;
                }



                if (fs != null)
                {
                    fs.Close();
                    fs = null;
                }


                _thread = null;
            }


        }

        /// <summary>Returns null or the full path for extracting (inclusive pdf name)</summary>
        protected string SetNewExtractingPath()
        {
            string name  = GetNameFromPdf(PdfFileName);
            ExtractPath = String.Format( @"{0}\Pdf2Jpg\{1}\", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), name );

            if ( Directory.Exists(ExtractPath) == true )
            {
                try
                {
                    Directory.Delete(ExtractPath, true);
                }
                catch(Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }


            if ( Directory.Exists(ExtractPath) == false )
            {
                try
                {
                    Directory.CreateDirectory(ExtractPath);
                }
                catch(Exception ex)
                {
                    Debug.Print(ex.Message);
                }
            }


            if ( Directory.Exists(ExtractPath) == true )
            {
                return ExtractPath;
            }

            return null;
        }







        /// <summary>Returns only the name without extension</summary>
        private string GetNameFromPdf(string pdf)
        {
            int startIndex  = pdf.LastIndexOf( @"\" ) + 1;
            int length      = pdf.Length - 4 - startIndex;

            string name = pdf.Substring(startIndex, length);

            return name;
        }


        /// <summary>Wrapper for UWP IRandomAccessStream</summary>
        protected class RandomAccessStream : IRandomAccessStream
        {
            protected Stream    _stream;


            /// <summary>Create a new Stream with a FileStraem or a Memorystream</summary>
            public RandomAccessStream(Stream stream)
            {
                _stream = stream;
            }



            public IInputStream             GetInputStreamAt  (ulong position)
            {
                _stream.Position = (long)position;
                return _stream.AsInputStream();
            }


            public IOutputStream            GetOutputStreamAt (ulong position)
            {
                _stream.Position = (long)position;
                return _stream.AsOutputStream();
            }


            public void                     Seek              (ulong position)
            {
                _stream.Seek( (long)position, SeekOrigin.Begin );
            }


            /// <summary>Not supported</summary>
            public IRandomAccessStream      CloneStream       ()
            {
                throw new NotSupportedException();
            }




            public bool                     CanRead
            {
                get 
                { 
                    return _stream.CanRead;
                }
            }

            public bool                     CanWrite
            {
                get 
                {
                    return _stream.CanWrite;
                }
            }



            public ulong                    Position
            {
                get 
                {
                    return (ulong)this._stream.Position; 
                }
            }

            public ulong                    Size
            {
                get
                {
                    return (ulong)_stream.Length;
                }
                set
                {
                    _stream.SetLength ( (long)value );
                }
            }



            public void Dispose()
            {
                _stream.Dispose();
            }



            public IAsyncOperationWithProgress<Windows.Storage.Streams.IBuffer, uint>    ReadAsync(IBuffer buffer, uint count, InputStreamOptions options)
            {
                return GetInputStreamAt(Position).ReadAsync (buffer, count, options);
            }



            public IAsyncOperationWithProgress<uint, uint>                               WriteAsync(IBuffer buffer)
            {
                return GetOutputStreamAt(Position).WriteAsync (buffer);
            }

            public IAsyncOperation<bool>                                                 FlushAsync()
            {
                return GetOutputStreamAt(Position).FlushAsync ();
            }




        }


    }
}