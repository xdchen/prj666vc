using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;

namespace prj666vc.ViewModels
{
    public class NoteList
    {
        public string Name { get; set; }

        public string CourseCode { get; set; }
    }

    public class NotePublic
    {
        public NotePublic()
        {
            this.CreatedDate = DateTime.Now;
            this.Status = false;
        }
    
        public string Name { get; set; }

        public string CourseCode { get; set; }

        public DateTime CreatedDate { get; set; }
        
        public string ContentType { get; set; }

        public string PostOwner { get; set; }

        public string FileName { get; set; }

        //[Required]
        public HttpPostedFileBase File { get; set; }

        public Boolean Status { get; set; }
        
    }

    public class NoteBase : NotePublic
    {
        public int Id { get; set; }

    }

    public class NoteFull : NoteBase
    {
        // These are image-related properties
        // For this code example, we do NOT expose them
        // during a normal JSON or XML serialization
        //[JsonIgnore, IgnoreDataMember]
        public byte[] Content { get; set; }
       // [JsonIgnore, IgnoreDataMember]
        
    }
}