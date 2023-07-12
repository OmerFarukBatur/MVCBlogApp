namespace MVCBlogApp.Application.ViewModels
{
    public class VM_LocalUploadFile
    {
        public int uploaded { get; set; }
        public string fileName { get; set; }
        public string url => folderName + fileName;
        public string ErrorMessage { get; set; }

        private const string folderName = "~/Upload/";
    }
}
