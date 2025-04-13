using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.DataAccessLayer.Interfaces
{
    public interface IDocumentRepository
    {
        public void SaveChanges();
        public void AddDocument(Document document);
        
        public List<Document> GetDocument(string txt);
        public Document GetDocumentById(int id);
        public void AddContent(Content c);
        public Content GetContent(int documentId);
    }
}
