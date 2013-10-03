using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prj666vc.Models
{
    public class Note
    {
        public int Id { get; set; }

        //[Required]
        public string Name { get; set; }

        //[Required]
        public string CourseCode { get; set; }

        //[Required]
        public string PostOwner { get; set; }
        
        public DateTime CreatedDate { get; set; }

        public string FileName { get; set; }

        public string ContentType { get; set; }       

        public byte[] Content { get; set; }

        public string Description { get; set; }

        public Boolean Status { get; set; }

    }
}