using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace MyPractice.Code
{
    class ProcessDocument
    {
        private DocumentManager documentManager;

        protected ProcessDocument(DocumentManager dm)
        {
            this.documentManager = dm;
        }

        public static void Start(DocumentManager dm)
        {
            Task.Factory.StartNew(new ProcessDocument(dm).run);
        }

        protected void run()
        {
            while (true)
            {
                if (documentManager.IsDocumentAvailable )
                {
                    Document doc = documentManager.GetDocument();
                    Console.WriteLine("Processing Document  {0}",doc.Title);
                    
                }
                Thread.Sleep( new Random( ).Next() * 20);
            }
        }
    }
}
