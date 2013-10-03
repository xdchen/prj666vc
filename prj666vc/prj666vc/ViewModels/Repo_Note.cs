using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace prj666vc.ViewModels
{
    public class Repo_Note : Repo_Base
    {
        // Get all
        
        public IEnumerable<NoteBase> GetAll()
        {
            var all = ds.Notes.OrderBy(o => o.CourseCode);
            return Mapper.Map<IEnumerable<NoteBase>>(all);
        }

        // Get one
        public NoteFull GetById(int id)
        {
            var one = ds.Notes.Find(id);

            return (one == null) ? null : Mapper.Map<NoteFull>(one);
        }

        // Add new
        public NoteFull AddNew(NotePublic note)
        {
            var n = ds.Notes.Add(Mapper.Map<Models.Note>(note));
            ds.SaveChanges();

            return Mapper.Map<ViewModels.NoteFull>(n);
        }

        // Update existing
        // Provide your own implementation
        public NoteFull UpdateExisting(NoteBase updatedNote)
        {
            // Fetch the existing Program object
            var n = ds.Notes.Find(updatedNote.Id);

            if (n == null)
            {
                return null;
            }
            else
            {
                // Fetch the object from the data store - ds.Entry(p)
                // Get its current values collection - .CurrentValues
                // Set those to the values provided - .SetValues(updatedProgram)
                ds.Entry(n).CurrentValues.SetValues(updatedNote);
                // The SetValues method ignores missing properties, and navigation properties
                ds.SaveChanges();
                return Mapper.Map<ViewModels.NoteFull>(n);
            }
        }

        // Update existing, file only
        public NoteFull UpdateExistingFile(int id, string filename, string contentType, byte[] updatedContent)
        {

            var n = ds.Notes.Find(id);

            if (n == null)
            {
                return null;
            }
            else
            {
                n.FileName = filename;
                n.Content = updatedContent;
                n.ContentType = contentType;
                ds.SaveChanges();
                return Mapper.Map<NoteFull>(n);
            }
        }

        // Delete existing
        // Provide your own implementation
        public void DeleteNote(int id)
        {
            var n = ds.Notes.Find(id);

            if (n == null)
            {
                
            }
            else
            {
                try
                {
                    // If this fails, throw an exception, in 'version 2'...
                    // It may fail because of the presence of associated objects
                    // This implementation prevents the exception from bubbling up
                    ds.Notes.Remove(n);
                    ds.SaveChanges();
                }
                catch (Exception) { }
            }
        }
    }
}