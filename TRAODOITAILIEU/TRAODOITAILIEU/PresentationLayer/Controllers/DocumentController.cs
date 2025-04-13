using Microsoft.AspNetCore.Mvc;
using TRAODOITAILIEU.BusinessLayer.DTOs;
using TRAODOITAILIEU.BusinessLayer.Interfaces;
using TRAODOITAILIEU.DataAccessLayer.ModelFromDB;

namespace TRAODOITAILIEU.PresentationLayer.Controllers
{
    [Route("/api/document")]
    [ApiController]
    public class DocumentController : Controller
    {
        private readonly IDocumentService docService;
        public DocumentController(IDocumentService _docService)
        {
            docService = _docService;
        }

        [HttpPost]
        [Route("upload")]
        public IActionResult Upload([FromBody]DocumentRequest request)
        {
            UpLoadDocumentRequest request1 = new UpLoadDocumentRequest
            {
                DocumentName = request.DocumentName,
                Category = request.Category,
                Author = request.Author,
                Price = request.Price
            };
            ContentRequest request2 = new ContentRequest
            {
                commentDate = request.commentDate,
                content = request.content
            };

            Document document = docService.UploadDocument(request1, request2);
            return Ok(document);
        }

        [HttpPost]
        [Route("updateDocument")]
        public IActionResult update(int documentId, [FromBody]DocumentRequest request) 
        {
            var x = docService.UpdateDocument(documentId, request);
            return Ok(x);
        }
    }
}
