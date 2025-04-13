using TRAODOITAILIEU.DataAccessLayer.Data;
using TRAODOITAILIEU.DataAccessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.DataAccessLayer.Repositories
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly TDTLContext db;
        public DocumentRepository(TDTLContext _db)
        {
            db = _db;
        }
        public void AddDocument(Document document)
        {
            db.Documents.Add(document);
        }

        public List<Document> GetDocument(string txt)
        {
            List<Document> li = db.Documents.Where(a => a.DocumentName.Contains(txt)).Select(a => a).ToList();
            return li;
        }

        public Document GetDocumentById(int id)
        {
            var doc = db.Documents.FirstOrDefault(a => a.DocumentId == id);
            return doc;
        }

        public void AddContent(Content c)
        {
            db.Contents.Add(c);
        }

        public void SaveChanges()
        {
            db.SaveChanges();
        }

        public Content GetContent(int documentId)
        {
            Content content = db.Contents.FirstOrDefault(a => a.DocumentId == documentId);
            return content;
        }
    }
}
