using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
     
using Lucene;
using Lucene.Net.Search;
using System.Xml;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Index;
using Lucene.Net.Documents;
using Lucene.Net.QueryParsers;
using System.IO;



class luceneAdapter
{
    // http://www.aspcode.net/C-and-Lucene-to-index-and-search.aspx


    //uso de la libreria...
    //     // we create and index for searching if not exists
    //        luceneAdapter luc = new luceneAdapter();

    //        luc.searchInFiles(txtBus.Text);

    public luceneAdapter()
    {
        string sIndexLocation = IndexLocation();
        //1. Check to see we do have an index 
        bool created;
        EnsureIndexExists(out created, sIndexLocation);
        //2. If not then create the index - and fill with some fake data 
        if (created)
        {
            InsertIndexData(sIndexLocation);
        }
    }


    private string IndexLocation()
    {
        return System.IO.Path.Combine(Environment.CurrentDirectory, "testindex");
    }

    private void EnsureIndexExists(out bool created, string sIndexPath)
    {
        created = false;
        if (!IndexReader.IndexExists(sIndexPath))
        {
            IndexWriter writer = new IndexWriter(sIndexPath, new StandardAnalyzer(), true);
            created = true;
            writer.Close();
        }

    }
    
    public void InsertIndexData(string sIndexPath)
    {
        IndexWriter writer = new IndexWriter(sIndexPath, new StandardAnalyzer(), false);

        //Lets insert all data - for this example I'm using  
        //some fake stuff, but you could of course easily index anything - say data from  
        //a database, generated from files/web spidering etc 

        DirectoryInfo docDir = new DirectoryInfo(util.templates_dir);
        FileInfo[] files = docDir.GetFiles();

        foreach (FileInfo f in files)
        {
            Document doc = new Document();
            doc.Add(new Field("path", f.FullName,Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("modified",DateTools.TimeToString(f.LastWriteTime.Ticks, DateTools.Resolution.MINUTE),Field.Store.YES, Field.Index.UN_TOKENIZED));
            doc.Add(new Field("content", new StreamReader(f.FullName, System.Text.Encoding.Default)));
            writer.AddDocument(doc);
            Console.Out.WriteLine("adding " + f.ToString());
        }
        writer.Optimize();
        writer.Close();

    }

    public  void searchInFiles(string  query )
    {
        IndexReader reader = IndexReader.Open(IndexLocation());
        IndexSearcher searcher = new IndexSearcher(reader);
        QueryParser oParser = new QueryParser("path", new StandardAnalyzer());      
        

        string sSearchQuery = "(" + query + ")";

  
        Hits oHitColl = searcher.Search(oParser.Parse(sSearchQuery));
        for (int i = 0; i < oHitColl.Length(); i++)
        {
            Document oDoc = oHitColl.Doc(i);
           // oItem.SubItems.Add(oDoc.Get("type"));
        }

        searcher.Close(); 

      
    }

    
  ////string[] querys = { "dominos pizza" };
        //string[] fields = { "title" };
        //Lucene.Net.Search.BooleanClause.Occur[] clauses = { Lucene.Net.Search.BooleanClause.Occur.MUST };
        //string[] sortby = { "id" };

        //XmlDocument xDoc = GetSearchResult(@"C:\luceneindexpath\", querys, fields, clauses, sortby);
        //return xDoc;

    public static XmlDocument GetSearchResult(string Indexpath, string[] querys, string[] fields, BooleanClause.Occur[] clauses, string[] sortingfields)
    {
        //XMLDocument is created to return output records  
        XmlDocument xResDoc = new XmlDocument();
        xResDoc.LoadXml("<SEARCHRESULTS></SEARCHRESULTS>");
        try
        {
            // This block will parse the given queries   
            // (i.e) would remove characters other than a-z and 0-9  
            for (int i = 0; i < querys.Length; i++)
            {
                querys[i] = querys[i].ToLower();
                querys[i] = System.Text.RegularExpressions.Regex.Replace(querys[i], "[^a-z0-9]", " ");
                while (querys[i].Contains("  "))
                    querys[i] = querys[i].Replace("  ", " ");
            }
            //  

            if (System.IO.Directory.Exists(Indexpath))
            {
                // Open's Already created Lucene Index for searching  
                Lucene.Net.Index.IndexReader idxReader = Lucene.Net.Index.IndexReader.Open(Indexpath);
                Searcher searcher = new IndexSearcher(idxReader);

                //Creates a Lucene Query with given search inputs  
                Query qry = MultiFieldQueryParser.Parse(querys, fields, clauses, new StandardAnalyzer());
                ScoreDoc[] hits;

                //Assigns No. of Records to be fetched   
                //here idxReader max records is used   
                //can be changed to get specific top records  
                int top = idxReader.MaxDoc();

                //To get output with specific sort  
                if (sortingfields.Length > 0)
                {
                    TopFieldDocCollector collector = new TopFieldDocCollector(idxReader, new Sort(sortingfields), top);
                    searcher.Search(qry, collector);
                    hits = collector.TopDocs().scoreDocs;
                }
                else //To get output without specific sort  
                {
                    TopDocCollector collector = new TopDocCollector(top);
                    searcher.Search(qry, collector);
                    hits = collector.TopDocs().scoreDocs;
                }

                //Loops through the output records and creates an XMLElement for XML Output  
                for (int i = 0; i < hits.Length; i++)
                {
                    int docId = hits[i].doc;
                    Document doc = searcher.Doc(docId);
                    XmlElement xEle = xResDoc.CreateElement("SEARCHRESULT");
                    foreach (Field fl in doc.Fields())
                    {
                        xEle.SetAttribute(fl.Name(), doc.Get(fl.Name()));
                    }
                    xResDoc.DocumentElement.AppendChild(xEle);
                }
                searcher.Close();
                idxReader.Close();
            }
        }
        catch (Exception ex)
        {
            //Print Error Message  
        }
        return xResDoc;
    }

}
 
