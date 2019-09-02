﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Base.Common.Cos;

namespace Base.Domain.Entitys
{
    [Serializable]
    public class DocRecord : EntityBase
    {
        [Key]
        public Guid DocId { get; set; }
        public string DocType { get; set; }
        public string FileName { get; set; }
        public long FileSize { get; set; }
        public string DocSource { get; set; }
        public string FileExtension { get; set; }
        public string Memo { get; set; }
        public string CosBuketName { get; set; }
        public string CosKey { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
