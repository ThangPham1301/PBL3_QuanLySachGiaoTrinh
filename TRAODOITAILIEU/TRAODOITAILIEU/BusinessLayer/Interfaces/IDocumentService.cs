using TRAODOITAILIEU.BusinessLayer.DTOs;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.BusinessLayer.Interfaces
{
    public interface IDocumentService
    {
        public Document UploadDocument(UpLoadDocumentRequest request, ContentRequest rq);
        public Document UpdateDocument(int documentId, DocumentRequest request);
    }
}
