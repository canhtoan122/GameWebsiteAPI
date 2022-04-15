using GameWebsiteAPI.Data;
using GameWebsiteAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace GameWebsiteAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly string AppDirectory = Path.Combine(Directory.GetCurrentDirectory(), "File");
        private static List<FileRecord> fileDB = new List<FileRecord>();
        private readonly DataContext _context;

        public UserProfileController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserProfile>>> Get()
        {
            return Ok(await _context.UserProfile.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<UserProfile>>> Add(UserProfile user)
        {
            _context.UserProfile.Add(user);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserProfile.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<List<UserProfile>>> Update(UserProfile request)
        {
            var result = await _context.UserProfile.FindAsync(request.User_ID);
            if (result == null)
                return BadRequest("User not found.");

            result.FullName = request.FullName;
            result.DateOfBirth = request.DateOfBirth;
            result.Sex = request.Sex;
            result.Ethnic = request.Ethnic;
            result.Nationality = request.Nationality;
            result.Religion = request.Religion;
            result.Address = request.Address;
            result.Email = request.Email;
            result.PhoneNumber = request.PhoneNumber;

            await _context.SaveChangesAsync();

            return Ok(await _context.UserProfile.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<UserProfile>>> Delete(int id)
        {
            var result = await _context.UserProfile.FindAsync(id);
            if (result == null)
                return BadRequest("User not found.");

            _context.UserProfile.Remove(result);
            await _context.SaveChangesAsync();

            return Ok(await _context.UserProfile.ToListAsync());
        }

        [HttpPost("Post File")]
        [Consumes("multipart/form-data")]
        public async Task<HttpResponseMessage> PostAsync([FromForm] FileManagement model)
        {
            try
            {
                FileRecord file = await SaveFileAsync(model.MyFile);

                if (!string.IsNullOrEmpty(file.FilePath))
                {
                    file.AltText = model.AltText;
                    file.Description = model.Description;
                    //Save to Inmemory object
                    //fileDB.Add(file);
                    //Save to SQL Server DB
                    SaveToDB(file);
                    return new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                    return new HttpResponseMessage(HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return new HttpResponseMessage(HttpStatusCode.InternalServerError)
                {
                    Content = new StringContent(ex.Message),
                };
            }
        }

        private async Task<FileRecord> SaveFileAsync(IFormFile myFile)
        {
            FileRecord file = new FileRecord();
            if (myFile != null)
            {
                if (!Directory.Exists(AppDirectory))
                    Directory.CreateDirectory(AppDirectory);

                var fileName = DateTime.Now.Ticks.ToString() + Path.GetExtension(myFile.FileName);
                var path = Path.Combine(AppDirectory, fileName);

                file.Id = fileDB.Count() + 1;
                file.FilePath = path;
                file.FileName = fileName;
                file.FileFormat = Path.GetExtension(myFile.FileName);
                file.ContentType = myFile.ContentType;

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    await myFile.CopyToAsync(stream);
                }

                return file;
            }
            return file;
        }

        private void SaveToDB(FileRecord record)
        {
            if (record == null)
                throw new ArgumentNullException($"{nameof(record)}");

            FileData fileData = new FileData();
            fileData.FilePath = record.FilePath;
            fileData.FileName = record.FileName;
            fileData.FileExtension = record.FileFormat;
            fileData.MimeType = record.ContentType;

            _context.FileData.Add(fileData);
            _context.SaveChanges();
        }

        [HttpGet("Get All file")]
        public List<FileRecord> GetAllFiles()
        {
            //getting data from inmemory obj
            //return fileDB;
            //getting data from SQL DB
            return _context.FileData.Select(n => new FileRecord
            {
                Id = n.Id,
                ContentType = n.MimeType,
                FileFormat = n.FileExtension,
                FileName = n.FileName,
                FilePath = n.FilePath
            }).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> DownloadFile(int id)
        {
            if (!Directory.Exists(AppDirectory))
                Directory.CreateDirectory(AppDirectory);

            //getting file from inmemory obj
            //var file = fileDB?.Where(n => n.Id == id).FirstOrDefault();
            //getting file from DB
            var file = _context.FileData.Where(n => n.Id == id).FirstOrDefault();

            var path = Path.Combine(AppDirectory, file?.FilePath);

            var memory = new MemoryStream();
            using (var stream = new FileStream(path, FileMode.Open))
            {
                await stream.CopyToAsync(memory);
            }
            memory.Position = 0;
            var contentType = "APPLICATION/octet-stream";
            var fileName = Path.GetFileName(path);

            return File(memory, contentType, fileName);
        }
        [HttpDelete("Delete file")]
        public async Task<ActionResult> DeleteFile(int id)
        {
            var file = _context.FileData.Where(n => n.Id == id).FirstOrDefault();

            var path = Path.Combine(AppDirectory, file?.FilePath);


            if (path != null)
            {
                System.IO.File.Delete(path);
                _context.SaveChanges();
            }
            return Ok(await _context.FileData.ToListAsync());
        }
    }
}
