using prj666vc.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace prj666vc.Controllers
{
    public class NotesSharingController : Controller
    {
        Repo_Note ns = new Repo_Note();

        // GET: /NotesSharing/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult NoteShareStatus(int id)
        {
            

            var nb = ns.GetById(id);
            nb.Status = !nb.Status;
            ns.UpdateExisting(nb);

            var nc = ns.GetAll();

            if (nb == null)
            {
                return View();
            }
            else
            {
                return View("ViewMyNotes",nc);
            }
            
        }

        public ActionResult ShareNote()
        {            
            return View();
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult ShareNote(NotePublic createdNote)
        {
            
            /*if (SharedNotes != null && SharedNotes.ContentLength > 0)
            {
                var fileName = Path.GetFileName(SharedNotes.FileName);
                var path = Path.Combine(Server.MapPath("../../Uploads"), fileName);
                SharedNotes.SaveAs(path);
            }*/
            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                /*byte[] sharedNotes = new byte[ns.File.InputStream.Length];
                ns.File.InputStream.Read(sharedNotes, 0, sharedNotes.Length);*/

                var v = ns.AddNew(createdNote);
                if (v != null)
                {
                    if (createdNote.File != null && createdNote.File.ContentLength > 0)
                    {
                        string mimeType = createdNote.File.ContentType;
                        Stream fileStream = createdNote.File.InputStream;
                        string fileName = createdNote.File.FileName;
                        int fileLength = createdNote.File.ContentLength;
                        byte[] fileData = new byte[fileLength];
                        fileStream.Read(fileData, 0, fileLength);
                        var nf = ns.UpdateExistingFile(v.Id, fileName, mimeType, fileData);
                    }
                }

                ViewBag.Message = "File has been uploaded successfully";
                return RedirectToAction("ViewMyNotes");
            }


           /* if (ModelState.IsValid)
            {
                var postBlog = _repository.Blogs.Single(b => b.BlogId == post.BlogId);
                post.Created = DateTime.Now;
                postBlog.Posts.Add(post);



                PostImage newImage = new PostImage()
                                         {
                                             MimeType = image.ContentType,
                                             ImageData = new byte[image.ContentLength],
                                             PostId = post.PostId
                                         };
                _repository.AddImage(newImage);



                _repository.Save();
                return RedirectToAction("Index");
            }*/
            
        }

        
        public ActionResult ViewMyNotes()
        {
            var nb = ns.GetAll();

            
            if (nb == null)
            {
                return View();
            }
            else
            {                
                return View(nb);
            }
        }

        //
        // GET: /NotesSharing/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /NotesSharing/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /NotesSharing/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /NotesSharing/Edit/5

        public ActionResult NoteEdit(int id)
        {
            var nb = ns.GetById(id);


            if (nb == null)
            {
                return View();
            }
            else
            {
                return View("NoteEdit",nb);
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult NoteEdit(int id, NoteBase updatedNote)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                var v = ns.UpdateExisting(updatedNote);
              //  foreach (string upload in Request.Files)
  
                if (updatedNote.File != null && updatedNote.File.ContentLength > 0) 
                {
                    string mimeType = updatedNote.File.ContentType;
                    Stream fileStream = updatedNote.File.InputStream;
                    string fileName = updatedNote.File.FileName;
                    int fileLength = updatedNote.File.ContentLength;
                    byte[] fileData = new byte[fileLength];
                    fileStream.Read(fileData, 0, fileLength);
                    var nf = ns.UpdateExistingFile(id, fileName, mimeType, fileData);
                    
                }
                ViewBag.Message = "File has been uploaded successfully";
                return RedirectToAction("ViewMyNotes",v);
            }
        }

        public ActionResult NoteDownload(int id)
            {
                var document = ns.GetById(id);
                var cd = new System.Net.Mime.ContentDisposition
                {
                    // for example foo.bak
                    FileName = document.FileName, 

                    // always prompt the user for downloading, set to true if you want 
                    // the browser to try to show the file inline
                    Inline = false, 
                };
                Response.AppendHeader("Content-Disposition", cd.ToString());
                return File(document.Content, document.ContentType);
            }

        public ActionResult RemoveNoteFile(int id)
        {
            var rnf = ns.GetById(id);

            return View(rnf);
            
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult RemoveNoteFile(int id, NoteBase nb)
        {
            if (ns.GetById(id) != null)
            {
                string mimeType = null;
                string fileName = null;
                byte[] fileData = null;
                var nf = ns.UpdateExistingFile(id, fileName, mimeType, fileData);
                if (nf != null)
                {
                    ViewBag.Message = "File has been uploaded successfully";
                }


            }
            return RedirectToAction("ViewMyNotes");

        }

 /*       
        public ActionResult RemoveNoteFileConfirmed(int id)
        {
            if (ns.GetById(id) != null)
            {
                string mimeType = null;
                string fileName = null;
                byte[] fileData = null;
                var nf = ns.UpdateExistingFile(id, fileName, mimeType, fileData);
                if (nf != null)
                {
                    ViewBag.Message = "File has been deleted successfully";
                }
                
                
            }
            return RedirectToAction("ViewMyNotes");
        }

*/
        //
        // POST: /NotesSharing/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /NotesSharing/Delete/5

        public ActionResult NoteDelete(int id)
        {            
            var nd = ns.GetById(id);

            return View(nd);
        }

        [HttpPost]
        public ActionResult NoteDelete(int id, NoteBase nb)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }
            else
            {
                try
                {
                    ns.DeleteNote(id);
                }
                catch (Exception) { }

                return RedirectToAction("ViewMyNotes");
            }
        }

        //
        // POST: /NotesSharing/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
