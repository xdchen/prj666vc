using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace prj666vc.ViewModels
{
    public class VM_NotesSharing
    {
        [Required]
        public HttpPostedFileBase File { get; set; }
    }
}