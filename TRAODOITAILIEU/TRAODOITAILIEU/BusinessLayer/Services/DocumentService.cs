using System.Security.Claims;
using TRAODOITAILIEU.BusinessLayer.DTOs;
using TRAODOITAILIEU.BusinessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.BusinessLayer.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IDocumentRepository docRepo;

        public DocumentService(IDocumentRepository _docRepo)
        {
            docRepo = _docRepo;
        }
        public Document UploadDocument(UpLoadDocumentRequest request, ContentRequest rq)
        {
            Document doc = new Document
            {
                DocumentName = request.DocumentName,
                Category = request.Category,
                Price = request.Price,
                Author = request.Author,
                AccountId = AccountService.account_id
            };

            docRepo.AddDocument(doc);   
            docRepo.SaveChanges();


            Content content = new Content
            {
                CommentDate = rq.commentDate,
                Content1 = rq.content,
                DocumentId = doc.DocumentId
            };
            docRepo.AddContent(content);
            docRepo.SaveChanges();
            return doc;
        }
        public Document UpdateDocument(int documentId, DocumentRequest request)
        {
            var doc = docRepo.GetDocumentById(documentId);
            if (doc == null)
            {
                throw new Exception("Document not found");
            }

            doc.DocumentName = request.DocumentName;
            doc.Category = request.Category;
            doc.Price = request.Price;
            doc.Author = request.Author;


            var content = docRepo.GetContent(documentId);
            content.CommentDate = request.commentDate;
            content.Content1 = request.content;
            docRepo.SaveChanges();
            return doc;
        }


    }
}
