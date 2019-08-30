using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Base.IBusinessService;
using Base.SDK.Request.DocRecord;
using Base.SDK.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;


namespace Base.Api.Controllers
{
    [Route("api/[controller]")]
    public class DocRecordController : ControllerBase
    {
        public IDocRecordBiz DocRecordBiz { get; set; }
        /// <summary>
        /// 文件导入(流)
        /// </summary>
        /// <param name="req"></param>
        /// <returns></returns>
        [HttpPost("UpLoadFile")]
        [AllowAnonymous]
        public async Task<SingleApiResponse> UpLoadFile()
        {
            var files = Request.Form.Files;
            StringValues docType;
            StringValues docSource;
            Request.Form.TryGetValue("DocType", out docType);
            Request.Form.TryGetValue("DocType", out docSource);
            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {

                    string fileExt = formFile.FileName.Split('.')[1]; //文件扩展名，不含“.”
                    var bytes = StreamToBytes(formFile.OpenReadStream());
                    var req = new DocRecordUpLoadFileRequest()
                    {
                        DocType = docType,
                        FileName = formFile.FileName,
                        FileSize = formFile.Length,
                        DocSource = docSource,
                        FileExtension = fileExt,
                        Bytes = bytes
                    };
                    return await DocRecordBiz.UpLoadFile(req);

                }
            }
            return new SingleApiResponse() ;
        }

        private byte[] StreamToBytes(Stream stream)
        {
            byte[] bytes = new byte[stream.Length];
            stream.Read(bytes, 0, bytes.Length);
            // 设置当前流的位置为流的开始 
            stream.Seek(0, SeekOrigin.Begin);
            return bytes;
        }
    }
}
