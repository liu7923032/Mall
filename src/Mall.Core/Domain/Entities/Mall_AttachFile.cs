using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Domain.Entities.Auditing;

namespace Mall.Domain.Entities
{
    /// <summary>
    /// 放置附档的位置
    /// </summary>
    public class Mall_AttachFile: CreationAuditedEntity
    {
        /// <summary>
        /// 隶属
        /// </summary>
        public string ParentId { get; set; }

        [Required]
        public string FileName { get; set; }

        [Required]
        public string FilePath { get; set; }

        [Required]
        public string FileType { get; set; }

        [Required]
        public string ContentType { get; set; }


        public string FileSize { get; set; }

        public string Describe { get; set; }
    }
}
